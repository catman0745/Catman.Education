# Catman.Education

School / college API for student testing

### Live demo

[React UI](https://github.com/catman0745/catman-edu-webui) live demo: [Catman.Education](https://catman-education.xyz).
API demo base URL: [catman-education.xyz/api](https://catman-education.xyz/api).

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
