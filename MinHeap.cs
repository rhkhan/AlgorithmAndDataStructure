using system;

public class BinaryMinHeap{
  int[] data;
  int heapsize;
  
  public BinaryMinHeap(int size){
    data=new int[size];
    heapsize=0;
  }
  
  public int getMinimum(){
    if(heapsize==0)
      throw new KeyNotFoundException();
    else
      return data[0];
  }
  
  public int  getLeftChildIndex(int index){
    return 2*index+1;
  }
  
  public int getRightChildIndex(int index){
    return 2*index+2;
  }
  
  public int getParentIndex(int index){
    return (index-1)/2;
  }
  
  public void insert(int item){
    if(heapsize>=data.Length)
      throw new IndexOutOfRangeException();
      
    data[heapsize]=item;
    heapifyUP(heapsize);
    heapsize++;
  }
  
  public void heapifyUP(int index){
    if(index==0)
     return;
    
    int parentIndex=getParentIndex(index);
    if(data[parentIndex]>=data[index]){
      int tmp=data[parentIndex];
      data[parentIndex]=data[index];
      data[index]=tmp;
      heapifyUP(parentIndex);
    }
  }
  
  public void removeMin(){
    if(heapsize==0)
      throw new KeyNotFoundException();
    else{
      data[0]=data[heapsize-1];
      if(heapsize>0)
        heapifyDOWN(0);
      heapsize--;
    }
  }
  
  public void heapifyDOWN(int index){
    int left=getLeftIndex(index);
    int right=getRightIndex(index);
    
    if(right>=heapsize){
      if(left>=heapsize)
       return;
      else
       smallest=left;
    }
    else{
      if(data[left]<=data[right]
       smallest=left;
      else
       smallest=right;
    }
   if(data[index]>data[smallest]){
     int tmp=data[index];
     data[index]=data[smallest];
     data[smallest]=tmp;
     heapifyDOWN(smallest);
   }
  }
}

//Driver function
public static void main(string[] args){
 BinaryMinHeap bmp=new BinaryMinHeap(6);
 bmp.insert(1);
 bmp.insert(2);
 bmp.insert(3);
 Console.WriteLine(bmp.getMinimum());
 bmp.removeMin();
 Console.WriteLine(bmp.getMinimum());
 Console.Read();
}
