// c# program to find sum of all numbers 
// that are formed from root to leaf paths 
using System; 

public class Node 
{ 
	public int data; 
	public Node left, right; 

	public Node(int item) 
	{ 
		data = item; 
		left = right = null; 
	} 
} 

class GFG 
{ 
public Node root; 

public virtual int treePathsSumUtil(Node node, 
									int val) 
{ 
	// Base case 
	if (node == null) 
	{ 
		return 0; 
	} 

	// Update val 
	val = (val * 10 + node.data); 

	if (node.left == null && node.right == null) 
	{ 
		return val; 
	} 

	// recur sum of values for left and right subtree 
	return treePathsSumUtil(node.left, val) + 
		treePathsSumUtil(node.right, val); 
} 

public virtual int treePathsSum(Node node) 
{ 
	return treePathsSumUtil(node, 0); 
} 

public static void Main(string[] args) 
{ 
	GFG tree = new GFG(); 
	tree.root = new Node(6); 
	tree.root.left = new Node(3); 
	tree.root.right = new Node(5); 
	tree.root.right.right = new Node(4); 
	tree.root.left.left = new Node(2); 
	tree.root.left.right = new Node(5); 
	tree.root.left.right.right = new Node(4); 
	tree.root.left.right.left = new Node(7); 

	Console.Write("Sum of all paths is " + 
				tree.treePathsSum(tree.root)); 
} 
} 

