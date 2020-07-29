# Build API ASP.Net Core fundamentals

## Chapter 5. Creating Association APIs

### Introduction

/api/camps
/api/camps/ATL2018
/api/camps/ATL2018/talks            ---> Associative API
/api/camps/ATL2018/talks/1

The idea is to split those endpoints into 2 Controllers: One for Camps and the other for Talks

### Create an Association Controller

[Routes("{api/camps/{moniker}/[controller]}")]
[ApiController]
public class TalksController : ControllerBase{

}

the rest is pretty much like creating the other controller.

### Get all
Look at the code. No special magic was done here

### Get
Look at the code. No special magic was done here

### POST

To create a new Talk, make sure that the Post() method receives proper data: rigth moniker, right talk, right speaker.

Then create it.

remember to return the object AND the location (use linkGenerator)

### Validation

Add the validations to the Talk Model

[Requiered]
[StringLength]

### Put

He made some magic in the Profiler.


### Delete

delete it

### What we've learned

1. The API design should imply the structure to your users
2. Breaking up your API into individual controllers is good
3. The association hierarchy can be deep or shallow.
