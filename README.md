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

## Tests
