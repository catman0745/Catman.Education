# Catman.Education

School / college API for student testing

### Architectural notes

`Catman.Education.Application` is the core of the API. The core **must** be responsible for all kinds of checks, validations and domain rules. The core **must not rely** on other tiers to do this. But that does not mean that other tiers cannot do it either (e.g. `Catman.Education.WebApi` does a simple `DTO` validation and authorization to reduce the load on the application).

**Note**: *if `Catman.Education.WebApi` for example stops validating `DTO`s, the application will continue to function correctly. `Catman.Education.WebApi` does not contain critical checks but simply duplicates some checks from `Catman.Education.Application`.*

### Dependencies

- Databse is `PostgreSQL 12`
- Runtime is `.Net 5.0`

### How to run

Set following environment variables:
| Variable name | Purpose | Default value |
| --- | --- | --- |
| `CATMAN_EDUCATION_CONNECTION` | Postgres db connection string | |
| `CATMAN_EDUCATION_AUTH_ISSUER` | Authorization token issuer name | Catman.Education |
| `CATMAN_EDUCATION_AUTH_AUDIENCE` | Authentication clients name | Catman.Education.Audience |
| `CATMAN_EDUCATION_TOKE_LIFETIME` | Token lifetime in minutes | 60 |
| `CATMAN_EDUCATION_AUTH_KEY` | JWT encryption key (**must be at least 16 characters long**) | |
| `ASPNETCORE_ENVIRONMENT` | Environment type (usually `Development`, `Staging` or `Production`) | |
| `CATMAN_EDUCATION_CLIENT_ORIGIN` | Allowed client origin (leave empty to allow any) | |

#### Run development version locally

Restore dependencies:

```
dotnet restore
```

Apply migrations:

```
dotnet ef database update -s Catman.Education.WebApi -p Catman.Education.Persistence
```

Start the API (default port is `5000`):

```
dotnet run -p Catman.Education.WebApi
```

#### Deploy on server

Publish application:

```
dotnet publish -o ./publish --no-self-contained -c Release
```

Create migration script:

```
# Create a script containing all migrations:
dotnet ef migrations script -i -o "publish/migration.sql" -p Catman.Education.Persistence -s Catman.Education.WebApi

# Create a script containing all migrations after "SpecificMigration":
dotnet ef migrations script "SpecificMigration" -o "publish/migration.sql" -p Catman.Education.Persistence -s Catman.Education.WebApi
```

Send the `publish` folder to the server.

Apply migration:

```
psql -d <db_name> -f /path/to/migration.sql
```

Launch WebApi:

```
/path/to/Catman.Education.WebApi
```
