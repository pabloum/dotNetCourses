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

### Implement a DbContext

class myDbContext : DbContext
{
  DbSet<myRestaurant> Restaurants {get; set;}
}

### Entity framework tool:

Migrations ;)

### Using other databases and tools.

One of the trickiest steps: connecting to a data base.

For other, google for documentation.

IF YOU ARE NOT ON WINDOWS ANOTHER OPTION IS STILL TO RUN MICROSOFT SQL SERVER, AND TO DO THAT BY USING DOCKER IMAGES THAT MICROSOFT PROVIDES !!!!!!!! GODDAMN IT

Search for:   Quickstart: Run SQL Server container images with Docker.

You mar run this with Docker for Mac or Windows.

Other ways:

  * mssql-cli
      command line tool:     `$ pip install mssql-cli`  



### Using Database migrations.

Migrations are all about  keeping a database schema in sync with the models in my application code.

So, every time a make a change to one of my models, my C# objects that I'm using to store information into the database (most people would call entities), I can run these Entity Framework migrations to create the schema changes that I can apply to my database.

To create a new one.
`$ dotnet ef migrations add initialcreate -s ../PumToFood/PumToFood.csproj`

Other options:
  $ dotnet ef migrations   
                          add     Adds a new migration.
                          list    Lists available migrations.
                          remove  Removes the last migration.
                          script  Generates a SQL script from migrations.

### Running Database migrations.

Commands:

$ dotnet ef database
                      drop    Drops the database.
                      update  Updates the database to a specified migration.

.

`dotnet ef database update -s ../PumToFood/PumToFood.csproj`

*Note*. I'm running all these commands in the Data project, i.e. where we have the DbContext class.



### Implementing Data Access Service.

Just implement that thing. !!
