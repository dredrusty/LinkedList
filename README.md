[![NuGet stable version](https://badgen.net/nuget/v/VV.DataStructure.LinkedList)](https://www.nuget.org/packages/VV.DataStructure.LinkedList)
[![Build status](https://dev.azure.com/rustyvik/DataStructures.LinkedList/_apis/build/status/linkedlist.build)](https://dev.azure.com/rustyvik/DataStructures.LinkedList/_build/latest?definitionId=17)
[![Azure DevOps tests](https://img.shields.io/azure-devops/build/rustyvik/DataStructures.LinkedList/18)](https://dev.azure.com/rustyvik/DataStructures.LinkedList/_build?definitionId=18&branchName=develop)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=style-flat&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=style-flat&logo=c-sharp&logoColor=white)


# LinkedList
This is a C# class library that describes LinkedList data structure.</br>
Provides a standard set of operations for working with a linked list, including cloning.</br>
Implemented `IList` methods.</br>
It is also possible to subscribe to events raised by certain operations on an instance of a `LinkedList`.</br>
Comparison operators are implemented for nodes.

## Installation

	dotnet add package VV.DataStructure.LinkedList --version 2.0.0-CI-20230830-191441
    

## LinkedList&lt;TValue>

To avoid an ambiguous reference between `System.Collections.Generic.LinkedList<T>` and `VV.DataStructure.LinkedList.LinkedList<TValue>` you can use using alias.
For example, 
```csharp
using MyList = VV.DataStructure.LinkedList;
```


### Examples of using
There are two ways to create `LinkedList`:</br>

- create an empty `LinkedList`:</br>
```csharp
MyList.LinkedList<TValue> list = new();
```

- or pass to constructor any `IEnumerable<T>` collection:</br>
```csharp
string[] array = new string[2] { "abc", "ABC"};
MyList.LinkedList<string> list = new(array);
```

Also:

- you can get the number of elements in `LinkedList`:</br>
```csharp
Console.WriteLine(list.Count);
//returns 2
```
- you can find a value of the element by index:</br>
```csharp
list.Get(0);
//returns abc
```
- you can manually fill the list. Every element will be added in th end of the `LinkedList`:</br>
```csharp
list.Add("qwerty");
list.Add("QWERTY");
```
- you can update the value of an element at a given index:</br>
```csharp
list.Update(2, "ytrewq"); 
```
- you can use foreach:</br>
```csharp
foreach(string item in list)
Console.WriteLine(item);
//returns abc ABC ytrewq QWERTY
```
- you can get an index of a specific element of the `LinkedList`:</br>
```csharp
list.IndexOf(0);
//returns abc
list.IndexOf(10);
//returns -1
```
- you can insert an item to the `LinkedList` at the specified index:</br>
```csharp
list.Insert(1, "boom");
```
- you can delete an item from the `LinkedList` at the specified index:</br>
```csharp
list.RemoveAt(2);
```
- you can determine whether the `LinkedList` contains a specific value:</br>
```csharp
list.Contains("QWERTY");
//returns true
```
- you can сopy the elements of the `LinkedList` to an array, starting at a particular array index:</br>
```csharp
string [] array = new[7];
list.CopyTo(array, 0);
//returns abc boom ytrewq QWERTY null null null
```
- you can remove the first occurrence of the specified item from the `LinkedList`:</br>
```csharp
list.Remove("boom");
//returns true
```
- you can clear the `LinkedList`:</br>
```csharp
list.Clear();
Console.WriteLine(list.Count);
//returns 0
```
- you can clone the `LinkedList` and get a new `LinkedList` instance:</br>
```csharp
MyList.LinkedList listCloned = list.Clone();


### Events

There are 4 type of events implemented:
- OnElementInsert.
- OnElementRemove.
- OnElementUpdate.
- OnListChanged.

**Example of using:**
```csharp
list.Add (10);
list.Add (20);
list.Add (30);

void PrintDetails (object sender, LinkedListEventArgs<int> e)
{
    Console.WriteLine($"Item {e.Value} + was inserted at index {e.Index} + by {e.TriggerMethod} method.");
}

list.OnElementInsert += PrintDetails;

list.Insert(1, 40);

///Output
Item 40 + was inserted at index 1 + by Insert method.
```

### Events

There are 4 type of events implemented:
- OnElementInsert.
- OnElementRemove.
- OnElementUpdate.
- OnListChanged.

**Example of using:**
```csharp
list.Add (10);
list.Add (20);
list.Add (30);

void PrintDetails (object sender, LinkedListEventArgs<int> e)
{
    Console.WriteLine($"Item {e.Value} + was inserted at index {e.Index} + by {e.TriggerMethod} method.");
}

list.OnElementInsert += PrintDetails;

list.Insert(1, 40);

///Output
Item 40 + was inserted at index 1 + by Insert method.
```

## LinkedListNode&lt;TValue>
### Examples of using

- creation:</br>
```csharp
LinkedListNode<string> node1 = new("XYZ");
LinkedListNode<string> node2 = new("abc");
```
- ==:</br>
```csharp
var result = node1 == node2;
// returns false
```
- !=:</br>
```csharp
var result = node1 != node2;
// returns true
```
- <:</br>
```csharp
var result = node1 < node2;
// returns false
```
- \>:</br>
```csharp
var result = node1 > node2;
// returns true
```
- <=:</br>
```csharp
var result = node1 <= node2;
// returns false
```
- \>=:</br>
```csharp
var result = node1 >= node2;
// returns true
```

#### peculiarities:
1. IsReadonly is always `false` in this version.</br>

### Tests
Project covered by NUnit tests.
