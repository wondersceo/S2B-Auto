using System;
using System.Drawing;
using System.Windows.Forms;

namespace S2B_Auto
{
    public partial class Form1 : Form
    {
        #region Fields
        private ImageProcessor? _imageProcessor;
        private OCRProcessor? _ocrProcessor;
        private ProductCrawler? _productCrawler;
        #endregion

        public Form1()
        {
            InitializeComponent();
            InitializeProcessors();
            InitializeUI();
        }

        private void InitializeProcessors()
        {
            try
            {
                _imageProcessor = new ImageProcessor();
                _ocrProcessor = new OCRProcessor();
                _productCrawler = new ProductCrawler();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�ʱ�ȭ �� ���� �߻�: {ex.Message}");
            }
        }

        private void InitializeUI()
        {
            if (progressBar1 != null)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
            }

            if (dataGridView1 != null)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
            }

            if (button1 != null)
            {
                button1.Click += button1_Click;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1 == null) return;

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "MainImagePath")
            {
                string? imagePath = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    using (Form imageForm = new Form())
                    {
                        PictureBox pb = new PictureBox();
                        pb.Dock = DockStyle.Fill;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;

                        try
                        {
                            pb.Image = Image.FromFile(imagePath);
                            imageForm.Controls.Add(pb);
                            imageForm.Size = new Size(800, 600);
                            imageForm.StartPosition = FormStartPosition.CenterParent;
                            imageForm.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"�̹��� �ε� �� ����: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (sender is not Button) return;  // sender null üũ�� �̷��� ����

            if (_productCrawler == null || _imageProcessor == null || _ocrProcessor == null ||
                textBox1 == null || progressBar1 == null || dataGridView1 == null || button1 == null)
            {
                MessageBox.Show("�ʿ��� ������Ұ� �ʱ�ȭ���� �ʾҽ��ϴ�.");
                return;
            }
           
            try
            {
                string url = textBox1.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("URL�� �Է����ּ���.");
                    return;
                }

                button1.Enabled = false;
                progressBar1.Value = 0;

                // ��ǰ ���� ��������
                var productInfo = await _productCrawler.GetProductInfoAsync(url);
                progressBar1.Value = 30;

                // �̹��� ó��
                try
                {
                    if (!string.IsNullOrEmpty(productInfo.MainImagePath))
                    {
                        string imagePath = await _imageProcessor.ProcessAndSaveImage(productInfo.MainImagePath, true);
                        productInfo.MainImagePath = imagePath;
                    }
                    progressBar1.Value = 60;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�̹��� ó�� �� ����: {ex.Message}");
                }

                // OCR ó��
                try
                {
                    if (!string.IsNullOrEmpty(productInfo.MainImagePath))
                    {
                        string extractedText = _ocrProcessor.ExtractTextFromImage(productInfo.MainImagePath);
                        // TODO: ����� �ؽ�Ʈ ó��
                    }
                    progressBar1.Value = 90;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"OCR ó�� �� ����: {ex.Message}");
                }

                // DataGridView�� ������ �߰�
                dataGridView1.Rows.Add(
                    productInfo.ProductName,
                    productInfo.Specification,
                    productInfo.ModelName,
                    productInfo.Price,
                    productInfo.Manufacturer,
                    productInfo.OriginType
                );

                progressBar1.Value = 100;
                MessageBox.Show("ó���� �Ϸ�Ǿ����ϴ�.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ó�� �� ������ �߻��߽��ϴ�: {ex.Message}");
            }
            finally
            {
                button1.Enabled = true;
                progressBar1.Value = 0;
            }
        }
    }
}