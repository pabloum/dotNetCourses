
# Design Patterns

## Creational

### Prototype

Specifies the kinds of objects to create using a prototypical instance, and creates new objects by copying this prototype.

This pattern allows a client to request a clone of an existing object from the object itself.

  - Cloning logic is in the object itself
  - Cut down on your sub-class hierarchy by allowing you to create configurable clones of existing classes instead.
  - Hides cloning implementation.

Diafram:
  Client         ----------->               Prototype - Interface
  ------                                    ----------
  Operation()                               Clone() - Blueprint
                                                    |
                                                ____|____
                                               |         |
                          ConcreteImplementation1      ConcreteImplementation1
                          return copy of self           return copy of self



p = prototype->Clone()


In Summary, you'll want to implement the prototype pattern when object creation, composition and representation needs to be separate from a given system. 
