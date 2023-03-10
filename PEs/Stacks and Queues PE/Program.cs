namespace Stacks_and_Queues_PE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prints the data being added
            Console.WriteLine("Addubg data");
            Console.WriteLine("-a: 97");
            Console.WriteLine("-b: 98");
            Console.WriteLine("-c: 99");
            Console.WriteLine("-d: 100");
            Console.WriteLine("-e: 101");
            Console.WriteLine();

            // Creates a stack and queue of strings
            MyStack<string> stackS = new MyStack<string>();
            MyQueue<string> queueS = new MyQueue<string>();

            // Populates the stack
            stackS.Push("a");
            stackS.Push("b");
            stackS.Push("c");
            stackS.Push("d");
            stackS.Push("e");

            // Populates the queue
            queueS.Enqueue("a");
            queueS.Enqueue("b");
            queueS.Enqueue("c");
            queueS.Enqueue("d");
            queueS.Enqueue("e");

            // Creates a stack and queue of ints
            MyStack<int> stackI = new MyStack<int>();
            MyQueue<int> queueI = new MyQueue<int>();

            // Populates the stack
            stackI.Push(97);
            stackI.Push(98);
            stackI.Push(99);
            stackI.Push(100);
            stackI.Push(101);

            // Populates the queue
            queueI.Enqueue(97);
            queueI.Enqueue(98);
            queueI.Enqueue(99);
            queueI.Enqueue(100);
            queueI.Enqueue(101);

            // Prints each of the elements of the string stack
            Console.WriteLine($"The string stack has {stackS.Count} items in it\n" +
                $"  Starting at the top they are:");
            Console.WriteLine("\t" + stackS.Peek());
            for (int i = 0; i < 4; i++)
            {
                //Console.WriteLine(stackS.Peek());
                Console.WriteLine("\t" + stackS.Pop());
            }
            Console.WriteLine();

            // Prints each of the elements of the int stack
            Console.WriteLine($"The int stack has {stackI.Count} items in it\n" +
                 $"  Starting at the top they are:");
            Console.WriteLine("\t" + stackI.Peek());
            for (int i = 0; i < 4; i++)
            {
                //Console.WriteLine(stackS.Peek());
                Console.WriteLine("\t" + stackI.Pop());
            }
            Console.WriteLine();

            // Prints each of the elements of string queue
            Console.WriteLine($"The string queue has {queueS.Count} items in it\n" +
                $"  Starting at the top they are:");
            Console.WriteLine("\t" + queueS.Peek());
            for (int i = 0; i < 4; i++)
            {
                //Console.WriteLine(stackS.Peek());
                Console.WriteLine("\t" + queueS.Dequeue());
            }
            Console.WriteLine();

            // Prints each of the elements of the int queue
            Console.WriteLine($"The int queue has {queueI.Count} items in it\n" +
                $"  Starting at the top they are:");
            Console.WriteLine("\t" + queueI.Peek());
            for (int i = 0; i < 4; i++)
            {
                //Console.WriteLine(stackS.Peek());
                Console.WriteLine("\t" + queueI.Dequeue());
            }
        }
    }
}