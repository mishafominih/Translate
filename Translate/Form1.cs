using System.Drawing;
using System.Windows.Forms;

namespace Translate
{
	public class Form1 : Form
	{
		public Form1()
		{
			var btn = new Button();
			btn.Location = new Point(50, 50);
			btn.Size = new Size(100, 100);
			btn.Text = "нажми меня)";
			btn.Click += (sender, args) => MessageBox.Show("кнопка была нажата");
			Controls.Add(btn);
		}
	}
}
