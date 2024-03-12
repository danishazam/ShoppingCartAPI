# ShoppingCartAPI

A Shopping Cart Web API project in C#. The project uses SQL Server as backend.

# Configuration

Change the database connection string in appsettings.json

# Database Migration
Use the following commands in either Package Manager Console or PowerShell to initialize the DB

PM> Add-Migration "InitialCreate" \
PM> Update-Database

