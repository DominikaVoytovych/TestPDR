using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WinAppPDR
{
    public partial class SelectionForm : Form
    {
        private bool isDarkMode = true;
        private string configPath = "appsettings.json";
        private string testsFolder = Path.Combine(Application.StartupPath, "Tests");

        public SelectionForm()
        {
            InitializeComponent();
            LoadSettings();
            ApplyTheme();
            PopulateTestList();
        }

        // сканування папки з тестами і заповнення ListBox
        private void PopulateTestList()
        {
            lstTests.Items.Clear();
            if (!Directory.Exists(testsFolder))
                Directory.CreateDirectory(testsFolder);

            foreach (string file in Directory.GetFiles(testsFolder, "*.json"))
            {
                lstTests.Items.Add(Path.GetFileNameWithoutExtension(file));
            }

            btnStartCustom.Enabled = lstTests.Items.Count > 0;
        }

        // старт стандартного тесту з основними закодованими питаннями
        private void btnStartDefault_Click(object sender, EventArgs e)
        {
            var questions = DefaultQuestions.Load();
            LaunchQuestionForm(questions);
        }

        // вибір тесту зі списку, завантаження його вмісту і запуск форми з питаннями
        private void btnStartCustom_Click(object sender, EventArgs e)
        {
            if (lstTests.SelectedIndex < 0)
            {
                MessageBox.Show("Будь ласка, оберіть тест зі списку.", "Увага");
                return;
            }

            string selectedName = lstTests.SelectedItem.ToString();
            string path = Path.Combine(testsFolder, selectedName + ".json");

            try
            {
                string json = File.ReadAllText(path);
                var testFile = JsonSerializer.Deserialize<TestFile>(json);

                if (testFile?.Questions == null || testFile.Questions.Count == 0)
                {
                    MessageBox.Show("Тест не містить питань.", "Помилка");
                    return;
                }

                LaunchQuestionForm(testFile.Questions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося завантажити тест: " + ex.Message, "Помилка");
            }
        }

        //метод для запучку форми з питаннями
        private void LaunchQuestionForm(List<QuestionData> questions)
        {
            this.Hide();
            var form = new QuestionForm(questions);
            form.FormClosed += (s, e) => this.Close();
            form.Show();
        }

        // відкриття форми для створення нового тесту, після закриття якої оновлюється список тестів
        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            var createForm = new CreateForm();
            createForm.FormClosed += (s, e) => PopulateTestList();
            createForm.ShowDialog();
        }

        //----зміна теми----
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

            lstTests.BackColor = isDarkMode ? Color.FromArgb(45, 45, 45) : Color.White;
            lstTests.ForeColor = isDarkMode ? Color.White : Color.Black;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn.BackColor != Color.FromArgb(46, 160, 95)) // preserve green accent
                    {
                        btn.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                        btn.ForeColor = isDarkMode ? Color.White : Color.Black;
                    }
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = isDarkMode ? Color.White : Color.Black;
                }
            }

            btnStartDefault.BackColor = Color.FromArgb(46, 160, 95);
            btnStartDefault.ForeColor = Color.White;
            btnChangeStyles.Text = isDarkMode ? "Світла тема" : "Темна тема";
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("theme", out var t))
                        isDarkMode = t.GetString() == "dark";
                }
            }
            catch { }
        }

        private void SaveSettings()
        {
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" };
                File.WriteAllText(configPath,
                    JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch { }
        }
    }
}