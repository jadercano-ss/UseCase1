# Country API Documentation

## Application Description

The Country API provides an extensive database of countries, allowing users to retrieve detailed information about countries around the globe. Our intuitive API supports various filtering options, including filtering by name, population range, sorting preferences, and limiting the number of results returned. By offering these features, we aim to make it simpler for developers to fetch data tailored to their specific needs, ensuring efficient queries and useful results. Whether you're building a geography-based game, an educational tool, or a sophisticated data analytics platform, our Country API is the ideal solution to source accurate and up-to-date country information.

## Endpoint: `/countries`

This endpoint allows users to retrieve a list of countries based on several optional parameters.

### Parameters:

1. **name** (optional): A string value. Filters the countries by names that contain the provided value.
2. **population** (optional): A number (in millions). Filters the countries where the population is lower than the provided value.
3. **sortBy** (optional): Accepts either 'ascend' or 'descend'. Sorts the countries based on the provided order.
4. **limit** (optional): An integer. Filters the amount of countries returned by the endpoint.

### Examples:

1. **Get all countries**:
   ```
   GET /countries
   ```

2. **Get countries with names containing 'land'**:
   ```
   GET /countries?name=land
   ```

3. **Get countries with a population less than 10 million**:
   ```
   GET /countries?population=10
   ```

4. **Get countries sorted in ascending order**:
   ```
   GET /countries?sortBy=ascend
   ```

5. **Get countries sorted in descending order**:
   ```
   GET /countries?sortBy=descend
   ```

6. **Get the top 5 countries in ascending order**:
   ```
   GET /countries?sortBy=ascend&limit=5
   ```

7. **Get countries with names containing 'land' and a population less than 50 million**:
   ```
   GET /countries?name=land&population=50
   ```

8. **Get the top 3 countries with names containing 'land' sorted in descending order**:
   ```
   GET /countries?name=land&sortBy=descend&limit=3
   ```

9. **Get the top 10 countries with a population less than 100 million in descending order**:
   ```
   GET /countries?population=100&sortBy=descend&limit=10
   ```

10. **Get countries with names containing 'ca', sorted in ascending order, and a population less than 80 million**:
   ```
   GET /countries?name=ca&sortBy=ascend&population=80
   ```

Remember, while all parameters are optional, combining them can provide more tailored results. Adjust the parameters according to your requirements to get the most out of the Country API.

# Country API Documentation (.NET 6 Minimal API)

## Application Description

The Country API, developed using .NET 6 Minimal API, offers an extensive database of countries. Users can obtain detailed data about countries around the globe with versatile filtering options. This document provides all necessary details on setting up and running the application locally.

## Prerequisites

1. **.NET 6 SDK**: Ensure you have the .NET 6 SDK installed. If not, download and install it from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/6.0).

## Setting Up the Project

1. **Clone the Repository**:
   ```bash
   git clone [repository-url] CountryAPI
   ```

2. **Navigate to the Project Directory**:
   ```bash
   cd CountryAPI
   ```

3. **Restore the Dependencies**:
   Dependencies might be defined in the project. Use the following command to restore them.
   ```bash
   dotnet restore
   ```

## Running the Application Locally

1. **Using the Command Line**:
   You can run the application from the terminal.
   ```bash
   dotnet run
   ```

   After executing the command, you should see a message indicating that the server is now running. Typically, it will be hosted at `http://localhost:5000` and `https://localhost:5001`.

2. **Using Visual Studio**:
   If you're using Visual Studio:

   - Open the solution (`.sln`) file in Visual Studio.
   - Set the appropriate project as the startup project (if not already set).
   - Press `F5` or click on the "Run" button.

## Accessing the API

Once the server is running, you can access the `/countries` endpoint using any API client or your browser:

```
http://localhost:5000/countries
```

Remember to use the parameters as described in the previous section to filter or sort the results.