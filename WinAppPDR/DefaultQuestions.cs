using System.Collections.Generic;

namespace WinAppPDR
{
    // Keeps the 20 hardcoded questions separate from UI logic.
    public static class DefaultQuestions
    {
        public static List<QuestionData> Load() => new List<QuestionData>
        {
            new QuestionData {
                Text = "Кому може передавати керування власник ТЗ?",
                Options = new[] { "Будь-кому", "Особі з посвідченням відповідної категорії", "Тільки родичу" },
                CorrectIndex = 1, ImagePath = "" },
            new QuestionData {
                Text = "На яких ТЗ встановлюється цей знак?",
                Options = new[] { "Глухі водії", "Інваліди", "Навчальні ТЗ" },
                CorrectIndex = 0, ImagePath = "q2.jpg" },
            new QuestionData {
                Text = "Який із зображених дорожніх знаків попереджає про наближення до ділянки концентрації ДТП?",
                Options = new[] { "Знак 1", "Знак 2", "Знак 3" },
                CorrectIndex = 0, ImagePath = "q3.jpg" },
            new QuestionData {
                Text = "Чи дозволено Вам стоянку в зазначеному місці?",
                Options = new[] { "Так", "Ні", "Залежить від часу" },
                CorrectIndex = 1, ImagePath = "q4.jpg" },
            new QuestionData {
                Text = "Вночі під час зустрічного роз'їзду чи варто вмикати дальнє світло?",
                Options = new[] { "Так", "Ні", "Залежить від умов" },
                CorrectIndex = 1, ImagePath = "q5.jpg" },
            new QuestionData {
                Text = "Чи дозволено виїзд на трамвайну колію попутного напрямку?",
                Options = new[] { "Так", "Ні", "Залежить від умов" },
                CorrectIndex = 1, ImagePath = "q6.jpg" },
            new QuestionData {
                Text = "Чи дозволено водієві сірого авто обігнати біле?",
                Options = new[] { "Так", "Ні", "Залежить від умов" },
                CorrectIndex = 1, ImagePath = "q7.jpg" },
            new QuestionData {
                Text = "Яким ТЗ дозволено рух по смузі для маршрутних ТЗ?",
                Options = new[] { "Так", "Ні", "Залежить від умов" },
                CorrectIndex = 1, ImagePath = "q8.jpg" },
            new QuestionData {
                Text = "Проїжджаючи дане перехрестя, Ви повинні:",
                Options = new[] { "Варіант 1", "Варіант 2", "Варіант 3" },
                CorrectIndex = 0, ImagePath = "q9.jpg" },
            new QuestionData {
                Text = "Як повинен вчинити водій синього авто в даній ситуації?",
                Options = new[] { "Варіант 1", "Варіант 2", "Варіант 3" },
                CorrectIndex = 0, ImagePath = "q10.jpg" },
            new QuestionData {
                Text = "Чи дозволений розворот у технологічних розривах розділювальної смуги на автомагістралі?",
                Options = new[] { "Дозволений, якщо дорога добре проглядається", "Дозволений", "Заборонений" },
                CorrectIndex = 2, ImagePath = "q11.jpg" },
            new QuestionData {
                Text = "Яким способом дозволено буксирування ТЗ під час ожеледиці?",
                Options = new[] { "На жорсткому зчепленні або часткового навантаження", "Тільки на гнучкому", "Тільки на жорсткому", "Тільки частковим навантаженням" },
                CorrectIndex = 0, ImagePath = "" },
            new QuestionData {
                Text = "При наявності стороннього тіла в рані необхідно:",
                Options = new[] { "Вийняти стороннє тіло і накласти пов'язку", "Зафіксувати, якщо виступає >5 см", "Накласти пов'язку, не виймаючи стороннього тіла" },
                CorrectIndex = 2, ImagePath = "" },
            new QuestionData {
                Text = "У якому випадку вам дозволяється експлуатація легкового авто?",
                Options = new[] { "Не працює спідометр", "Не працює покажчик температури", "Не працюють замки дверей" },
                CorrectIndex = 1, ImagePath = "" },
            new QuestionData {
                Text = "Щоб керувати ТЗ безпечно, потрібно:",
                Options = new[] { "Просити пасажирів стежити", "Дивитися тільки вперед", "Постійно оцінювати дорожню обстановку" },
                CorrectIndex = 2, ImagePath = "q15.jpg" },
            new QuestionData {
                Text = "Умови використання Європротоколу:",
                Options = new[] { "Страховий поліс в одного з водіїв", "Поліси в обох водіїв", "Поліси або посвідчення УБД", "Всі твердження вірні" },
                CorrectIndex = 3, ImagePath = "" },
            new QuestionData {
                Text = "Чи призначена пішохідна доріжка для осіб у кріслах колісних без двигуна?",
                Options = new[] { "Так, призначена", "Ні, не призначена" },
                CorrectIndex = 0, ImagePath = "" },
            new QuestionData {
                Text = "У транспортному потоці найбезпечніше рухатися зі швидкістю:",
                Options = new[] { "Вище потоку", "Нижче потоку", "Рівній швидкості потоку" },
                CorrectIndex = 2, ImagePath = "" },
            new QuestionData {
                Text = "Як має рухатися ТЗ на дорозі з двома і більше смугами?",
                Options = new[] { "Продовжувати рух по тій самій смузі", "У будь-якій смузі на розсуд", "Якнайближче до правого краю" },
                CorrectIndex = 0, ImagePath = "" },
            new QuestionData {
                Text = "Яка необхідна умова при огляді на стан сп'яніння на місці?",
                Options = new[] { "Два свідки та поліцейський", "Присутність двох свідків", "Присутність одного понятого", "Присутність двох поліцейських" },
                CorrectIndex = 1, ImagePath = "" },
        };
    }
}