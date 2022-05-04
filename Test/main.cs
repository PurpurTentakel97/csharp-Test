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
			string[] strings = {"a","b","c","d","e"};
			var list1 = new List(strings);

			list1.Add("f",5);
			Console.WriteLine(list1.Print());


			string[] strings2 = {"1","2","3","4","5"};
			var list2 = new List(strings2);
			Console.WriteLine(list2.Print());

			var list3 = new List();
			list3.Add("blub");
			Console.WriteLine(list3.Print());

			var list4 = list1 + list2 + list3;
			Console.WriteLine(list4.Print());

			list4.Replace("123",7);
			list4.Replace("456",9);
			list4.Replace("789",11);
			Console.WriteLine(list4.Print());

			list4.Replace("abc", "f");
			Console.WriteLine(list4.Print());
		}

	}
}