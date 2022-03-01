# Smart Charging

The project is developed in Rider and a temporary cloud database used (SQL Server).
Connection string can be found in `appsettings.Development.json`

1. Select configuration in IDE: SmartCharging.Api - Development 
2. Run the project
3. Swagger window will open
4. Additional database connection is not required. You can use any tool to track data changes.
5. Create Group
6. Create Charge Station
7. Create Connectors
8. Run other APIs

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