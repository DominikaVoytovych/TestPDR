using System.Collections.Generic;

namespace WinAppPDR
{
    public class QuestionData
    {
        public string Text { get; set; } = "";
        public string[] Options { get; set; } = new string[0];
        public int CorrectIndex { get; set; }
        public string ImagePath { get; set; } = "";
    }

    // Wraps a full test file saved to /Tests
    public class TestFile
    {
        public string TestName { get; set; } = "Custom Test";
        public List<QuestionData> Questions { get; set; } = new List<QuestionData>();
    }
}