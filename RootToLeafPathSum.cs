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

public class Tree 
{ 
	public Node root; 

	public virtual int treePathsSum(Node root,int sum) 
	{ 
	    if(root==null)
	      return 0;
	    sum=(sum*10+root.data);
	    if(root.left==null && root.right==null)
		return sum;

	    return treePathsSum(root.left,sum)+treePathsSum(root.right,sum);
	} 

	public static void Main(string[] args) 
	{ 
		Tree tree = new Tree(); 
		tree.root = new Node(6); 
		tree.root.left = new Node(3); 
		tree.root.right = new Node(5); 
		tree.root.right.right = new Node(4); 
		tree.root.left.left = new Node(2); 
		tree.root.left.right = new Node(5); 
		tree.root.left.right.right = new Node(4); 
		tree.root.left.right.left = new Node(7); 

		Console.Write("Sum of all paths is " + tree.treePathsSum(tree.root,0)); 
	} 
} 

