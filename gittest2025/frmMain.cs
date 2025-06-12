using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // �ǉ�
using gittest2025.Models;

namespace gittest2025
{
    public partial class frmMain : Form
    {
        private readonly TemperatureDataManager temperatureDataManager = new TemperatureDataManager();
        private int? selectedIndex = null;
        private readonly ToolTip graphToolTip = new ToolTip();

        // �f�[�^�_�̃q�b�g���苗���i�s�N�Z���j
        private const int DataPointHitRadius = 10;

        // ���x�͈͂̒萔
        private const double MinTempScale = 30.0;  // Y���̍ŏ��l
        private const double MaxTempScale = 50.0;  // Y���̍ő�l
        private const double WarningTempHigh = 37.0;  // �x�����C���i���j
        private const double WarningTempLow = 35.0;   // �x�����C���i��j

        public frmMain()
        {
            InitializeComponent();
            InitializeTemperatureGraph();
        }

        /// <summary>
        /// �O���t�̏����ݒ�
        /// </summary>
        private void InitializeTemperatureGraph()
        {
            // �f�U�C�i�Œǉ�����pictureBoxGraph�𗘗p
            pictureBoxGraph.Paint += PictureBoxGraph_Paint;
            pictureBoxGraph.MouseDown += PictureBoxGraph_MouseDown;
            pictureBoxGraph.MouseMove += PictureBoxGraph_MouseMove;
            UpdateTemperatureGraph();
        }

        /// <summary>
        /// �̉����̓_�C�A���O��\�����A�f�[�^��ǉ�
        /// </summary>
        private void btnAddTemperature_Click(object sender, EventArgs e)
        {
            using var inputForm = new TemperatureInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                var record = new TemperatureRecord(inputForm.RecordTime, inputForm.Temperature);
                temperatureDataManager.AddRecord(record);
                UpdateTemperatureGraph();
            }
        }

        /// <summary>
        /// �O���t���ŐV�̑̉��f�[�^�ōĕ`��
        /// </summary>
        private void UpdateTemperatureGraph()
        {
            pictureBoxGraph.Invalidate();
        }

        /// <summary>
        /// PictureBox��Paint�C�x���g�ŃO���t��`��
        /// </summary>
        private void PictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            int width = pictureBoxGraph.Width;
            int height = pictureBoxGraph.Height;

            graphics.Clear(Color.White);

            // ���̕`��
            using (var axisPen = new Pen(Color.Black, 2))
            {
                graphics.DrawLine(axisPen, 50, height - 40, width - 20, height - 40); // X��
                graphics.DrawLine(axisPen, 50, 20, 50, height - 40); // Y��
            }

            // �^�C�g���ƃ��x���̕`��
            graphics.DrawString("�̉�����", new Font("Meiryo", 14), Brushes.Black, width / 2 - 40, 5);
            graphics.DrawString("�̉�(��)", new Font("Meiryo", 10), Brushes.Black, 5, 20);
            graphics.DrawString("���͎���", new Font("Meiryo", 10), Brushes.Black, width / 2 - 30, height - 25);

            // �x�����C���̕`��i�O���t�̈���j
            int graphTop = 20;
            int graphBottom = height - 40;
            int graphHeight = graphBottom - graphTop;

            // 37�x�̃��C���i�ԁj
            float y37 = (float)(graphBottom - ((WarningTempHigh - MinTempScale) / (MaxTempScale - MinTempScale) * graphHeight));
            using (var warningPenHigh = new Pen(Color.Red, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                graphics.DrawLine(warningPenHigh, 50, y37, width - 20, y37);
                graphics.DrawString("37.0��", new Font("Meiryo", 8), Brushes.Red, 15, y37 - 7);
            }

            // 35�x�̃��C���i�j
            float y35 = (float)(graphBottom - ((WarningTempLow - MinTempScale) / (MaxTempScale - MinTempScale) * graphHeight));
            using (var warningPenLow = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                graphics.DrawLine(warningPenLow, 50, y35, width - 20, y35);
                graphics.DrawString("35.0��", new Font("Meiryo", 8), Brushes.Blue, 15, y35 - 7);
            }

            if (temperatureDataManager.Records.Count > 0)
            {
                var records = temperatureDataManager.Records.OrderBy(r => r.RecordTime).ToList();
                DateTime minTime = records.First().RecordTime;
                DateTime maxTime = records.Last().RecordTime;
                double timeSpan = (maxTime - minTime).TotalMinutes;
                if (timeSpan == 0) timeSpan = 1; // 1�_�݂̂̏ꍇ

                PointF[] dataPoints = records.Select(r =>
                {
                    float x = 50 + (float)((r.RecordTime - minTime).TotalMinutes / timeSpan * (width - 80));
                    float y = (float)(height - 40 - ((double)r.Temperature - MinTempScale) / (MaxTempScale - MinTempScale) * (height - 60));
                    return new PointF(x, y);
                }).ToArray();

                // �܂��
                if (dataPoints.Length > 1)
                    graphics.DrawLines(Pens.Blue, dataPoints);

                // �_
                foreach (var pt in dataPoints)
                    graphics.FillEllipse(Brushes.Red, pt.X - 4, pt.Y - 4, 8, 8);
            }
        }

