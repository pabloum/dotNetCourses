# Design Patterns

## Creational

### Factory and abstract factory

Simple factory - Factory Method - Abstract Factory


A factory is an object for creating objects.

Purpose: allow you to reuse code, as well as introducing extensibility.

There are 3 "Flavors":
  1. Simple factory
  2. Factory Method
  3. Abstract Factory


Factory pattern characteristics.

  1. Client: Asks for a created product
  2. Creator: Facilitates a creation.
  3. Product: The product of the creation.


### Simple Factory
```cs
public static class SkillFactory
{
  public static Skill CreateSkill()
  {
    return new Skill();
  }
}
```

### Factory Method
Implement CreateSkill in various ways by its subclasses.

```cs
public abstract class SkillFactory
{
  public abstract Skill CreateSkill(string params);

  public Skill GetSkill(string params)
  {
    var skill = CreateSkill(params);
    return skill;
  }
}
```

This gives the possibility to add additional common behavior when retrieving a created object. 

### Abstract Factory
