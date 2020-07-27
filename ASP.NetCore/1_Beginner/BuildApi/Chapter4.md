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
