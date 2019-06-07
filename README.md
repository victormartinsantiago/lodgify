#  Readme

## 1. Data Model

To cater for future changes, I've modeled the domain so that one rental may have more than one contact. Current implementation processes a single contact (default contact).

## 2. Database Choice

In order to facilitate development and make the process of running the solution easier, the service is configured to use an in memory implementation of Entity Framework:  `Microsoft.EntityFrameworkCore.InMemory`  This means the data will only be kept while the service is up and running. 

The service can, nevertheless, be reconfigured the use a SqlServer implementation `Microsoft.EntityFrameworkCore.SqlServer`:

 - **BuildAndRun.ps1**: Update the environment variable `CONNECTION_STRING` with the approriate connection string targeting a newly created SqlServer database
 - **VacationRental.Contact.Api/Properties/launchsettings.json**: Update the environment variable `CONNECTION_STRING` with the approriate connection string targeting a newly created SqlServer database.
 - **VacationRental.Contact.Api/Startup.cs**: Uncomment the line `app.ApplicationServices.EnsureDatabaseCreated()` so that the database schema gets populated on the target database when the service starts up.
 - **VacationRental.Contact.Domain/Extensions/ServiceCollectionExtensions.cs**: Comment out the line `serviceCollection.AddInMemoryDataRepository()` and uncomment the line `serviceCollection.AddSqlServerDataRepository()`. This will configure the DbContext to use SqlServer and read the connection string from the environment variable `CONNECTION_STRING`

## 3. Running the service as a container

A `Dockerfile` is provided at the root level that builds a Docker image for the `VacationRental.Contact.Api` project. A multistage approach is used so that the resulting image is as light as possible. 

A powershell script `BuildAndRun.ps1` is also provided. This script will trigger the Docker image creation and it will spin up a new container after a successful build. The script is parametrized for convenience.
