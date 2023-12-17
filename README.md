# Resumade Application Setup Guide

## Requirements

To run the Resumade application, the following requirements must be met:

### SQL Server Instance

An instance of SQL Server is required to be running on the local machine. This instance can be run in a Docker container or installed and run locally.

### Connection Strings

You will need to provide connection strings in the `Resumade.Server` project's `appsettings.json` file. Replace the example strings with your actual connection strings. Below are the placeholders for the connection strings:

```json
"AuthConnectionString": "Server=127.0.0.1,1433; Database=AuthenticationDatabase; User=sa; Password=ResumadeStrongPassword123!;TrustServerCertificate=true;",
"ResumadeConnection": "Server=127.0.0.1,1433; Database=ResumadeDatabase; User=sa; Password=ResumadeStrongPassword123!;TrustServerCertificate=true;"
```


### Separate Databases for Authentication

Note that separate databases will be created for the authentication side of the application and the main application data.

## Database Setup

Once the SQL Server instance is running and the connection strings are set up, execute the following commands to update the databases:

### Prerequisites

Ensure you have the following installed:

- .NET Core 7 SDK
- EF Framework Core Tools 7.0.1 (or higher)

### Update Database

Navigate to the Server directory of the Resumade project and run the following commands:

```bash
cd path/to/Resumade/Server
dotnet ef database update --context ResumadeContext 
dotnet ef database update --context ApplicationDbContext
```


These commands will apply the necessary database migrations to your SQL Server instance.

## Running the Application

Once the databases are set up and migrated, you can run the application:

1. Navigate to the root directory of the project.
2. Run the following command:

```bash
dotnet run
```

This command will start the application.

## Accessing the Application

After starting the application:

- The frontendwill be accessible at `https://localhost:7264`.

## Usage

- To use the application, navigate to the provided frontend URL in your web browser.
