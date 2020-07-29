# Build API with ASP.NET Core

## Chapter 3: Modifying data


### URI Design.

What we do:

Resource        Get (read)      Post (create)        Put (update)        Delete(remove)
----------------------------------------------------------------------------
/customers      Get List        Create item          Update batch        Error
/cusromers/12   Get item        Error                Update Item         Delete Item


What we should receive back:

Resource        Get (read)      Post (create)        Put (update)        Delete(remove)
----------------------------------------------------------------------------
/customers      List            New item              StatusCode Only     StatusCode Only°
/cusromers/12   item            StatusCode Only°       Update Item         StatusCode Only

° should be an error


Some Notes:

* You should not support deleting an entire list.
* You should return Success or BadRequest according to the case.


### Model Binding.

How data comes into the server. -> We do that in the form of Model Binding.

We can bind the body we send in the request in 2 ways:

1. [ApiController] before class name
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase

2. [FromBody] in the method declaration

public async Task<ActionResult<CampModel>> Post([FromBody]CampModel model)
{
    // code
}

### Implementing POST

```
try
{
    // Create a new camp

    var location = _linkGenerator.GetPathByAction("Get", "Camps", new { moniker = model.Moniker });

    if (string.IsNullOrWhiteSpace(location)) return BadRequest("Could not use current Moniker");

    var camp = _mapper.Map<Camp>(model);
    _repository.Add(camp);

    if (await _repository.SaveChangesAsync())
    {
        return Created(location, _mapper.Map<CampModel>(camp));
    }
}
```

### Adding Model validation

if (ModelState.IsValid) { customized }

### Implementing PUT

Just check the code. There was nothing weird

### Implementing DELETE

Just check the code. There was nothing weird


### What we've learned

- Model binding
- Models to include validations
- Using verbs to match the operations is key to an API.
