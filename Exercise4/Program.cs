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
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter '{+item}' to add or '-item' to remove(or '0' to return to main menu):");
                string input = Console.ReadLine()!;
                if (input == "0") break;

                char nav = input[0];
                string value = Console.ReadLine()!;
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Add '{value}'. Count: {theList.Count}, Capacity:{theList.Capacity}");
                        break;
                    case '-':
                        theList.Add(value);
                        Console.WriteLine($"Remove '{value}'. Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
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
                           string LastInQueue= queue.Last();
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
                catch(Exception ex) {
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
            if(string.IsNullOrEmpty(text))
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
            char[] reversedChar= new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                reversedChar[i] = itemStack.Pop();
            }
            //converts the reversedChars array back into a string.
            return new string(reversedChar);
        Console.WriteLine("Enter text");
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
                char lastChar = input[input.Length -1];

                //check if the first charachter char has a corresponding closing charachter charand if it matches the last character
                if(validPairs.ContainsKey(firstChar) && validPairs[firstChar]== lastChar)
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

   The stack is used for storing value types and method calls with automatic memory management, while the heap is used for dynamic memory allocation, particularly for reference types, with memory managed by the garbage collector.
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
 //variables are stored on either the stack or heap, which one depends on whether the variable is of reference or value type, and on the context in which the variable is declared.

// Minnet är updelat i en stacken och HEAPEN.
//Stacken kan ses som en mängd boxar staplade på varandra. där vi använder innehållet i den översta boxen och för att komma åt den undre måste den ovanstående boxen först lyftas av.exmpelvis stacken kan ses som skolådor i en skobutik för att komma åt den nedre lådorna måste lyftta bort de övre.

//The stack stores local variables and the heap stores reference type variables 

//STACKEN: har koll på vilka anrop och metoder som körs, när metoden körd kastas den från stacken och nästa körs är självunderhållande och behöver ingen hjälp med minnet.last-in, first-out,to get a plate you must take one from the top (pop), to add a plate you must add it to the top of the stack (push).The stack is a simple data structure and its two operations – push and pop – are fast and efficient. 
 STACKEN: Används för snabb minnesallokering av värdetyper och metodanrop. Minnet hanteras automatiskt.


//HEAPEN är en form av struktur där allt är tillgängligt på en gång med enkel åtkomst. vi kan likna HEAPEN med en hög med ren tvätt som ligger utspridd över an säng
 Används för data som behöver existera under en längre tid 
//HEAPEN: Håller stor del av infromationen (men inte har någne koll på exekveringordning) behöver orao sig för GARBAGE COLLECTION (GC). ALLSTÅ: skorkarongerna sköter sig själv medan tvätthögen måste renas på smutsig tvätt ibland.
HEAPEN: any item in a heap can be accessed at any time.
HEAPEN: Används för mer flexibel och långlivad minnesallokering av referenstyper. Minnet hanteras av garbage collectorn.
*/


//2) Vad är value types respektive reference types och vad skiljer dem åt?
/*
 Value Type är typer från sysem.valuetypen e.g: bool,byte,enum,int,long,unit,double
The type of a variable – specifically whether it's a reference or value type – and the context in which it was declared, determine whether it is stored on the stack or heap.
//A value type variable does hold the value to which it is associated.

Reference types är typer som class ,interface,string, delegate, object 
Refernce lagras alltid på HEAPEN, medan Value Types lagras där de deklareras
//Reference type variable does not hold the value of the object it refers to, it holds a reference to that object.

A value type is a type that when declared as a variable, allocates some data at a memory address. A reference type is similar, but as its name suggests the variable in this case would instead hold a reference (memory address) to another part of memory where the memory for the data actually lives.

 */

//3) Följande metoder(se bild nedan) generarar olika svar. Den första retunerar 3, den andra retunerar 4, varför?

//Value Type: För att det först svaret körs på stacken eftersom den är value types x,y lagras på stacken
//Reference Type: Den andra lever i heapen altså lagras i minnet är refference type av class x lagras på stacken, men objektet lagras på heapen. allokerar minne på heapen för det.
//Första metoden använder värdetyper (int), där variablerna x och y är separata kopior av värden. Att ändra y påverkar inte x.



//Reference Tyep: MyInt x = new MyInt(); skapar ett nytt objekt x av typen MyInt och allokerar minne på heapen för det. y=x refererar til samma objekt på heapen.
//y.Myvalue=4; ändrar MyValue fältet för objektet som både x och y refererar till, vilket sätter MyValue till 4.
//return x.MyValue; returnerar MyValue-fältet för objektet som x refererar till, vilket nu är 4.
//Andra metoden använder referenstyper (MyInt), där x och y är referenser till samma objekt på heapen. Att ändra y.MyValue påverkar x.MyValue eftersom båda refererar till samma objekt.

