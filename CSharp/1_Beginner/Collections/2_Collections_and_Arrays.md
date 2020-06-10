
## Introducing collections and arrays.

  * Collection for multiple items
  * Coding with arrays.
      - Enumerate data
      - Look-up / replace data
  * Zero based indexing
  * Collection debugging

### What is a collection?

Type whose purpose is to group data together, and let you deal with lots of objects at the same time.

Collections let you treat lots of objects as one single object.

Collection instance:
  -> Search
  -> Doing something with every item in the collection.  (Enumerate)


There are a lot of options, but the three more mentioned in this course:

  Array - List - Dictionary

Those are the most widely used general purpose collection.

### The Array:  A fixed sized, ordered collection.

1. Contains fixed number of items
2. Definite order.

A good example is the days of the week. They don't change. They remain the same. Always.

[] -> Tell the compiler it is an array.
{} -> we put here the items of our array.

```
string[] days_of_week = {
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
};
```

### Enumerating an array.

foreach loop. Simplest way to iterate every single item in the collection.

foreach (var day in days_of_week) {
  Console.WriteLine(day);
}

* Other array of type Drawing.Point
  System.Drawing.Point[] points = {
    new System.Drawing.Point(3,5),
    new System.Drawing.Point(9,9),
    new System.Drawing.Point(18,5),
  }


### Some collection terminology

- Element or Item: An object (or struct) in a collection
- Enumerate or Iterate: Go through each element in turn.

### Looking up array items.

Access an individual item in a collection.

Console.WriteLine("Ingrese número");
int n = int.Parse(Console.ReadLine());


days_of_week[position_you_want_to_see];  // index

### Arrays are Zero-indexed

First element is 0;
Last element is Size-1

### Collections are safe.

Collections, nor only arrays, are safe against bad lookups. Meaning, if you try to access a position which is not part of the collection, there will be an error. For instance, if a try to access days_of_week[8], an exception will be thrown.

### Converting between zero-based and One-based indexing.

days_of_week[n-1];

Historically, 0 indexing was for working easier with memory and because it performed better.

### Replacing arrays items.

days_of_week[2] = "Modification";

### debugging with arrays

### Arrays to other collections

Same principles for most collections:
  1. square bracket look-up syntax
  2. foreach lookups
  3. 0-based indexing
  4. Integration with the debugger.


### Summary

Collections group items together.
foreach
[] identify
Zerobased indexed
