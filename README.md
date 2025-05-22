# License Management Portal

A web application for managing software licenses, organizations, resellers, and related entities.
The Frontend part can be found [here](https://github.com/Adeity/dp-fe-new) and the unit tests [here](https://github.com/Adeity/dp-be-unit-tests)
## Features

- User authentication and role management (Admin, Reseller, etc.)
- Organization and contact management
- License and activation tracking
- Package and subscription management
- Invoice management
- Serial number request logging
- RESTful API with OpenAPI/Swagger documentation

## Tech Stack

- ASP.NET Core (.NET 9)
- Entity Framework Core (Code First, Migrations)
- SQL Server (see `db-compose.yaml` for Docker setup)
- Identity for authentication and authorization

## Project Structure

- `Controllers/` - API controllers
- `Context/` - Entity Framework DbContext and conventions
- `Model/` - Entity and DTO classes
- `Repositories/` - Data access layer (repositories and interfaces)
- `Services/` - Business logic layer
- `Utilities/` - Helper classes and utilities
- `Migrations/` - EF Core migrations
- `Extensions/` - Extension methods (e.g., seeding)
- `Properties/` - Launch settings

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/) (for local SQL Server)

### Setup

1. **Start the database:**
    ```sh
    docker compose -f db-compose.yaml up -d
    ```

2. **Apply migrations and seed data (optional):**
    - Uncomment the following lines in `Program.cs` (inside the development environment block):
      ```csharp
      // app.DeleteDatabase();
      // app.ApplyMigrations();
      // app.ApplySeeds();
      ```
    - Run the application once to initialize the database, then comment them again.

3. **API Documentation:**
    - Visit [http://localhost:5077/swagger](http://localhost:5077/swagger) for Swagger UI.

## Configuration

- Connection strings and environment variables are set in `appsettings.json` and `appsettings.Development.json`.
- Launch profiles are in `Properties/launchSettings.json`.

## License
MIT
