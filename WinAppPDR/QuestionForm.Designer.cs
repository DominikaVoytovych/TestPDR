namespace WinAppPDR
{
    partial class QuestionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnSkip = new Button();
            gpListAnswers = new GroupBox();
            lblQuestion = new Label();
            pbImage = new PictureBox();
            pnlOptions = new Panel();
            btnSubmit = new Button();
            btnChangeStyles = new Button();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // btnSkip
            // 
            btnSkip.FlatAppearance.BorderSize = 0;
            btnSkip.FlatStyle = FlatStyle.Flat;
            btnSkip.Location = new Point(20, 550);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(200, 50);
            btnSkip.TabIndex = 5;
            btnSkip.Text = "Пропустити";
            btnSkip.Click += BtnSkip_Click;
            // 
            // gpListAnswers
            // 
            gpListAnswers.Location = new Point(20, 20);
            gpListAnswers.Name = "gpListAnswers";
            gpListAnswers.Size = new Size(1060, 100);
            gpListAnswers.TabIndex = 0;
            gpListAnswers.TabStop = false;
            gpListAnswers.Text = "Список питань";
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblQuestion.Location = new Point(20, 140);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(1060, 80);
            lblQuestion.TabIndex = 1;
            // 
            // pbImage
            // 
            pbImage.Location = new Point(20, 230);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(500, 300);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 2;
            pbImage.TabStop = false;
            // 
            // pnlOptions
            // 
            pnlOptions.Location = new Point(550, 230);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(500, 300);
            pnlOptions.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Location = new Point(269, 550);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(200, 50);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Обрати";
            btnSubmit.Visible = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Location = new Point(900, 550);
            btnChangeStyles.Name = "btnChangeStyles";
            btnChangeStyles.Size = new Size(150, 50);
            btnChangeStyles.TabIndex = 6;
            btnChangeStyles.Text = "Світла тема";
            btnChangeStyles.Click += btnChangeStyles_Click;
            // 
            // QuestionForm
            // 
            ClientSize = new Size(1100, 650);
            Controls.Add(gpListAnswers);
            Controls.Add(lblQuestion);
            Controls.Add(pbImage);
            Controls.Add(pnlOptions);
            Controls.Add(btnSubmit);
            Controls.Add(btnSkip);
            Controls.Add(btnChangeStyles);
            Name = "QuestionForm";
            Text = "Офіційні тести з ПДР Україна";
            Load += QuestionForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnChangeStyles;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.GroupBox gpListAnswers;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnSubmit;
    }
}