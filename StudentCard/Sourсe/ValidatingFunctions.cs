using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentCard.Forms
{
    public class ValidatorFunctions
    {
        public static void SetOptionsForLettersTextBox(KeyPressEventArgs e, IWin32Window control, ToolTip toolType)
        {
            var symbol = e.KeyChar.ToString();

            if (!(Regex.Match(symbol, @"[а-яА-Я]").Success || e.KeyChar == (int)Keys.Back))
            {
                e.Handled = true;
                toolType.Show($"Вводить можно только русские буквы", control);
            }
            else
            {
                toolType.Hide(control);
            }
        }

        public static void SetOptionsForLettersGroupTextBox(KeyPressEventArgs e)
        {
            var symbol = e.KeyChar.ToString();

            if (!(Regex.Match(symbol, @"([а-яА-Я]|[0-9])").Success || e.KeyChar == (int)Keys.Back))
            {
                e.Handled = true;
            }
        }

        public static void UpdateColorOnUpdatingStringTextBox(string text, object sender)
        {
            var newTextBox = (TextBox)sender;

            newTextBox.BackColor = text != "" ? Color.White : Color.DarkGray;
        }

        public static void UpdateColorStringMaskedTextBox(string text, object sender)
        {
            var newMaskedTextBox = (MaskedTextBox) sender;

            newMaskedTextBox.BackColor = text != "" && newMaskedTextBox.MaskCompleted  ? Color.White : Color.DarkGray;
        }
    }
}