# .Net Core fundamentals

## Working with SQL and entity framework core


### Installing Entity Framework

*DbContext*

*Migration* The framework can create or update a database to store all the information that we need about a given Entity. The framework can change the schema of the database so that the database can store all the information available for the given Entity (e.g. Restaurant) => Feature of the entity framework known as Migrations

To create a migration, we need to use the command line.

CLI
Use the command line

~ dotnet ef dbcontext
                       - list
                       - info
                       - scaffold     // Creates code from existing data base (?)

In DotNet 3.0 it is not installed by default. You would need to use this:

dotnet tool install --global dotnet-ef
