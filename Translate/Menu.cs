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
			CreateButton(lite, new Rectangle(361, 485, 241, 49), "Lite");
			CreateButton(pro, new Rectangle(676, 485, 241, 49), "Pro");
		}

		private void CreateButton(Button button, Rectangle rec, string text)
		{
			button.Bounds = rec;
			button.Text = text;
			button.BackColor = Color.FromArgb(138, 154, 169);
			//button.Font = new Font("Merienda One");
			Controls.Add(button);
		}
	}
}
