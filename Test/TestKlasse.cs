using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	internal class TestKlasse
	{
		public static int number = 10;
		public string word;

		public TestKlasse(string word)
		{
			this.word = word;
		}

		public void Print()
		{
			Console.WriteLine(number);
			for (int i = 0; i < number; i++)
			{
				Console.WriteLine(word + " " + (i + 1).ToString());
			}
		}
	}
}


