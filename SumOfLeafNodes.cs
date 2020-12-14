using System;
public class Program
{
	public class Node
	{
		public int data;
		public Node left, right;

		// constructor 
		public Node(int data)
		{
			this.data = data;
			left = null;
			right = null;
		}
	}

	public static int sumOfLeafNodes(Node root, int sum)
	{
		if (root == null)
			return 0;
		if (root.left == null && root.right == null)
		{
			sum += root.data;
			return sum;
		}
		return sumOfLeafNodes(root.left, sum) + sumOfLeafNodes(root.right, sum);
	}

	public static void Main(string[] args)
	{
		Node root = new Node(1);
		root.left = new Node(2);
		root.left.left = new Node(4);
		root.left.right = new Node(5);
		root.right = new Node(3);
		root.right.right = new Node(7);
		root.right.left = new Node(6);
		root.right.left.right = new Node(8);
    
		int sum= sumOfLeafNodes(root,0);
		Console.WriteLine(sum);
		Console.Read();
	}
}