        /// <summary>
        /// �O���t��ŃN���b�N���ꂽ�_��I�����A����\���܂��͍폜���j���[��\��
        /// </summary>
        private void PictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (temperatureDataManager.Records.Count > 0)
            {
                var records = temperatureDataManager.Records.OrderBy(r => r.RecordTime).ToList();
                DateTime minTime = records.First().RecordTime;
                DateTime maxTime = records.Last().RecordTime;
                double timeSpan = (maxTime - minTime).TotalMinutes;
                if (timeSpan == 0) timeSpan = 1;

                PointF[] dataPoints = records.Select(r =>
                {
                    float x = 50 + (float)((r.RecordTime - minTime).TotalMinutes / timeSpan * (pictureBoxGraph.Width - 80));
                    float y = (float)(pictureBoxGraph.Height - 40 - ((double)r.Temperature - MinTempScale) / (MaxTempScale - MinTempScale) * (pictureBoxGraph.Height - 60));
                    return new PointF(x, y);
                }).ToArray();

                int nearest = -1;
                double minDist = double.MaxValue;
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    double dx = dataPoints[i].X - e.X;
                    double dy = dataPoints[i].Y - e.Y;
                    double dist = dx * dx + dy * dy;
                    if (dist < minDist)
                    {
                        minDist = dist;
                        nearest = i;
                    }
                }

                if (nearest >= 0 && minDist < DataPointHitRadius * DataPointHitRadius)
                {
                    selectedIndex = nearest;
                    var record = records[nearest];
                    
                    // �I�����ꂽ�f�[�^�̕\�����X�V
                    lblSelectedDateTime.Text = $"����: {record.RecordTime:yyyy/MM/dd HH:mm}";

                    // �̉��l�ɂ���ĕ����F��ύX
                    if ((double)record.Temperature <= WarningTempLow)
                    {
                        lblSelectedTemperature.ForeColor = Color.Blue;
                    }
                    else if ((double)record.Temperature >= WarningTempHigh)
                    {
                        lblSelectedTemperature.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblSelectedTemperature.ForeColor = Color.Black;
                    }

                    lblSelectedTemperature.Text = $"�̉�: {record.Temperature:F1}��";

                    if (e.Button == MouseButtons.Right)
                    {
                        contextMenuStrip1.Show(pictureBoxGraph, e.Location);
                    }
                }
            }
        }

        /// <summary>
        /// �}�E�X�ړ����Ƀf�[�^�_��Ȃ�c�[���`�b�v�\��
        /// </summary>
        private void PictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (temperatureDataManager.Records.Count == 0)
            {
                graphToolTip.Hide(pictureBoxGraph);
                return;
            }

            var records = temperatureDataManager.Records.OrderBy(r => r.RecordTime).ToList();
            DateTime minTime = records.First().RecordTime;
            DateTime maxTime = records.Last().RecordTime;
            double timeSpan = (maxTime - minTime).TotalMinutes;
            if (timeSpan == 0) timeSpan = 1;

            PointF[] dataPoints = records.Select(r =>
            {
                float x = 50 + (float)((r.RecordTime - minTime).TotalMinutes / timeSpan * (pictureBoxGraph.Width - 80));
                float y = (float)(pictureBoxGraph.Height - 40 - ((double)r.Temperature - MinTempScale) / (MaxTempScale - MinTempScale) * (pictureBoxGraph.Height - 60));
                return new PointF(x, y);
            }).ToArray();

            int nearestIndex = -1;
            double minDist = double.MaxValue;
            for (int i = 0; i < dataPoints.Length; i++)
            {
                double dx = dataPoints[i].X - e.X;
                double dy = dataPoints[i].Y - e.Y;
                double dist = dx * dx + dy * dy;
                if (dist < minDist)
                {
                    minDist = dist;
                    nearestIndex = i;
                }
            }

            if (nearestIndex >= 0 && minDist < DataPointHitRadius * DataPointHitRadius)
            {
                var record = records[nearestIndex];
                string toolTipText = $"���͎���: {record.RecordTime:yyyy/MM/dd HH:mm}\n�̉�: {record.Temperature:F1} ��";
                if (graphToolTip.GetToolTip(pictureBoxGraph) != toolTipText)
                {
                    graphToolTip.Show(toolTipText, pictureBoxGraph, e.Location.X + 10, e.Location.Y + 10, 2000);
                }
            }
            else
            {
                graphToolTip.Hide(pictureBoxGraph);
            }
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (selectedIndex.HasValue && selectedIndex.Value >= 0 && selectedIndex.Value < temperatureDataManager.Records.Count)
            {
                var record = temperatureDataManager.Records[selectedIndex.Value];

                // �폜�m�F�_�C�A���O��\��
                var result = MessageBox.Show(
                    $"�I�������̉��f�[�^�i{record.RecordTime:yyyy/MM/dd HH:mm}�A{record.Temperature:F1}���j���폜���܂����H",
                    "�폜�̊m�F",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    temperatureDataManager.RemoveRecord(record);
                    selectedIndex = null;
                    UpdateTemperatureGraph();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�m�F���܂����B", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
