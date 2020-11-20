1) Get the length of Linked List. Let the length be len. 
2) Print the (len – n + 1)th node from the beginning of the Linked List. 


 void printNthFromEnd(int n)  
    {  
        int len = 0;  
        Node temp = head;  
        while (temp != null)  
        {  
            temp = temp.next;  
            len++;  
        }  
        if (len < n)  
            return;  
  
        temp = head;  
  
        // 2) get the (len-n+1)th node from the beginning  
        for (int i = 1; i < len - n + 1; i++)  
            temp = temp.next;  
  
        Console.WriteLine(temp.data);  
    }  
