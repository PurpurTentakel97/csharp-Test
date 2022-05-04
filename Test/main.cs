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
			var list1 = new List();

			list1.Add("a",5);
			list1.Add("b");
			list1.Add("c");
			list1.Add("d");
			Console.WriteLine(list1.Print());

			var list2 = new List();
			list2.Add("1");
			list2.Add("2");
			list2.Add("3");
			list2.Add("4");
			Console.WriteLine(list2.Print());

			var list3 = list1 + list2;
			Console.WriteLine(list3.Print());

			list3.Replace("123",7);
			list3.Replace("456",9);
			list3.Replace("789",11);
			Console.WriteLine(list3.Print());

			list3.Replace("abc", "a");
			Console.WriteLine(list3.Print());
		}

	}
}