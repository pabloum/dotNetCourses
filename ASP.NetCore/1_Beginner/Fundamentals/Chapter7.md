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

- Adjust StartUp
      // for aspnetcore3.0+

      services.AddRazorPages();
      services.AddControllers();


      app.UseRouting();            
      app.UseEndpoints(e =>
      {
          e.MapRazorPages();
          e.MapControllers();
      });


### Using Data Tables

Documentation: https://datatables.net

You could either:
  1. Go to that page, manually download the plug-in and paste it into the wwwwroot
  or
  2. Rigth click on wwwwroot, Add, Client-side Library, Search for datables and click installl
  or
  3. Copy and paste the cdn from the Documentation page.

Other option. (Recommended by the author)

  4. Use NPM:
    In the same folder where wwwroot: `npm init`
    then paste `npm install --save datatables.net-bs4`


### Managing Production Scripts and Development scripts

After the download with npm, make sure to reference the files where you need

```
<environment include="Development">
    <script src="~\node_modules\datatables.net\js\jquery.dataTables.js"></script>
    <script src="~\node_modules\datatables.net-bs4\js\dataTables.bootstrap4.js"></script>
    <link href="~\node_modules\datatables.net-bs4\css\dataTables.bootstrap4.css" rel="stylesheet" />
</environment>
```

The author suggest that if you start using NPM, use every Library with that. So the previously downloaded and used bootstrap and jQuery files, should be cleaned up, and installed later on with NPM.

### Serving files from node_modules directory

We used a NuPackage created by OdeToFood, to load scripts from a different script than wwwroot. After installing it, we edited Startup.cs. => app.UseNodeModules();

We learned how to integrate some Front-End libraries. Using CDN, or NPM, or even downloading it could be a possibility.

Datatables => pre built table. Cool to use.


### Summary

We learned how to integrate client-side libraries.
We learned how to expose an API. The one that we implemented was very simple though. 
