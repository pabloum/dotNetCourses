# Entity Framework Core: Getting Started

## Working with views and Stored Procedures and Raw SQL

### Introduction and Overview

- Using migrations to add views & stored procedures to a database
- Understanding and mapping keyless entities
- Mapping and querying with database views
- Querying with raw SQL commands and Stored Procedure
- Executing SQL commands on the database


### Adding views and other database objects using migrations

The migrations API has a lovely little method called Sql().

migrationsBuilder.Sql("SQL Command");

Steps to use it:

  1. Create a migrations without changes. That will create the class with the methods Up() and Down() totally empty.
  2. Use migrationsBuilder.Sql("SQL Command"); inside the Up() method:
      ```cs
      migrationsBuilder.Sql(@"CREATE FUNCTION[dbo].[SamuraiBattleStatus](@samuraiId int)
                              [...]");
      migrationsBuilder.Sql(@"CREATE or ALTER dbo.SamuraiBattleStatus
                              AS
                              [...]");
      ```
      Note: Use @ before the string to allow line wrapping the code
  3. Implement the Down() method
      ```cs
      migrationsBuilder.Sql(@"DROP VIEW dbo.SamuraiBattleStatus");
      migrationsBuilder.Sql(@"DROP FUNCTION dbo.EarliestBattleFoughtBySamurai");
      ```
You can create the views in the same way


### Using keyless entities to map to views

There is another way to map entities so that EF Core will always consider them to be read-only. What's really special about this, is that it allows you to map to views and tables that have no primary key.


Keyless ~ without PK


So, if you really want to use a keyless entity, create the domain, dto, whatever you need. Then, create the DbSet in the DbContext. But, YOU MUST SPECIFY that it does not have a key, inside the `OnModelCreating()` with the method `HasNoKey()`. You also have to use the method `ToView()` to tell EF that the View already exists. In that way, EF wont create it every time you add a migration

```cs
void OnModelCreating(){
  modelBuilder.Entity<SamuraiBattleStat>.HasNoKey().ToView("SamuraiBattleStats"); // ToView("NameOfTheView")
}
```

NOTE !! EF Core WON'T track an entity marked with HasNoKey(). So, you won't have to worry about using AsNoTracking()
If you try to force it to track, EF Core will simply ignore that.
