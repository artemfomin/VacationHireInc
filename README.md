| Requirement                   | Done | Comment 
|-------------------------------|------|---------
| Complete backend API          | Partialy | For a complete backend had insufficient time and conditions (e.g. live environment) 
| Dockerized microservices      | Done | 
| Domains with bounded contexts | Done | 
| RESTful API                   | Done | Minimal APIs
| Basic authentication          | - | For multiple microservices authentiction should be more than basic (e.g. OIDC, SAML, etc) which improves complexity too much for a short test period
| Cloud design patterns         | Partially | 12 Factor app
| Mocked data layer             | Done | SQLite
| Architecture documentation    | Done | End of this README

# Requirements

- .NET 8 SDK
- Environment variable `ConnectionStrings__VHI` with connection string for Rental API
- Environment variable `ConnectionStrings__VHI_Invoicing` with connection string for Invoicing API

# API docs
Please see [API documentation](./.docs/API%20docs.md)  
Or feel free to use  [Postman request collection](./.postman/RentalAPI.postman_collection.json)

# Security

Security measures should be performed in infrastructure as well.
- API accessibility level is managed by web server, load balancer or ingress controller
- TLS is performed by public cloud app instance or ingress controller
- Authentication is performed by external source
- EF Core ORM eliminates SQL injections
- In production databases are not exposed and kept within cluster or accessed using managed identity

# Extensibility

Service `Rental` can be easily extended internally or cloned / forked with different asset types to handle new types of rentable assets.

# Highlights

- `Rental` API is developed deeper using Clean architecture while `Invoicing` is done simpler to save time
- Unit tests are not done due to time shortage. To show how I do unit tests I share also my old technical task
- Communication between APIs is not done as it's a good practice to use message brokers in distributed systems. However good setup of SB, Kafka or RabbitMQ is quite time consuming
- Sometimes we can find unused classes. I added some (e.g. `CommandTransactionalBehavior`) to demonstrate different automation opportunities if it was production setup (in this example not SQLite which doesn't support transactions)
- `CurrencyRates` should be updated by function or other serverless app and stored externally in S3 / Azure compatible file storage

# Possible next actions

- Code cleanup (hurry is not the best strategy)
- Add authentication source (Azure EntraID, KeyCloak, Identity Server, OAuth)
- Add industry type database MSSQL / Postgres
- Add IaC
- Create docker environment or K8s environment 
- Add vendor images / charts (e.g. Apache Kafka, MinIO)

# Application architecture
![Application architecture](./.docs/Vacation%20hire%20inc%20-%20App%20level.svg)

# Data architecture
![Data architecture](./.docs/Vacation%20hire%20inc%20-%20Data%20architecture.svg)

# Component architecture
![Component architecture](./.docs/Vacation%20hire%20inc%20-%20Component%20architecture.svg)


