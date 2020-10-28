using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using System.Collections;
using System.Linq;
using System.Globalization;
using System.Diagnostics;

namespace Data_Structures
{
    class DisplayDataStructures
    {
        static string NameFile = "Names.txt";
        Stack stack;
        Queue q;
        static Hashtable nameHash;
        static Stopwatch sw;

        string[] names;
        public void DataStructures()
        {
            stack = new Stack();
            nameHash = new Hashtable();
            q = new Queue();
            sw = new Stopwatch();
            LoadNames();
        }

         public void LoadNames()
        {
            names = File.ReadAllLines(NameFile);
            for(int i =0; i < names.Length; i++)
            {
                nameHash.Add(i, names[i]);
                stack.Push( names[i]);
                q.Enqueue(names[i]);
            }

            Array_VS_Map();
            Stack_Vs_Queue();
        }

        void Array_VS_Map()
        {
            //The Array is able to search throughout the entire data structure until it's able to find the value that it's searching for. But since it's a fixed size, you cannot adjust the size of the array
            string nameFound = ArraySearch();
            WriteLine($"Found {nameFound}");
            WriteLine($"The starting position in the hashtable is {names[0]}\n"); 

            //The hashtable requires a key to be matched with an object value. Because of this, the data structure can immediately go to the key in the hashtable and obtain the value in it.
            //This works especially well with Employee IDs or product IDs. 
            //Unlike arrays, Hashtables are able to remove objects and not have an errors when the size decreases.
            nameFound = (string)nameHash[4923]; //4923 is the position in which the name "Zelda is stored inside the HashTable
            WriteLine($"Found {nameFound}");
            WriteLine($"The starting position in the hashtable is {(string)nameHash[0]}\n\n");

            //The different between an array and a hashtable/map is that array have a fixed size, while hashtables/maps are able to remove and adjust its size while also having a key attached to the value.
            //So when a system is using something like Order#s or Employee IDs, values that have a Key attached, then Hashtables would be more appropriate. However, when a system is just using something like
            //a simple list of names, then an array is more appropriate.
        }

        void Stack_Vs_Queue()
        {
            //Stack is a Last In First Out (LiFo). Meaning the last item pushed into the stack is the first element. Stacks have a keyword attached called Pop()
            //that removes the top element in the stack, but the element can't be specified. It always has to be the top element.
            string nameFound = StackSearch();
            WriteLine($"Found {nameFound}");
            WriteLine($"The starting position in the stack is {stack.Pop()} and it's now removed.\n");

            //Queue is a First In First Out(FiFo). Meaning that the first item in the queue, will the be the first element. Queue has a keyword called Dequeue()
            //that takes the first element in the queue, and moves it to the end/or top of the Queue making it the last element. 
            nameFound = QueueSearch();
            WriteLine($"Found {nameFound}");
            WriteLine($"The starting position in the stack is {q.Dequeue()} and it's now at the top of the Queue\n\n");

            //Both data structures are able to removes items. though stack can only remove the top element, so they can have adjustable sizes. The only difference between the two is the order in which the
            //elements are inserted.
            //Stacks and Queues are equally as efficient as the other. It really all depends on what order you want the data structure to be.
        }

        string ArraySearch()
        {
            for(int i = 0; i < names.Length; i++)
            {
                if(names[i] == "Zelda")
                {
                    return names[i];
                }
            }
            return String.Empty;
        }

        string StackSearch()
        {
            foreach(string s in stack)
            {
                if(s == "Dorothea")
                {
                    return s;
                }
                
            }
            return String.Empty;
        }

        string QueueSearch()
        {
            foreach(string q in q)
            {
                if(q == "Dorothea")
                {
                    return q;
                }
            }
            return String.Empty;
        }
    }
}
