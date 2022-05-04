using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	public class List
	{
		private Node? first;
		private Node? current;
		private int size;

		public int Count
		{
			get
			{
				return size;
			}
		}


		public List(string[] values)
		{
			size = 0;
			first = null;
			current = null;

			for (int i = 0; i < values.Length; i++)
			{
				Add(values[i]);
			}
		}
		public List(string value)
		{
			size = 0;
			first = null;
			current = null;
			Add(value);
		}
		public List()
		{
			size = 0;
			first = null;
			current = null;
		}

		public void Add(string entry, int count = 1)
		{
			for (int i = 0; i < count; i++)
			{
				size++;
				var node = new Node(entry);

				if (first is null)
				{
					first = node;
					continue;
				}

				current = first;
				while (current.next is not null)
				{
					current = current.next;
				}
				current.next = node;
			}

		}

		public string Get(int index)
		{
			if (index >= size || index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}

			current = first;
			for (int i = 0; i < index; i++)
			{
				current = current.next;
			}

			return current.entry;
		}

		public void Delete(string toDelete)
		{
			if (first is null)
			{
				throw new ArgumentOutOfRangeException("No Nodes");
			}

			size--;

			if (first.entry == toDelete)
			{
				first = first.next;
				return;
			}

			GetAndDeleteEntryFromCurrentNode(toDelete);
		}
		public void Delete(int toDelete)
		{
			if (toDelete >= size || toDelete < 0)
			{
				throw new ArgumentOutOfRangeException("Index out of Range");
			}

			size--;

			if (toDelete == 0)
			{
				first = first.next;
				return;
			}

			GetAndDeleteEntryFromCurrentNode(toDelete);
		}

		public string Pop(string toPop)
		{
			if (first is null)
			{
				throw new ArgumentOutOfRangeException("No Nodes");
			}

			size--;

			if (first.entry == toPop)
			{
				var ret = first.entry;
				first = first.next;
				return ret;
			}
			return GetAndDeleteEntryFromCurrentNode(toPop);
		}
		public string Pop(int toPop)
		{
			if (first is null)
			{
				throw new ArgumentOutOfRangeException("no Nodes");
			}

			size--;

			if (toPop == 0)
			{
				var ret = first.entry;
				first = first.next;
				return ret;
			}

			return GetAndDeleteEntryFromCurrentNode(toPop);

		}

		public void Replace(string value, int toReplace)
		{
			if (toReplace >= size || toReplace < 0)
			{
				throw new ArgumentOutOfRangeException("Index out of Range");
			}

			current = first;
			for (int i = 0; true; i++)
			{
				if (i != toReplace)
				{
					current = current.next;
					continue;
				}
				current.entry = value;
				return;
			}
		}
		public void Replace(string value, string toReplace)
		{
			if (first is null)
			{
				throw new ArgumentOutOfRangeException("No Nodes");
			}

			current = first;
			for (int i = 0; true; i++)
			{
				if (i >= size)
				{
					return;
				}

				if (current.entry != toReplace)
				{
					current = current.next;
					continue;
				}
				current.entry = value;


			}
		}

		public List Slice(int index_u, int index_o)
		{
			if (index_u >= size || index_u < 0)
			{
				throw new ArgumentOutOfRangeException("Index out of Range");
			}
			if (index_o >= size || index_o < 0)
			{
				throw new ArgumentOutOfRangeException("Index out of Range");
			}
			if (index_u > index_o)
			{
				throw new InvalidDataException("lower index is greater upper index");
			}

			var ret = new List();
			current = first;
			for (int i = 0; true; i++)
			{
				if (i < index_u)
				{
					current = current.next;
					continue;
				}
				ret.Add(current.entry);

				if ((i + 1) >= index_o)
				{
					break;
				}

				current = current.next;
			}

			return ret;

		}

		public void Print()
		{
			if (first is null)
			{
				Console.WriteLine(ToString() + " [Empty]");
				return;
			}

			current = first;
			string ret = ToString() + " [";
			while (true)
			{
				ret += current.entry + ",";

				if (current.next is null)
				{
					ret = ret.Remove(ret.Length - 1);
					ret += "]";
					break;
				}
				current = current.next;
			}

			Console.WriteLine(ret);
		}

		private string GetAndDeleteEntryFromCurrentNode(string toPop)
		{
			current = first;
			while (current is not null)
			{
				if (current.entry != toPop)
				{
					current = current.next;
					continue;
				}

				Node bevor = first;
				while (bevor.next != current)
				{
					bevor = bevor.next;
				}

				bevor.next = current.next;
				break;
			}

			if (current == null)
			{
				throw new InvalidOperationException("Not Found");
			}

			return current.entry;

		}
		private string GetAndDeleteEntryFromCurrentNode(int toPop)
		{
			current = first;
			for (int i = 0; true; i++)
			{
				if (i != toPop)
				{
					current = current.next;
					continue;
				}

				Node bevor = first;
				while (bevor.next != current)
				{
					bevor = bevor.next;
				}

				bevor.next = current.next;
				return current.entry;
			}
		}

		public static List operator +(List a, List b)
		{
			var ret = new List();
			List[] lists = { a, b };

			foreach (var list in lists)
			{
				if (list.first == null)
				{
					continue;
				}

				var current = list.first;
				while (true)
				{
					ret.Add(current.entry);
					if (current.next == null)
					{
						break;
					}
					current = current.next;
				}
			}

			return ret;
		}


		public class Node
		{
			public string entry;
			public Node next;

			public Node(string entry)
			{
				this.entry = entry;
				next = null;
			}
		}
	}
}
