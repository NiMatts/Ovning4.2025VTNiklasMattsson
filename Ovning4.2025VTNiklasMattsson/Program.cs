using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Ovning4._2025VTNiklasMattsson;

class Program
{
    //1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
    //  se illustration StackHeapIllustration.jpg
    //2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
    //  Value Types lagras direkt på stacken
    //  Reference Types lagras en referens på stacken och objektet på heapen
    //  Value Types igenom stackens funktionallitet sker minneshanteringen automatiskt
    //  Reference Types minneshanteringen sker systematiskt
    //3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
    //  I första bilden är x och y value types      value types kopierar värdet
    //  I andra bilden är x och y reference types   reference types kopierar referensen

    //MainMeny
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
                    ExamineParenthesis();
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

    //Lists
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
            char value = ' ';// Value is for separating and storing the menu part of input
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
                    if (theList.Count > 0 || !string.IsNullOrWhiteSpace(input.Substring(1)))
                    {
                        theList.RemoveAll(x => x == input.Substring(1));
                        CheckList(theList);
                    }
                    else
                    {
                        Console.WriteLine($"Listan är tom.");
                    }
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
    //2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
    //    när listan överfylls.  
    //3. Med hur mycket ökar kapaciteten?
    //    dubblas. om inget annat specifieras.
    //4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
    //    Tjattig minneshantering. 
    //5. Minskar kapaciteten när element tas bort ur listan?
    //    nej.
    //6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
    //    När man redan innan vet kravet på strl.
    //    När kraven på minneshantering är stor.

    //Queues
    static void ExamineQueue()
    {
        Queue<string> theQueue = new Queue<string>();
        bool isAlive = true;
        do
        {
            Console.WriteLine("Please navigate through the menu by inputting\n(+, -, 3)"
                + "\n+. Add item to queue"
                + "\n-. remove item from queue"
                + "\n*. Clear queue and simulate prepared queue"
                + "\n1. check queue"
                + "\n2. reset queue"
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
                        theQueue.Enqueue(input.Substring(1));
                        Console.WriteLine($"{input.Substring(1)} ställer sig i kön");
                    }
                    break;
                case '-':
                    if (theQueue.Count > 0 || !string.IsNullOrWhiteSpace(input.Substring(1)))
                    {
                        DequeueSpecificPerson(theQueue, input.Substring(1));
                        Console.WriteLine($"{input.Substring(1)}: lämnar kön");
                    }
                    else
                    {
                        Console.WriteLine($"Kön är tom.");
                    }
                    break;
                case '*':
                    SimulateQueue(theQueue);
                    break;
                case '1':
                    Console.WriteLine("Displaying Queue");
                    PrintQueue(theQueue);
                    break;
                case '2':
                    Console.WriteLine("Clearing Queue");
                    theQueue.Clear();
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
    static void PrintQueue(Queue<string> queue)
    {
        Console.WriteLine("Queue: " + string.Join(", ", queue));
    }
    static void SimulateQueue(Queue<string> queue)
    {
        queue.Clear();
        Array simArray = new[] { "+Kalle", "+Greta", "-Kalle", "+Stina", "-Greta", "+Olle" };
        Console.WriteLine($"ICA öppnar och kön till kassan är tom");
        foreach (string sim in simArray)
        {
            if (sim.Contains('+'))
            {
                queue.Enqueue(sim.Substring(1));
                Console.WriteLine($"{sim.Substring(1)} ställer sig i kön");
            }
            else if (sim.Contains("-"))
            {
                queue.Dequeue();
                Console.WriteLine($"{sim.Substring(1)}: blir expedierad och lämnar kön");
            }
            PrintQueue(queue);
        }
    }
    static void DequeueSpecificPerson(Queue<string> queue, string personToRemove)
    {
        int queueLength = queue.Count;
        for (int i = 0; i < queueLength; i++)
        {
            string person = queue.Dequeue();  // Remove the first person

            if (person != personToRemove)
            {
                queue.Enqueue(person);  // Add back if it's not the person we want to remove
            }
        }
    }
    //1. Simulera följande kö på papper:
    //      a.ICA öppnar och kön till kassan är tom
    //      b.Kalle ställer sig i kön
    //      c.Greta ställer sig i kön
    //      d.Kalle blir expedierad och lämnar kön
    //      e.Stina ställer sig i kön
    //      f. Greta blir expedierad och lämnar kön
    //      g.Olle ställer sig i kön
    //      h. …
    //   se illustration Queue.jpg

    //Stacks
    static void ExamineStack()
    {
        Stack<string> theList = new Stack<string>();
        bool isAlive = true;
        do
        {
            Console.WriteLine("Please navigate through the menu by inputting\n(r, e)"
                + "\nr. Reverse string"
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
                case 'r':
                    if (input.Length == 1 || string.IsNullOrWhiteSpace(input.Substring(1)))
                    {
                        Console.WriteLine("input empty: (example format: rSteve)");
                    }
                    else
                    {
                        ReverseText(input.Substring(1));
                    }
                    break;
                case 'e':
                    isAlive = false;
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (r, e)");
                    break;
            }
        } while (isAlive);
    }
    static void ReverseText(string text)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in text)
        {
            stack.Push(c);
        }
        Console.WriteLine($"{text}");
        string reversed = "";
        while (stack.Count > 0)
        {
            Console.WriteLine($"{reversed}<-{stack.First()}");
            reversed += stack.Pop();
        }
        Console.WriteLine($"reversed: {reversed}");
    }
    //1. Simulera ännu en gång ICA-kön på papper.Denna gång med en stack.Varför är det inte så smart att använda en stack i det här fallet?
    //      se illustration Stack.jpg
    //      köer är mer FIFO än FILO. 


    //Parenteser
    static void ExamineParenthesis()
    {
        Stack<string> theList = new Stack<string>();
        bool isAlive = true;
        do
        {
            Console.WriteLine("Please navigate through the menu by inputting\n(1, e)"
                + "\n1. Check parenthesis format"
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
                case '1':
                    if (input.Length == 1 || string.IsNullOrWhiteSpace(input.Substring(1)))
                    {
                        Console.WriteLine("input empty: (example format: 1Steve)");
                    }
                    else
                    {
                        if (CheckParanthesis(input.Substring(1)))
                        {
                            Console.WriteLine($"Balanced opening and closing special characters:{input.Substring(1)}");
                        }
                        else
                        {
                            Console.WriteLine($"Unbalanced opening and closing special characters:{input.Substring(1)}");
                        }
                    }
                    break;
                case 'e':
                    isAlive = false;
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (1, e)");
                    break;
            }
        } while (isAlive);
    }
    static bool CheckParanthesis(string teststring)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in teststring)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                {
                    //stängde innan öppning
                    return false;
                }

                char openParenthesis = stack.Pop();
                if ((c == ')' && openParenthesis != '(') ||
                    (c == '}' && openParenthesis != '{') ||
                    (c == ']' && openParenthesis != '['))
                    {
                        //stänger fel öppning
                        return false;
                    }
            }
        }
        return stack.Count == 0;
    }
}   //1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad sträng på papper.Du ska använda dig av någon eller några av de datastrukturer vi
    //   precis gått igenom. Vilken datastruktur använder du? 
    //      se illustration Parenteser.jpg
    //      Jag använder mig utav en stack.FILO

