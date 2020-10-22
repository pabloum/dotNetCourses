
# Design Patterns

## Structural

### Facade

 FIRST APPROACH:

    The big class problem:

    ClassA                  Facade                   Program
    -------                 -------                  -------
    Method1                 Mehtod1                  Facade.Method1
    Method2                 Mehtod2                  Facade.Method2
    Method3                 Mehtod3                  Facade.Method3
    Method4                 Mehtod4                  Facade.Method4
    Method5                 
    Method6
    Method7
    Method8


    ```cs
    static void Main(){
        var servicesFacade = new ServicesFacade();
        servicesFacade.DoSomethingExplicit1();
        servicesFacade.DoSomethingExplicit2();
    }
    ```

    The Facade may be orchestrating calls.


SECOND APPROACH

              Facade Class.
                  ^
                  |
Service1          |               
---------         |               
Method1           |               
Method2           |
                  |
                  |               Program
Service2          |               ----------
---------         |               Facade.Method
Method1           |   
Method2           |
                  |
                  |
Service3          |
---------         |
Method1           |
Method2           |
