using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class ArrayStack
    {
        private int max_size;
        public int[] stack { get; set; }
        private int top;
        public ArrayStack(int max_size)
        {
            this.top = 0;
            this.max_size = max_size;
            stack = new int[max_size];
        }
        private bool IsEmpty()
        {
            return top == 0;
        }
        //Удаление верхнего элемента из стека
        public void pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
            }
            else
                --top;
        }
        //добавление нового элемента в стек
        public void push(int NewItem)
        {
            if (top >= max_size)
                Console.WriteLine("Стек полон");
            else
            {
                stack[++top] = NewItem;
            }
        }
        public void getTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стук пуст");
            }
            else
                Console.WriteLine(stack[top]);
        }
        public void destroyStack()
        {
            top = 0;
        }
    }
}
