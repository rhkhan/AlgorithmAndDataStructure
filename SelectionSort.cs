public void sort(int[] arr)
{
  int n=arr.Length;
  for(int i=0;i<n-1;i++)
  {
    int minIndex=i;
    for(int j=i+1;j<n;j++)
    {
      if(arr[j]<arr[minIndex])
        minIndex=j;
    }
    
    int tmp=arr[i];
    arr[i]=arr[minIndex];
    arr[minIndex]=tmp;
  }
}
