/*
 - store the nodes of the linked list in an array
 - check longest palindrome in the array
*/

int max=int.MinValue;
int longestPalindrome(int[] arr)
{
  int i=0;
  while(i<arr.length)
  {
    int count=0;
    int L=i;
    int R=arr.length-1;
    while(L<R)
    {
     if(arr[L]==arr[R])
     {
       count++;
       L++;R--;
     }
     else
     {
      R--;
     }
    }
    
    if(count>max)
     max=count;
  }
  
  return max;
}
