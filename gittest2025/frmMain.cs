using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using gittest2025.Models;

namespace gittest2025
{
    public partial class frmMain : Form
    {
        private readonly TemperatureDataManager temperatureDataManager = new TemperatureDataManager();
        private int? selectedIndex = null;
        private readonly ToolTip graphToolTip = new ToolTip();

        private Button btnCsvExport;
        private Button btnCsvImport;

        private const int DataPointHitRadius = 10;

        private const double MinTempScale = 30.0;
        private const double MaxTempScale = 50.0;
        private const double WarningTempHigh = 37.0;
        private const double WarningTempLow = 35.0;

        public frmMain()
        {
            InitializeComponent();
            InitializeTemperatureGraph();
            InitializeCsvButtons();
        }

        private void InitializeTemperatureGraph()
        {
            pictureBoxGraph.Paint += PictureBoxGraph_Paint;
            pictureBoxGraph.MouseDown += PictureBoxGraph_MouseDown;
            pictureBoxGraph.MouseMove += PictureBoxGraph_MouseMove;
            UpdateTemperatureGraph();
        }

        private void InitializeCsvButtons()
        {
            btnCsvExport = new Button
            {
                Text = "CSV出力",
                Location = new Point(490, 296),
                Size = new Size(90, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnCsvExport.Click += btnCsvExport_Click;
            this.Controls.Add(btnCsvExport);

            btnCsvImport = new Button
            {
                Text = "CSV取込",
                Location = new Point(390, 296),
                Size = new Size(90, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnCsvImport.Click += btnCsvImport_Click;
            this.Controls.Add(btnCsvImport);
        }

        private void btnCsvExport_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSVファイル|*.csv";
                saveFileDialog.Title = "CSV出力";
                saveFileDialog.FileName = "temperature_data.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        temperatureDataManager.SaveRecordsToCsv(saveFileDialog.FileName);
                        ShowNotification("CSVファイルの出力に成功しました。");
                    }
                    catch (Exception ex)
                    {
                        ShowNotification($"CSVファイルの出力に失敗しました.\n{ex.Message}", true);
                    }
                }
            }
        }

        private void btnCsvImport_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSVファイル|*.csv";
                openFileDialog.Title = "CSV取込";
                openFileDialog.FileName = "temperature_data.csv";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        temperatureDataManager.LoadRecordsFromCsv(openFileDialog.FileName);
                        UpdateTemperatureGraph();
                        ShowNotification("CSVファイルの読み込みに成功しました。");
                    }
                    catch (Exception ex)
                    {
                        ShowNotification($"CSVファイルの読み込みに失敗しました.\n{ex.Message}", true);
                    }
                }
            }
        }

        private void ShowNotification(string message, bool isError = false)
        {
            var notifyIcon = new NotifyIcon
            {
                Visible = true,
                Icon = SystemIcons.Information,
                BalloonTipTitle = isError ? "エラー" : "通知",
                BalloonTipText = message,
                BalloonTipIcon = isError ? ToolTipIcon.Error : ToolTipIcon.Info
            };

            notifyIcon.ShowBalloonTip(3000);

            var timer = new System.Windows.Forms.Timer
            {
                Interval = 3000
            };
            timer.Tick += (s, e) =>
            {
                notifyIcon.Dispose();
                timer.Dispose();
            };
            timer.Start();
        }

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

        private void UpdateTemperatureGraph()
        {
            pictureBoxGraph.Invalidate();
        }

        private void PictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            int width = pictureBoxGraph.Width;
            int height = pictureBoxGraph.Height;

            graphics.Clear(Color.White);

            using (var axisPen = new Pen(Color.Black, 2))
            {
                graphics.DrawLine(axisPen, 50, height - 40, width - 20, height - 40);
                graphics.DrawLine(axisPen, 50, 20, 50, height - 40);
            }

            graphics.DrawString("体温グラフ", new Font("Meiryo", 14), Brushes.Black, width / 2 - 40, 5);
            graphics.DrawString("体温(℃)", new Font("Meiryo", 10), Brushes.Black, 5, 20);
            graphics.DrawString("日時", new Font("Meiryo", 10), Brushes.Black, width / 2 - 30, height - 25);

            int graphTop = 20;
            int graphBottom = height - 40;
            int graphHeight = graphBottom - graphTop;

            float y37 = (float)(graphBottom - ((WarningTempHigh - MinTempScale) / (MaxTempScale - MinTempScale) * graphHeight));
            using (var warningPenHigh = new Pen(Color.Red, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                graphics.DrawLine(warningPenHigh, 50, y37, width - 20, y37);
                graphics.DrawString("37.0℃", new Font("Meiryo", 8), Brushes.Red, 15, y37 - 7);
            }

            float y35 = (float)(graphBottom - ((WarningTempLow - MinTempScale) / (MaxTempScale - MinTempScale) * graphHeight));
            using (var warningPenLow = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                graphics.DrawLine(warningPenLow, 50, y35, width - 20, y35);
                graphics.DrawString("35.0℃", new Font("Meiryo", 8), Brushes.Blue, 15, y35 - 7);
            }

            if (temperatureDataManager.Records.Count > 0)
            {
                var records = temperatureDataManager.Records.OrderBy(r => r.RecordTime).ToList();
                DateTime minTime = records.First().RecordTime;
                DateTime maxTime = records.Last().RecordTime;
                double timeSpan = (maxTime - minTime).TotalMinutes;
                if (timeSpan == 0) timeSpan = 1;

                PointF[] dataPoints = records.Select(r =>
                {
                    float x = 50 + (float)((r.RecordTime - minTime).TotalMinutes / timeSpan * (width - 80));
                    float y = (float)(height - 40 - ((double)r.Temperature - MinTempScale) / (MaxTempScale - MinTempScale) * (height - 60));
                    return new PointF(x, y);
                }).ToArray();

                if (dataPoints.Length > 1)
                    graphics.DrawLines(Pens.Blue, dataPoints);

                foreach (var pt in dataPoints)
                    graphics.FillEllipse(Brushes.Red, pt.X - 4, pt.Y - 4, 8, 8);
            }
        }

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
                    
                    lblSelectedDateTime.Text = $"日時: {record.RecordTime:yyyy/MM/dd HH:mm}";

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

                    lblSelectedTemperature.Text = $"体温: {record.Temperature:F1}℃";

                    if (e.Button == MouseButtons.Right)
                    {
                        contextMenuStrip1.Show(pictureBoxGraph, e.Location);
                    }
                }
            }
        }

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
                string toolTipText = $"日時: {record.RecordTime:yyyy/MM/dd HH:mm}\n体温: {record.Temperature:F1} ℃";
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

                var result = MessageBox.Show(
                    $"選択した体温データ({record.RecordTime:yyyy/MM/dd HH:mm}、{record.Temperature:F1}℃)を削除しますか？",
                    "削除の確認",
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
            MessageBox.Show("確認しました。", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
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