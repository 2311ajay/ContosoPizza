# ASP.NET Core
## A simple implementation of the popular ASP.NET Core backend framework 

[![N|Solid](https://ardalis.com/static/2bcf8d1ec45106e529bb3a6176467a31/c5cb2/aspnetcore-logo.png)](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)

Markdown made with [Dilinger.io](https://dillinger.io/)
## Features

- Rate-limitting capabilities, referred from [CodeMazeBlog](https://github.com/CodeMazeBlog/CodeMazeGuides/tree/main/aspnetcore-webapi/RateLimitingDemo/RateLimitingDemo.UsingCustomMiddleware).
- Basic CRUD operations, applied and adapted from [Microsoft ASP.NET Core](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/1-introduction).
- [MongoDB](https://www.mongodb.com/) database for persistent storage, 

Treat this repo as a first step on your journey to mastering ASP.NET Core. 

## To Do

The front end folder contains a template from [Vercel](https://vercel.com/templates/next.js/admin-dashboard-tailwind-postgres-react-nextjs), more work needs to be done to connect front and backend:
- [X] Add [automated code generation](https://github.com/acacode/swagger-typescript-api) for REST framework using the Swagger file generated in backend. 
- [] Make sense of client-server interaction of the nextJs project.


## Installation

At the moment, the install guide is for backend only

Project requires [aspnetcore](https://dotnet.microsoft.com/en-us/download/dotnet) 6.0 to run. Please note that the versions REALLY matter and can lead to weird issues with supporting packages.

Install the dependencies and devDependencies and start the server.

```sh
cd ContosoPizza
dotnet watch
```