# Notes

## Resources

### Migrations
You will need the `dotnet-ef` tool installed. See more [here](https://learn.microsoft.com/en-us/ef/core/cli/)

To create new migrations:
```
dotnet ef migrations add MigrationName
```
Choose a descriptive name for `MigrationName`

Then, to apply migrations:
```
dotnet ef database update
```

This can also be used to initialize the database
You will probably need the `ASPNETCORE_ENVIRONMENT=Development` environment variable set, otherwise it may default to `Production`, which is fine if you intend to update the database for production.

### Docker
https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-10.0
https://medium.com/codex/containerizing-a-net-app-with-postgres-using-docker-compose-a35167b419e7

### Postgres
The Users table is actually AspNetUsers

## Feedback (week 1)
- would be nice to be able to have an option to say why a request was rejected
- when a request for non-sensitive data comes through should be automatically approved
- admins should have the options to add new datasets
- button to extend expiry dates
  - non-sensitive data should be automatically extended
- use the official colour palette and logo (no crown)
