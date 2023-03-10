namespace Stacks_and_Queues_PE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Addubg data");
            Console.WriteLine("-a: 97");
            Console.WriteLine("-b: 98");
            Console.WriteLine("-c: 99");
            Console.WriteLine("-d: 100");
            Console.WriteLine("-e: 101");

            MyStack<string> stackS = new MyStack<string>();
            MyQueue<string> queueS = new MyQueue<string>();

            stackS.Push("a");
            stackS.Push("b");
            stackS.Push("c");
            stackS.Push("d");
            stackS.Push("e");

            queueS.Enqueue("a");
            queueS.Enqueue("b");
            queueS.Enqueue("c");
            queueS.Enqueue("d");
            queueS.Enqueue("e");

            MyStack<int> stackI = new MyStack<int>();
            MyQueue<int> queueI = new MyQueue<int>();

            stackI.Push(97);
            stackI.Push(98);
            stackI.Push(99);
            stackI.Push(100);
            stackI.Push(101);

            queueI.Enqueue(97);
            queueI.Enqueue(98);
            queueI.Enqueue(99);
            queueI.Enqueue(100);
            queueI.Enqueue(101);
        }
    }
}