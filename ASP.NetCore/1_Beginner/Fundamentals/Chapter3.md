# .Net Core fundamentals

## Working with models and model binding.


### Working with HTML Forms.

form action=""

  label
  input

  button type="submit"

<form action="/update" method="get">
 -> This is just an example. A GET method should never change data in the server

`form method get` are a good approach for searching and reading. We send it in the query string.
`form method post` are a good approach for an update scenario. A post send data back to the server with key-values pairs in the body of the message, not in the query string.
