# Create project 
````bash 
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL # add libari
`````

````bash 
dotnet add package Microsoft.EntityFrameworkCore.Tools
````

# Add Configuration 
````bash
 "ConnectionStrings": {
    "DefaultConnection": "Hos=localhost;Port=5432;Database=minhaapi_db;Username=postgres;Password=postgres"
    }
````


dotnet add package EFCore.NamingConventions