# Unite Data
Unite domain models and services.

Repository contains the following packages:
- [Data](https://github.com/dkfz-unite/unite-data/pkgs/nuget/Unite.Data) - domain models
    - Independent package, contains only domain models
- [Context](https://github.com/dkfz-unite/unite-data/pkgs/nuget/Unite.Data.Context) - database context, mappers and services
    - Depends on `Data` package
    - Requires [SQL](https://github.com/dkfz-unite/unite-environment/tree/main/programs/postgresql) service to map domain models to database tables

The packages are used as [NuGet](https://learn.microsoft.com/en-us/nuget/what-is-nuget) dependencies across different services to provide access to the database.
