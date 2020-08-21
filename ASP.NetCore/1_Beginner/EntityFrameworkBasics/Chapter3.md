# Entity Framework Core: Getting Started

## Controlling database and schema changes with Migrations

### Introduction

- Overview of EF Core Migrations API
- Create and inspect migration file
- Using EF Core Migrations to create database or database scripts
- Reverse engineer an existing database into classes and DbContext.

### Understanfin EF Core Migrations

Code first paradigm:

    - Define/change model
    - create a migration file --> Describes the change
    - Apply migration to DB or Script. The migration could run the SQL scripts for you.

They are designed to work easily with source-control

### Adding your first migration.

Migrations tool needs some kind of executable to run the migrations. The Data Library project won't be able to do it on its own.

Commands. Need package Microsoft.EntityFrameworkCore.Tools and  Microsoft.EntityFrameworkCore.Data

In Data project (i.e. where DbContext is located):

```bash
add-migration init -s ../ConsoleApp
```

### Inspecting the first migrations

Migration file (the one with the timestamp)
ModelSnapshot -> that's where EF migrations keeps keep track of the current state of the model.

<timestamp>_<name_of_migration>
  -> Method Up(): Creates tables, adds columns, Creates Indexes (foe every FK it discovers in the model)
  -> Mehtod Down(): if we wver want to unwind this particular migration.


### Using Migrations to Script or directly create the database.

```bash
script-migration
```

```bash
update-database -verbose
```

### Reverse Engineering an Existing database

Typically a one time procedure

```bash
scaffold-dbcontext -provider <provider> -connection <connection_string>
```

e.g
```bash
scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData"
```

How to determine mappings to DB
  1. Conventions. (Default assumptions)
  2. Override with fluent Mappings
        Tweak the context with what is called the Fluent API
  3. Override with data annotations
        Are much more limited.
