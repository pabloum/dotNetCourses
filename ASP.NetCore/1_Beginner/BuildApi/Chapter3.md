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

### 
