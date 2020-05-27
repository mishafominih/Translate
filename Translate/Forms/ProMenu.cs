using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Translate
{
    public partial class ProMenu : Form
    {
        public ProMenu()
        {
            ClientSize = new Size(1280, 720);
            BackgroundImage = Image.FromFile(new DirectoryInfo("Images") + @"\ProMenu.jpg");
            Initialization();
        }

        private void Initialization()
        {
            var checkYourself = new Button();
            var dictionary = new Button();
            var addNewWord = new Button();
            var back = new Button();

            ConstructorControls.CreateButton(back, new Rectangle(10, 50, 41, 36), "", this);
            ConstructorControls.WorkWithButton(checkYourself, new Rectangle(467, 266, 344, 49), "check yourself", this, new ProTarnslate());
            ConstructorControls.WorkWithButton(dictionary, new Rectangle(519, 359, 240, 49), "dictionary", this, new MyDictionary());
            ConstructorControls.WorkWithButton(addNewWord, new Rectangle(467, 451, 344, 49), "add a word", this, new AddNewWord());
            AddClicl(back);
        }

        private void AddClicl(Button button)
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
