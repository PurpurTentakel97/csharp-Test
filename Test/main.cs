// Purpur Tentakel
// 02.05.2022
// Test - Main
// C# v. 10.0

namespace Test
{

	class Program
	{
		static void Main(string[] args)
		{
			var strings = new string[] { "a","b","c","d","e"};
			var list1 = new List(strings);

			list1.Add("f",5);
			list1.Print();
			PrintBreak();


			var strings2 = new string[] { "1","2","3","4","5"};
			var list2 = new List(strings2);
			list2.Print();
			PrintBreak();

			var list3 = new List();
			list3.Add("blub");
			list3.Print();
			PrintBreak();

			var list4 = list1 + list2 + list3;
			list4.Print();

			list4.Replace("123",7);
			list4.Replace("456",9);
			list4.Replace("789",11);
			list4.Print();

			list4.Replace("abc", "f");
			list4.Print();
			PrintBreak();

			var list5 = list4.Slice(3, 6);
			list5.Print();
			PrintBreak();
		}


		private static void PrintBreak()
		{
			Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
		}

	}
}