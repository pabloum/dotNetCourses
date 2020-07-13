# .Net Core fundamentals

## Integrating Client-side Javascript and class

### Serving static files and content from wwwwroot

By static assets, the author means those files that make up libraries like bootstrap and jQuery.

Everything that is going to be "exposed" should be in this folder. e.g. images, css files, js files, an so on.

### Using ASP.Net Core environments

<environment include="Development"> </environment>
<environment exclude="Development"> </environment>

This is a tag helper. It looks like an HTML tag, but it will be executed on the server.

launchSettings.json
  -> we set the environment.

In Development we want detailed error messages. In Production not.
In Production we may want, for instancem, to include JS script files from a content delivery network. It will serve up those files with a little less latency and be a little be faster and hopefully cached for the end user.

JQuery offers server side validation for forms.

### Enforcing validation on the client

```
@section Scripts {
  <parial name="_ValidationScriptsPartial" />
  <parial name="_NameOfMyScript" />
}
```

### Loading Restuarants from the clients.

I created a new Razor page. I did nothing in the model. But here is what the author wrote on the HTML.

```
@section Scripts {
    <script>


        $(function () {
            $.ajax("/api/restaurants", { method: "get" })
                .then(function (response) {
                    console.dir(response); // ?
                });
        });


    </script>
}
```


### Implementing an API Controller


- Create a folder named Api

- Then, right click on the folder, add a controller, API controller with actions using Entity Framework.

-  
