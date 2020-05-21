
---------------------------------------------------------------------------
---------------------------------------------------------------------------
#LINQ - Language Integrated Query.
---------------------------------------------------------------------------
---------------------------------------------------------------------------
|
|
*****************************
## 2. LINQ and C#.
*****************************

### The power of IEnumerable

Extension methods and Lambdas -> important for using LINQ

Remember that LINQ is designed to work against different kinds of data sources, e.g. in memory data or database

In order to perform LINQ operations, the data we are using must implement `IEnumerable<T>` interface

`Employee[] developers;`
`List<Employee> tester;`
This 2 collection types implement the `IEnumerable<T>`, so we may use linq

```
// Employee[] developers = new Employee[]
IEnumerable<Employee> developers = new Employee[]
{
    new Employee { Id = 1, Name = "Pablo" },
    new Employee { Id = 2, Name = "Vasco" }
};

// List<Employee> testers = new List<Employee>
IEnumerable<Employee> testers = new List<Employee>
{
    new Employee { Id = 3, Name = "José" },
    new Employee { Id = 4, Name = "Nati" }
};

// IEnumerator<Employee> enumerator = developers.LINQ_QUERY_OPERATORS();
IEnumerator<Employee> enumerator = developers.GetEnumerator();
while (enumerator.MoveNext())
{
    LOG(enumerator.Current.Name);
}
```

LINQ does not work with normal methods, where you just add functionalities like orderby or filter where.
*LINQ works by using extension methods* --> Ganz wichtig

IEnumerable<T> perfect for hiding the source of data. It is just an interface.

*Extension methods*: They allow to implement functionality against an interface or any type definition without changing the underlying type --dafaq--

We don't want to implement all the LINQ operations as methods in IEnumerable. That would break it all. We don't want that. We just need to extend its functionality.


### Creating an extension method
