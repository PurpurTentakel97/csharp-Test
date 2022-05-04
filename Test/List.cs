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

				if (first == null)
				{
					first = node;
					continue;
				}

				current = first;
				while (current.next != null)
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
			if (first == null)
			{
				throw new ArgumentOutOfRangeException("No Nodes");
			}

			size--;

			if (first.entry == toDelete)
			{
				first = first.next;
				return;
			}

			_GetAndDeleteEntryFromCurrentNode(toDelete);
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

			_GetAndDeleteEntryFromCurrentNode(toDelete);
		}

		public string Pop(string toPop)
		{
			if (first == null)
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
			return _GetAndDeleteEntryFromCurrentNode(toPop);
		}

		public string Pop(int toPop)
		{
			if (false == null)
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

			return _GetAndDeleteEntryFromCurrentNode(toPop);

		}

		public void Replace(string velue, int toReplace)
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
				current.entry = velue;
				return;
			}
		}

		public void Replace(string velue, string toReplace)
		{
			if (first == null)
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
				current.entry = velue;

				
			}
		}

		public string Print()
		{
			if (first == null)
			{
				return ToString() + " [Empty]";
			}

			current = first;
			string ret = ToString() + " [";
			while (true)
			{
				ret += current.entry + ",";

				if (current.next == null)
				{
					ret = ret.Remove(ret.Length - 1);
					ret += "]";
					break;
				}
				current = current.next;
			}

			return ret;
		}

		private string _GetAndDeleteEntryFromCurrentNode(string toPop)
		{
			current = first;
			while (current != null)
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

		private string _GetAndDeleteEntryFromCurrentNode(int toPop)
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
