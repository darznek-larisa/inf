using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class Node_CLL
    {
        public int data { get; set; }
        public Node_CLL next { get; set; }
        public Node_CLL(int data)
        {
            this.data = data;
            this.next = next;
        }
    }
    class CycledLinkedList
    {
        private Node_CLL head;
        public int count { get; set; }
        public CycledLinkedList()
        {
            this.head = null;
            count = 0;
        }
        public void insert(int data)
        {
            Node_CLL curr = new Node_CLL(data);
            Node_CLL ptr = head;
            curr.next = head;
            if (head != null)
            {
                while (ptr.next != head)
                {
                    ptr = ptr.next;
                }
                ptr.next = curr;
            }
            else
            {
                curr.next = curr;
            }
            head = curr;
        }
        //n - количество элементов в цилкическом списке
        public void printCLL(int n)
        {
            Node_CLL ptr = head;
            int k = 0;
            do
            {
                Console.Write(ptr.data + " ");
                k++;
                ptr = ptr.next;
            }
            while (k != n + 1);
            Console.WriteLine();
        }
    }
}
