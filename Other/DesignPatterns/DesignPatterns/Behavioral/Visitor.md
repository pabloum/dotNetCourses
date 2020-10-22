
# Design Patterns

## Behavioral

### Visitor

Create Visitor Blueprint
Then implement concrete classes

Visitor is behavioral because it focuses on communication between objects.

Represents an operation to be performed on the elements of an object structure without changing the classes of the elements on which it operates.

* Behavior can be added to existing hierarchy.
  - No changes to underlying classes
* Behavior is class-specific
* No hierarchical connection is necessary
  - as long as classes are marked as visitable.

Visitor Pattern diagram:
  ![Ola k ase](UMLDiagram.PNG)


This design pattern might be useful when:

  _"When a project has several different classes, with different interfaces, that need additinal behavior without changing their underlying structure"_
