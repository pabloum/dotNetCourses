# Entity Framework Core: Getting Started

## Mapping Many-to-Many and One-to-One Relationships

### Introduction

Understanding nature of many-to-many in EF-Core

Aligning classes and mappings for many-to-many

Adding one-to-one relationship

Migrating the database to reflect model changes

## Understanding nature of many-to-many in EF-Core

In previous versions of EF, there was magic in many to many relationships.

Now, in the latest version EF Core 6, one must use a "join Entity".

Example:

Samurai - Battle -> Many-to-Many

Now, in code, we must create 3 entities:
    1. Samurai
    2. Samurai Battle    ("Join entity")
    3. Battle

EF Core WON'T map directly without the join entity. A lot of the old magic, has gone.

### Setting up many-to-many relationships.

Check the files: Samurai.cs, Battle.cs, SamuraiBattle.cs, AND DbContext (SamuraiContext for this project)

### Adding a One-to-One relationship.

Dependent End of 1:1 is Always optional

### Visualizing how EF Core sees your model

You need DGML editor and EF Core Power Tools extension.

You need to change SamuraiApp.Data.csproj
    - <TargetFrameworks>netcoreapp3.0;netstandard2.0</TargetFrameworks>
    - <PackageReference Include="Microsoft.EntityFrameworkCore.Design">

Then, right click on the Data project, select EF Core Tools, then add DbContext model diagram.

### Controlling Table names with Mappgings

Another way of naming the Table in the DB
In DbContext:

```cs
void OnModelCreating(ModelBuilder modelBuilder){
  modelBuilder.Entity<Horse>().ToTable("Horses");
}
```

Note: If you have a One-to-One relationship, you could just configure it as additional columns on the main table. In this case, you could be creating Horse_Name. But, that's advanced configuration.
