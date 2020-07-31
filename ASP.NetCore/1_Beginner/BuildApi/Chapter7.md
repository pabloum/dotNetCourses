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
