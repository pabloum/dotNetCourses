
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

Allow us to define a static method that appears to be a member of another type. Any type: classes, interfaces, structs, even *sealed* types that we can't extend using inheritance.

** Extension method must be defined in a non-generic static class.

`static public double MyExtensionMethod(this string data)` -> `this` tells the compiler, that the method is an extension method.

We can have as many parameters as we wish, but only the first one need the `this` modifier.

The type of the first parameter is important because that's the type that I'm targeting to extend with this particular method.
  * In other words, I want MyExtensionMethod to appear as an instance method on a `string` type.

e.g.
```
string m_str = "45.676";
m_str.MyExtensionMethod();
```
Behind the scenes: Just calling the static method I created, but this is useful, because the syntax is much easier to read.

LINQ uses a lot extension methods to extend interfaces like IEnumerable<T>. And all the other LINW query operators, the operators that can  filter and sort and aggregate, they are all defined as extension methods.

I cannot re-implement, replace or method which is already an instance method on an object


### Understanding Lambda Expressions

_Hi_

Where method -> For filtering
Ways of using it:

1. _Named method_
  ```
  IEnumerable<string> filteredList = cities.Where(StartsWithM); // Name of the method. I'm not calling it

  [...]

  public bool StartWithM(string city) {
    return city.Name.StartsWith("M");
  }
```
2. _anonymous method_
  Other approach. Use `delegate` keyword. This allows to write an inline method.
  We call this an _anonymous method_
  ```
  IEnumerable<string> filteredList = cities.Where( delegate (string s )
                                                      { return city.Name.StartsWith("M"); }
                                                  ); // Name of the method. I'm not calling it
  ```
3. _Lambda expression syntax_
  Short, concise syntax for defining a method that I can invoke. This is also an anonymous method

  ```
  IEnumerable<string> filteredList = cities.Where(s => s.Name.StartsWith("M") );
  // Name of the method. I'm not calling it
  ```

|
|


### Using Func and Action Types

`.Where();` // This function expects a `Func<City, bool> predicate` type

Func<> type is an easy way to work with delegates.
  Delegates: Types that allow me to create variables that point to methods.

There are 17 overloads to the Func type. That meand, the Funct type can take from 1 to 17 different generic type parameters

```
Func<TypeParam1, TypeParam2, ReturnType>
```

e.g.

```
int Suma(int a, int b) { reuturn a+b;}

Func<int, int, int> f = Suma;
Func<int, int, int> g = (x, y) => x + y; // parenthesis mandatory for zero or more than one parameter
Func<int, int, int> h = (int x, int y) => x * y; // type name optional
Func<int, int, int> h = (int x, int y) => {
  int result = x * y;
  return result;
}; // type name optional

```

Type: Action<>  -> This is to store functions which do not retunrn a value, and all the generic values that you send ar just going to be parameters to the function.

Action<int> print = x => Console.WriteLine("I received a " + x)


e.g.

  developers.Where(e => e.Name.Length >= 5)   // los desarrolladores con el nombre mayor de 5 letras
            .OrderBy(e => e.Name);            // ordenar los resultados por nombre

Lo que estoy enviando dentro de esos métodos son varibales de tipo Func<>
