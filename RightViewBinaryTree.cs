    public virtual void rightView(Node node, int level, 
                                        Max_level max_level) 
    { 
  
        // Base Case  
        if (node == null) 
        { 
            return; 
        } 
  
        // If this is the last Node of its level  
        if (max_level.max_level < level) 
        { 
            Console.Write(node.data + " "); 
            max_level.max_level = level; 
        } 
  
        // Recur for right subtree first, then left subtree  
        rightViewUtil(node.right, level + 1, max_level); 
        rightViewUtil(node.left, level + 1, max_level); 
    } 
