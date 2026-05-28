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
        private List<QuestionData> questions = new List<QuestionData>();
        private int currentId = -1;
        private int errorsCount = 0;
        private int answeredCount = 0;
        private bool[] isAnswered = new bool[20];
        private bool isDarkMode = true; // За замовчуванням темна
        private string configPath = "appsettings.json";

        public QuestionForm()
        {
            InitializeComponent();
            LoadAllQuestions();
            LoadSettings();
            ApplyTheme();
            this.Load += QuestionForm_Load;
        }

        
        //питання
        private void LoadAllQuestions()
        {
            // питання та варіанти відповідей для 20 питань, зображення для деяких питань
            questions.Add(new QuestionData { Text = "Кому може передавати керування власник ТЗ?", 
                Options = new string[] { "Будь-кому", "Особі з посвідченням відповідної категорії", "Тільки родичу" }, 
                CorrectIndex = 1, ImagePath = "" });
            questions.Add(new QuestionData { Text = "На яких ТЗ встановлюється цей знак?", 
                Options = new string[] { "Глухі водії", "Інваліди", "Навчальні ТЗ" }, 
                CorrectIndex = 0, ImagePath = "q2.jpg" });
            questions.Add(new QuestionData { Text = "Який із зображених дорожніх знаків попереджає про наближення до ділянки (місця) концентрації дорожньо-транспортних пригод?", 
                Options = new string[] { "Знак 1", "Знак 2", "Знак 3" }, 
                CorrectIndex = 0, ImagePath = "q3.jpg" });
            questions.Add(new QuestionData { Text = "Чи дозволено Вам стоянку в зазначеному місці?", 
                Options = new string[] { "Так", "Ні", "Залежить від часу" }, 
                CorrectIndex = 1, ImagePath = "q4.jpg" });
            questions.Add(new QuestionData { Text = "Вночі, коли Ви наближаєтеся до зустрічного транспортного засобу, Ви увімкнете фари дальнього світла, щоб Ваш автомобіль було краще видно:", 
                Options = new string[] { "Так", "Ні", "Залежить від умов" }, 
                CorrectIndex = 1, ImagePath = "q5.jpg" });
            questions.Add(new QuestionData { Text = "Чи дозволено автомобілю виконати виїзд на трамвайну колію попутного напрямку?", 
                Options = new string[] { "Так", "Ні", "Залежить від умов" }, 
                CorrectIndex = 1, ImagePath = "q6.jpg" });
            questions.Add(new QuestionData { Text = "Чи дозволено водієві сірого автомобіля виконати обгін білого?", 
                Options = new string[] { "Так", "Ні", "Залежить від умов" }, 
                CorrectIndex = 1, ImagePath = "q7.jpg" });
            questions.Add(new QuestionData { Text = "Яким транспортним засобам дозволено рух по смузі для маршрутних транспортних засобів у даній ситуації?", Options = new string[] { "Так", "Ні", "Залежить від умов" }, CorrectIndex = 1, ImagePath = "q8.jpg" });
            questions.Add(new QuestionData { Text = "Проїжджаючи дане перехрестя, Ви повинні:", 
                Options = new string[] { "Варіант 1", "Варіант 2", "Варіант 3" }, 
                CorrectIndex = 0, ImagePath = "q9.jpg" });
            questions.Add(new QuestionData { Text = "Як повинен вчинити водій синього автомобіля в даній ситуації?", 
                Options = new string[] { "Варіант 1", "Варіант 2", "Варіант 3" }, 
                CorrectIndex = 0, ImagePath = "q10.jpg" });
            questions.Add(new QuestionData { Text = "Чи дозволений розворот у технологічних розривах розділювальної смуги на автомагістралі?", 
                Options = new string[] { "Дозволений, якщо дорога добре проглядається", "Дозволений", "Заборонений" }, 
                CorrectIndex = 2, ImagePath = "q11.jpg" });
            questions.Add(new QuestionData { Text = "Яким способом дозволено виконувати буксирування транспортних засобів під час ожеледиці?", 
                Options = new string[] { "На жорсткому зчепленні або часткового навантаження", "Тільки на гнучкому", "Тільки на жорсткому", "Тільки частковим навантаженням" }, 
                CorrectIndex = 0, ImagePath = "" });
            questions.Add(new QuestionData { Text = "При наявності стороннього тіла в рані необхідно:", 
                Options = new string[] { "Вийняти стороннє тіло і накласти пов'язку", "Зафіксувати, якщо виступає >5 см", "Накласти пов'язку, не виймаючи стороннього тіла" }, 
                CorrectIndex = 2, ImagePath = "" });
            questions.Add(new QuestionData { Text = "У якому випадку вам дозволяється експлуатація легкового автомобіля?", 
                Options = new string[] { "Не працює спідометр", "Не працює покажчик температури", "Не працюють замки дверей" }, 
                CorrectIndex = 1, ImagePath = "" });
            questions.Add(new QuestionData { Text = "Щоб керувати транспортним засобом безпечно, потрібно:", 
                Options = new string[] { "Просити пасажирів стежити", "Дивитися тільки вперед", "Постійно оцінювати дорожню обстановку" }, 
                CorrectIndex = 2, ImagePath = "q15.jpg" });
            questions.Add(new QuestionData { Text = "Умови використання Європротоколу:", 
                Options = new string[] { "Наявність страхового поліса в одного з водіїв", "Наявність полісів у обох водіїв", "Наявність полісів або посвідчення УБД", "Всі твердження вірні" }, 
                CorrectIndex = 3, ImagePath = "" });
            questions.Add(new QuestionData { Text = "Чи призначена пішохідна доріжка для осіб у кріслах колісних без двигуна?", 
                Options = new string[] { "Так, призначена", "Ні, не призначена" }, 
                CorrectIndex = 0, ImagePath = "" });
            questions.Add(new QuestionData { Text = "У транспортному потоці найбезпечніше рухатися зі швидкістю:", 
                Options = new string[] { "Вище потоку", "Нижче потоку", "Рівній швидкості потоку" }, 
                CorrectIndex = 2, ImagePath = "" });
            questions.Add(new QuestionData { Text = "Як має рухатися ТЗ на дорозі з двома і більше смугами?", 
                Options = new string[] { "Продовжувати рух по тій самій смузі", "У будь-якій смузі на розсуд", "Янайближче до правого краю" }, 
                CorrectIndex = 0, ImagePath = "" });
            questions.Add(new QuestionData { Text = "Яка необхідна умова при огляді на стан сп'яніння на місці?", 
                Options = new string[] { "Два свідки та поліцейський", "Присутність двох свідків", "Присутність одного понятого", "Присутність двох поліцейських" }, 
                CorrectIndex = 1, ImagePath = "" });
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            //створюю 20 кнопок для питань з дизацном та розташуванням
            for (int i = 0; i < 20; i++)
            {
                Button btn = new Button();
                btn.Name = "btnTemp" + (i + 1);
                btn.Text = (i + 1).ToString();
                btn.Size = new Size(40, 40);
                btn.Location = new Point(20 + i * 50, 30);
                btn.BackColor = Color.FromArgb(60, 60, 60);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += btnTemp_Click;
                gpListAnswers.Controls.Add(btn);
            }
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            //визначаю індекс питання та відображаю його вміст
            Button btn = sender as Button; 
            int index = int.Parse(btn.Text) - 1;

            //якщо на питання вже відповіли, не дозволяємо до нього повернутись
            if (isAnswered[index]) return;
            currentId = index;

            //цикл проходжусь по всії кнопках та скидаю виділення, окрім тих, що вже відповіли
            foreach (Control c in gpListAnswers.Controls)
            {
                if (c is Button b && b.BackColor != Color.Green && b.BackColor != Color.Red) //залишаю чероні та зелені питання без змін
                    b.BackColor = Color.FromArgb(60, 60, 60); //інший сірий колір для остальних питань, на які ще не відповіли
            }
            btn.BackColor = Color.FromArgb(0, 120, 215); // синій колір для виділення поточного питання

            var q = questions[currentId]; //отримую дані поточного питання та відображаю їх
            lblQuestion.Text = $"Питання №{currentId + 1}: {q.Text}"; //перевіряю наявність зображення для питання та відображаю його, якщо є

            string path = Path.Combine(Application.StartupPath, "images", q.ImagePath); //питання в папці images, якщо є
            bool hasImage = !string.IsNullOrEmpty(q.ImagePath) && File.Exists(path); //перевірка на наявність фото

            //якщо зображення є - показую, нема - приховую
            if (hasImage)
            {
                pbImage.Visible = true;
                pbImage.ImageLocation = path;
                pnlOptions.Location = new Point(550, 230);
            }
            else
            {
                pbImage.Visible = false;
                pnlOptions.Location = new Point(250, 230);
            }

            //очищую панель з варантами та створюю нові
            pnlOptions.Controls.Clear(); 
            btnSubmit.Visible = false;

            //створюю радіокнопки для варіантів відповідей
            for (int i = 0; i < q.Options.Length; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Text = q.Options[i];
                rb.ForeColor = Color.White;
                rb.Font = new Font("Segoe UI", 12F);
                rb.AutoSize = true;
                rb.Name = "rb" + i;

                rb.Location = new Point(20, 20 + i * 50);

                rb.Click += (s, ev) => { btnSubmit.Visible = true; };

                pnlOptions.Controls.Add(rb);

                ApplyTheme(); // застосовую тему до нових радіокнопок
            }
        }

        //відповісти
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //визначаю вибрану радіокнопку та перевіряю правильність відповіді
            var selectedRb = pnlOptions.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            int selectedIndex = int.Parse(selectedRb.Name.Replace("rb", ""));
            bool isCorrect = (selectedIndex == questions[currentId].CorrectIndex);

            // оновлюю статистику
            isAnswered[currentId] = true;
            answeredCount++;
            if (!isCorrect) errorsCount++;

            // візуально блокуємо кнопку питання
            var btn = gpListAnswers.Controls.Find("btnTemp" + (currentId + 1), true).FirstOrDefault() as Button;
            btn.BackColor = isCorrect ? Color.Green : Color.Red;
            btn.Enabled = false; // вимикаю клікабельність

            // перевірка завершення тесту
            if (answeredCount == 20)
            {
                ShowFinalResult();
            }
            else
            {
                // автоперехід до наступного  питання
                var nextBtn = gpListAnswers.Controls.Find("btnTemp" + (currentId + 2), true).FirstOrDefault() as Button;
                if (nextBtn != null) btnTemp_Click(nextBtn, EventArgs.Empty);
            }
        }

        //результати
        private void ShowFinalResult()
        {
            //якщо менше або 2 помилки, то все гуд я пройшла, більше - провал і на другиц рік
            string message = errorsCount <= 2
                ? $"Вітаємо! Ви склали іспит. Помилок: {errorsCount}"
                : $"Іспит не складено. Помилок: {errorsCount}. Максимум дозволено 2.";

            MessageBox.Show(message, "Результати іспиту");
            this.Close(); // закриваю форму після іспиту
        }
        private void BtnSkip_Click(object sender, EventArgs e)
        {
            // пропускаю до наступного питання
            if (currentId < 19)
            {
                var nextBtn = gpListAnswers.Controls.Find("btnTemp" + (currentId + 2), true).FirstOrDefault() as Button;
                if (nextBtn != null) btnTemp_Click(nextBtn, EventArgs.Empty);
            }
        }

        //Зміна теми
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme()
        {
            // фон форми та основний текст
            this.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : Color.WhiteSmoke;
            this.ForeColor = isDarkMode ? Color.White : Color.Black;

            void PaintControl(Control parent)
            {
                foreach (Control ctrl in parent.Controls)
                {
                    // радіобатони та лейбли отримують колір тексту
                    if (ctrl is Label || ctrl is RadioButton)
                    {
                        ctrl.ForeColor = isDarkMode ? Color.White : Color.Black;
                    }
                    // кнопки питань (крім тих, що вже мають результат)
                    else if (ctrl is Button btn)
                    {
                        // якщо це кнопка "Обрати", залишаємо її колір
                        if (btn == btnSubmit)
                        {
                            btn.BackColor = Color.FromArgb(46, 160, 95);
                            btn.ForeColor = Color.White;
                        }
                        // інакше фарбуємо як звичайну кнопку
                        else if (btn.BackColor != Color.Green && btn.BackColor != Color.Red && btn.BackColor != Color.FromArgb(0, 120, 215))
                        {
                            btn.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                            btn.ForeColor = isDarkMode ? Color.White : Color.Black;
                        }
                    }
                    // груповий бокс
                    else if (ctrl is GroupBox gb)
                    {
                        gb.ForeColor = isDarkMode ? Color.White : Color.Black;
                    }

                    PaintControl(ctrl);
                }
            }

            PaintControl(this);
            btnChangeStyles.Text = isDarkMode ? "Світла тема" : "Темна тема";
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(configPath))
                {
                    string jsonString = File.ReadAllText(configPath);
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        isDarkMode = (doc.RootElement.GetProperty("theme").GetString() == "dark");
                    }
                }
            }
            catch { }
        }

        private void SaveSettings()
        {
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" };
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, jsonString);
            }
            catch { }
        }
    }
}
