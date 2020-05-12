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
            CreateTextBox(inputTextBox, 99, 148);
            CreateTextBox(outputTextBox, 559, 148);
        }

        private void CreateTextBox(TextBox textBox, int x, int y)
        {
            textBox.Multiline = true;
            textBox.BackColor = Color.FromArgb(236, 236, 236);
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(449, 480);
            Controls.Add(textBox);
        }
    }
}
