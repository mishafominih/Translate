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
        }
    }
}
