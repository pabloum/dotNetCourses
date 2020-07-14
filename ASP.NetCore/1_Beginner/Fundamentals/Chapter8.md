# ASP.Net Core fundamentals

## Chapter 8: Working with the internals of ASP.Net Core

Behind the scenes.

Topics: 1. Request processing with middleware
        2. How ASP.Net core program gets started
        3. Look up more details of the configuration
        4. How to log diagnostic information.


### Exploring the Application Entry-Point  (Program.cs)


```
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

### Middleware
  Analogy:  Corn story -> Son, Mom, Dad pipeline.

  Logger => Authorizer => Router

  Middleware pipeline is bidirectional. Request flow in, and responses flow out.

  In StartUp class, in Configure() method, you "install" the middleware


### Exploring the Application middleware

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); `// To display html and detailed erros in case of exception `
}
else
{
    app.UseExceptionHandler("/Error"); `// To display user friendly error, without sensitive info in case of exception `
    app.UseHsts(); // Tells the browser only to access this info over a secure connection.
}



### Building custom Middleware

Jeje.  Like for example, UseNodeModules() installed from OdeToCode. Toll, oder?

app.Use(SayHelloMiddleware);

[. . .]

RequestDelegate SayHelloMiddleware(RequestDelegate next) {
    return async ctx => {
      if (ctx.Request.Path.StartsWithSegments("/hello")){
        ctx.Response.WriteAsync("Hello, World!");
      }
      else {
        await next(ctx);
        if (ctx.Response.StatusCode ){
          // do  something if you want
        }
      }
    };
}

RequestDelegate:  is a method that is going to handle an HTTP request.
    delegate Task RequestDelegate(HttpContext context); // definition of RequestDelegate



### Logging Application messages.

Debug -> Windows -> Output ..:: ::.. => Aquí puedo ver los logs

### Configuring the App using the default web host builder

The output, can show only Warning messages, or Error messages or Info messages. You can set up to show all what you want.

ASP.Net core open source (?)
github.com/aspnet/AspNetCore => Repo

Configuration sources in .Net Core are hierarchical. Meaning, if you use the same name for attributes in appsetting.json, appsettings.Development.json, or any other, it will take the last which was loaded. (Check the implementation of CreateDefaultBuilder() on github)
