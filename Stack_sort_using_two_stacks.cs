using System; 
using System.Collections.Generic; 
  
class Program 
{ 
public static Stack<int> sortstack(Stack<int> input) 
{ 
    Stack<int> tmpStack = new Stack<int>(); 
    while (input.Count > 0) 
    { 
        int tmp = input.Pop();  
        while (tmpStack.Count > 0 && tmpStack.Peek() > tmp) 
        { 
            input.Push(tmpStack.Pop()); 
        } 
        tmpStack.Push(tmp); 
    } 
    return tmpStack; 
} 
  
public static void Main(string[] args) 
{ 
    Stack<int> input = new Stack<int>(); 
    input.Push(34); 
    input.Push(3); 
    input.Push(31); 
    input.Push(98); 
    input.Push(92); 
    input.Push(23); 
  
    Stack<int> tmpStack = sortstack(input); 
    Console.WriteLine("Sorted numbers are:"); 
    while (tmpStack.Count > 0) 
    { 
        Console.Write(tmpStack.Pop() + " "); 
    } 
} 
} 
