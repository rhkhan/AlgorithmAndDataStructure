import java.util.*;

public class Tree{
	
static class Node 
{
	int val;
	Node left, right;
}

static Node newNode(int data)
{
	Node temp = new Node();
	temp.val = data;
	temp.left = temp.right = null;
	return temp;
}

static void dfs(Node root, int sum, ArrayList<Integer> pathSum)
{	
	if (root == null)
		return;
	
	sum += root.val;

	// Store the path sum if node is leaf
	if (root.left == null && root.right == null)
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
	ArrayList<Integer> pathSumList = new ArrayList<>();

	dfs(root, 0, pathSumList);

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
