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
