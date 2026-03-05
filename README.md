# Shopping Cart Minimal Implementation

The minimal solution is implemented as a single **ASP.NET Core Web API** service using a **layered architecture** approach. In a full production scenario, **User** and **Product** functionalities would typically be implemented as separate **microservices** to allow independent scaling, deployment, and maintenance. However, for the purpose of this minimal solution, their interactions are included within the same service to clearly demonstrate the **Shopping Cart** functionality.

## Architecture Overview

The application is organized into logical layers:

- **Presentation** – handles HTTP requests and responses.  
- **Application Layer** – contains business logic and orchestration.  
- **Domain Layer** – encapsulates core domain entities and business rules.  
- **Infrastructure Layer** – manages data access and external communication.  

Persistence is implemented using a relational database (e.g., **SQL Server**) with **Entity Framework Core** using a **Code-First approach**, allowing the domain model to define the database schema directly.

## Key Features

- Basic **CRUD operations**  
- **Global exception handling** middleware  
- **Dependency injection**  
- Clean separation of responsibilities  

## Design Goals

This minimal implementation emphasizes **clarity and correctness**, while remaining easily extensible to a full **microservices architecture** in the future. It demonstrates the **Shopping Cart workflow** with a design that supports maintainability, modularity, and potential scaling of individual components. Specifically, **User** and **Product** are modeled here for demonstration purposes but should exist as independent microservices in a production setup.

## Project Structure
## Getting Started

1. **Clone the repository:**
```bash
git clone https://github.com/JaramaskaElena/ShoppingCart
**Restore dependencies**
dotnet restore
**Apply database migrations (Code-First approach):**
dotnet ef database update
**Run the application:**
dotnet run
