
---------------------------------------------------------------------------
---------------------------------------------------------------------------
LINQ - Language Integrated Query.
---------------------------------------------------------------------------
---------------------------------------------------------------------------
|
|
*****************************
1. INTRODUCTION.
*****************************

How to work with data 'in the past'?
  -> Depends on where the data is.
      + In memory? -> Through Object Data - Algorithms and Generics.
      + Relational Data -> ADO.Net and SQL
      + XML Data -> XmlDocument and XPath/ESLT

Well, LINQ offers a consistent API for all these different data sources.

LINQ gives us strongly typed, compile checks on queries that can execute against
in-memory data, relational data, and XML Data.

What can I access?
  - Objects, MongoDB, CSV Files, File System, SQL DB, JSON, HL7 XML and more!!

Examples: 
```
DirectoryInfo directory = new DirectoryInfo(path);
var query = from file in directory.GetFiles()
           orderby file.Length descending
           select file;

var query2 = directory.GetFiles()
            .OrderByDescending(f => f.Length)
            .Take(5);
```
*****************************
2. LINQ and C#.
*****************************
