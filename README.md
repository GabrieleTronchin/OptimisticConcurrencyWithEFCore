```md
# Handling Optimistic Concurrency with EFCore

This project demonstrates how to manage **optimistic concurrency** using **Entity Framework Core** in **.NET 9**.  
The project consists of two main applications:

- **OptimisticConcurrency.Host**: A RESTful API that exposes services.
- **OptimisticConcurrency.Persistence**: Contains the repository logic and EF Core integration for data access.

## Project Structure

### 1. OptimisticConcurrency.Host
This application is a RESTful API designed to manage movies through standard CRUD operations (Create, Read, Update, Delete).  
It uses **Swagger** to provide interactive API documentation and testing.

Key features include:
- Endpoints to list all movies, retrieve a movie by its ID, add new movies, and update existing ones.
- Built-in support for optimistic concurrency, implemented via a `RowVersion` property.

### 2. OptimisticConcurrency.Persistence
This component encapsulates all data access logic using **Entity Framework Core**.  
It defines a repository—referred to as the `MovieRepository`—which manages all interactions with movie entities.

Key aspects include:
- Methods to add, retrieve, update, and delete movie records.
- Implementation of optimistic concurrency control using the `RowVersion` property, ensuring that data updates do not conflict when multiple users attempt to modify the same record concurrently.

### 3. Docker Compose
The project includes a configuration file for **Docker Compose**. This file is used to run a containerized instance of **SQL Server** required by the project.  
To run this file, you can use the provided `deploy-compose.ps1` script; otherwise, modify the appsettings according to your SQL Server connection string.

## API Endpoints Overview

The API provides several endpoints for managing movie records:
- **GET /movies**: Retrieve a list of all movies.
- **GET /movie/{id}**: Retrieve the details of a specific movie using its ID.
- **POST /movie**: Add a new movie to the database.
- **PUT /movie**: Update an existing movie's details.

## Getting Started

To get started with the project, follow these steps:

1. **Clone the Repository:**
   - Use Git to clone the repository and navigate to the project directory.

2. **Build and Run:**
   - Build the solution using the .NET build tools.
   - Run the application. The API will be launched and can be accessed via a web browser.

3. **Access the API via Swagger UI:**
   - Open your web browser and navigate to the provided URL (commonly `http://localhost:5223/swagger`) to interact with the API using the Swagger interface.
