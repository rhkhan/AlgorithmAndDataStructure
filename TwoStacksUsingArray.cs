using System; 

public class TwoStacks { 
	public int size; 
	public int top1, top2; 
	public int[] arr; 

	public TwoStacks(int n) 
	{ 
		arr = new int[n]; 
		size = n; 
		top1 = -1; 
		top2 = size; 
	} 
  
	public virtual void push1(int x) 
	{  
		if (top1 < top2 - 1) { 
			top1++; 
			arr[top1] = x; 
		} 
		else { 
			Console.WriteLine("Stack Overflow"); 
			return;
		} 
	} 

	public virtual void push2(int x) 
	{ 
		if (top2>top1) { 
			top2--; 
			arr[top2] = x; 
		} 
		else { 
			Console.WriteLine("Stack Overflow"); 
			return;
		} 
	} 
  
	public virtual int pop1() 
	{ 
		if (top1 >= 0) { 
			int x = arr[top1]; 
			top1--; 
			return x; 
		} 
		else { 
			Console.WriteLine("Stack Underflow"); 
			return -1; // assuming stack will not store -1; 
		} 
		return 0; 
	} 

	public virtual int pop2() 
	{ 
		if (top2 <= size-1) { 
			int x = arr[top2]; 
			top2++; 
			return x; 
		} 
		else { 
			Console.WriteLine("Stack Underflow"); 
			return -1 // assuming stack will not store -1;
		} 
		return 0; 
	} 

	// Driver Code 
	public static void Main(string[] args) 
	{ 
		TwoStacks ts = new TwoStacks(5); 
		ts.push1(5); 
		ts.push2(10); 
		ts.push2(15); 
		ts.push1(11); 
		ts.push2(7); 
		Console.WriteLine("Popped element from" + " stack1 is " + ts.pop1()); 
		ts.push2(40); 
		Console.WriteLine("Popped element from" + " stack2 is " + ts.pop2()); 
	} 
} 

// This code is contributed by Shrikant13 
