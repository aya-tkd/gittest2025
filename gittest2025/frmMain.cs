using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // 追加
using gittest2025.Models;

namespace gittest2025
{
    public partial class frmMain : Form
    {
        private readonly TemperatureDataManager temperatureDataManager = new TemperatureDataManager();
        private int? selectedIndex = null;

        public frmMain()
        {
            InitializeComponent();
            InitializeTemperatureGraph();
        }

        /// <summary>
        /// グラフの初期設定
        /// </summary>
        private void InitializeTemperatureGraph()
        {
            // デザイナで追加したpictureBoxGraphを利用
            pictureBoxGraph.Paint += PictureBoxGraph_Paint;
            pictureBoxGraph.MouseDown += PictureBoxGraph_MouseDown;
            UpdateTemperatureGraph();
        }

        /// <summary>
        /// 体温入力ダイアログを表示し、データを追加
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
        /// グラフを最新の体温データで再描画
        /// </summary>
        private void UpdateTemperatureGraph()
        {
            pictureBoxGraph.Invalidate();
        }

        /// <summary>
        /// PictureBoxのPaintイベントでグラフを描画
        /// </summary>
        private void PictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int width = pictureBoxGraph.Width;
            int height = pictureBoxGraph.Height;

            g.Clear(Color.White);

            // 軸の描画
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, 50, height - 40, width - 20, height - 40); // X軸
            g.DrawLine(axisPen, 50, 20, 50, height - 40); // Y軸

            // ラベル
            g.DrawString("体温推移", new Font("Meiryo", 14), Brushes.Black, width / 2 - 40, 5);
            g.DrawString("体温(℃)", new Font("Meiryo", 10), Brushes.Black, 5, 20);
            g.DrawString("入力時間", new Font("Meiryo", 10), Brushes.Black, width / 2 - 30, height - 25);

            // データ点の描画
            if (temperatureDataManager.Records.Count > 0)
            {
                var records = temperatureDataManager.Records.OrderBy(r => r.RecordTime).ToList();
                double minTemp = 35, maxTemp = 42;
                DateTime minTime = records.First().RecordTime;
                DateTime maxTime = records.Last().RecordTime;
                double timeSpan = (maxTime - minTime).TotalMinutes;
                if (timeSpan == 0) timeSpan = 1; // 1点のみの場合

                PointF[] points = records.Select(r =>
                {
                    float x = 50 + (float)((r.RecordTime - minTime).TotalMinutes / timeSpan * (width - 80));
                    float y = (float)(height - 40 - ((double)r.Temperature - minTemp) / (maxTemp - minTemp) * (height - 60));
                    return new PointF(x, y);
                }).ToArray();

                // 折れ線
                if (points.Length > 1)
                    g.DrawLines(Pens.Blue, points);

                // 点
                foreach (var pt in points)
                    g.FillEllipse(Brushes.Red, pt.X - 4, pt.Y - 4, 8, 8);
            }
        }

        /// <summary>
        /// グラフ上で右クリックされた点を選択し、削除メニューを表示
        /// </summary>
        private void PictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && temperatureDataManager.Records.Count > 0)
            {
                var records = temperatureDataManager.Records.OrderBy(r => r.RecordTime).ToList();
                double minTemp = 35, maxTemp = 42;
                DateTime minTime = records.First().RecordTime;
                DateTime maxTime = records.Last().RecordTime;
                double timeSpan = (maxTime - minTime).TotalMinutes;
                if (timeSpan == 0) timeSpan = 1;

                PointF[] points = records.Select(r =>
                {
                    float x = 50 + (float)((r.RecordTime - minTime).TotalMinutes / timeSpan * (pictureBoxGraph.Width - 80));
                    float y = (float)(pictureBoxGraph.Height - 40 - ((double)r.Temperature - minTemp) / (maxTemp - minTemp) * (pictureBoxGraph.Height - 60));
                    return new PointF(x, y);
                }).ToArray();

                int nearest = -1;
                double minDist = double.MaxValue;
                for (int i = 0; i < points.Length; i++)
                {
                    double dx = points[i].X - e.X;
                    double dy = points[i].Y - e.Y;
                    double dist = dx * dx + dy * dy;
                    if (dist < minDist)
                    {
                        minDist = dist;
                        nearest = i;
                    }
                }
                if (nearest >= 0 && minDist < 100) // 10px以内
                {
                    selectedIndex = nearest;
                    contextMenuStrip1.Show(pictureBoxGraph, e.Location);
                }
            }
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (selectedIndex.HasValue && selectedIndex.Value >= 0 && selectedIndex.Value < temperatureDataManager.Records.Count)
            {
                var record = temperatureDataManager.Records[selectedIndex.Value];
                temperatureDataManager.RemoveRecord(record);
                selectedIndex = null;
                UpdateTemperatureGraph();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("確認しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
