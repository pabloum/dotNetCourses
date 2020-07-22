# Build an API with ASP.NET Core

## Pragmatic Rest

### ----------------------------------


### Where we´re headed

  * Creating API with ASP.Net Core
  * Creting API Controllers
  * Querying and Modifying data
  * Using association Controllers
  * Defining operational API's => or API's that don't conform to data or entities
  * Versioning API's with MVC 6


### How does Http work?

  * First of all: There are some changes compared with ASP.Net Web APIs
      -> Microsoft merged the MVC and Web API stacks
  * Core of the course: Learn to make request over a network connection. We are creating an API that needs to be  called over a web connection
  * The web request work is different than simple networking.
    All requests that we are going to make are going to be over the HyperText Transfer Protocol.


  - STANDARD REQUEST
      1. Some user wants to make a request to a server. This might be for a web page, a web api, a Javascript file, an image, etc.
      2. The server receives and processes the request.
      3. The server creates a response
      4. The server returns a response.

      *REQUEST* Composed by: VERB, HEADERS, AND CONTENT
      *RESPONSE* Composed by: STATUS CODE, HEADERS, AND CONTENT

  One of the main ideas: Server is stateless, meaning it isn't maintaining a constant connection. Every API request is a one round trip call. Servers are not going to remember who you are.

  - *Verbs*
      - GET: Retrieve a resource. "Please give me something"
      - POST: Add a new resource
      - PUT: Update an existing resource
      - PATCH: Update an existing resource with set of specific information
      - DELETE: Remove the resource

      The main difference between PUT and PATCH is that PUT takes an entire resource or an entire thing and update it entirely. Whereas, PATCH only takes one small change. e.g. only update ZipCode, while leaving name and city the same.

### What is REST?

REpresentational State Transfer

* CONCEPTS
    - Separation of client and server
    - Server requests are stateless
    - Cacheable requests
    - They use an URI or Uniform Interface.

* PROBLEMS
    - Too difficult to be qualified as REST / RESTful
    - Dogma of REST vs Pragmatism
      -> Structured architectural style, that might not fit into every domain.
      -> The need to be productive.


### What are Resources?


.
