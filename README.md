# Smart Charging

The project is developed in Rider and a temporary cloud database used (SQL Server).
Connection string can be found in `appsettings.Development.json`

1. Run the project
2. Swagger window will open
3. Additional database connection is not required. You can use any tool to track data changes.
4. Create Group
5. Create Charge Station
6. Create Connectors
7. Run other APIs

### Migration

`dotnet ef --startup-project ../SmartCharging.Api migrations add [MIGRATION_NAME]`

`dotnet ef --startup-project ../SmartCharging.Api database update`

### Tools
* .NET 6 SDK
* Rider or Visual Studio 2022

### Tech Stack & Patterns
* .Net 6
* Entity Framework Core
* SQL Server
* Swagger
* AutoMapper
* Unit Of Work
* Repository