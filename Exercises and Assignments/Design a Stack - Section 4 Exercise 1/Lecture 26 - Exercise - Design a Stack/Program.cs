﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Exercise: Design a Stack

A Stack is a data structure for storing a list of elements in a LIFO (last in, first out) fashion.

Design a class called Stack with three methods.
void Push(object obj)
object Pop()
void Clear()

The Push() method stores the given object on top of the stack. We use the “object” type here so
we can store any objects inside the stack. Remember the “object” class is the base of all classes
in the .NET Framework. So any types can be automatically upcast to the object. Make sure to
take into account the scenario that null is passed to this object. We should not store null
references in the stack. So if null is passed to this method, you should throw an
InvalidOperationException. Remember, when coding every method, you should think of all
possibilities and make sure the method behaves properly in all these edge cases. That’s what
distinguishes you from an “average” programmer.

The Pop() method removes the object on top of the stack and returns it. Make sure to take into
account the scenario that we call the Pop() method on an empty stack. In this case, this method
should throw an InvalidOperationException. Remember, your classes should always be in a valid
state and used properly. When they are misused, they should throw exceptions. Again, thinking
of all these edge cases, separates you from an average programmer. The code written this way
will be more robust and with less bugs.

The Clear() method removes all objects from the stack.

We should be able to use this stack class as follows:
var stack = new Stack();
stack.Push(1);
stack.Push(2);
stack.Push(3);

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());

The output of this program will be
3
2
1

Note: The downside of using the object class here is that if we store value types (eg int, char,
bool, DateTime) in our Stack, boxing and unboxing occurs, which comes with a small
performance penalty. In my C# Advanced course, I’ll teach you how to resolve this by using
generics, but for now don’t worry about it. 
// Then why did he talk about it in Lecture 24 - Boxing and Unboxing
// .http://www.csharpstar.com/csharp-program-stack-push-pop/
*/

namespace Lecture_26___Exercise___Design_a_Stack
{
    class Stack
    {
        //private object _stack { get; set; }
        //private Stack<object> _stack = new Stack<object>();
        private List<object> _stack = new List<object>();

        public Stack()
        {
            Console.WriteLine("Inside Stack constructor");
        }

        public void Push(object obj)
        {
            // if null is passed to this method
            // throw InvalidOperationException
            
            if (obj != null)
            {
                _stack.Add(obj);
                // Console.WriteLine("Pushing onto the stack " + obj);
            }
        }

        public object Pop()
        {
            // Removes the object from top of stack and returns it
            // if Pop() is called on empty stack,
            // throw InvalidOperationException
            try
            {
                if (_stack.Count > 0)
                {
                    var index = _stack.Count - 1;
                
                    var toReturn = _stack[index];
                    _stack.RemoveAt(index);

                    return (toReturn);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("OOPs");
            }
            return 0;
        }

        void Clear()
        {
            // Removes all objects from the stack
            _stack.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Stack<object> stack = new Stack<object>();
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            //stack.Push(null);
            //stack.Push("My Sharona");

            Console.WriteLine("Popping off " + stack.Pop());
            Console.WriteLine("Popping off " + stack.Pop());
            Console.WriteLine("Popping off " + stack.Pop());
        }
    }
}
