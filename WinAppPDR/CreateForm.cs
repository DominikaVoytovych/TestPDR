using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WinAppPDR
{
    public partial class CreateForm : Form
    {
        private bool isDarkMode = true;
        private string configPath = "appsettings.json";
        private string testsFolder = Path.Combine(Application.StartupPath, "Tests");

        // список питань, які користувач додав під час поточного сеансу створення тесту
        private List<QuestionData> pendingQuestions = new List<QuestionData>();

        public CreateForm()
        {
            InitializeComponent();
            LoadSettings();
            ApplyTheme();
            UpdateQuestionCounter();
        }

        // додаю нове питання до поточного тесту (зберігаю в пам'яті, а не одразу в файл)
        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text) ||
                string.IsNullOrWhiteSpace(txtOptions.Text) ||
                string.IsNullOrWhiteSpace(txtCorrectIndex.Text))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Увага");
                return;
            }

            if (!int.TryParse(txtCorrectIndex.Text.Trim(), out int correctIdx))
            {
                MessageBox.Show("Індекс правильної відповіді має бути числом.", "Помилка");
                return;
            }

            string[] options = txtOptions.Text.Split(',');
            if (correctIdx < 0 || correctIdx >= options.Length)
            {
                MessageBox.Show($"Індекс має бути від 0 до {options.Length - 1}.", "Помилка");
                return;
            }

            pendingQuestions.Add(new QuestionData
            {
                Text = txtQuestion.Text.Trim(),
                Options = options,
                CorrectIndex = correctIdx,
                ImagePath = ""
            });

            txtQuestion.Clear();
            txtOptions.Clear();
            txtCorrectIndex.Clear();
            txtQuestion.Focus();
            UpdateQuestionCounter();

            MessageBox.Show($"Питання #{pendingQuestions.Count} додано.", "Успіх");
        }

        // зберігаю тест у файл
        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (pendingQuestions.Count == 0)
            {
                MessageBox.Show("Додайте хоча б одне питання перед збереженням.", "Увага");
                return;
            }

            string testName = txtTestName.Text.Trim();
            if (string.IsNullOrWhiteSpace(testName))
            {
                MessageBox.Show("Будь ласка, введіть назву тесту.", "Увага");
                return;
            }

            // замінюю недопустимі символи в назві файлу на підкреслення
            foreach (char c in Path.GetInvalidFileNameChars())
                testName = testName.Replace(c, '_');

            if (!Directory.Exists(testsFolder))
                Directory.CreateDirectory(testsFolder);

            string filePath = Path.Combine(testsFolder, testName + ".json");

            var testFile = new TestFile
            {
                TestName = testName,
                Questions = pendingQuestions
            };

            try
            {
                File.WriteAllText(filePath,
                    JsonSerializer.Serialize(testFile,
                        new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));

                MessageBox.Show($"Тест «{testName}» збережено ({pendingQuestions.Count} питань).", "Успіх");
                pendingQuestions.Clear();
                txtTestName.Clear();
                UpdateQuestionCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message, "Помилка");
            }
        }

        // оновлюю лічильник питань на формі
        private void UpdateQuestionCounter()
        {
            lblCounter.Text = $"Питань у тесті: {pendingQuestions.Count}";
        }

        //---зміна теми---
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme()
        {
            this.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.WhiteSmoke;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.White;
                    txt.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                    btn.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
                else if (ctrl is Label lbl)
                    lbl.ForeColor = isDarkMode ? Color.White : Color.Black;
            }

            btnSaveTest.BackColor = Color.FromArgb(46, 160, 95);
            btnSaveTest.ForeColor = Color.White;
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