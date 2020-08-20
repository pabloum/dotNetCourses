# Entity Framework Core: Getting Started

## Create your first App usign EF Core 3.1

### Introduction

What we'll learn:

  1. Building your first App that uses EF Core
  2. Controlling database creation and schema changes
  3. Add more relations
  4. Interacting with your EF Core data model.
  5. Interacting with related data.
  6. Working with views, stored procedures and raw SQL
  7. Using EF Core in an ASP.Net Core App
  8. Using EF Core in your tests.


### What is Entity Framework Core?

Object Relational Mapper. It's been improving dramatically over the years.

.Net APIs for performing data access in your software.

Cross-platform  

ORM are designed to reduce the friction between how data is structured in a relational database and how you define your classes.

Without ORM we typically have to write a lot of code to transform database results into instances of the types in our software.

An ORM allows us to express our queries using our classes, and then the ORM itself builds and executes the relevant SQL for us, as well as materializing objects from the data that came back from the database

*High Level ORM benefits*
  - Developer productivity    (Reduce redundant data interaction coding task)
  - Coding consistency.
  -

EF has a mapping layer in between Code and DDBB -> This gives us a lot of flexibility.

3rd party tools: AzureCosmos DB. For non-relational DDBB
