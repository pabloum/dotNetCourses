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
