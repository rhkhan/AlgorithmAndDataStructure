/*
Approach 1:
 - Do in-order traversal of tree
 - make the first node of the tree as the head of the list
 - traverse the tree until the left and right child of a node is null
 - if node is the head then set the next node
 - if node is not the head then set next and prev pointer
 - if node is last the set the next to head and prev to the previous node
*/
