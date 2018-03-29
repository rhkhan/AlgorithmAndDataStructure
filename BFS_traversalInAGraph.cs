namespace BFS
{


    class Program
    {
         static LinkedList<Tuple<int>>[] adjacencyList;

        static void Main()
        {
            int V,edges;
            string[] edge;
            Console.WriteLine("Enter number of Vertex: ");
            V = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of edges: ");
            edges = Convert.ToInt32(Console.ReadLine());

            adjacencyList = new LinkedList<Tuple<int>>[V];

            // intitializing empty adjacent list
            for (int i = 0; i < adjacencyList.Length; i++) {
                adjacencyList[i] = new LinkedList<Tuple<int>>();
            }

            Console.WriteLine("Enter Source Vertex and Destination Vertex (int digit)");
            while (edges > 0) {
                edge = Console.ReadLine().Split(' ');
                int start = Convert.ToInt32(edge[0]);
                int end = Convert.ToInt32(edge[1]);

                addEdge(start, end);
                edges--;
            }

            Console.WriteLine("source and destination vertex list: ");
            printAdjacencyList();

            Console.WriteLine("Enter source vertex: ");
            int s=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Traverse graph using BFS from node: ");
            GraphTraverseBFS(s);

            Console.Read();
        }

        static void addEdge(int start, int end){
            adjacencyList[start].AddFirst(new Tuple<int>(end));
        }

        // Prints the Adjacency List
        static void printAdjacencyList()
        {
            int i = 0;

            foreach (LinkedList<Tuple<int>> list in adjacencyList)
            {
                Console.Write("adjacencyList[" + i + "] -> ");

                foreach (Tuple<int> edge in list)
                {
                    Console.Write(edge.t1 + " ");
                }

                ++i;
                Console.WriteLine();
            }
        }


        // ############### BFS traversal from a given source ###################
        static void GraphTraverseBFS(int u)
        {

            Queue<int> q=new Queue<int>(); // Create a queue for BFS
            bool[] visited=new bool[1000]; // boolean array to track visited vertex

            for(int i=0;i<visited.Length;i++)
                visited[i]=false; // mark all the vertices as not visited (By default set as false)

            
            q.Enqueue(u); // enque the starting vertex
            visited[u]=true; // mark it as visited

            while(q.Count>0){ // while queue is not empty
                u=q.Dequeue(); // dequeue a vertex from queue and print
                Console.Write(u+ " ");

                // Get all the adjacent vertices of the dequed vertex
                // If an adjacent vertex is not visited ten enqueue it and mark it as visited
                foreach (Tuple<int> t in adjacencyList[u])
                {
                    int n = t.t1;
                    if (!visited[n]) {
                        visited[n] = true;
                        q.Enqueue(n);
                    }
                }
                 
            }

        }
    }

    public class Tuple<T1>
    {
        public T1 t1 { get; private set; }
        //public T2 t2 { get; private set; }

        public Tuple(T1 item1) {
            t1 = item1;
            //t2 = item2;
        }
    }
    
    
}
