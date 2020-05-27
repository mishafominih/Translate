using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Translate
{
	public static class ConstructorControls
	{
		private static StringFormat str = new StringFormat();

		public static void WorkWithButton(Button button, Rectangle rec, string text, Form thisForm, Form nextForm)
		{
			CreateButton(button, rec, text, thisForm);
			PaintButton(button);
			CreateForms(nextForm, button, thisForm);
		}

		public static void WorkWithButton(Button button, Rectangle rec, string text, Form thisForm)
		{
			CreateButton(button, rec, text, thisForm);
			PaintButton(button);
		}

		public static void CreateForms(Form form, Button button, Form thisForm)
		{
			button.Click += (a, b) =>
			{
				thisForm.Hide();
				form.Show();
			};
		}

		public static void CreateButton(Button button, Rectangle rec, string text, Form thisForm)
		{
			button.Bounds = rec;
			button.Text = text;
			button.BackColor = Color.Transparent;
			button.ForeColor = Color.White;
			button.Font = GetNewFont();
			thisForm.Controls.Add(button);
		}

		public static Font GetNewFont()
		{
			var fontCollection = new PrivateFontCollection();
			fontCollection.AddFontFile(@"Fonts\MeriendaBold.ttf");
			FontFamily family = fontCollection.Families[0];
			return new Font(family, 15);
		}

		public static void PaintButton(Button button)
		{
			button.Paint += (sender, e) =>
			{
				str.Alignment = StringAlignment.Center;
				str.LineAlignment = StringAlignment.Center;
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.Clear(Color.FromArgb(138, 154, 169));
				var rec = button.ClientRectangle;
				e.Graphics.DrawRectangle(new Pen(button.BackColor), rec);
				e.Graphics.FillRectangle(new SolidBrush(button.BackColor), rec);
				e.Graphics.DrawString(button.Text, button.Font, new SolidBrush(button.ForeColor), rec, str);
				var buttonPath = RoundedRectangle(rec, rec.Height);
				button.Region = new Region(buttonPath);
			};
		}
		
		public static GraphicsPath RoundedRectangle(Rectangle rec, int roundSize)
		{
			var gh = new GraphicsPath();
			
			gh.AddArc(rec.X, rec.Y, roundSize, roundSize, 180, 90);
			gh.AddArc(rec.X + rec.Width - roundSize, rec.Y, roundSize, roundSize, 270, 90);
			gh.AddArc(rec.X + rec.Width - roundSize, rec.Y + rec.Height - roundSize, roundSize, roundSize, 0, 90);
			gh.AddArc(rec.X, rec.Y + rec.Height - roundSize, roundSize, roundSize, 90, 90);

			gh.CloseFigure();

			return gh;
		}

		public static void CreateTextBox(TextBox textBox, int x, int y, Form thisForm, int sizeX, int sizeY)
		{
			textBox.Multiline = true;
			textBox.BackColor = Color.FromArgb(236, 236, 236);
			textBox.Location = new Point(x, y);
			textBox.Size = new Size(sizeX, sizeY);
			thisForm.Controls.Add(textBox);
		}
	}
}
