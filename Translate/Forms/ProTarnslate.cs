using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Translate
{
    public partial class ProTarnslate : Form
    {
        public ProTarnslate()
        {
            ClientSize = new Size(1280, 720);
            BackgroundImage = Image.FromFile(new DirectoryInfo("Images") + @"\ProTranslate.jpg");
            Initialize();
        }

        private void Initialize()
        {
            var inputTextBox = new TextBox();
            var outputTextBox = new TextBox();
            var back = new Button();
            ConstructorControls.CreateButton(back, new Rectangle(10, 45, 41, 36), "", this);
            AddClick(back);
            ConstructorControls.CreateTextBox(inputTextBox, 99, 148, this, 449, 480);
            ConstructorControls.CreateTextBox(outputTextBox, 559, 148, this, 449, 480);
        }

        private void AddClick(Button button)
        {
            button.Click += (a, b) =>
            {
                var form = new ProMenu();
                Hide();
                form.Show();
            };
        }
    }
}
