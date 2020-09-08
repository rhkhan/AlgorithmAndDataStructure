public bool isBalanced(string str)
{
  Stack<char> st=new Stack<char>();
  for(int i=0;i<str.Length;i++)
  {
    if(str[i]=='(' || str[i]=='{' || str[i]=='[')
      st.push(str[i]
    else
    {
      if(st.Count==0) return false;
      else
      {
        if(str[i]==')')
        {
          if(st.Pop()!='(')
           return false;
        }
        else if(str[i]=='}')
        {
         if(st.Pop()!='{')
           return false;
        }
        else if(str[i]==']')
        {
         if(st.Pop()!='[')
           return false;
        }
      }
    }
  } //end for
   return st.Count==0;
}
