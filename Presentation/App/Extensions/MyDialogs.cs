using System.Windows.Forms;

namespace App.Extensions
{
    public static class MyDialogs
    {
        public static bool Question(string Text)
        {
            return (MessageBox.Show(Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
    }
}
