# MyTrailer

## Overview

MyTrailer is a trailer rental application that allows customers to search, book, and rent trailers. This project follows a monolithic architecture while applying Domain-Driven Design (DDD) principles.

### Features
- Search for available trailers
- Book trailers for short or long-term rental
- Secure payment process
- Optional insurance offerings
- Trailer return and late fee processing

## Architecture

The project follows a layered architecture:
- **Domain**: Contains the core business logic and domain entities.
- **Application**: Orchestrates the business logic and communicates with the infrastructure layer.
- **Infrastructure**: Responsible for data persistence and external system interactions.
- **API**: Provides a RESTful API for clients.

## Technology Stack

- **.NET 8.0**
- **Entity Framework Core** for data persistence
- **ASP.NET Core** for API development
- **Swagger** for API documentation

## Our Solution
- We began by building our solution as a Monolithic application, guided by the insights gained from our event-storming model. This helped us identify bounded contexts and domain entities, and gave us a solid understanding of the business logic and application flow.  
  The monolith was designed following a layered architecture, with clearly defined Domain, Application, Infrastructure, and API layers, and our project structure reflects this setup.  
  We opted for this approach because of the familiarity and simplicity of layered architecture, which offers easier development and testing—especially beneficial for a small team like ours. Plus, it allowed us to quickly set up the monolith and get the application running for the next development stages.


- Once the initial Monolithic prototype was in place, we began breaking it down into microservices.
    - Using the Strangler Fig pattern, we were able to gradually extract features from the monolith and move them into independent microservices. Services like payment and insurance were prime candidates for this, as they were not directly tied to the core business logic and could be separated relatively easily.
      - We refactored the monolith to communicate with the microservices via RESTful APIs. The microservices were built using the same technology stack as the monolith but on a smaller scale, making it easier to maintain and scale specific services.

## Design of the Monolith

### Domain

The Domain layer forms the core of our application, holding the business logic and domain entities. 
Our domain entities are implemented as simple POCOs (Plain Old CLR Objects), 
with data annotations to handle validation effectively. To ensure stability, 
our value objects are designed as immutable, meaning once they're created, 
they can't be changed. This helps maintain the integrity of the business rules. 
Aggregates in the domain encapsulate both entities and value objects, 
ensuring that related components are grouped logically and operate cohesively within their boundaries.

### Application

The Application layer is where business logic gets orchestrated. 
It acts as the middleman, coordinating communication between the Domain and Infrastructure layers. 
Our application services are stateless and purpose-driven, with each service focused on a specific use case. 
These services depend on domain services and repositories to perform operations, ensuring smooth data flow and logic handling. 
To streamline communication, we also use DTOs (Data Transfer Objects), which help manage input and output between different layers of the application, 
making sure everything stays clean and efficient.

### Infrastructure

Handling all the behind-the-scenes operations, the Infrastructure layer manages data persistence and the database. 
We’ve set up EF Core’s `DbContext` and entity configurations to maintain seamless interaction with the database. 
This layer is also responsible for managing EF Core migrations, allowing us to evolve the database schema over time. 
Additionally, seed data is included to initialize the database, making the setup process smoother and ensuring it's ready to go from day one.

### API (The Layer Named MyTrailer)

The API layer serves as the interface for external clients, providing a RESTful API to interact with the system. Our controllers handle the actions required for various use cases, relying on Application services to execute the underlying logic. We’ve also incorporated Swagger for API documentation, making the API easier to navigate. In the prototype phase, Swagger also doubled as a simple GUI for testing, offering a user-friendly interface to explore the application's endpoints and features.

## Design of Entities, Value Objects, and Aggregates

- **Entities**: We kept the design of our entities simple, focusing only on the essential properties and methods required for the application.
---
- **Value Objects**: Our value objects are immutable, with read-only properties and no public setters, ensuring their integrity once created.
---
- **Aggregates**: Aggregates are responsible for encapsulating the related entities and value objects, providing methods that enforce business rules and consistency within the aggregate boundary.

## What We Would Do Differently

If we were to start over, we would dedicate more time to domain modeling and design. This would ensure that our entities, value objects, and aggregates are not only well-defined but also closely aligned with business requirements from the outset.  
Ubiquitous language and bounded contexts, core concepts of DDD, would also be more rigorously applied to ensure clearer communication and design consistency within the domain.
----
## Notes:
**Regarding Tests:**
even though it wasn't a requirement a small number of tests were written for the calculation of the late fee and the insurance cost. but were later not usable/runnable as the payment service was extracted to a microservice.
