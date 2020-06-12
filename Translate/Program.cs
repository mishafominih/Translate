using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translate
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Translator.LoadDictionaryFrom("Dictionary.txt");
			Application.Run(new Menu());
		}
	}
}
