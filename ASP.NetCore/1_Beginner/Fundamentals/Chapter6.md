# .Net Core fundamentals

## Building the user interface. More tips to work with razor pages

Layout page, ViewStart and View Import.
Partial views. View components.

### Razor Layout pages and sections.

@page     // Provides the ability to respond to an URL.
@{

}

This directive is what makes a page a Razor page.

Layout page is NOT a razor page.
  This one would be a Razor View.

3. `_Layout.cshtml`. The underscore ( _ ) is a convention for saying that that view is not rendered by its own. That View is needed from another in order to populate. This view is a component that is required by other views, or plugs in into something else.


This would go inside Layout, to indicate to insert all the produced html from other file.

@RenderBody()

@RenderSection("nameOfMySection", required: false)

---- Inside the razor page, for example:
@section nameOfMySection  {
  <div> My message </div>
}

### Layout
We can avoid using the default layout or just set the layout that we want to use.
For instance.
```
@{
    Layout = null;
}

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
</body>
</html>
```

Where to we set the defailt layout?
  `_ViewStart.cshtml`

Where to we import all namespaces and tag helpers?
  `_ViewImport.cshtml`


### Reusing markup with Partial views.

Follow the same steps for razor page, but uncheck `Generate Page Model` and check `Create a partial view`

Remember the conventio: Use underscore _ to indicate that it is not a primary page.


### Using a View component

Uses MVC pattern.

Difference with a Pazor page: View component does not respond to a HTTP request. I'm not worried about GET or POST or any of that.

A view component is more like a partial view. It is going to be embedded inside other view, which is simply going to say: please, go and render this component.

When that happens, ASP.Net is going to call a method called Invoke(), which you have to implement in your class, which should implement `ViewComponent` interface.

### Rendering a view component.

Convention: Create named Components inside Shared folder.

There, create the folder of your created ViewComponent. e.g. RestaurantCount

Add reference inside `_ViewImports.cshtml`

    `@addTagHelper *, PumToFood`

Kebab case (kebab-case)
<vc::restaurant-count></vc::restaurant-count> // Where you want to place your view component.

What if you need to send parameters?

  <vc::restaurant-count myParameter="coso"></vc::restaurant-count>

  then on the Invoke method:

  Invoke(in myParameter) {}


Important difference:

  *View compoent* A view component can be completely independet.
  *Partial view* Always depends on model information coming from its parent view.
