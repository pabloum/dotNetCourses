
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

->
```cs
public override Prototype ShallowCopy()
{
    return (Prototype)this.MemberwiseClone();
}
```
MemberwiseClone -> Returns a shallow copy of the current object.
ShallowCopy means that all non-static value types in the object are copied over to the clone but reference types only have their addresses copied. That means that any change to the original object will affect the copied object which can be veru troublesome in most cases.




*Important variant*
Adding a prototype manager:

Very common, so you'd better get used to it.


Prototype works well with Object Pool (though not originally included in the gang of 4) especially if it has a manager class.

Works with indefinite variety of prototypes. Not only 1. You can implement that interface as many times as you wish.


*Use cases and implications*

* Not for everything - all classes don't need copy behavior.
* When classes to instantiate are specified at runtime
* Avoiding a class hierarchy of factories that mirrors the class hierarchy of your products
* When classes can only have a small, finite combination of states.
