# .Net Core fundamentals

## Drilling into data.

dotnet cli

In console

~ dotnet
  Shows options

~ dotnet new
  Shows what you can create

~ dotnet new razor
  Creates a new Web Application Project. Not an MVC one. ;)


We are creating a Razor pages.

Folder Pages


~ dotnet asp-codegenerator -h

~ dotnet asp-codegenerator razorpages -h

`~ dotnet asp-codegenerator razorpages List Empty -udl -outDir Pages\Restaurant`
    List : Page named List
    Empty: using the empty template
    -udl use default layout
    -outDir : Place this into the following directory:


ctor + tab + tab
prop + tab + tab

To read appsettings.json

create a new project for the entities.

PumToFood.Core
  => For classes and Types and processing algorithms that are the core of the business or the core of the app.

|
|
|

### Building a Data Access Service

Add dependency in configure services like this:

services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
// JUST for development and test. A List<T> is not thread safe, meaning, it can't be accessed at the same time


### Summary

We have learned to display a list of restaurants. We used a razor page to process HTTP request for Get, and then we put together data for the page to display.

Separation of concerns in razor pages:
All of your heavy lifting takes place in C# code in the PageModel, while the cshtml file contains just simple expressions and HTML markup
