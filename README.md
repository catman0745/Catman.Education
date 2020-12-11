# Catman.Education
School / college API for student testing


### How to run

Set following environment variables:
| Variable name | Purpose | Default value |
| --- | --- | --- |
| `CATMAN_EDUCATION_CONNECTION` | Postgres db connection string | |
| `CATMAN_EDUCATION_AUTH_ISSUER` | Authorization token issuer name | Catman.Education |
| `CATMAN_EDUCATION_AUTH_AUDIENCE` | Authentication clients name | Catman.Education.Audience |
| `CATMAN_EDUCATION_TOKE_LIFETIME` | Token lifetime in minutes | 60 |
| `CATMAN_EDUCATION_AUTH_KEY` | JWT encryption key (**must be at least 16 characters long**) | |
| `ASPNETCORE_ENVIRONMENT` | Environment type for | |
| `CATMAN_EDUCATION_CLIENT_ORIGIN` | Allowed client origin (leave empty to allow any) | |

Restore dependencies:
```
dotnet restore
```

Apply migrations:
```
dotnet ef database update -s Catman.Eudcation.WebApi -p Catman.Education.Persistence
```

Start the API (default port is `5000`):
```
dotnet run -p Catman.Education.WebApi
```
