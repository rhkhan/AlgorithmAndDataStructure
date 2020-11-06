import java.util.*;

class GFG{
	
static class Node 
{
	int val;
	Node left, right;
};

static Node newNode(int data)
{
	Node temp = new Node();
	temp.val = data;
	temp.left = temp.right = null;
	return temp;
}

static void dfs(Node root, int sum,
				ArrayList<Integer> pathSum)
{
	
	// Return if the node is NULL
	if (root == null)
		return;

	// Add value of the node to
	// the path sum
	sum += root.val;

	// Store the path sum if node is leaf
	if (root.left == null && 
	root.right == null)
	{
		pathSum.add(sum);
		return;
	}

	// Move to the left child
	dfs(root.left, sum, pathSum);

	// Move to the right child
	dfs(root.right, sum, pathSum);
}

static void findPathSum(Node root) 
{ 
	
	// To store all the path sum
	ArrayList<Integer> pathSum = new ArrayList<>();

	// Calling dfs function
	dfs(root, 0, pathSum);

	// Printing all the path sum
	for(int num : pathSum)
	{
		System.out.print(num + " ");
	} 
}

public static void main(String[] args)
{
	
	Node root = newNode(30);
	root.left = newNode(10);
	root.right = newNode(50);
	root.left.left = newNode(3);
	root.left.right = newNode(16);
	root.right.left = newNode(40);
	root.right.right = newNode(60);
	findPathSum(root); 
}
}
