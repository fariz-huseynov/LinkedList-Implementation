using System;

class MainClass {
  public static void Main (string[] args) { 
    var linkedList = new LinkedList(10);
    linkedList.AddLast(5);
    linkedList.AddLast(16);
    var node1 = linkedList.Find(16);
    linkedList.AddBefore(node1,15);
    var node2 = linkedList.Find(15);
    linkedList.AddAfter(node2,17);
    linkedList.RemoveFirst();
    linkedList.RemoveLast();
    linkedList.Print();
   
    Console.WriteLine("Count: " + linkedList.Count+". Contains 18: "+linkedList.Contains(18).ToString());
  } 

}

public class LinkedListNode {
  public int Value {get; set;}
  public LinkedListNode Next {get; set;}
  public LinkedListNode Previous {get; set;}
  public LinkedListNode( int value){
  this.Value = value;
  this.Next = null;
  } 
}

public class LinkedList { 
  public LinkedListNode First {get; private set;}
  public LinkedListNode Last {get; private set;}
  public int Count {get;private set;} = 0;

  public LinkedList( int node){
    this.First = new LinkedListNode(node);
    this.Last = this.First;
    this.Count++;
  }

  public void AddFirst( int value){
    var newNode=new LinkedListNode(value);
    newNode.Next = this.First;
    this.First = newNode;
    this.Count++;
  }

  public void AddLast( int value){
    var newNode = new LinkedListNode(value); 
    this.Last.Next = newNode;
    this.Last = this.Last.Next;
    this.Count++;
  }

  public void AddAfter(LinkedListNode node, int value){
     var newNode = new LinkedListNode(value);
     if(node.Next!=null){
        newNode.Next=node.Next;
        node.Next=newNode;
     }else{
       node.Next = newNode;
     } 
     this.Count++;
  }

  public void AddBefore(LinkedListNode node, int value){
    var newNode = new LinkedListNode(value);
    var currentNode = this.First;
    while(currentNode.Next.Value != node.Value){
      currentNode = currentNode.Next;
    }
    newNode.Next = node;
    currentNode.Next = newNode;
    this.Count++;
  }
  
  public void RemoveFirst(){ 
    this.First = this.First.Next; 
    this.Count--;
  }

  public void RemoveLast(){ 
    var currentNode = this.First;
    while(currentNode.Next != null && currentNode.Next.Value != this.Last.Value){
      currentNode = currentNode.Next;
    }
    currentNode.Next=null;
    this.Count--;
  }

  public void Remove( int value){
    var currentNode = this.First;
    while(currentNode.Next.Value!=value){
      currentNode = currentNode.Next;
    }
    currentNode.Next=currentNode.Next.Next;
    this.Count--;
  }

  public LinkedListNode Find( int value){
    var currentNode = this.First;
    while(currentNode.Value!=value){
      currentNode = currentNode.Next;
    }
    return currentNode;
  }
 
  public void Print(){
    var currentNode = this.First;
    while(currentNode != null){
      Console.WriteLine(currentNode.Value);
      currentNode = currentNode.Next;
    }
  }

public bool Contains(int value){
  var currentNode = this.First;
  while(currentNode != null){
    if(currentNode.Value==value)
      return true;
      currentNode = currentNode.Next;
  }
  return false;
}
}
