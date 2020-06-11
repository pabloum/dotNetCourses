# LINQ

## Filtering, Ordering and Projecting.

Example.

  1. Take CSV
  2. Filtering unnecessary lines -> headers and last blank line
  3. Projection -> People call it the select operator.
      Projection operator is select operator or map operator.


File.ReadAllLines(path);

  parameter:  the path
  return type: array of strings

.Skip() and .Take() are very useful for paging operations. When you need to display records 10 to 20 of a large set of records. Think about a web page that doesnt display all records at once, but display just 10 records at a time, per page.

```
main {
  // 1st way
  var query = from line in File.ReadAllLines(path).Skip(1)
            where line.Length > 1
            select TransformToCar(line);
            // ToList() wouldnt work here

  query.ToList();

  // 2nd way
  File.ReadAllLines(path)
      .Skip(1)  // Will avoid processing header line. This is a partition operation
      .Where(line => line.Length > 1)
      .Select(TransformToCar)
      .ToList();
}

private static Car TransformToCar(string arg1, int arg2)
{
  var columns = line.Split(',');

  return new Car {
      Year = int.Parse(columns[0]),
      Manufacturer = columns[1],
      Name = columns[2],
      Displacement = double.Parse(columns[3]),
      Cylinders = int.Parse(columns[4]),
      City = int.Parse(columns[5]),
      Highway = int.Parse(columns[6]),
      Combined = int.Parse(columns[7])
  };
}
```

### Finding most efficient cars:

```
// Sort the most fuel efficient cars.
var query = cars.OrderByDescending(car => car.Combined)
                .ThenBy(car => car.Name); // This is a secondary option for ordering. Do not use OrderBy again for a secondary order.

var query2 =   from car in cars
               orderby car.Combined descending, car.Name ascending/*, a third option... etc*/
               select car;
```

There is a Reverse() operator that can only be used in the method syntax

### Filtering with Where and First

```
// Sort the most fuel efficient cars.
var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                .OrderByDescending(car => car.Combined)
                .ThenBy(car => car.Name); // This is a secondary option for ordering. Do not use OrderBy again for a secondary order.

var query2 =   from car in cars
               where car.Manufacturer == "BMW" && car.Year == 2016
               orderby car.Combined descending, car.Name ascending/*, a third option... etc*/
               select car;

var top = query.First(); // not available in query syntax
var top2 = query.First(c => c.Cylinders > 6); // not available in query syntax. This brings the first value it finds that fullfils that condition
                                              // Exception might be thrown if no condition is found.    
var top3 = query.FirstOrDefault(c => c.Cylinders > 6); // not available in query syntax. This brings the first value it finds that fullfils that condition
        // default would be null if nothing is found


var last = query.Last(); // This is the last
var last2 = query.Last(c => c.Cylinders < 6); // This is the last
```

### Quantifying data

Quantifiers tells us if anything matches a predicate, or if a data set contains a specific item

they return a bool. They dont offer deferred execution.

These methods do not offer deferred execution, but they are as lazy as possible.
  -> As soon as Any() finds something that matches, it stops and returns true
  -> As soon as All() finds something that doesnt match, it stops and returns false

.Any();
.All();
.Contains();

### Projecting data with select

In LINQ, the primary projection operation is SELECT

```
File.ReadAllLines(path)
    .Skip(1)
    .Where(line => line.Length > 1)
    //.Select(TransformToCar)
    //.Select(l => TransformToCar(l))
    .ToCar() // Customized way of doing the previous Select. THis is a projection
    .ToList();       
```

Where .ToCar() is an extension method defined as follows:
```
public static class MyLinqExtension
{
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(',');

            yield return new Car
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7])
            };
        }
    }
}
```

Anonymous types:

```
var anon = new {
  Name = "Pablo"
};
```

A projection with an anonymous type

With the query syntax
```
var query2 = from car in cars
where car.Manufacturer == "BMW" && car.Year == 2016
orderby car.Combined descending, car.Name ascending/*, a third option... etc*/
// select car;
select new { // This is an anonymous type.  
    Manufacturer = car.Manufacturer,
    car.Name, // Shortcut. No need to use the name. COmpiler just undertands to use the same name
    car.Combined
};
```

With the methdod syntax
```
// Sort the most fuel efficient cars.
var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                .OrderByDescending(car => car.Combined)
                .ThenBy(car => car.Name) // This is a secondary option for ordering. Do not use OrderBy again for a secondary order.
                .Select(c => new { // This is an anonymous type.  
                    Manufacturer = c.Manufacturer,
                    c.Name, // Shortcut. No need to use the name. COmpiler just undertands to use the same name
                    c.Combined
                });
```

### Flattening data with select Many

SelectMany() -> Another projection operator
It is called a flattening operator.

Collection of collections. A sequence of sequences

SelectMany()
  Flattens a collection of collections into a single collection.

Analogy:
  You have 3 cars. In each car you have a different amount of passengers. Now, given a car, you have a list of passengers. If you select many passengers, from all three cars, the method flattens all passengers into one single list, instead of having a list o lists.

Note: for the following example remember that a string is a collection of char
```
var result = cars.SelectMany(c => c.Name); // Returns a list of all characters of all record names
foreach (var character in result)
  Console.WriteLine(character);
```

the previous is equivalent to:
```
var result = cars.Select(c => c.Name);

foreach (var name in result)
  foreach (var character in name)
    Console.WriteLine(character);
```

So, SelectMany() takes a sequence and iterates in whatever is inside, and puts all that into a single list.


### Summary

```
var query2 = from car in cars
where car.Manufacturer == "BMW" && car.Year == 2016
orderby car.Combined descending, car.Name ascending/*, a third option... etc*/
// select car;
select new { // This is an anonymous type.  
   Manufacturer = car.Manufacturer,
   car.Name, // Shortcut. No need to use the name. COmpiler just undertands to use the same name
   car.Combined
};
```
