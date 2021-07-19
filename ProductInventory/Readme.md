**Product Inventory Programm**

This console application is using .NET Core

When running the console application you will see a formatted table to show the Sell In and Quality Information for each item in the command line


There is a startUp class that makes use of ConfigureServices class to serve instances of the services
These are called within the Program class to allow use through out the application

There is a background task set using IHostedService for automatic updates to the table after 24 hours
UpdateInventoryService Class contains the logic to update each Inventory Item in the console table
InventoryTableService class contains the logic for creating the console table - UpdateInventoryService class methods are used here through dependency injection

Unit tests using MSBuild are located in the test project
There you can run the test explorer to check if logic is passing


