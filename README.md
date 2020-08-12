# Inno Stark Assignment
.NET Core multi-layered Web-API with latest Entity Framework version with UOM and Repository Pattern. An API with basic CRUD (Create, Read, Update, Delete) operations.

### Prerequisites
What things you need to run compiled project
* **Visual Studio 2019**
* **.NET Core 3.1**
* **MSSQL Server**

## Built With
* Multi-Layered Architecture - To make it decoupled from each module.
* Implement Repository and Unit of Work pattern.
* Entity Framework Core - Used for for persistence.
* AutoMapper - Add for mapping models into API resources.
* Swagger Middleware - To have a friendly API interface & enable middleware for serving generated JSON document and the SwaggerUI
* Fluent Validation - For building strongly-typed validation rules.
* Bearer Authentication - JWT Authorization header in swagger/

### Layered Architecture
* **API Layer** - Presentation APP - handle API Restful calls, resource mappings and resources validation
* **Core Layer** - Home for models & interfaces
* **Service Layer** - Center of business login, the link between our API and Data.
* **Data Access Layer** - Persistence layer - communicate with database using Entity Framework Core.

### Task Achieved
* Routing
* MVC
* Startup
* Configuration
* Middleware
* UOM Pattern
* Repository Pattern
* Layered/n-tier architecture
* Solid-Principles
* Git Repository
* Compiled - Ready to run

## Bearer Authentication Key
- Bearer (apiKey): innostarkassignmentkey
- Authentication Username: innostark
- Authentication Password: 123456
```
To perform delete operation, user must be authorize
```



