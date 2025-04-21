using System;

namespace Ovning4._2025VTNiklasMattsson;

    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> theList = new List<string>();
            bool isAlive = true;
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting\n(+, -, 3)"
                    + "\n+ Add item to list"
                    + "\n-. remove item from list"
                    + "\ne. exít to main menue");
                string input = ""; //Creates the character input to be used with the switch-case below.
                char value = ' ';
                try
                {
                    input = Console.ReadLine(); //Tries to set input to the first char in an input line
                    value = input![0];

                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (value)
                {
                    case '+':
                        if (input.Length == 1 || string.IsNullOrWhiteSpace(input.Substring(1)))
                        {
                            Console.WriteLine("input empty: (example format: +Steve)");
                        }
                        else
                        {
                            theList.Add(input.Substring(1));
                            CheckList(theList);
                        }
                        break;
                    case '-':
                        theList.RemoveAll(x => x == input.Substring(1));
                        CheckList(theList);
                        break;
                    case 'e':
                        isAlive = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -, e)");
                        break;
                }
            } while (isAlive);
        }
        static void CheckList(List<string> lista)
        {
            for (int i = 0; i < lista.Capacity; i++)
            {
                if (i < lista.Count)
                {
                    Console.WriteLine($"{i}: {lista[i]}");
                }
                else
                {
                    Console.WriteLine($"{i}: capacity");
                }
            }
            Console.WriteLine($"listaCount: {lista.Count} listaCapacity: {lista.Capacity}");
        }
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> theList = new Queue<string>();
            bool isAlive = true;
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting\n(+, -, 3)"
                    + "\n+ Add item to list"
                    + "\n-. remove item from list"
                    + "\ne. exít to main menue");
                string input = ""; //Creates the character input to be used with the switch-case below.
                char value = ' ';
                try
                {
                    input = Console.ReadLine(); //Tries to set input to the first char in an input line
                    value = input![0];

                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (value)
                {
                    case '+':
                        if (input.Length == 1 || string.IsNullOrWhiteSpace(input.Substring(1)))
                        {
                            Console.WriteLine("input empty: (example format: +Steve)");
                        }
                        else
                        {
                            theList.Add(input.Substring(1));
                            CheckQueue(theList);
                        }
                        break;
                    case '-':
                        theList.RemoveAll(x => x == input.Substring(1));
                        CheckQueue(theList);
                        break;
                    case 'e':
                        isAlive = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -, e)");
                        break;
                }
            } while (isAlive);
        }
        static void CheckQueue(Queue<string> lista)
        {
            /*for (int i = 0; i < lista.Capacity; i++)
            {
                if (i < lista.Count)
                {
                    Console.WriteLine($"{i}: {lista[i]}");
                }
                else
                {
                    Console.WriteLine($"{i}: capacity");
                }
            }
            Console.WriteLine($"listaCount: {lista.Count} listaCapacity: {lista.Capacity}");*/
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> theList = new Stack<string>();
            bool isAlive = true;
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting\n(+, -, 3)"
                    + "\n+ Add item to list"
                    + "\n-. remove item from list"
                    + "\ne. exít to main menue");
                string input = ""; //Creates the character input to be used with the switch-case below.
                char value = ' ';
                try
                {
                    input = Console.ReadLine(); //Tries to set input to the first char in an input line
                    value = input![0];

                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (value)
                {
                    case '+':
                        if (input.Length == 1 || string.IsNullOrWhiteSpace(input.Substring(1)))
                        {
                            Console.WriteLine("input empty: (example format: +Steve)");
                        }
                        else
                        {
                            theList.Add(input.Substring(1));
                            CheckStack(theList);
                        }
                        break;
                    case '-':
                        theList.RemoveAll(x => x == input.Substring(1));
                        CheckStack(theList);
                        break;
                    case 'e':
                        isAlive = false;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (+, -, e)");
                        break;
                }
            } while (isAlive);
        }
        static void CheckStack(List<string> lista)
        {
            /*for (int i = 0; i < lista.Capacity; i++)
            {
                if (i < lista.Count)
                {
                    Console.WriteLine($"{i}: {lista[i]}");
                }
                else
                {
                    Console.WriteLine($"{i}: capacity");
                }
            }
            Console.WriteLine($"listaCount: {lista.Count} listaCapacity: {lista.Capacity}");*/
        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }


