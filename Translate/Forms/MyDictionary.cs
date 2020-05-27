using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Translate
{
    public partial class MyDictionary : Form
    {
        public MyDictionary()
        {
            ClientSize = new Size(1280, 720);
            BackgroundImage = Image.FromFile(new DirectoryInfo("Images") + @"\Dictionary.jpg");
            Initialize();
        }

        private void Initialize()
        {
            var checkWord = new Button();
            var rec = new Rectangle(560, 138, 64, 54);
            var back = new Button();
            var textBox1 = new TextBox();
            var textBox2 = new TextBox();
            var textBox3 = new TextBox();
            var enterWord = new TextBox();
            ConstructorControls.CreateTextBox(enterWord, 130, 140, this, 410, 50);
            ConstructorControls.CreateTextBox(textBox1, 740, 145, this, 427, 107);
            ConstructorControls.CreateTextBox(textBox2, 740, 318, this, 427, 107);
            ConstructorControls.CreateTextBox(textBox3, 740, 490, this, 427, 107);
            ConstructorControls.CreateButton(back, new Rectangle(10, 50, 41, 36), "", this);
            ConstructorControls.WorkWithButton(checkWord, rec, "enter", this);
            checkWord.BackColor = Color.FromArgb(199, 214, 219);
            AddClick(back);
        }

        private void AddClick(Button button)
        {
            button.Click += (sender, e) =>
            {
                var form = new ProMenu();
                Hide();
                form.Show();
            };
        }
    }
}
