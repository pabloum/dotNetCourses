#

## Building your first API.

### Introduction

### Creating an action

[Route("api/[controller]")]
public class CampsController : ControllerBase
{
  public object CualquierCosa() {
    return new { Moniker = "PUM", Name = "Pablo"};
  }
}

### Status Codes

Tells if something went good or not

Standard codes:
  200 OK                It worked
  400 Bad Request       You did bad
  500 Internal error    We did bad

304 - Not modified. Representing cached objects


### Using status codes

[HttpGet]   // Attribute.
public IActionResult Get()
{
    if (false)
        return BadRequest("Bad studd happend");

    return Ok(new { Moniker = "ATL2018", Name = "Pablo Uribe M"});
}

Methods: They're in the base class. You may find them
          Ok()                  200
          BadRequest()          500

Route + Verb => which method to use. -> This is ultimately the endpoint. Not the class, but the method.


### Using GET for collections.

Faites attention aux choses async. Wrap your return type within a Task<>
```
[HttpGet]  // Attribute.
public async Task<IActionResult> Get()
{
    try
    {
        var results = await _repository.GetAllCampsAsync();

        return Ok(results);
    }
    catch (Exception)
    {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
    }
}
```


### Returning models instead of entities.

Why?
  Payload is a contract with your users.
  Likely want to filter data for security too
  Surrogate keys are useful too.

Use AutoMapper. Create Profiles for the mapper.

Tip. Return `ActionResult<T>`. With that, the framework understands to return an Ok() if you return a type that matches with `T`


### Getting an individual item

[HttpGet("{moniker}")] // string by default
public object Get(string moniker) { // ... // }

[HttpGet("{id:int}")]
public object Get(int id) { // .. // }


### Returning related data

With the help of AutoMapper we have 2 options.

1. In CampsModel, create all the fields from Location, with the prefix Location. Automapper does the job.

2. In Profile, use .ForMember as follows:

    e.g.
    CreateMap<Camp, CampModel>()
        .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName));

### Query strings

Get(bool insertTalks = false)

when this variables becomes optional, it understands that i is about a query string

### Search

We just created another Get method, with a new parameters and a new Attribute ([HttpGet("search")])
Then, we just used the pre-existing method created by the teacher, which he included in the Repository.


### What we've learned

Error handling in an HTTP way

Using IActionResult and ActionResult to serializing objects into JSON

Query strings are useful for declaring format or searching. 
