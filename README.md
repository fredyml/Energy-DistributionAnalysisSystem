# Energy Distribution Analysis System

The Energy Distribution Analysis System is an application that allows customers of a power distribution company to access executive information to make informed decisions about maintenance and evaluation of different segments in the distribution of electrical energy. The application uses historical consumption, cost, and loss data provided by the customer to provide detailed insights into the performance of the segments.

## Requirements

The application should provide three endpoints that allow retrieving specific information about the electrical energy distribution segments:

### Request 1: Historical Consumption by Segments

This endpoint allows retrieving a history for each segment, including consumption, losses, and cost per consumption within a specified time period.

**Endpoint:** GET /energy/historical-segments

**Query Parameters:**
- startDate (required): The start date of the historical data in 'yyyy-MM-dd' format.
- endDate (required): The end date of the historical data in 'yyyy-MM-dd' format.

**Response:**
The response will include a JSON object with the historical data for each segment, including consumption, losses, and cost per consumption.

### Request 2: Historical Consumption by Customer (Residential, Commercial, Industrial)

This endpoint allows retrieving a history for each customer type (residential, commercial, industrial), including the segment, consumption, losses, and cost per consumption within a specified time period.

**Endpoint:** GET /energy/historical-customer

**Query Parameters:**
- startDate (required): The start date of the historical data in 'yyyy-MM-dd' format.
- endDate (required): The end date of the historical data in 'yyyy-MM-dd' format.
- customerType (required): The customer type ('residential', 'commercial', or 'industrial').

**Response:**
The response will include a JSON object with the historical data for each customer type, including the segment, consumption, losses, and cost per consumption.

### Request 3: Top 20 Worst Segments/Customer

This endpoint allows retrieving a list of the top 20 segments/customer with the highest losses within a specified time period. This helps identify the segments that generate the highest losses and plan corrective or preventive maintenance actions.

**Endpoint:** GET /energy/top-segments-customer

**Query Parameters:**
- startDate (required): The start date of the historical data in 'yyyy-MM-dd' format.
- endDate (required): The end date of the historical data in 'yyyy-MM-dd' format.

**Response:**
The response will include a JSON object with the list of the top 20 segments/customer with the highest losses.

## Architecture

The Energy Distribution Analysis System follows a Clean Architecture approach to achieve a clear separation of concerns and easy scalability and maintainability of the system. The architecture consists of the following layers:

- **Domain:** Contains the entities and business rules of the domain.
- **Application:** Contains the application services that implement the application logic and orchestrate operations between the domain and infrastructure layers.
- **Infrastructure:** Contains the concrete implementations of the interfaces defined in the domain and application layers. It includes data persistence, communication with external services, and other infrastructure components.
- **API:** Contains the API controllers that define the endpoints and handle HTTP requests and responses. It also includes filters and middleware for exception handling and application configuration.

## Technologies Used

The application utilizes the following technologies and tools:

- ASP.NET Core: Framework for web application development.
- Entity Framework Core: Object-Relational Mapping (ORM) for database access.
- SQL Server: Relational database engine for storing historical data.
- NLog: Logging library for event logging and log generation.
- Microsoft.Extensions.Logging: Logging library for event logging and log generation.

## Configuration

The application configuration is done through the `appsettings.json` file located in the project's root. In this file, the following aspects can be configured:

- Event logging level and log generation.
- Database connection string.

## Execution

To run the application, follow these steps:

1. Make sure you have .NET Core SDK installed on your machine.
2. Clone the Energy Distribution Analysis System repository.
3. Navigate to the root directory of the project in the command line.
4. Run the following command to build the application:
   ```
   dotnet build
   ```
5. Run the following command to start the application:
   ```
   dotnet run
   ```
6. The application will be available at the following URL: `http://localhost:5000` or `https://localhost:5001` (if HTTPS is enabled).

## Team

The Energy Distribution Analysis System was developed by Fredy Mendoza.
