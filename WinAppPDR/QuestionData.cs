public struct QuestionData
{
    public string Text;
    public string ImagePath;
    public string[] Options; // Масив варіантів відповідей
    public int CorrectIndex;  // Індекс правильної відповіді (0, 1 або 2)
    public Color ButtonColor; // Зберігаємо стан кнопки тут
    public int? SelectedOption; // Який варіант обрав користувач
}