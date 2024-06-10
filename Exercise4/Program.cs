using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
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
            /*
             1) Skriv klart implementationen av ExamineList-metoden så att undersökningen blir
                genomförbar.
               List<int> myList = new List<int>();

            // Add elements to the list
            for (int i = 0; i < 10; i++)
            {
                myList.Add(i);
                Console.WriteLine($"Count: {myList.Count}, Capacity: {myList.Capacity}");
            }

            2) När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)?
            When you create a new List<int>, it starts with an initial capacity of 4 elements. This default initial capacity is chosen to balance memory overhead and performance.
            The list's capacity increases when it needs to accommodate more elements than its current capacity allows. This usually happens when you try to add an element to the list and its Count exceeds its Capacity.
           
             3) Med hur mycket ökar kapaciteten?
            When the number of elements reaches the current capacity, the list doubles its capacity by allocating a new internal array with twice the size of the current capacity.
            The capacity typically increases by a factor or a specific amount. In .NET, the List<T> class uses a doubling strategy, where the capacity doubles every time it needs to increase.

             4) Varför ökar inte listans kapacitet i samma takt som element läggs till?

            The list's capacity does not increase in the same proportion as elements are added to optimize memory usage and performance. The capacity of the list increases dynamically but not necessarily in lockstep with the number of elements added, reflecting the list's efficient memory management strategy.This strategy ensures that appending elements to the list remains efficient with an amortized constant time complexity. 
              The list's capacity does not increase at the same rate as elements are added because it would be inefficient to resize the underlying array every time an element is added. Instead, the list allows for some extra capacity to avoid frequent resizing. When the extra capacity is exhausted, the list increases its capacity.
           
            5) Minskar kapaciteten när element tas bort ur listan?

              No, the capacity does not decrease when elements are removed from the list. Removing elements only affects the Count property, which tracks the number of elements in the list. The capacity remains unchanged unless explicitly resized.
            After removing elements from the list, the Count property decreases, but the Capacity property remains unchanged. This behavior ensures that the list does not unnecessarily resize its internal data structure when elements are removed, improving performance and avoiding unnecessary memory allocations.
          

            6) När är det då fördelaktigt att använda en egendefinierad array istället för en lista?

            It is advantageous to use a custom array instead of a list when you need precise control over memory allocation or when you know the exact size of the collection in advance. Custom arrays allow you to allocate memory efficiently without the overhead of dynamically resizing arrays. However, lists are more flexible and convenient for most scenarios, especially when the size of the collection is not known in advance or may change dynamically.

             * In both cases, look at the count and capacity of the list
            
             * Below you can see some inspirational code to begin working.
            */


            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            List<int> myList = new List<int>();

            // Add elements to the list
            for (int i = 0; i < 10; i++)
            {
                myList.Add(i);
                Console.WriteLine($"Count: {myList.Count}, Capacity: {myList.Capacity}");
            }

            Console.WriteLine("*************************");
            for (int i = 0; i < 10; i++)
            {
                myList.Remove(i);
                Console.WriteLine($"Count: {myList.Count}, Capacity: {myList.Capacity}");
            }
            Console.WriteLine("\nAfter removing elemnts: ");
            Console.WriteLine($"Count: {myList.Count}, Capacity: {myList.Capacity}");

            List<string> theList = new List<string>();
            //* Loop this method untill the user inputs something to exit to main menue.
            while (true)
            {
                Console.WriteLine("Enter '{+item}' to add or '-item' to remove(or '0' to return to main menu):");
                string input = Console.ReadLine()!;
                if (input == "0") break;

                char nav = input[0];
                string value = Console.ReadLine()!;
                //switch(nav){
                /*Create a switch statement with cases '+' and '-'*/

                switch (nav)
                {
                    // * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Add '{value}'. Count: {theList.Count}, Capacity:{theList.Capacity}");
                        break;
                    //  * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                    case '-':
                        theList.Add(value);
                        Console.WriteLine($"Remove '{value}'. Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                    // * As a default case, tell them to use only + or -
                    default:
                        Console.WriteLine("Use only '+' or '-' symbol");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            /*
             Enqueue: Adds a new element to the queue.
            Dequeue: Removes and returns the first (front) element from the queue.
            Peek: Returns the first element in the queue.
            Return queue.Count == 0;: Checks if the queue is empty.
            Count: Finds the number of elements in the queue.
             */
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("");
            queue.Enqueue("Kalle");
            queue.Enqueue("Greta");
            queue.Enqueue("Stina");
            queue.Enqueue("Olle");

            while (true)
            {
                Console.WriteLine("Queue operations:"
                    + "\n1. Add to queue (enqueue)"
                    + "\n2. Remove from queue (dequeue)"
                    + "\n3. Display queue"
                    + "\n4. Last in the queue"
                    + "\n5. First in the queue"
                    + "\n6. Total in the queue"
                    + "\n0. Exit to main menu");
                string input = Console.ReadLine()!;
                char choice = input.Length > 0 ? input[0] : ' ';
                string name = input.Length > 1 ? input.Substring(1).Trim() : "";
                try
                {


                    switch (choice)
                    {
                        case '1':
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Enter a queue name:");
                                string person = Console.ReadLine()!;
                                Console.WriteLine($"{person} has been added to the queue:");
                                queue.Enqueue(person);
                            }
                            else
                            {
                                Console.WriteLine("Please provide a name to enqueue.");
                            }
                            break;
                        case '2':
                            if (queue.Count > 0)
                            {
                                string removedPerson = queue.Dequeue();
                                Console.WriteLine(queue.Dequeue() +
                                $" has been removed from the queue.");

                            }
                            else
                            {
                                Console.WriteLine("The queue is empty, nothing to dequeue.");
                            }
                            break;
                        case '3':
                            DisplayQueue(queue);
                            break;
                        case '4':
                            string LastInQueue = queue.Last();
                            Console.WriteLine("The last perosn in the queue is " + LastInQueue);
                            break;
                        case '5':
                            string FirstInQueue = queue.First();
                            Console.WriteLine("The fisrt perosn in the queue is " + FirstInQueue);
                            break;
                        case '6':
                            int Total = queue.Count;
                            Console.WriteLine("Toalt perosn in the queue " + Total);
                            break;
                        case '0':
                            return;
                        default:
                            Console.WriteLine("Please enter a valid option (0, 1, 2, 3, 4)");
                            break;
                    }
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Operation error : {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occured: {ex.Message}");
                }


            }
            static void DisplayQueue(Queue<string> queue)
            {
                // check if the is person in queue
                if (queue.Count == 0)
                {
                    Console.WriteLine("The queue is empty.");
                }
                else
                {
                    //Display perosns in the queue
                    Console.WriteLine("Persons in the queue:");
                    foreach (var item in queue)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            /* 1) Simulera ännu en gång  ICA-kön på papper. Denna gång med en stack. Varför är det
          inte så smart att använda en stack i det här fallet?
        eftersom stack är LIFO altså 'Last in First Out' därför Queue passar bättre man vill köpa betala och dra
         */
            /*
             Implementera en ReverseText-metod som läser in en sträng från användaren och
            med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
            omvända strängen till användaren.
             */

            Console.WriteLine("Please enter a string to reverse:");
            string input = Console.ReadLine()!;

            // Reverse the string using a stack
            string reverseInput = ReverseText(input);


            /* Console.WriteLine(input.Reverse()+ "Reverse()");*/
            /*   Console.WriteLine("Original :" + input);*/


            // Print the reversed string
            Console.WriteLine("Reversed string :" + reverseInput);

            /*  Stack myStack = new Stack();

              myStack.Push("1.The");
              myStack.Push("2.quick");
              myStack.Push("3.brown");
              myStack.Push("4.fox");
              myStack.Push("5. " + ReverseText(reverseInput));
              myStack.Push("6.Original text " + ReverseText(input));

              foreach (var item in myStack)
              {
                  Console.WriteLine("Print out : " + item);

              }*/
        }

        static string ReverseText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            // Create a stack to hold characters
            Stack<char> itemStack = new Stack<char>();

            // Push each character of the string onto the stack
            foreach (char c in text)
            {
                itemStack.Push(c);

                /*Console.WriteLine("Executing the c in the character " + c );*/
            }

            Console.WriteLine("******<pushing to stack>*****");

            // Pop characters from the stack to build the reversed string
            //Create a character array of the same length as the input string:
            char[] reversedChar = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                reversedChar[i] = itemStack.Pop();
            }
            //converts the reversedChars array back into a string.
            return new string(reversedChar);

        }



        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            //List<int> lista = new List<int>() {1, 2, 3, 4 };// return (4[3{1}3](2{1}2)4)
            // (2(1)2), {1}, [3(2{1}2)3]

            //Input the String:
            Console.WriteLine("Enter a string to check:");
            string input = Console.ReadLine()!;

            bool result = IsValidParanthesis(input);
            PrintResult(result);
            Console.WriteLine($"The string starts and ends with a matching pair: {result}");


            //Function to Check Validation:
            static bool IsValidParanthesis(string input)
            {
                //a length must be greater than 2  to ensure that there are enough characters in the string to form a valid pair.
                if (string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    return false;
                }
                // Define valid pairs
                Dictionary<char, char> validPairs = new Dictionary<char, char>()
                {
                    {'(',')' },
                    {'{','}' },
                    {'[',']' },
                    {'<','>' },
                };

                char firstChar = input[0];
                char lastChar = input[input.Length - 1];

                //check if the first charachter char has a corresponding closing charachter charand if it matches the last character
                if (validPairs.ContainsKey(firstChar) && validPairs[firstChar] == lastChar)
                {
                    return true;
                }

                return false;
            }


        }

        private static void PrintResult(bool result)
        {
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The string starts and ends with a matching pair: {result}");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"The string does not starts and ends with a matching pair: {result}");
            }
            Console.ResetColor();


        }
    }
}

