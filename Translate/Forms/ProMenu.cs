using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MyButton.WorkWithButton(checkYourself, new Rectangle(467, 266, 344, 49), "check yourself", this, new ProTarnslate());
            MyButton.WorkWithButton(dictionary, new Rectangle(519, 359, 240, 49), "dictionary", this, new MyDictionary());
            MyButton.WorkWithButton(addNewWord, new Rectangle(467, 451, 344, 49), "add a word", this, new AddNewWord());
        }
    }
}
