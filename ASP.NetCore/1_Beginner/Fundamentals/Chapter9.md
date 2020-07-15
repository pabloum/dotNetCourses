# ASP.Net Core Fundamentals

## Deploying ASP.Net Core Applications

### Publishing apps vs Deploying Apps

Putting the ASP.Net Core Application somewhere in a server-hosting environment.

The hosting can vary widely.

  -> Windows server running IIS
  -> Linux server running NginX or Apache


- *Publishing* .Net Core Application: Something you hace to do before deploying.
                Makes sure all the files and everything you need is put together into a specific location so you can take all the files that you need and then deploy them.

                Advanced settings:
                    1. Configuration: Debug / Release
                    2. Target Framewotk
                    3. Deployment mode: Framework dependent OR Self-Contained (does not depend on a framework being installed on the server)
                    4. Target runtime: (for deployment mode): win-x86, win-x64, osx-x64, linux-x64.
                        Where is the app going to be running.


- *Deploying*  .Net Core Application:


### Using dotnet publish

dotnet publish --help

e.g.
dotnet publish -o :c/temp/PumToFood

then inside that folder you could run your program:
dotnet PumToFood.dll


Be careful. For this case, the folder node_modules was not published. Thus, there would be an error if you try to execute `dotnet PumToFood.dll`. You could run `npm install` in that folder because there is `package.json` but that is not ideal, especially if you want to automate things.


### Using MSBuild to execute npm install


MSBuild -> the .csproj  xml


Edit: add the following:

```
<Target Name="PostBuild" AfterTargets="ComputeFilesToPublish">
    <Exec command="npm install"/>
</Target>
```

This is the simplest scenario. You could check before if Node, npm is installed, or you could just do that for development or release.

Then, you also need to add the following:

```
<ItemGroup>
    <Content Include="node_modules/*" CopyToPublishDirectory="PreserveNewest"/>
</ItemGroup>
```

Also delete other previously included node_modules things.

Now, you should be able to run `dotnet PumToFood.dll`

This approach is Framework dependent. Faites attention.

### Building a self-contained Application

i.e. Does not require to have a version of the framework installed. GG
