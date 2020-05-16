using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Translate
{
	public static class MyButton
	{
		private static StringFormat str = new StringFormat();

		public static void WorkWithButton(Button button, Rectangle rec, string text, Form thisForm, Form nextForm)
		{
			CreateButton(button, rec, text, thisForm);
			PaintButton(button);
			CreateForms(nextForm, button, thisForm);
		}

		private static void CreateForms(Form form, Button button, Form thisForm)
		{
			button.Click += (a, b) =>
			{
				form.Show();
				thisForm.Hide();
			};
		}

		private static void CreateButton(Button button, Rectangle rec, string text, Form thisForm)
		{
			button.Bounds = rec;
			button.Text = text;
			button.BackColor = Color.FromArgb(138, 154, 169);
			button.ForeColor = Color.White;
			button.Font = GetNewFont();
			thisForm.Controls.Add(button);
		}

		private static Font GetNewFont()
		{
			var fontCollection = new PrivateFontCollection();
			fontCollection.AddFontFile(@"Fonts\MeriendaBold.ttf");
			FontFamily family = fontCollection.Families[0];
			return new Font(family, 15);
		}

		private static void PaintButton(Button button)
		{
			button.Paint += (sender, e) =>
			{
				str.Alignment = StringAlignment.Center;
				str.LineAlignment = StringAlignment.Center;
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.Clear(Color.FromArgb(197, 212, 217));
				var rec = button.ClientRectangle;
				e.Graphics.DrawRectangle(new Pen(button.BackColor), rec);
				e.Graphics.FillRectangle(new SolidBrush(button.BackColor), rec);
				e.Graphics.DrawString(button.Text, button.Font, new SolidBrush(button.ForeColor), rec, str);
				var buttonPath = RoundedRectangle(rec, rec.Height);
				button.Region = new Region(buttonPath);
			};
		}
		
		private static GraphicsPath RoundedRectangle(Rectangle rec, int roundSize)
		{
			var gh = new GraphicsPath();
			
			gh.AddArc(rec.X, rec.Y, roundSize, roundSize, 180, 90);
			gh.AddArc(rec.X + rec.Width - roundSize, rec.Y, roundSize, roundSize, 270, 90);
			gh.AddArc(rec.X + rec.Width - roundSize, rec.Y + rec.Height - roundSize, roundSize, roundSize, 0, 90);
			gh.AddArc(rec.X, rec.Y + rec.Height - roundSize, roundSize, roundSize, 90, 90);

			gh.CloseFigure();

			return gh;
		}

	}
}
