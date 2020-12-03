/*
 Approach:
 - use two pointers prv and current
 - set prv=null and current=head
 - traverse linkedlist
 - while traversing until current!=null
 - check if prv!=null and compare prv.data with current.data
 - if current.data>prv.data
 - then set prev.next=current.next
 - set prev=current
 - set current=current.next
 - finally return head
*/
