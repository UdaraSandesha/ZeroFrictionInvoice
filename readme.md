# Architecture & used technologies

- This project is developed with .NET 7
- CQRS pattern is used with MediatR with Domain driven Design principals
- EF Core on with Azure CosmosDb is used for Data Persistance

# Running the project

- .NET SDK which supports .NET 7 is needed
- Create an Azure CosmosDb instance and create a container as "Invoices" inside it (use "/Id" as the partition key when creating the Invoices container)
- Add your "AccountEndpoint","AccountKey","DatabaseName" in the appsettings.json file in ZeroFrictionInvoice.Api directory
	- AccountEndpoint is the "URI" value in Keys section of your Cosmos Db account
	- AccountKey is the "PRIMARY KEY" value in Keys section of your Cosmos Db account