using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class Queue
    {
        private int max_queue;
        public int[] items { get; set; }
        private int front;
        private int rear;
        private int count;
        public Queue(int max_queue)
        {
            this.front = 0;
            this.rear = -1;
            this.max_queue = max_queue;
            items = new int[max_queue];
        }
        //добавление элемента в конец очереди
        public void EnQueue(int NewItem)
        {
            if (count == max_queue)
                Console.WriteLine("Очередь полна");
            else
            {
                rear = (rear + 1) % max_queue;
                items[rear] = NewItem;
                ++this.count;
            }
        }
        private bool IsEmpty()
        {
            return (count == 0);
        }
        //удаление улемента из начала очереди
        public void DeQueue()
        {
            if (IsEmpty())
                Console.WriteLine("Очерень пуста");
            else
            {
                front = (front + 1) % max_queue;
                --count;
            }
        }
        //возврат первого элемента очереди
        public void GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Очерень пуста");
            }
            else
            {
                Console.WriteLine("Первый элемент очереди: " + this.items[front]);
            }
        }
    }
}
