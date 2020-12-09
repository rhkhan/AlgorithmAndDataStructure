using System;
using System.Collections;

public class Node
{
  char data;
  Node left,right;
  public Node(char d)
  {
    this.data=d;
    left=right=null;
  }
}

public class ExpressionTree
{
  public bool isOperator(char c)
  {
    if(c=='+' || c=='-' || c=='*' || c=='/' || c=='^')
     return true;
    return false;
  }
  public Node constructTree(char[] postfixArr)
  {
    Stack<Node> st=new Stack<Node>();
    Node t,t1,t2;
    
    for(int i=0;i<postfixArr.Length;i++)
    {
      if(!isOperator(postfixArr[i])
      {
        t=new Node(postfixArr[i]);
        st.Push(t); //push the operands into stack
      }
      else
      {
        t=new Node(postfixArr[i]);
        t1=st.Pop();
        t2=st.Pop();
        t.left=t2;
        t.right=t1;
        st.Push(t);
      }
    }//end for
    
    return st.Pop(); // last element popped from the stack will be the root of the tree
  }
  
  public inorder(Node root)
  {
    if(root==null);
     return;
    inorder(root.left);
    Console.WriteLine(root.data+" ");
    inorder(root.right);
  }

  public static void Main(String[] args)
  {
    ExpressionTree et=new ExpressionTree();
    string postfix="ab+ef*g*-";
    char[] charArray=postfix.ToCharArray();
    Node root=et.constructTree(charArray);
    Console.WriteLine("infix expression is");
    et.inorder(root);
  }
}
