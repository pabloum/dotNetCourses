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
