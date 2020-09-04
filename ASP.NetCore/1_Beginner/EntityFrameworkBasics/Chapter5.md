# Entity Framework Core: Getting Started

## Interacting with your EF Core Data Model

### Introduction and Overview

Querying Update, Inserting, deleting.


### Looking at SQL built by EF Core

```cs
DbSet<Samurai> Samurais {get; set; };
[. . .]
Samurais.Add(samurai);
```

Tracking entity. That Add() method "translate" into a SQL statement, that will be executed in the database. All that is work of the EF Core.

This process is wrapped in a Transaction. If it goes well, it will commit. Otherwise, there will be a Rollback.

For more detail, you could use SQL Profiler. /* ^_^ *\

### Adding Logging to EF Core's workload.

In .csproj
<PackageReference Include="Microsoft.Extensions.Logging.Console" Version="3.1.7" />

In DbContext.cs
```cs
public static readonly ILoggerFactory ConsoleLoggerFactory
= LoggerFactory.Create(builder =>
{
   builder
       .AddFilter((category, level) =>
           category == DbLoggerCategory.Database.Command.Name
           && level == LogLevel.Information)
       .AddConsole();

public void OnConfiguring(){
  optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory)  // remember to add this new Extension Method
                .UseSqlServer(connectionString);
}
});
```

This will give us basic Logs of EF Core. We would't have to worry about this on an ASP.NET Core app. It brings it by default.


### Benefiting from Bulk Operation Support.

EF Core supports Bulk operations. Previous versions did not.

Examples:
```cs
// This is a bulk operation.
using (var context = new SamuraiContext())
{
    var samurai1 = new Samurai { Name = "Andrea" };
    var samurai2 = new Samurai { Name = "ValentinaV" };
    var samurai3 = new Samurai { Name = "Vanesa" };
    var samurai4 = new Samurai { Name = "Ana María" };
    var samurai5 = new Samurai { Name = "ValentinaC" };
    var samurai6 = new Samurai { Name = "Leidy" };

    var list = new List<Samurai>() { samurai3, samurai4, samurai5, samurai6 };

    context.Samurais.AddRange(samurai1, samurai2);  // Way 1
    context.Samurais.AddRange(list);                // Way 2

    context.SaveChanges();
}
```

Conext also has Add() and AddRange(). It infers which DbSet to Use.
Particularly useful to insert various records of different types
```cs
using (var context = new SamuraiContext())
{
    var samurai = new Samurai { Name = "MaVero" };
    var clan = new Clan { ClanName = "Globant" };

    context.AddRange(samurai, clan);

    context.SaveChanges();
}
```

Batch commands
Batch operation
Batch Size

Each database provider is responsible for setting specific limitations. SQL Provider sets a limit on number of rows, 1000 max, the number of parameters (2100), and other details.

You can also specify the maximum number of batches when you're configuring the model builder in the <Samurai>Context.
      UseSqlServer() -> Exposes a set of options. You can add a lambda for those options and access, for instance, MaxBatchSize

```cs
public void OnConfiguring(){
  optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory)  // remember to add this new Extension Method
                .UseSqlServer(connectionString, options => optionns.MaxBatchSize(150));
}
});
```


### Understanding the Query workflow  

Query
  -> EF Core reads model and works with providet to work out SQL
      -> Send SQL to database
          -> Receives tabular results
              -> Materializes results as objects
                  -> Adds tracking details to DbContext instance.

Remember, there is lazy execution.

So, be careful.

This is fine
```cs
foreach(var samurai in context.Samurais){
  Console.WriteLine(samurai);
}
```

This could bring side effects
```cs
foreach(var samurai in context.Samurais){
  Console.WriteLine(samurai.Name);
  Console.WriteLine(samurai.Id);
  Console.WriteLine(samurai.Birthday);
}
```

Better  bring first the results, then iterate
```cs
var samurais = context.Samurais.ToList();
foreach(var samurai in samurais){
  Console.WriteLine(samurai.Name);
  Console.WriteLine(samurai.Id);
  Console.WriteLine(samurai.Birthday);
}
```
