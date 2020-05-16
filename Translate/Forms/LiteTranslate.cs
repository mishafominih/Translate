using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			MyButton.WorkWithButton(buttonTranslate, new Rectangle(500, 132, 300, 49), "Перевести", this);
			buttonTranslate.Click += (e, a) =>
			{
				outputTextBox.Text = TranslateText.GetTextTranslation(inputTextBox.Text);
			};

			inputTextBox = new TextBox();
            outputTextBox = new TextBox();
            CreateTextBox(inputTextBox, 107, 204);
            CreateTextBox(outputTextBox, 691, 204);
        }

        private void CreateTextBox(TextBox textBox, int x, int y)
        {
            textBox.Multiline = true;
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(500, 411);
            Controls.Add(textBox);
        }
    }
}
