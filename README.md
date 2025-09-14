## EF Core Setup

This project uses Entity Framework Core with SQLite.

### 1. Install EF Core tools (first time only)
```
dotnet tool install --global dotnet-ef
```
### 2. Create database & apply migrations

From the solution root, run:

```
dotnet ef database update -p ExpenseTracker.Infrastructure -s ExpenseTracker.WebApi
```
### 3. Add a new migration (when models change)

```
dotnet ef migrations add MigrationName -p ExpenseTracker.Infrastructure -s ExpenseTracker.WebApi
dotnet ef database update -p ExpenseTracker.Infrastructure -s ExpenseTracker.WebApi
```
### 4. Database file location

The SQLite database is stored at:

#### ExpenseTracker.Infrastructure/Data/expense-tracker.db
