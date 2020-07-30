# Build API ASP.Net Core fundamentals

## Functional APIs

### Definition

Apis on the web:

A: Verbs included in API
B: Link relations, e.g. Hypermedia

A inner join B: Pragmatic Rest. URI Endpoints.
                                Resources URI
                                HTTP verbs
                                Stateless server
                                Content negotiation.

- Funtional APIs are not really dealing with resources.
- REST defines URIs as resources
    * But exceptions exist
    * ... don't be afraid of funtional Apis
    * Avoid Remote Procedure Call (RPC) at all costs

- When you use Funtional APIs:
    * For operational needs
      e.g. clearing the cache, restarting servers, starting batch jobs, etc

    * Avoid for reporting


*Be careful. If you start creating a lot of these, be suspicious. You could be creating a NON-Restful API. You would be using an RPC over Http, which you can do, but it is not what this course is about.*


### Creating a functional API

Just create a regular controller. But when you create an action, do not use a "regular verb". Use OPTIONS, with the next attribute:

[HttOptions("reloadconfig")]

```
[HttpOptions("reloadconfig")]
public IActionResult ReloadConfig()
{
   try
   {
       var root = (IConfigurationRoot)_config;
       root.Reload();
       return Ok();
   }
```
in Postman use the verb Options.

http://localhost6600/api/reloadconfig


Be careful. If you start creating a lot of these, be suspicious. You could be creating a NON-Restful API. You would be using an RPC over Http, which you can do, but it is not what this course is about.


### What we've learned

* Rest is important, but being pragmatic is a good idea.
* Create functional APIs if necessary. It does not make your code bad or wrong.
* Do not fall in the RPC trap.
