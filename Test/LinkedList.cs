/*
 * Purpur Tentakel
 * 02.05.2022
 * Test - Lists
 */

namespace Lists
{
    public class LinkedList
    {
        private Node? first;
        private int size;

        public int Count
        {
            get
            {
                return size;
            }
        }

        public LinkedList(string[] values)
        {
            first = null;
            size = 0;

            Add(values);
        }
        public LinkedList(string value, int count = 1)
        {
            first = null;
            size = 0;

            Add(value, count);
        }
        public LinkedList()
        {
            first = null;
            size = 0;
        }

        public void Add(string value, int count = 1)
        {
            if (count <= 0)
            {
                return;
            }

            Node? preview = null;
            var current = first is null
            ? (first = new Node(value))
            : (GetLastNode().next = new Node(value));

            for (int i = 1; i < count; i++)
            {
                preview = current;
                current = new Node(value);
                preview.next = current;
            }
            size += count;
        }
        public void Add(string[] values)
        {
            foreach (string value in values)
            {
                Add(value);
            }
        }

        public string Get(int index)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            if (!IsValidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            return GetNodeAt(index).entry;
        }
        public int Get(string value)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            return GetFirstIndexFromEntry(value);
        }

        public string Pop(int index)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            if (!IsValidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                return GetAndDeleteFirstNode().entry;
            }
            return GetAndDeleteNode(index).entry;
        }
        public string Pop(string value)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            if (first.entry == value)
            {
                return GetAndDeleteFirstNode().entry;
            }


            return GetAndDeleteNode(value).entry;
        }

        public void Replace(string value, int index)
        {
            if (!IsValidIndex(index))
            {
                Console.WriteLine(size);
                throw new IndexOutOfRangeException();
            }

            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            var current = GetNodeAt(index);
            current.entry = value;
        }
        public void Replace(string value, string toOverride)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            var current = first;
            for (int i = 0; i < size; i++)
            {
                if (current.entry == toOverride)
                {
                    current.entry = value;
                }

                current = current.next;
            }
        }

        public LinkedList Slice(int index_u, int index_o)
        {
            if (!IsValidIndex(index_u) || !IsValidIndex(index_o))
            {
                throw new IndexOutOfRangeException();
            }

            if (index_u > index_o)
            {
                throw new InvalidOperationException("Wrong Index");
            }

            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            var ret = new LinkedList();
            var current = first;

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

        public void Delete(int index)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            if (!IsValidIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                GetAndDeleteFirstNode();
                return;
            }

            GetAndDeleteNode(index);
        }
        public void Delete(string value)
        {
            if (first is null)
            {
                throw new InvalidOperationException("No Nodes");
            }

            if (first.entry == value)
            {
                GetAndDeleteFirstNode();
                return;
            }

            GetAndDeleteNode(value);
        }

        public void Print()
        {
            if (first is null)
            {
                Console.WriteLine(ToString() + " [Empty]");
                return;
            }

            var current = first;
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


        private Node GetLastNode()
        {
            if (first is null)
            {
                return null;
            }

            var current = first;
            while (current.next is not null)
            {
                current = current.next;
            }
            return current;
        }

        private Node GetNodeAt(int index)
        {
            var current = first;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current;
        }
        private int GetFirstIndexFromEntry(string value)
        {
            var index = 0;
            var current = first;
            for (int i = 0; true; i++)
            {
                if (current.entry == value)
                {
                    break;
                }

                if (current.next is null)
                {
                    throw new InvalidOperationException("Value not found");
                }

                current = current.next;
                index++;
            }
            return index;
        }

        private Node GetAndDeleteFirstNode()
        {
            var ret = first;
            first = first.next;
            size--;
            return ret;
        }

        private Node GetAndDeleteNode(int index)
        {
            var current = first;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            var bevor = GetNodeBevoreNote(current);

            bevor.next = current.next;
            size--;
            return current;


        }
        private Node GetAndDeleteNode(string value)
        {
            var current = first;
            while (current != null)
            {
                if (current.entry == value)
                {
                    break;
                }
                current = current.next;
            }

            if (current is null)
            {
                throw new InvalidOperationException("Not found");
            }

            var before = GetNodeBevoreNote(current);

            before.next = current.next;
            size--;
            return current;
        }

        private Node GetNodeBevoreNote(Node node)
        {
            var before = first;
            while (before.next != node)
            {
                before = before.next;
            }
            return before;
        }

        private bool IsValidIndex(int index)
        {
            if (index >= size || index < 0)
            {
                return false;
            }
            return true;
        }

        public static LinkedList operator +(LinkedList a, LinkedList b)
        {
            var ret = new LinkedList();
            LinkedList[] lists = { a, b };

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
