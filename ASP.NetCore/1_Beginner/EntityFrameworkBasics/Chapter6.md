# Entity Framework Core: Getting Started

## Interacting with related data.


### Introduction and Overview

  - Inserting, update & delete related data.
  - Saving related data that wasn't tracked
  - Loading queries and shaping results with projections
  - Loading related data for objects in memory.
  - Filtering queries with related data.
  - Querying and persisting across many-to-many relationships
  - Querying and persisting across one-to-one relationships



### Inserting related data.

Example:

- Add new samurai with Quote
```cs
var samurai = new Samurai
{
    Name = "poca luz",
    Quotes = new List<Quote>
    {
        new Quote { Text = "Ich weiss es nicht" }
    }
};

using (var context = new SamuraiContext())
{
    context.Samurais.Add(samurai);
    context.SaveChanges();
}
```

- Add Quote to an existing Samurai
  In this case it is very important to keep track of the Samurai.
```cs
using (var context = new SamuraiContext())
{
    var samurai = context.Samurais.FirstOrDefault();
    samurai.Quotes.Add(new Quote
    {
        Text = "Aliens are not here"
    });
    context.SaveChanges();
}
```

- Add Quote to an existing Samurai, with NoTracking context:
```cs
using (var context = new SamuraiContext())
{
    var samurai = context.Samurais.FirstOrDefault();
    samurai.Quotes.Add(new Quote
    {
        Text = "Aliens are here"
    });

    using (var otherContext = new SamuraiContext())
    {
      otherContext.Update(samurai);
      otherContext.SaveChanges();      
    }
}
```

- Another way: (The author suggests using this style)
```cs
var quote = new Quote
{
  Text = "25 janvier",
  SamuraiId = <sent id>
};
using (var otherContext = new SamuraiContext())
{
  otherContext.Quotes.Add(quote);
  context.SaveChanges();      
}
```


* Important method to be take into account in disconnected scenarios: Attach()
    context.Samurais.Attach()




### Eager loading related data


Methods of Load Related Data:
  1. Eager loading
      Include related objects in query.
  2. Query projections
      Define the shape of query results.
  3. Explicit Loading
      Request related data of objects in memory.
  4. Lazy loading
      On-the-fly retrieval of related data.

1. Eager Loading:

```cs
var samuraiWithQuotes = context.Samurais.Include(s => s.Quotes).ToList();
```

Notes:  Include() is a Method of Samurais (plural). If you call Include() on a single samurai, it won't work.
e.g.
```cs
var samuraiWithQuotes = context.Samurais.FirstOrDefault().Include(s => s.Quotes).ToList(); // This will NOT work
var samuraiWithQuotes = context.Samurais.Where(z=>z.name="MaVero").Include(s => s.Quotes).ToList(); // This will NOT work
```

* You can include children and grandchildren with `ThenInclude()` like this:
    .Include(s => s.Quotes).ThenInclude(q => q.Transactions);

* You can use several Include()
    .Include(s => s.Quotes).Include(s => s.Clan)

Note: Include() does not allow you to filter which data is return



### Projecting related data in queries

Get an anonymous type, i.e. an object that does not match a class in your program. You may use this when you just want to bring some properties, and not the entire record.

```cs
var someProperties = context.Samurais.Select(s => new {s.Id, s.Name}).ToList();
```

This brings the Quotes related to the samurais
```cs
var someProperties = context.Samurais.Select(s => new {s.Id, s.Name, s.Quotes}).ToList();
```

You can filter
```cs
var someProperties = context.Samurais
                  .Select(s => new {s.Id, s.Name,
                          HappyQuotes = s.Quotes.Where(q=>q.Text.Contains("happy")) })
                  .ToList();
```

IMPORTANT NOTE:
EF Core can ONLY track entities recognized by the DbContext model. i.e. this anonymous types are not being tracked.
But propertiesof an anonymous types that are entities WILL BE tracked.


### Loading related data for objects already in memory.

```cs
```