/*
 1) hur fungerar stacken och heapen? Förklara gärna med exemple eller skiss på dess grundläggande funktion
 STACK: stores value types and manages memory in a Last-In-First-Out manner.Memory is free when the method exists.

HEAPEN: Stores reference types and dynamically allocated objects.Accessible from anywhere in the apllication and memory is free when object are no longer in use.

Exemple:
class Program
{
    static void Main()
    {
        int x = 10; // Stored on the stack
        int y = 20; // Stored on the stack

        // 'person' is a reference type stored on the heap
        Person person = new Person("Alice");

        Console.WriteLine($"x: {x}, y: {y}, person: {person.Name}");
    }
}

class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}

   The stack is used for storing value types and method calls with automatic memory management, while the heap is used for dynamic memory allocation, particularly for reference types, with memory managed by the garbage collector GC.
 */

/*
 2) Vad är value types respektive reference types i c# och vad skjlier sig?
  * Value Types: Varaibles that hold data directly and store it in the stack like int,bool,struct and when you assign a value type to another a copy is made. Allocate on the stack, copy the value directly, lifetime is determined by the scope they are declared in.

  * Reference Types: Are varibales that hold a reference to the data and stored in the heap with the reference on the stack e.g arrays,string, delegate. when assign a reference type to another both variables refer to the same object. Allocate on the heap and refernce itself to the stack, copy the reference and not the actual object. lifetime is manged by the garabage colletor GC
 */

