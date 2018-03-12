ASP.NET Core is a console app using ASP.NET Core libraries
*Better Performing
*Cross Platform 
*Can run on .NET Core or the full .NET Framework
*Runs on .NET Standard

ASP.NET Core Execution Workflow:
* The BuildWebHost lambda invokes the configuration defined in the StartUp class
* Within the StartUp class: 
	*The ConfigureServices() method is called to 
    add and configure services (i.e Components such as EntityFramework Core, MVC, Application Specific Services) 
	to the default ASP.NET Core DI container to be injected into the application
	*The Configure() method is called to use the services specified in the ConfigureServices() method 
	to configure how  HTTP requests are handled through the pipeline. 
	  -> We need to specify and configures the Middleware components in this Configure() method

 * HTTP Requests are handled by MiddleWare components which replaces HTTP Handlers
    * Examples of MiddleWare components are ASP.NET MVC, Diagnostics, Authentication
	* The Request is passed from one MiddleWare to the next with each MiddleWare
	* Each MiddleWare component determines whether to continue processing the request and send it
	  to the next MiddleWare component
	* Order of Middleware matters as the HTTP request is passed along each MiddleWare component

The Microsoft.AspNetCore.All Nuget Package includes all supported ASP.NET Core packages
* The GAC from the .NET Framework has been replaced with Package Stores found on C:\Program Files\dotnet\store\x64\netcoreapp2.0
* To Deploy ASP.NET Core apps, the .NET Core Runtime must be installed for the corresponding version




