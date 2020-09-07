# Entity Framework Core: Getting Started

## Interacting with related data.

### Introduction and Overview

Inserting, update & delete related data.

Saving related data that wasn't tracked

Loading queries and shaping results with projections

Loading related data for objects in memory.

Filtering queries with related data.

Querying and persisting across many-to-many relationships

Querying and persisting across one-to-one relationships


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
