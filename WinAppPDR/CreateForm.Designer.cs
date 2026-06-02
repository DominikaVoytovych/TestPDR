using System.Drawing;
using System.Windows.Forms;

namespace WinAppPDR
{
    partial class CreateForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTestName;
        private TextBox txtTestName;
        private Label lblQuestion;
        private TextBox txtQuestion;
        private Label lblOptions;
        private TextBox txtOptions;
        private Label lblCorrectIndex;
        private TextBox txtCorrectIndex;
        private Label lblCounter;
        private Button btnAddQuestion;
        private Button btnSaveTest;
        private Button btnChangeStyles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTestName = new Label();
            txtTestName = new TextBox();
            lblQuestion = new Label();
            txtQuestion = new TextBox();
            lblOptions = new Label();
            txtOptions = new TextBox();
            lblCorrectIndex = new Label();
            txtCorrectIndex = new TextBox();
            lblCounter = new Label();
            btnAddQuestion = new Button();
            btnSaveTest = new Button();
            btnChangeStyles = new Button();
            SuspendLayout();

            int col1 = 20, col2 = 160, w = 400, row = 20, step = 55;

            // Test name row
            lblTestName.Text = "Назва тесту:";
            lblTestName.Location = new Point(col1, row);
            lblTestName.Size = new Size(130, 30);
            lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtTestName.Location = new Point(col2, row);
            txtTestName.Size = new Size(w, 30);
            txtTestName.PlaceholderText = "Наприклад: Мій тест 1";
            row += step;

            // Question row
            lblQuestion.Text = "Питання:";
            lblQuestion.Location = new Point(col1, row);
            lblQuestion.Size = new Size(130, 30);
            lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtQuestion.Location = new Point(col2, row);
            txtQuestion.Size = new Size(w, 30);
            txtQuestion.PlaceholderText = "Текст питання";
            row += step;

            // Options row
            lblOptions.Text = "Варіанти:";
            lblOptions.Location = new Point(col1, row);
            lblOptions.Size = new Size(130, 30);
            lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtOptions.Location = new Point(col2, row);
            txtOptions.Size = new Size(w, 30);
            txtOptions.PlaceholderText = "Варіант А,Варіант Б,Варіант В";
            row += step;

            // Correct index row
            lblCorrectIndex.Text = "Правильний (0…):";
            lblCorrectIndex.Location = new Point(col1, row);
            lblCorrectIndex.Size = new Size(130, 30);
            lblCorrectIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            txtCorrectIndex.Location = new Point(col2, row);
            txtCorrectIndex.Size = new Size(80, 30);
            txtCorrectIndex.PlaceholderText = "0";
            row += step;

            // Counter
            lblCounter.Text = "Питань у тесті: 0";
            lblCounter.Location = new Point(col1, row);
            lblCounter.Size = new Size(300, 30);
            lblCounter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            row += 45;

            // Buttons
            btnAddQuestion.FlatStyle = FlatStyle.Flat;
            btnAddQuestion.FlatAppearance.BorderSize = 0;
            btnAddQuestion.Location = new Point(col1, row);
            btnAddQuestion.Size = new Size(170, 45);
            btnAddQuestion.Text = "+ Додати питання";
            btnAddQuestion.Click += btnAddQuestion_Click;

            btnSaveTest.FlatStyle = FlatStyle.Flat;
            btnSaveTest.FlatAppearance.BorderSize = 0;
            btnSaveTest.Location = new Point(200, row);
            btnSaveTest.Size = new Size(170, 45);
            btnSaveTest.Text = "💾 Зберегти тест";
            btnSaveTest.Click += btnSaveTest_Click;

            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.Location = new Point(390, row);
            btnChangeStyles.Size = new Size(130, 45);
            btnChangeStyles.Text = "Світла тема";
            btnChangeStyles.Click += btnChangeStyles_Click;

            // Form
            ClientSize = new Size(600, row + 80);
            Controls.AddRange(new Control[] {
                lblTestName, txtTestName,
                lblQuestion, txtQuestion,
                lblOptions, txtOptions,
                lblCorrectIndex, txtCorrectIndex,
                lblCounter,
                btnAddQuestion, btnSaveTest, btnChangeStyles
            });
            Name = "CreateForm";
            Text = "Створення тесту";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }
    }
}