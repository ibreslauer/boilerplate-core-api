# Boilerplate.Data library

### About
This library's purpose is to contain:
- DbContext and models generated from an existing SQL database schema (database-first approach)  
- Services that use the generated DbContext to execute queries and commands

### Data Model Scaffolding
The **`BoilerplateDataContext`** is scaffolded from a specified SQL database (`BoilerplateDb` on localhost) using this PMC (Package Manager Console) command:

`Scaffold-DbContext -Connection name=ConnectionStrings:Default -Provider Microsoft.EntityFrameworkCore.SqlServer -Force -Context BoilerplateDataContext -ContextDir Context -OutputDir Models -UseDatabaseNames -DataAnnotations -Tables User, UserToken`

The command explicitly lists the tables to be included in the scaffolding so it doesn't scaffold the whole schema.

**Note:** Running the command overwrites the existing classes and is a destructive action.
Before running the command set `Boilerplate.Data` as the _Default project_ in Package Manager Console's dropdown.
If you want new tables/views scaffolded, include them in the `-Tables` parameter.

### Connection string
The `-Connection` parameter of the above command points to a value from the settings file `appsettings.json`.
Since connection strings can contain sensitive data, they shouldn't be kept in the project or source control, but - as one of the options - in the runtime machine's _Environment Variables_.

To add a connection string to your _Environment Variables_ use this command:  
`setx boilerplate_ConnectionStrings__Default "data source=<SERVER>;initial catalog=<DATABASE>;persist security info=True;user id=<USER_ID>;password=<PASSWORD>;" /M`

**`setx`** command persists the environment variable, the **`/M`** switch sets the variable in the System environment (without the switch the variable is set in _User variables_).  
The **`boilerplate_`** prefix is there only to denote that the variable is used by the Boilerplate API and is discarded at runtime.  
`ConnectionStrings__Default` key corresponds to the `ConnectionStrings { Default: "" }` section of the `appsettings.json` configuration.

**Note:** When using the default ASP.NET Core configuration, environment variable key-value pairs are loaded after reading appsettings.json and will therefore override values from the appsettings configuration.

### References:
[Configuration in ASP.NET Core](https://docs.microsoft.com/hr-hr/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1)  
[Reverse Engineering/Scaffolding](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding)

