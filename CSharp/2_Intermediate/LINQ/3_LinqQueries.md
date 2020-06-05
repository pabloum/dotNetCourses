
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
