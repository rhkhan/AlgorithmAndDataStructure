//############## Sort a stack using recursion #################
/*
        s.Push(30);  
        s.Push(-5);  
        s.Push(18);  
        s.Push(14);  
        s.Push(-3);

 berfore sort: -3->14->18->14->-30

 void sortStack(Stack<int> s)
 {
  if(s.Count>0){
    int tmp=s.Pop();
    sortStack(s);
    sortedInsert(s,tmp);
  }
 }

 void sortedInsert(Stack<int> st, int x)
 {
   if(st.Count==0 || x>st.Peek())
   {
     st.Push(x);  
     return;
   }
   int tmp=st.Pop();
   sortedInsert(st,x);
   st.Push(temp);
 }

Illustration:
1. sortStack method: untill stack becomes empty, Pop element from stack recursively and store the Popped values in a tmp variable
2. sortStack method: when stack becomes empty then call the recursive method sortedInsert with the stored values in the tmp one by one.
   tmp contains: [-3, 14, 18, 14, -30]
3. sortedInsert: if stack is empty OR the new value received from temp is greater then the top of the stack then push the newValue into the stack
4. sortedInsert: Pop value from the stack and store in a variable and recursively call sortedInsert to compare the next top element of stack with the newValue
5. sortedInsert: finally push the value stored in the variable into the stack
6. Continue the Operation for each of the tmp values found in step 2.

*/
