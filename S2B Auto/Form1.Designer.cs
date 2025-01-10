namespace S2B_Auto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            dataGridView1 = new DataGridView();
            colProductName = new DataGridViewTextBoxColumn();
            colSpecification = new DataGridViewTextBoxColumn();
            colModelName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colManufacturer = new DataGridViewTextBoxColumn();
            colOriginType = new DataGridViewComboBoxColumn();
            colOriginDetail = new DataGridViewComboBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colMaterial = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewComboBoxColumn();
            colTaxation = new DataGridViewComboBoxColumn();
            colChildCertInput = new DataGridViewTextBoxColumn();
            colChildCertButton = new DataGridViewButtonColumn();
            colElectricCertInput = new DataGridViewTextBoxColumn();
            colElectricCertButton = new DataGridViewButtonColumn();
            colLifeCertInput = new DataGridViewTextBoxColumn();
            colLifeCertButton = new DataGridViewButtonColumn();
            colCommCertInput = new DataGridViewTextBoxColumn();
            colCommCertButton = new DataGridViewButtonColumn();
            colMainImage = new DataGridViewButtonColumn();
            colDetailImage = new DataGridViewButtonColumn();
            colDescription = new DataGridViewButtonColumn();
            colAdditionalShippingCheck = new DataGridViewCheckBoxColumn();
            colJejuShippingFee = new DataGridViewTextBoxColumn();
            colDeliveryPeriod = new DataGridViewComboBoxColumn();
            colReturnFee = new DataGridViewTextBoxColumn();
            colRegisterBtn = new DataGridViewButtonColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 35);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(600, 300);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(171, 353);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "실행";
            button1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(171, 393);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(600, 34);
            progressBar1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colProductName, colSpecification, colModelName, colPrice, colManufacturer, colOriginType, colOriginDetail, colStock, colMaterial, colUnit, colTaxation, colChildCertInput, colChildCertButton, colElectricCertInput, colElectricCertButton, colLifeCertInput, colLifeCertButton, colCommCertInput, colCommCertButton, colMainImage, colDetailImage, colDescription, colAdditionalShippingCheck, colJejuShippingFee, colDeliveryPeriod, colReturnFee, colRegisterBtn });
            dataGridView1.Location = new Point(12, 452);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1512, 225);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "물품명";
            colProductName.MinimumWidth = 8;
            colProductName.Name = "colProductName";
            // 
            // colSpecification
            // 
            colSpecification.HeaderText = "규격";
            colSpecification.MinimumWidth = 8;
            colSpecification.Name = "colSpecification";
            // 
            // colModelName
            // 
            colModelName.HeaderText = "모델명";
            colModelName.MinimumWidth = 8;
            colModelName.Name = "colModelName";
            // 
            // colPrice
            // 
            colPrice.HeaderText = "제시금액";
            colPrice.MinimumWidth = 8;
            colPrice.Name = "colPrice";
            // 
            // colManufacturer
            // 
            colManufacturer.HeaderText = "제조사";
            colManufacturer.MinimumWidth = 8;
            colManufacturer.Name = "colManufacturer";
            // 
            // colOriginType
            // 
            colOriginType.HeaderText = "원산지";
            colOriginType.MinimumWidth = 8;
            colOriginType.Name = "colOriginType";
            // 
            // colOriginDetail
            // 
            colOriginDetail.HeaderText = "원산지상세";
            colOriginDetail.MinimumWidth = 8;
            colOriginDetail.Name = "colOriginDetail";
            // 
            // colStock
            // 
            colStock.HeaderText = "재고수량";
            colStock.MinimumWidth = 8;
            colStock.Name = "colStock";
            // 
            // colMaterial
            // 
            colMaterial.HeaderText = "소재/재질";
            colMaterial.MinimumWidth = 8;
            colMaterial.Name = "colMaterial";
            // 
            // colUnit
            // 
            colUnit.HeaderText = "판매단위";
            colUnit.MinimumWidth = 8;
            colUnit.Name = "colUnit";
            // 
            // colTaxation
            // 
            colTaxation.HeaderText = "과세여부";
            colTaxation.MinimumWidth = 8;
            colTaxation.Name = "colTaxation";
            // 
            // colChildCertInput
            // 
            colChildCertInput.HeaderText = "어린이제품인증";
            colChildCertInput.MinimumWidth = 8;
            colChildCertInput.Name = "colChildCertInput";
            // 
            // colChildCertButton
            // 
            colChildCertButton.HeaderText = "어린이제품인증등록";
            colChildCertButton.MinimumWidth = 8;
            colChildCertButton.Name = "colChildCertButton";
            // 
            // colElectricCertInput
            // 
            colElectricCertInput.HeaderText = "전기용품인증번호";
            colElectricCertInput.MinimumWidth = 8;
            colElectricCertInput.Name = "colElectricCertInput";
            // 
            // colElectricCertButton
            // 
            colElectricCertButton.HeaderText = "전기용품인증등록";
            colElectricCertButton.MinimumWidth = 8;
            colElectricCertButton.Name = "colElectricCertButton";
            // 
            // colLifeCertInput
            // 
            colLifeCertInput.HeaderText = "생활용품인증번호";
            colLifeCertInput.MinimumWidth = 8;
            colLifeCertInput.Name = "colLifeCertInput";
            // 
            // colLifeCertButton
            // 
            colLifeCertButton.HeaderText = "생활용품인증등록";
            colLifeCertButton.MinimumWidth = 8;
            colLifeCertButton.Name = "colLifeCertButton";
            // 
            // colCommCertInput
            // 
            colCommCertInput.HeaderText = "방송통신인증번호";
            colCommCertInput.MinimumWidth = 8;
            colCommCertInput.Name = "colCommCertInput";
            // 
            // colCommCertButton
            // 
            colCommCertButton.HeaderText = "방송통신인증등록";
            colCommCertButton.MinimumWidth = 8;
            colCommCertButton.Name = "colCommCertButton";
            // 
            // colMainImage
            // 
            colMainImage.HeaderText = "기본이미지1";
            colMainImage.MinimumWidth = 8;
            colMainImage.Name = "colMainImage";
            // 
            // colDetailImage
            // 
            colDetailImage.HeaderText = "상세이미지";
            colDetailImage.MinimumWidth = 8;
            colDetailImage.Name = "colDetailImage";
            // 
            // colDescription
            // 
            colDescription.HeaderText = "상세설명";
            colDescription.MinimumWidth = 8;
            colDescription.Name = "colDescription";
            // 
            // colAdditionalShippingCheck
            // 
            colAdditionalShippingCheck.HeaderText = "추가배송비 설정";
            colAdditionalShippingCheck.MinimumWidth = 8;
            colAdditionalShippingCheck.Name = "colAdditionalShippingCheck";
            // 
            // colJejuShippingFee
            // 
            colJejuShippingFee.HeaderText = "제주 배송비";
            colJejuShippingFee.MinimumWidth = 8;
            colJejuShippingFee.Name = "colJejuShippingFee";
            // 
            // colDeliveryPeriod
            // 
            colDeliveryPeriod.HeaderText = "납품가능기간";
            colDeliveryPeriod.MinimumWidth = 8;
            colDeliveryPeriod.Name = "colDeliveryPeriod";
            // 
            // colReturnFee
            // 
            colReturnFee.HeaderText = "반품배송비";
            colReturnFee.MinimumWidth = 8;
            colReturnFee.Name = "colReturnFee";
            // 
            // colRegisterBtn
            // 
            colRegisterBtn.HeaderText = "상품등록";
            colRegisterBtn.MinimumWidth = 8;
            colRegisterBtn.Name = "colRegisterBtn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(171, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 25);
            label1.TabIndex = 5;
            label1.Text = "상품 URL 입력";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 944);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "상품정보추출";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private ProgressBar progressBar1;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colSpecification;
        private DataGridViewTextBoxColumn colModelName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colManufacturer;
        private DataGridViewComboBoxColumn colOriginType;
        private DataGridViewComboBoxColumn colOriginDetail;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colMaterial;
        private DataGridViewComboBoxColumn colUnit;
        private DataGridViewComboBoxColumn colTaxation;
        private DataGridViewTextBoxColumn colChildCertInput;
        private DataGridViewButtonColumn colChildCertButton;
        private DataGridViewTextBoxColumn colElectricCertInput;
        private DataGridViewButtonColumn colElectricCertButton;
        private DataGridViewTextBoxColumn colLifeCertInput;
        private DataGridViewButtonColumn colLifeCertButton;
        private DataGridViewTextBoxColumn colCommCertInput;
        private DataGridViewButtonColumn colCommCertButton;
        private DataGridViewButtonColumn colMainImage;
        private DataGridViewButtonColumn colDetailImage;
        private DataGridViewButtonColumn colDescription;
        private DataGridViewCheckBoxColumn colAdditionalShippingCheck;
        private DataGridViewTextBoxColumn colJejuShippingFee;
        private DataGridViewComboBoxColumn colDeliveryPeriod;
        private DataGridViewTextBoxColumn colReturnFee;
        private DataGridViewButtonColumn colRegisterBtn;
    }
}
