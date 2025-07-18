namespace _14_Generic
{
    
    internal class Program
    {
        static public void Max<T1>(T1 t1, T1 t2, T1 t3) where T1 : IComparable
        {
            if (t1.CompareTo(t2) == 0)
            {
                if (t1.CompareTo(t3) == 0)
                {
                    Console.WriteLine($"All nums is equals");
                }
                else if(t1.CompareTo(t3) > 0)
                {
                    Console.WriteLine($"Max: {t3}");
                }
                else
                {
                    Console.WriteLine($"Max: {t1}, {t2}");
                }
            }
            else if(t1.CompareTo(t2) > 0)
            {
                if (t1.CompareTo(t3) == 0)
                {
                    Console.WriteLine($"Max: {t1}, {t3}");
                }
                else if(t1.CompareTo(t3) > 0)
                {
                    Console.WriteLine($"Max: {t1}");
                }
                else
                {
                    Console.WriteLine($"Max: {t3}");
                }
            }
            else
            {
                if (t2.CompareTo(t3) == 0)
                {
                    Console.WriteLine($"Max: {t2}, {t3}");
                }
                else if (t2.CompareTo(t3) > 0)
                {
                    Console.WriteLine($"Max: {t2}");
                }
                else
                {
                    Console.WriteLine($"Max: {t3}");
                }
            }
        }
        static public void Min<T1>(T1 t1, T1 t2, T1 t3) where T1 : IComparable
        {
            if (t1.CompareTo(t2) == 0)
            {
                if (t1.CompareTo(t3) == 0)
                {
                    Console.WriteLine($"All nums is equals");
                }
                else if (t1.CompareTo(t3) < 0)
                {
                    Console.WriteLine($"Min: {t3}");
                }
                else
                {
                    Console.WriteLine($"Min: {t1}, {t2}");
                }
            }
            else if (t1.CompareTo(t2) < 0)
            {
                if (t1.CompareTo(t3) == 0)
                {
                    Console.WriteLine($"Min: {t1}, {t3}");
                }
                else if (t1.CompareTo(t3) < 0)
                {
                    Console.WriteLine($"Min: {t1}");
                }
                else
                {
                    Console.WriteLine($"Min: {t3}");
                }
            }
            else
            {
                if (t2.CompareTo(t3) == 0)
                {
                    Console.WriteLine($"Min: {t2}, {t3}");
                }
                else if (t2.CompareTo(t3) < 0)
                {
                    Console.WriteLine($"Min: {t2}");
                }
                else
                {
                    Console.WriteLine($"Min: {t3}");
                }
            }
        }

        static public T1 Sum<T1>(T1[] t1arr)
        {
            T1 sum = default(T1);
            foreach (T1 item in t1arr)
            {
                if (item is int || item is double || item is float)
                {
                    sum += (dynamic)item;
                }
                else if (item is string)
                {
                    sum += (dynamic)item;
                }
                else
                {
                    throw new ArgumentException("Unsupported type for summation.");
                }
            }
            return sum;
        }    

        class Stack<T>
        {
            private T[] items;
            private int top;
            public Stack(int size)
            {
                items = new T[size];
                top = -1;
            }
            public void Push(T item)
            {
                if (top == items.Length - 1)
                {
                    throw new InvalidOperationException("Stack overflow");
                }
                items[++top] = item;
            }
            public T Pop()
            {
                if (top == -1)
                {
                    throw new InvalidOperationException("Stack underflow");
                }
                return items[top--];
            }
            public int Count()
            {
                return top + 1;
            }
            public T peek()
            {
                if (top == -1)
                {
                    throw new InvalidOperationException("Stack is empty");
                }
                return items[top];
            }
        }
        class Queue<T>
        {
            private T[] items;
            private int front;
            private int rear;
            private int count;
            public Queue(int size)
            {
                items = new T[size];
                front = 0;
                rear = -1;
                count = 0;
            }
            public void Enqueue(T item)
            {
                if (count == items.Length)
                {
                    throw new InvalidOperationException("Queue overflow");
                }
                rear = (rear + 1) % items.Length;
                items[rear] = item;
                count++;
            }
            public T Dequeue()
            {
                if (count == 0)
                {
                    throw new InvalidOperationException("Queue underflow");
                }
                T item = items[front];
                front = (front + 1) % items.Length;
                count--;
                return item;
            }
            public int Count()
            {
                return count;
            }
            public T Peek()
            {
                if (count == 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }
                return items[front];
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
