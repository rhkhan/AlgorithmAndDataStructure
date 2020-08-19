// Disjoint Set Data Structure. 
using System; 
	
class DisjointSet
{ 
	int[] rank, parent; 
	int n; 

	// Constructor 
	public DisjointSet(int n) 
	{ 
		rank = new int[n]; 
		parent = new int[n]; 
		this.n = n; 
		makeSet(); 
	} 

	public void makeSet() 
	{ 
		for (int i = 0; i < n; i++) 
			parent[i] = i; 
	} 

	public int find(int x) 
	{ 
		if (parent[x] != x) 
			parent[x] = find(parent[x]); 
      
		return parent[x]; 
	} 


	public void union(int x, int y) 
	{ 
		int xRoot = find(x), yRoot = find(y); 
		if (xRoot == yRoot) 
			return; // no need to do union operation

		// If x's rank is less than y's rank 
		if (rank[xRoot] < rank[yRoot]) 
			parent[xRoot] = yRoot; 
		else if (rank[yRoot] < rank[xRoot]) 
			parent[yRoot] = xRoot; 
		else // if ranks are the same 
		{ 
			parent[yRoot] = xRoot; 
			rank[xRoot] = rank[xRoot] + 1; 
		} 
	} 
} 

// Driver code 
class Program 
{ 
	public static void Main(String[] args) 
	{ 
		// Let there be 5 persons with ids as 
		// 0, 1, 2, 3 and 4 
		int n = 5; 
		DisjointSet ds = new DisjointSet(n); 

		// 0 is a friend of 2 
		ds.union(0, 2); 
		// 4 is a friend of 2 
		ds.union(4, 2); 
		// 3 is a friend of 1 
		ds.union(3, 1); 

		// Check if 4 is a friend of 0  
      Console.WriteLine(ds.find(4) == ds.find(0)?"Yes":"No"); 
      
		// Check if 1 is a friend of 0 
      Console.WriteLine(ds.find(1) == ds.find(0)?"Yes":"No"); 
	} 
}
