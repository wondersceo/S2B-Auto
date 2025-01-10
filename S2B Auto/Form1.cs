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
                MessageBox.Show($"초기화 중 오류 발생: {ex.Message}");
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
                            MessageBox.Show($"이미지 로드 중 오류: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (sender is not Button) return;  // sender null 체크를 이렇게 수정

            if (_productCrawler == null || _imageProcessor == null || _ocrProcessor == null ||
                textBox1 == null || progressBar1 == null || dataGridView1 == null || button1 == null)
            {
                MessageBox.Show("필요한 구성요소가 초기화되지 않았습니다.");
                return;
            }
           
            try
            {
                string url = textBox1.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("URL을 입력해주세요.");
                    return;
                }

                button1.Enabled = false;
                progressBar1.Value = 0;

                // 상품 정보 가져오기
                var productInfo = await _productCrawler.GetProductInfoAsync(url);
                progressBar1.Value = 30;

                // 이미지 처리
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
                    MessageBox.Show($"이미지 처리 중 오류: {ex.Message}");
                }

                // OCR 처리
                try
                {
                    if (!string.IsNullOrEmpty(productInfo.MainImagePath))
                    {
                        string extractedText = _ocrProcessor.ExtractTextFromImage(productInfo.MainImagePath);
                        // TODO: 추출된 텍스트 처리
                    }
                    progressBar1.Value = 90;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"OCR 처리 중 오류: {ex.Message}");
                }

                // DataGridView에 데이터 추가
                dataGridView1.Rows.Add(
                    productInfo.ProductName,
                    productInfo.Specification,
                    productInfo.ModelName,
                    productInfo.Price,
                    productInfo.Manufacturer,
                    productInfo.OriginType
                );

                progressBar1.Value = 100;
                MessageBox.Show("처리가 완료되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"처리 중 오류가 발생했습니다: {ex.Message}");
            }
            finally
            {
                button1.Enabled = true;
                progressBar1.Value = 0;
            }
        }
    }
}