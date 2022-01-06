# ServiceCenterBackend

This is .NET Core backend which supports for frontend applications to connect with different service engineers and get their service. Service engineers having different specialist areas and depending on customer request and availability of engineers, assigned engineers may be differ for each customer.

## Setup

You can clone or download solution and build to get required nuget packages and ready the solution

## Data Storing

There should be a way to store engineers data easily for aplication functionalities. Insted of using file here i used **[Cache in-memory](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-6.0&viewFallbackFrom=aspnetcore-2.2)** .

It will initially read data from file(Kacific_service_engineers.json) in **Startup.cs** and store data into a local cache of application and it will remain 3 hours(as per configuration. this can change) from application start then we can use them in any level in the application to edit, update or remove. This should be replace with database in the real application

## Architecture

![Codingtest drawio (1)](https://user-images.githubusercontent.com/90056026/148330745-9abc4579-12fe-410e-94d1-4f6b90f299ae.png)

## Logging

**[NLog](https://nlog-project.org/)** is used to trace the aplication by logging. It initialize in the **Program.cs**. We can inject them whenever need in the application and use

## Check the functionality

- You can easily get the **[ServiceCenterFrontend](https://github.com/ishankapr/ServiceCenterFrontend)** application and connect the backend with that and test the scenarios
- Use postman and make request from it

### Postman cURL

curl --location --request POST 'http://localhost:17859/api/user/connect' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Name": "User1",
    "Category": 1,
    "LanguageLevel" : 1
}'

