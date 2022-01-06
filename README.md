# ServiceCenterBackend

This is .NET Core backend which supports for frontend applications to connect with different service engineers and get their service. Service engineers having different specialist areas and depending on customer request and availability of engineers, assigned engineers may be differ for each customer.

## Setup

You can clone or download solution and build to get required nuget packages and ready the solution

## Data Storing

There should be a way to store engineers data easily for aplication functionalities. Insted of using file here i used ** [Cache in-memory](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-6.0&viewFallbackFrom=aspnetcore-2.2)** .

It will initially read data from file in ** Startup.cs ** and store data into a local cache of application and it will remain 3 hours(as per configuration. this can change) from application start then we can use them in any level in the application to edit, update or remove. This should be replace with database in the real application

