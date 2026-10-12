# Unite Data

Shared architecture, development workflows, and agent instructions:
[UNITE project documentation](https://github.com/dkfz-unite/.github/blob/main/README.md).

Unite domain models and services.

Repository contains the following packages:
- [Data](https://github.com/dkfz-unite/unite-data/pkgs/nuget/Unite.Data) - domain models
    - Independent package, contains only domain models
- [Context](https://github.com/dkfz-unite/unite-data/pkgs/nuget/Unite.Data.Context) - database context, mappers and services
    - Depends on `Data` package
    - Requires [PostgreSQL](https://github.com/dkfz-unite/unite-env/tree/main/programs/postgresql) for database storage

The packages are used as [NuGet](https://learn.microsoft.com/en-us/nuget/what-is-nuget) dependencies across different services to provide access to the database.

## Model and mapping

The platform uses code first. `Unite.Data/Entities` contains plain entity
definitions, enums, and relationships. Explicit Fluent API mappings live in
`Unite.Data.Context/Mappers` and are applied by `DomainDbContext`; database
mapping attributes are kept out of the entity definitions. Review entities
and their mapper classes together when changing storage behavior.

The context targets PostgreSQL database `unite_data`. Migrations and the model
snapshot live in the separate
[unite-data-migrations](https://github.com/dkfz-unite/unite-data-migrations)
repository. Settle the model/mapping changes, then generate and review the
migration there, apply locally, and check affected services before publishing.
Local development can use sibling project references; Docker verification uses
published package versions selected in consuming projects.
