using System;
using System.Collections;

namespace SimpleCovidPOS
{
    class Program
    {
        static CustomerList customer = new CustomerList();
        static void Main(string[] args)
        {
            Console.WriteLine("This is a demonstration for git-first in GitHub");
            Console.WriteLine("This is a simple program for a POS system\n");
            bool doneShopping = false;
            while (!doneShopping)
            {
                Console.WriteLine("-----------------------------------------");
                DisplayOptions();
                
            choice:  var choice = System.Console.ReadKey();
                switch (choice.KeyChar)
                {
                
                    case 'a':
                        double value = 10;
                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine("This item costs {0} for 1", value);
                        Console.Write("Quantity: ");
                        int quantity = Int32.Parse(Console.ReadLine());
                        customer.AddItem(new Item("Face Mask", value, quantity));
                        break;
                    case 'b':
                        value = 70;
                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine("This item costs {0} for 1", value);
                        Console.Write("Quantity: ");
                        quantity = Int32.Parse(Console.ReadLine());
                        customer.AddItem(new Item("Face Shield", value, quantity));
                        break;
                    case 'c':
                        string name = "";
                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine("(a) 250mL");
                        Console.WriteLine("(b) 500mL");
                        Console.WriteLine("(c) 750mL");
                        Console.WriteLine("(d) 1000mL");
                        Console.Write("Make a selection: ");
                        choice2: var choiceVolume = System.Console.ReadKey();
                        switch (choiceVolume.KeyChar)
                        {
                            case 'a':
                                value = 100;
                                name = "Rubbing Alcohol - 250ml";
                                break;
                            case 'b':
                                value = 250;
                                name = "Rubbing Alcohol - 500ml";
                                break;
                            case 'c':
                                value = 300;
                                name = "Rubbing Alcohol - 750ml";
                                break;
                            case 'd':
                                name = "Rubbing Alcohol - 1000ml";
                                value = 500;
                                break;
                            default:
                                goto choice2;
                        }
                        Console.WriteLine("\n-----------------------------------------");
                        Console.WriteLine("This item costs {0} for 1", value);
                        Console.Write("Quantity: ");
                        quantity = Int32.Parse(Console.ReadLine());
                        customer.AddItem(new Item(name, value, quantity));
                        break;
                    case 'd':
                        Console.WriteLine("\n-----------------------------------------");
                        Console.Write("Item Name: ");
                        name = Console.ReadLine();
                        Console.Write("Value: ");
                        value = System.Convert.ToDouble(Console.ReadLine());
                        Console.Write("Quantity: ");
                        quantity = Int32.Parse(Console.ReadLine());
                        customer.AddItem(new Item(name, value, quantity));
                        break;
                    case 'z':
                        Console.WriteLine("\n-----------------------------------------");
                        doneShopping = true;
                        customer.ShowItems();
                        Console.WriteLine("Your total is {0}", customer.total);
                        break;
                    default:
                        goto choice;
                }
            }
        }
        public static void DisplayOptions()
        {
            Console.WriteLine("You currently have {0} items in your basket", customer.ItemCount());
            if (customer.ItemCount() != 0)
            {
                customer.ShowItems();
            }

            Console.WriteLine("\nAvailable Items: ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("(a) Face Mask");
            Console.WriteLine("(b) Face Shield");
            Console.WriteLine("(c) Rubbing Alcohol");
            Console.WriteLine("(d) Others...");
            Console.WriteLine("(z) Checkout");

            Console.WriteLine("-----------------------------------------");
            Console.Write("Make a selection <a/b/c/d/z>: ");
        }

    }

    class Item
    {
        public string name;
        public double value;
        public int quantity;

        public Item(string name, double value, int quantity)
        {
            this.name = name;
            this.value = value;
            this.quantity = quantity;
        }

        public override string ToString() => name + "(" + quantity + ") = " + value;
    }

    class CustomerList
    {
        public ArrayList items = new ArrayList();
        public double total = 0;

        public void AddItem(Item item)
        {
            items.Add(item);
            total += item.value * item.quantity;
        }

        public void ShowItems()
        {
            Console.WriteLine();
            foreach (Item item in items)
            {
                Console.WriteLine(item.name + "(" + item.quantity + ") = " + item.value*item.quantity);
            }
        }

        public int ItemCount()
        {
            int count = 0;
            foreach (Item item in items)
            {
                count += item.quantity;
            }
            return count;
        }
    }
}
