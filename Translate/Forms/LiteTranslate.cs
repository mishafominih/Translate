using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Translate
{
    public partial class LiteTranslate : Form
    {
		TextBox inputTextBox;
		TextBox outputTextBox;
		public LiteTranslate()
        {
            ClientSize = new Size(1280, 720);
            BackgroundImage = Image.FromFile(new DirectoryInfo("Images") + @"\LiteTranslate.jpg");
            Initialize();
        }

        private void Initialize()
		{
			var buttonTranslate = new Button();
            var back = new Button();
            ConstructorControls.CreateButton(back, new Rectangle(10, 50, 43, 36), "", this);
            AddClick(back);
            ConstructorControls.WorkWithButton(buttonTranslate, new Rectangle(500, 132, 300, 49), "Translate", this);
			buttonTranslate.Click += (e, a) =>
			{
				outputTextBox.Text = TranslateText.GetTextTranslation(inputTextBox.Text);
			};
            Controls.Add(buttonTranslate);

            inputTextBox = new TextBox();
            outputTextBox = new TextBox();
            ConstructorControls.CreateTextBox(inputTextBox, 107, 204, this, 500, 411);
            ConstructorControls.CreateTextBox(outputTextBox, 691, 204, this, 500, 411);
        }
        private void AddClick(Button button)
        {
            button.Click += (sender, e) =>
            {
                var form = new Menu();
                Hide();
                form.Show();
            };
        }
    }
}
