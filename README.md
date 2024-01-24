Conigure App
1. First Config your SQL Server Connection string in appseting.json file
   ![image](https://github.com/mahdigholamipak/BookLibrary/assets/80640317/4706640d-461e-4e91-a0ae-67f7c75a869c)

2. Add Migration
  in package manager console enter: Add-Migration InitMigration
or in powershell enter: dotnet ef migrations add InitMigration

3. Update Database
    in package manager console enter: Update-Database
or in powershell enter: dotnet ef database update
create reame.md file
