using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class ConnectedListStack
    {
        class StackNode
        {
            public string item { get; set; }
            public StackNode next { get; set; }
        }
        private StackNode top;
        public int count { get; set; }
        public ConnectedListStack()
        {
            this.top = null;
            count = 0;
        }
        private bool IsEmpty()
        {
            return top == null;
        }
        public void pop()
        {
            if (IsEmpty())
                Console.WriteLine("Стек пуст");
            else
            {
                StackNode temp = top;
                top = top.next;
                temp.next = null;
                temp = null;
                count--;
            }
        }
        public void push(string newItem)
        {
            StackNode temp = new StackNode();
            temp.item = newItem;
            temp.next = top;
            top = temp;
            count++;
        }
        public string getTop()
        {
            if (IsEmpty())
            {
                return "Стек пуст";
            }
            else
            {
                return top.item;
            }
        }
    }
}
