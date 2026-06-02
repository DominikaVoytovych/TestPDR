using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace WinAppPDR
{
    public partial class QuestionForm : Form
    {
        private List<QuestionData> questions;
        private int currentId = -1;
        private int errorsCount = 0;
        private int answeredCount = 0;
        private bool[] isAnswered;
        private bool isDarkMode = true;
        private string configPath = "appsettings.json";

        //  конструктор приймає список питань та ініціалізує форму, завантажує налаштування і застосовує тему
        public QuestionForm(List<QuestionData> questionList)
        {
            InitializeComponent();
            questions = questionList;
            isAnswered = new bool[questions.Count];
            LoadSettings();
            ApplyTheme();
            this.Load += QuestionForm_Load;
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Button btn = new Button
                {
                    Name = "btnTemp" + (i + 1),
                    Text = (i + 1).ToString(),
                    Size = new Size(40, 40),
                    Location = new Point(20 + i * 50, 30),
                    BackColor = Color.FromArgb(60, 60, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += btnTemp_Click;
                gpListAnswers.Controls.Add(btn);
            }

            // овтоматично відкриває перше питання при завантаженні форми
            var first = gpListAnswers.Controls.Find("btnTemp1", true).FirstOrDefault() as Button;
            first?.PerformClick();
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse(btn.Text) - 1;

            if (isAnswered[index]) return;
            currentId = index;

            // змінюю колір кнопки поточного питання та скидаю колір інших, які ще не відповіли
            foreach (Control c in gpListAnswers.Controls)
            {
                if (c is Button b &&
                    b.BackColor != Color.Green &&
                    b.BackColor != Color.Red)
                    b.BackColor = Color.FromArgb(60, 60, 60);
            }
            btn.BackColor = Color.FromArgb(0, 120, 215);

            var q = questions[currentId];
            lblQuestion.Text = $"Питання №{currentId + 1}: {q.Text}";

            string path = Path.Combine(Application.StartupPath, "images", q.ImagePath ?? "");
            bool hasImage = !string.IsNullOrEmpty(q.ImagePath) && File.Exists(path);

            pbImage.Visible = hasImage;
            pnlOptions.Location = hasImage
                ? new Point(550, 230)
                : new Point(250, 230);
            if (hasImage) pbImage.ImageLocation = path;

            pnlOptions.Controls.Clear();
            btnSubmit.Visible = false;

            for (int i = 0; i < q.Options.Length; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Text = q.Options[i],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12F),
                    AutoSize = true,
                    Name = "rb" + i,
                    Location = new Point(20, 20 + i * 50)
                };
                rb.Click += (s, ev) => btnSubmit.Visible = true;
                pnlOptions.Controls.Add(rb);
            }

            ApplyTheme();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            var selectedRb = pnlOptions.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            if (selectedRb == null) return;

            int selectedIndex = int.Parse(selectedRb.Name.Replace("rb", ""));
            bool isCorrect = selectedIndex == questions[currentId].CorrectIndex;

            isAnswered[currentId] = true;
            answeredCount++;
            if (!isCorrect) errorsCount++;

            var btn = gpListAnswers.Controls
                .Find("btnTemp" + (currentId + 1), true)
                .FirstOrDefault() as Button;
            if (btn != null)
            {
                btn.BackColor = isCorrect ? Color.Green : Color.Red;
                btn.Enabled = false;
            }

            if (answeredCount == questions.Count)
            {
                ShowFinalResult();
            }
            else
            {
                // пропускаю до наступного  питання
                for (int i = currentId + 1; i < questions.Count; i++)
                {
                    if (!isAnswered[i])
                    {
                        var next = gpListAnswers.Controls
                            .Find("btnTemp" + (i + 1), true)
                            .FirstOrDefault() as Button;
                        if (next != null) btnTemp_Click(next, EventArgs.Empty);
                        break;
                    }
                }
            }
        }

        private void ShowFinalResult()
        {
            int maxErrors = Math.Max(2, questions.Count / 10); // допускаю 10% помилок, але не менше 2
            string msg = errorsCount <= maxErrors
                ? $"Вітаємо! Ви склали іспит.\nПравильних: {questions.Count - errorsCount}/{questions.Count}"
                : $"Іспит не складено. Помилок: {errorsCount}.\nДопустимо: {maxErrors}.";

            MessageBox.Show(msg, "Результати іспиту");
            this.Close();
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            for (int i = currentId + 1; i < questions.Count; i++)
            {
                if (!isAnswered[i])
                {
                    var next = gpListAnswers.Controls
                        .Find("btnTemp" + (i + 1), true)
                        .FirstOrDefault() as Button;
                    if (next != null) { btnTemp_Click(next, EventArgs.Empty); break; }
                }
            }
        }

        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            SaveSettings();
        }

        // створює та відкриває форму для створення нового питання
        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            var createForm = new CreateForm();
            createForm.ShowDialog();
        }

        //---зміна теми---
        private void ApplyTheme()
        {
            this.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.WhiteSmoke;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            void Paint(Control parent)
            {
                foreach (Control ctrl in parent.Controls)
                {
                    if (ctrl is Label || ctrl is RadioButton)
                        ctrl.ForeColor = isDarkMode ? Color.White : Color.Black;
                    else if (ctrl is Button b)
                    {
                        if (b == btnSubmit)
                        { b.BackColor = Color.FromArgb(46, 160, 95); b.ForeColor = Color.White; }
                        else if (b.BackColor != Color.Green &&
                                 b.BackColor != Color.Red &&
                                 b.BackColor != Color.FromArgb(0, 120, 215))
                        {
                            b.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                            b.ForeColor = isDarkMode ? Color.White : Color.Black;
                        }
                    }
                    else if (ctrl is GroupBox gb)
                        gb.ForeColor = isDarkMode ? Color.White : Color.Black;

                    Paint(ctrl);
                }
            }

            Paint(this);
            btnChangeStyles.Text = isDarkMode ? "Світла тема" : "Темна тема";
        }

        private void LoadSettings()
        {
            try
            {
                if (!File.Exists(configPath)) return;
                using var doc = JsonDocument.Parse(File.ReadAllText(configPath));
                if (doc.RootElement.TryGetProperty("theme", out var t))
                    isDarkMode = t.GetString() == "dark";
            }
            catch { }
        }

        private void SaveSettings()
        {
            try
            {
                File.WriteAllText(configPath,
                    JsonSerializer.Serialize(
                        new { theme = isDarkMode ? "dark" : "light" },
                        new JsonSerializerOptions { WriteIndented = true }));
            }
            catch { }
        }
    }
}