using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    class Node
    {
        public int data { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }
        public Node(int data)
        {
            this.data = data;
        }
    }

    class DoubleLinkedList
    {
        private Node first;
        private Node last;
        public int count { get; set; }
        public DoubleLinkedList()
        {
            this.first = this.last = null;
            count = 0;
        }
        public void insertAfter(Node ref_node, Node new_node)
        {
            new_node.prev = ref_node;
            if (ref_node.next == null)
            {
                this.last = new_node;
            }
            else
            {
                new_node.next = ref_node.next;
                new_node.next.prev = new_node;
            }
            ref_node.next = new_node;
            count++;
        }
        public void insertBefore(Node ref_node, Node new_node)
        {
            new_node.next = ref_node;
            if (ref_node.prev == null)
                this.first = new_node;
            else
            {
                new_node.prev = ref_node.prev;
                new_node.prev.next = new_node;
            }
            ref_node.prev = new_node;
            count++;
        }
        public void insertStart(Node new_node)
        {
            if (this.first == null)
            {
                first = new_node;
                last = new_node;
                count++;
            }
            else
                this.insertBefore(this.first, new_node);
        }
        public void insertEnd(Node new_node)
        {
            if (last == null)
            {
                last = new_node;
                first = new_node;
                count++;
            }
            else
                this.insertAfter(last, new_node);
        }
        public void remove(Node node)
        {
            if (node.prev == null)
                first = node.next;
            else
                node.prev.next = node.next;
            if (node.next == null)
                last = node.prev;
            else
                node.next.prev = node.prev;
            count--;
        }
        public void printDLL()
        {
            Console.Write("Имеющийся ddl: ");
            Node current = first;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
