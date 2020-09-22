using System; 
using System.Collections.Generic; 

public class LinkedListNode 
{ 
	public int data; 
	public LinkedListNode next; 
	public LinkedListNode(int d) 
	{ 
		data = d; 
		next = null; 
	} 
} 

public class BinaryTreeNode 
{ 
	public int data; 
	public BinaryTreeNode left, right = null; 
	public BinaryTreeNode(int data) 
	{ 
		this.data = data; 
		left = right = null; 
	} 
} 

public class BinaryTree 
{ 
	LinkedListNode head; 
	BinaryTreeNode root; 
  
	void push(int new_data) 
	{ 
		// allocate node and assign data 
		ListNode new_node = new ListNode(new_data); 

		// link the old list off the new node 
		new_node.next = head; 

		// move the head to point to the new node 
		head = new_node; 
	} 

	BinaryTreeNode convertListToBinary(BinaryTreeNode node) 
	{ 
		Queue<BinaryTreeNode> q = new Queue<BinaryTreeNode>(); 

		// Base Case 
		if (head == null) 
		{ 
			node = null; 
			return node;
		} 
    
		node = new BinaryTreeNode(head.data); 
		q.Enqueue(node); 

		// advance the pointer to the next node 
		head = head.next; 

		// until the end of linked list is reached
		while (head != null) 
		{ 
			BinaryTreeNode parent = q.Dequeue(); 
			
			// 2.c) take next two nodes from the linked list. 
			// We will add them as children of the current 
			// parent node in step 2.b. Push them into the 
			// queue so that they will be parents to the 
			// future nodes 
			BinaryTreeNode leftChild = null, rightChild = null; 
			
			leftChild = new BinaryTreeNode(head.data); 
			q.Enqueue(leftChild); 
			head = head.next; 
			
			if (head != null) 
			{ 
				rightChild = new BinaryTreeNode(head.data); 
				q.Enqueue(rightChild); 
				head = head.next; 
			} 

			// 2.b) assign the left and right children of 
			//	 parent 
			parent.left = leftChild; 
			parent.right = rightChild; 
		} 
		
		return node; 
	} 

	void inorderTraversal(BinaryTreeNode node) 
	{ 
		if (node != null) 
		{ 
			inorderTraversal(node.left); 
			Console.Write(node.data + " "); 
			inorderTraversal(node.right); 
		} 
	} 

	// Driver code 
	public static void Main() 
	{ 
		BinaryTree tree = new BinaryTree(); 
		
		/* Last node of Linked List */
		tree.push(36); 
		tree.push(30); 
		tree.push(25); 
		tree.push(15); 
		tree.push(12); 
		
		/* First node of Linked List */
		tree.push(10); 
		BinaryTreeNode node = tree.convertListToBinary(tree.root); 

		Console.WriteLine("Inorder Traversal of the constructed Binary Tree is:"); 
		tree.inorderTraversal(node); 
	} 
} 

