using System;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание односвязного списка");
            LinkedList list = new LinkedList();
            list.Insert(0, 1);
            list.Insert(1, 2);
            list.Insert(2, 3);
            list.PrintList();
            Console.WriteLine("Удаление элемента под индексом 1");
            list.Remove(1);
            list.PrintList();
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Создание двусвязного списка");
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            DoubleLinkedList ddl = new DoubleLinkedList();
            ddl.insertStart(n1);
            ddl.insertEnd(n5);
            ddl.insertAfter(n1, n2);
            ddl.insertBefore(n5, n3);
            ddl.remove(n1);
            ddl.printDLL();
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Создание кольцевого односвязного списка");
            CycledLinkedList cll = new CycledLinkedList();
            cll.insert(1);
            cll.insert(2);
            cll.insert(3);
            cll.printCLL(2);
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Создание ограниченной очереди");
            Queue queue = new Queue(5);
            queue.EnQueue(3);
            queue.EnQueue(2);
            queue.EnQueue(1);
            queue.GetFront();
            Console.WriteLine("Удаление первого элемента в очереди");
            queue.DeQueue();
            queue.GetFront();
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Создание ограниченного стека в виде массива");
            ArrayStack arrayStack = new ArrayStack(5);
            arrayStack.push(2);
            arrayStack.push(5);
            arrayStack.getTop();
            arrayStack.pop();
            arrayStack.getTop();
            arrayStack.destroyStack();
            arrayStack.getTop();
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Создание стека в виде связанного списка");
            ConnectedListStack conStack = new ConnectedListStack();
            conStack.getTop();
            conStack.push("2");
            Console.WriteLine("Stack top = " + conStack.getTop());
            conStack.push("3");
            Console.WriteLine("Stack top = " + conStack.getTop());
            conStack.push("5");
            Console.WriteLine("Stack top = " + conStack.getTop());
            conStack.pop();
            Console.WriteLine("Stack top = " + conStack.getTop());
            conStack.pop();
            Console.WriteLine("Stack top = " + conStack.getTop());
            Console.WriteLine("_____________________________________");

            Console.WriteLine("Вычисление постфиксных выражений.");
            PostfixExpressions exp = new PostfixExpressions(" 2*(3+2)*((5*2-8)+(6-2*2))");
            Console.WriteLine("Инфиксное выражение: " + exp.GetStartExp());
            Console.WriteLine("Постиксное выражение: " + exp.ReversePostfix());
            exp.Calc();
        }
    }
}