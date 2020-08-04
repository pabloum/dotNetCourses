# Build API ASP.Net Core fundamentals

## Versioning your APIs

### Introduction

Once you publish your API it is set on stone

  - Users/ customers rely on API, but requirements change.
  - Need a way to evolve Api , but don't break clients
  - Api Versioning is NOT product versioning.
        i.e. they do not need to be tied together.

*Problems with API versioning*

In .NET
  - Is done with 'Package' versions. e.g. assemblies.

API versioning is harder
  - Need to support new and old users with a single code base
  - side-by-side deployment isn't feasible.
  - Code base should support both versions.

*API Versioning schemes*
  - There are a lot of ways to version an API.
  - Not all of them are recommended
  - You must find a mechanism that works for your organization.

  BUT REMEMBER: You're serving your clients . . .  not yourselves.

### Types of versioning

* We can use the URI
    /api/v2/customers

* Query strings
    /api/custormers?v=2.0

* With headers
    GET /api/customers  HTTP /1.1
    Host: localhost6600
    Content-Type:
    X-Version: 2.0

* More headers
    - Accept header
        Accept: application/json; version=2.0
    - Content-type header   
        Conent-Type: n.n


### Introducing API versioning

Nuget Package: Microsoft.AspNetCore.Mvc.Versioning

On services:

```
services.AddApiVersioning(opt => {
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = new ApiVersion(1, 1);
    opt.ReportApiVersions = true;
});
```
Edit AddMvc:

`services.AddMvc(opt => opt.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);`

### Versioning actions. i.e through methods

[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ...

    [MapToApiVersion("1.0")]
    publi Get10() { ... }

    [MapToApiVersion("1.1")]
    publi Get11 { ... }

How to call an specific version:
    http://localhost:6600/api/camps/atl2018?api-version=1.0


### Versioning controllers.

Duplicate controller. You would have a lot o repeated code, but you could have the power to edit different versions.

In our example:
      Camps2Controller
      CampsController


### Versioning with headers

In StartUp.cs

ApiVersionReader:

```
services.AddApiVersioning(opt => {
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = new ApiVersion(1, 1);
    opt.ReportApiVersions = true;
    //opt.ApiVersionReader = new QueryStringApiVersionReader(); // By default, and the strign is "api-version"
    //opt.ApiVersionReader = new QueryStringApiVersionReader("ver"); // If you just want to change the string
    opt.ApiVersionReader = new HeaderApiVersionReader("X-Version"); // Name of the header.
});
```


You would want to avoid this because it adds an extra level of complexity, if the user of your api is a newby for example. Or even if he's an expert, it would add more complexity to the written code.

Talk with your clients


### Using multiple versioning methods

Specify just one. One or the other. Query or header. Don't use both, or you'll get an ambiguous error response if you call the endpoint with different versions on querystring and header



### URL Versioning

The author thinks this is a very very bad idea. But widely used, so it is worth the learning

http://localhost:6600/api/v1/camps

The reason the author does not like this, is that there is no good rollover.
Meaning that the user is forced to always specify the version he's trying to reach. There's no optional part of this.

This tends to be fragile

Two changes:

1. opt.ApiVersionReader = new UrlSegmentApiVersionReader();
2. [Route("api/v{version:apiVersion}/[controller]")] -> This atrribute to the class.

And you'll need to do that in all of your controllers.



### Versioning conventions

Allow to centralize all your versioning information, and not include it in all your controllers.

```
// This is the same as what we did with the attributes.
opt.Conventions.Controller<TalksController>()
    .HasApiVersion(1, 0)
    .HasApiVersion(1, 1)
    .Action(c => c.Delete(default(string), default(int)))
        .MapToApiVersion(1,1)
;
```

### Other versioning methods

(outside of the scope of this course)

1. Versioning Library:
    - Versioning by namespaces.
    - Versioning by content type
    - Writing your own Reader
    - Writing your own Resolvers

It's up to you how crazy and how complex you wanna get. All of these may be very domain specific


### What  we've learned

Api versioning supported by Microsoft. It is not just another random library out there.

You can version your URLs and payloads

You can choose attribute or conventions for versioning configuration.
