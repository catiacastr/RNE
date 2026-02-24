
# Products API

## Features
- InMemory EF Core
- 5 Physical + 5 Digital products seeded
- Filtering & sorting
- LINQ aggregation endpoint (/products/stock-value)
- DTO validation
- Clean layered architecture

## Run locally
dotnet run

## Run with Docker
docker build -t products-api .
docker run -p 5000:80 products-api
