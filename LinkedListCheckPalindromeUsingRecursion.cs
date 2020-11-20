Node head1,head2;
head1 = head;
isPalindrome(head); // calling function
bool isPalindrome(Node head2) 
    { 
        //head1=head;
        if (head2 == null) 
            return true; 
 
        bool isp = isPalindrome(head2.next); 
        if (isp == false) 
            return false; 
 
        /* Check values at current head1 and head2 */
        Boolean isp1 = (head2.data == head1.data); 
        if(isp1==false)
           reurn false;
        
        head1 = head1.next; 
 
        return isp1; 
    } 
