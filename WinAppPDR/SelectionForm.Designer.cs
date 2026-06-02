using System.Drawing;
using System.Windows.Forms;

namespace WinAppPDR
{
    partial class SelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblCustomTests;
        private ListBox lstTests;
        private Button btnStartDefault;
        private Button btnStartCustom;
        private Button btnCreateTest;
        private Button btnChangeStyles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCustomTests = new Label();
            lstTests = new ListBox();
            btnStartDefault = new Button();
            btnStartCustom = new Button();
            btnCreateTest = new Button();
            btnChangeStyles = new Button();
            SuspendLayout();

            // lblTitle
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(460, 45);
            lblTitle.Text = "Тести з ПДР України";

            // btnStartDefault
            btnStartDefault.FlatStyle = FlatStyle.Flat;
            btnStartDefault.FlatAppearance.BorderSize = 0;
            btnStartDefault.Location = new Point(20, 80);
            btnStartDefault.Size = new Size(460, 55);
            btnStartDefault.Text = "▶  Розпочати стандартний тест (20 питань)";
            btnStartDefault.Font = new Font("Segoe UI", 11F);
            btnStartDefault.Click += btnStartDefault_Click;

            // lblCustomTests
            lblCustomTests.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCustomTests.Location = new Point(20, 160);
            lblCustomTests.Size = new Size(460, 30);
            lblCustomTests.Text = "Власні тести:";

            // lstTests
            lstTests.Font = new Font("Segoe UI", 11F);
            lstTests.Location = new Point(20, 195);
            lstTests.Size = new Size(460, 160);

            // btnStartCustom
            btnStartCustom.FlatStyle = FlatStyle.Flat;
            btnStartCustom.FlatAppearance.BorderSize = 0;
            btnStartCustom.Location = new Point(20, 370);
            btnStartCustom.Size = new Size(220, 50);
            btnStartCustom.Text = "▶  Запустити обраний";
            btnStartCustom.Font = new Font("Segoe UI", 10F);
            btnStartCustom.Click += btnStartCustom_Click;

            // btnCreateTest
            btnCreateTest.FlatStyle = FlatStyle.Flat;
            btnCreateTest.FlatAppearance.BorderSize = 0;
            btnCreateTest.Location = new Point(260, 370);
            btnCreateTest.Size = new Size(220, 50);
            btnCreateTest.Text = "+ Створити новий тест";
            btnCreateTest.Font = new Font("Segoe UI", 10F);
            btnCreateTest.Click += btnCreateTest_Click;

            // btnChangeStyles
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.Location = new Point(360, 440);
            btnChangeStyles.Size = new Size(120, 40);
            btnChangeStyles.Text = "Світла тема";
            btnChangeStyles.Click += btnChangeStyles_Click;

            // Form
            ClientSize = new Size(500, 500);
            Controls.AddRange(new Control[] {
                lblTitle, btnStartDefault,
                lblCustomTests, lstTests,
                btnStartCustom, btnCreateTest,
                btnChangeStyles
            });
            Name = "SelectionForm";
            Text = "Головне меню — ПДР";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}