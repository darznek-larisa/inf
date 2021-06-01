using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class LinkedList
    {
        private int max_list = 100;
        public int last { get; set; }
        public int[] items { get; set; }
        public LinkedList()
        {
            this.last = 0;
            this.items = new int[max_list];
        }
        public void Insert(int n, int newItem)
        {
            if (this.last >= 100)
            {
                Console.WriteLine("Список полон.");
            }
            else
            {
                if (n > this.last || n < 0)
                {
                    Console.WriteLine("Такой позиции нет");
                }
                else
                {
                    for (int i = this.last; i >= n; i--)
                        this.items[i + 1] = this.items[i];
                    this.last = this.last + 1;
                    this.items[n] = newItem;
                }
            }
        }

        public void Remove(int n)
        {
            if (n > this.last || n < 1)
                Console.WriteLine("Такой позиции нет");
            else
            {
                this.last = this.last - 1;
                for (int i = n; i < this.last; i++)
                    this.items[i] = this.items[i + 1];
            }
        }
        public int Find(int x)
        {
            return Array.IndexOf(items, x);
        }
        public void PrintList()
        {
            Console.Write("Имеющийся list: ");
            for (int i = 0; i < last; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