/*
 3) Följande metoder genererar olika svar. den första retunerar 3, den andra retunerar 4 varför ?
The differnce in behavior lies in the distiction between value type and reference types.
In the first method: since "int" is a vlaue type when we assign it to another a copy value is made, "x" and "y" are indepnedent after assignment and changing "y" does not affect "x"

Value Type:

    int x = new int(); // x is a value type, initialized to 0 by default
    x = 3; // x is assigned the value 3
    int y = new int(); // y is a value type, initialized to 0 by default
    y = x; // y is assigned the value of x (which is 3), a copy of x is made
    y = 4; // y is now assigned the value 4, x remains unchanged
    return x; // x still holds the value 3



Reference Type: MyIntx and MyIntY reference to the same object after assignment so changing the object through "y" also reflects "x"

    MyInt x = new MyInt(); // x is a reference type, points to a new MyInt object
    x.MyInt = 3; // The MyInt property of the object x points to is set to 3
    MyInt y = new MyInt(); // y is a reference type, points to a new MyInt object
    y = x; // y is now referencing the same object as x
    y.MyInt = 4; // The MyInt property of the shared object is now set to 4

 */


//1) Hur fungerar stacken och heapen? Förklara gärna med exemple eller skiss på dess grundlägande funktion.
/*
class Program
{
    static void Main()
    {
        // 'x,y' is a value type and stored on the stack
        int x = 10; 
        int y = 20; 

        // 'person' is a reference type, so the reference 'person' is stored on the stack,
        // but the actual 'Person' object is created and stored on the heap.
        Person person = new Person("Alice");

        // The 'Name' property is a string (reference type), so 'Name' is stored on the heap.
        // The reference to the string "Alice" is stored in the 'Name' property on the heap.
        
        Console.WriteLine($"x: {x}, y: {y}, person: {person.Name}");
        // 'x' and 'y' values are retrieved from the stack.
        // 'person.Name' is retrieved by first getting the reference from the stack, 
        // then accessing the 'Person' object on the heap, and finally getting the 'Name' property value.
    }
}

class Person
{
    public string Name { get; set; } // 'Name' is a property of reference type 'string', stored on the heap.

    public Person(string name)
    {
        // The 'name' parameter is a reference to the string passed in, stored on the heap.
        Name = name; // 'Name' property is assigned the reference to the string, so 'Name' points to the heap.
    }
}

 
// Variables are stored on either the stack or the heap, which one depends on whether the variable is of reference or value type, and on the context in which the variable is declared.

// Memory is divided into the stack and the heap.
// The stack can be seen as a set of boxes stacked on top of each other, where we use the contents of the topmost box and to access the one below, the box above must first be lifted off. For example, the stack can be seen as shoe boxes in a shoe store; to access the lower boxes, you must lift away the upper ones.

// The stack stores local variables and the heap stores reference type variables

// THE STACK: keeps track of which calls and methods are running. When a method is executed, it is thrown from the stack, and the next one runs. It is self-maintaining and needs no help with memory. Last-in, first-out; to get a plate, you must take one from the top (pop), and to add a plate, you must add it to the top of the stack (push). The stack is a simple data structure, and its two operations – push and pop – are fast and efficient.
THE STACK: Used for fast memory allocation of value types and method calls. Memory is managed automatically.

// THE HEAP is a form of structure where everything is accessible at once with easy access. We can liken the heap to a pile of clean laundry spread out over a bed.
Used for data that needs to exist for a longer time.
THE HEAP: Holds a large amount of information (but does not keep track of the execution order) and requires concern for garbage collection (GC). In other words: the stack maintains itself while the laundry pile must be cleaned of dirty laundry occasionally.
THE HEAP: Any item in a heap can be accessed at any time.
THE HEAP: Used for more flexible and long-lived memory allocation of reference types. Memory is managed by the garbage collector.
*/


