using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Translate
{
	public class Menu : Form
	{
		public Menu()
		{
			ClientSize = new Size(1280, 720);
			BackgroundImage = Image.FromFile(new DirectoryInfo("Images") + @"\Menu.jpg");
			Initialize();
		}

		private void Initialize()
		{
			var lite = new Button();
			var pro = new Button();
			ConstructorControls.WorkWithButton(lite, new Rectangle(361, 485, 241, 49), "lite", this, new LiteTranslate());
			ConstructorControls.WorkWithButton(pro, new Rectangle(676, 485, 241, 49), "pro", this, new ProMenu());
			Controls.Add(lite);
			Controls.Add(pro);
		}
	}
}
