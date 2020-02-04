//Include necessary import statements

public static int BinarySearchIterative(int[] arr,int keyVal){
  int minIndex=0;
  int maxIndex=arr.Length-1;

  while(minIndex<=maxIndex){
      int midIndex=(minIndex+maxIndex)/2;
      if(keyVal==arr[midIndex])
        return ++midIndex;
      else if(keyVal>midIndex){
        minIndex=midIndex+1; // If keyVal is greater then the mid the search in the right portion
      else
        maxIndex=midIndex-1; // else search in the left portion
  }
}
    return -1;
}
