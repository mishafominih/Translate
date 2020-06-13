using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Translate
{
    public partial class AddNewWord : Form
    {
        public AddNewWord()
        {
            ClientSize = new Size(1280, 720);
            BackgroundImage = Image.FromFile(new DirectoryInfo("Images") + @"\AddWord.jpg");
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var addWord = new Button();
            var rec = new Rectangle(560, 138, 64, 54);
            addWord.BackColor = Color.FromArgb(199, 214, 219);
            var wordTextBox = new TextBox();
            var translateTextBox = new TextBox();
            var backButton = new Button();
			ConstructorControls.WorkWithButton(addWord, rec, "добавить", this);
			addWord.Click += (e, a) =>
			{
				Translator.KnownWords.Add(wordTextBox.Text, translateTextBox.Text);
			};
			ConstructorControls.CreateButton(backButton, new Rectangle(15, 50, 41, 36), "", this);
            AddClick(backButton);
            ConstructorControls.CreateTextBox(translateTextBox, 135, 285, this, 475, 224);
            ConstructorControls.CreateTextBox(wordTextBox, 136, 138, this, 402, 54);
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
