using System;
using System.Collections;

namespace SimpleCovidPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a demonstration for git-first in GitHub");
        }
    }

    class Item {
        public string name;
        public double value;
        public int quantity;

        }

    class CustomerList{
        public ArrayList items = new ArrayList();
        public double total;

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}
