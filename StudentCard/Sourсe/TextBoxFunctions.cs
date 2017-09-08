using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentCard.Forms
{
    public class TextBoxFunctions
    {
        public static void UpdateInputString(object sender)
        {
            var textBox = (TextBox)sender;
            var textboxlenth = textBox.Text.Length;
            if (textBox.Text.Length == 1)
            {
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = textBox.Text.Length;
            }

            if (textBox.Text.Length > 1 && Regex.Match(textBox.Text[0].ToString(), @"[а-я]").Success)
            {
                var upper = textBox.Text[0].ToString().ToUpper();
                textBox.Text = textBox.Text.Remove(0, 1).Insert(0, upper);
            }
        }
    }
}