/*Approach 1:
1. Two loops for two lists
2. Outer loop data will be comparing the data with the inner loop list data
3. If matching is found then return the data
Time complexity: O(m*n) where m and n are number of nodes of two lists

Approach 2:
1. Add an extra boolean field in the node class, namely visited
2. Traverse the first list and set visited to true
3. Traverse the second list and if visited is found true, then retur the data
Time complexity: O(m+n)

Approach 3: using hashmap
1. traverse the first list and store data into hasmap
2. traverse the second list and if key is found in hasmap then return the key/node data
Time complexity: O(m+n)
*/

public static Node getIntersectedNode(Node n1, Node n2) 
    { 
        // define hashset 
        HashSet<Node> hs = new HashSet<Node>(); 
        while (n1 != null)  
        { 
            hs.Add(n1); 
            n1 = n1.next; 
        } 
        while (n2 != null) 
        { 
            if (hs.Contains(n2))  
            { 
                return n2; 
            } 
            n2 = n2.next; 
        } 
        return null; 
    } 
