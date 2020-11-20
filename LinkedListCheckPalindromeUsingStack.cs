static bool isPalindrome(Node head)
{
    Node current = head;
    bool ispalin = true;
    Stack<int> stack = new Stack<int>();
 
    while (current != null)
    {
        stack.Push(current.data);
        current = current.next;
    }
 
    while (head != null)
    {
        int d = stack.Pop();
        if (head.data == d) 
            ispalin = true;
        else
        {
            ispalin = false;
            break;
        }
        head = head.next;
    }
    return ispalin;
}
}
