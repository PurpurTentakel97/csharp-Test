// Purpur Tentakel
// 02.05.2022
// Test - Main
// C# v. 10.0

using System.Collections.Generic;
using Lists;

namespace Test
{

	class Program
	{
		static void Main(string[] args)
		{
			var list1 = new LinkedList();
			list1.Print();
			Console.WriteLine(list1.Count);
			PrintBreak();


			var list2 = new LinkedList("a",3);
			list2.Add("b",3);
			list2.Print();
			Console.WriteLine(list2.Count);
			Console.WriteLine(list2.Get(3));

			var entry = new string[] { "1", "2", "3", "4", "5", "5", "5" };
			list2.Add(entry);
			list2.Print();
			Console.WriteLine(list2.Count);
			Console.WriteLine(list2.Get("5"));
			PrintBreak();

			var list3 = new LinkedList(entry);
			list3.Print();
			Console.WriteLine(list3.Count);
			Console.WriteLine(list3.Pop(3));
			list3.Print();
			Console.WriteLine(list3.Count);
			Console.WriteLine(list3.Pop("1"));
			list3.Print();
			Console.WriteLine(list3.Count);
			PrintBreak();

			var list4 = new LinkedList(entry);
			list4.Delete(3);
			list4.Print();
			Console.WriteLine(list4.Count);
			list4.Delete("1");
			list4.Print();
			Console.WriteLine(list4.Count);
			PrintBreak();

			var list5 = new LinkedList(entry);
			list5.Print();
			list5.Replace("1", 1);
			list5.Print();
			Console.WriteLine(list5.Count);
			list5.Replace("1", "5");
			list5.Print();
			Console.WriteLine(list5.Count);
			PrintBreak();

			var list6 = list5.Slice(3, 6);
			list6.Print();
			Console.WriteLine(list6.Count);
			PrintBreak();

			var list7 = list5 + list6;
			list7.Print();
			Console.WriteLine(list7.Count);


		}

		private static void PrintBreak()
		{
			Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
		}

	}
}