//2) Vad är value types respektive reference types och vad skiljer dem åt?
/*

Value Types: e.g int, bool, double, struct, enum are stored directly on the stack, when we assign a value type to another , it copies the actual value. The memory are managed automatically by the system and typically fatser to access because they are stored on the stack.
Refernce Typess: e.g class, string, array, delegate, interface are stored on the Heap, but the reference (or pointer) to the data is stored on the stack. When we assign a reference type variable to another, it copies the reference to the object, not the actual data. Both variables then point to the same object.The memory are managed by the gabrbage collecotr GC, which cleans up unused objects on the heap.

Differnces: Value types are stored on the stack.
            Value types hold the actual data.
            Copying a value type copies the actual data.

            Reference types are stored on the heap.
            Reference types hold a reference to the data.
            Copying a reference type copies the reference to the data, not the data itself.

 */

//3) Följande metoder(se bild nedan) generarar olika svar. Den första retunerar 3, den andra retunerar 4, varför?

//Value Type: För att det först svaret körs på stacken eftersom den är value types x,y lagras på stacken
//Reference Type: Den andra lever i heapen altså lagras i minnet är refference type av class x lagras på stacken, men objektet lagras på heapen. allokerar minne på heapen för det.
//Första metoden använder värdetyper (int), där variablerna x och y är separata kopior av värden. Att ändra y påverkar inte x.



//Reference Tyep: MyInt x = new MyInt(); skapar ett nytt objekt x av typen MyInt och allokerar minne på heapen för det. y=x refererar til samma objekt på heapen.
//y.Myvalue=4; ändrar MyValue fältet för objektet som både x och y refererar till, vilket sätter MyValue till 4.
//return x.MyValue; returnerar MyValue-fältet för objektet som x refererar till, vilket nu är 4.
//Andra metoden använder referenstyper (MyInt), där x och y är referenser till samma objekt på heapen. Att ändra y.MyValue påverkar x.MyValue eftersom båda refererar till samma objekt.

