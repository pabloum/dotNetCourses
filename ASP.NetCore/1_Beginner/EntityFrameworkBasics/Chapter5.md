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
