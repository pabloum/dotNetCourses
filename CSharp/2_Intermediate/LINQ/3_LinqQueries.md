
---------------------------------------------------------------------------
---------------------------------------------------------------------------
#LINQ - Language Integrated Query.
---------------------------------------------------------------------------
---------------------------------------------------------------------------
|
|
*****************************
## 3. LINQ queries
*****************************

### Create custom Filter operator

I created an extension method to filter.

```
public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                               Func<T, bool> predicate)
{
    var result = new List<T>();

    foreach (var item in source)
    {
        if (predicate(item))
        {
            result.Add(item);
        }
    }

    return result;
}
```

### Creating an operator with Yield return

What deferred execution means?

In the previous implementation of Filer, we create first the List, then we do whatever we want with it.

There's other approach that uses `yield`. This code execution will begin ONLY when we try ti pull something out of that Enumerable that the method returns.

`yield` will help to create an IEnumerable

```
public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                               Func<T, bool> predicate)
{
    foreach (var item in source)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}
```
The `yield return` statement is what gives us the behavior known as Deferred Execution.

TODO ::: Explore this logic and syntax.

|
|
|
### Deferred execution explained  && Deferred execution advantages
 Fancy term that means that LINQ is as lazy as possible. It does the least amount of work it can get away with

 Any operation that inspects the results, will force the query to execute.
 e.g. Serialize the results into JSON or XML

 Not all LINQ methods are deferred.

There's one way to know if a method is deferred or not => MSDN Documentation

This is useful when you're not using all the resutls.

query.Take(1); // This would just take the first one, and would not execute the whole foreach statement for filtering

LEAST amount of work possible

 ```
 var enumerator = query1.GetEnumerator();

while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current.Title);
}
```

|
|
|
|
### Avoid pitfalls of Deferred execution  

For exameple when we call Count() method before actually using the elements.

When a method does not support deferred execution, and forces the entire query to complete before actually calling the method.

When you think that this might happen, there are ways to force that query into a concrete result with various methods: `.ToArray()<T>` , `ToList()<T>`

var query =  movies.Where(m => m.Year > 2000).ToList();


It is better to look in the documentation, but usually, methods that return an abstract type (such as Where() which returns IEnumerable) are deferred methods. On the other hand, methods such as ToList(), or Count(), return a concrete type (List<T> and int respectively) and must be executed immediately.

|
|
|
|
|

### Exceptions and Deferred queries

Deferred queries may also be tricky with exceptions

(It's generally bad practice to use the Base Exception class.)

Whe can declare empty queries like follows:

e.g.  `var query = Enumerable.Empty<Movie>();`

So, what you need to have inside the TRY block is the piece of code that forces the query no execute and not the definition of the query.

This is useless and your catch won't catch any resulting error
```
var query = Enumerable.Empty<Movie>();
try {
  query = movies.Where(m => m.Year > 2000);
}
catch {
  Console.WriteLine("Error");
}
query.Count();
```

This would be the correct approach
```
var query = movies.Where(m => m.Year > 2000);

try {
  query.Count();
}
catch {
  Console.WriteLine("Error");
}
```

|
|
|
|
|

### All about streaming operators

Methods that are Deferred methods, can be categorized into Streaming operators or Non-Streaming operators.


*Streaming Operator*
    .Where()

*Non-Streaming Operator*
    .OrderByDescending()
    .OrderBy()

    These type of operators don't force the query to execute when it is declared (unlike ToList()), therefore this method is Deferred. However, once the query is forced to execute, for example calling .Count() method, the query must interate the entire list (query) before executing the .Count() method. You can't be yielding one result at a time. It will operate the entire list, then when you get your list, it will count them.

e.g.

   To print the first element, the query will be execute until it finds the next element that fullfills the condition. If it finds one, it will stop execution, and yield that result. So, we will be executing the query in every single step of out while-loop
   ```
   var query = movies.Where(m => m.Year > 2000);
   var enumerator = query1.GetEnumerator();

   while (enumerator.MoveNext())
   {
       Console.WriteLine(enumerator.Current.Title);
   }
   ```

   It will execute the entire query before printing the title of the first element.
   ```
   var query = movies.Where(m => m.Year > 2000).OrderBy(m => m.Rating);
   var enumerator = query1.GetEnumerator();

   while (enumerator.MoveNext())
   {
       Console.WriteLine(enumerator.Current.Title);
   }
   ```

With In-Memory data it is better to filter and then Order. It is more efficient.


|
|
|
|
|

### Querying infinity.

Search for: *Classification of standard linq operators.* to check if an operator is deferred or not.

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/classification-of-standard-query-operators-by-manner-of-execution

static IEnumerable<double> Random() {
  var random = Random();
  while (true) {
    yield return random.NextDouble();
  }
}

var numbers = Random().Where(n => n > 0.5).Take(10);

This wouldn't execute forever. This would just execute until the method returns 10 numbers greater than 0.5

|
|
|
|
|

### Summary

Analyse if operators are lazy or not, before using them. That might improve the performance of your code.
