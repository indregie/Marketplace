
# Movie API

## Overview
This API provides endpoints for managing marketplace data.

## Prerequisites
- Docker
- Docker Compose
- Postman recommended (for easy testing)
 
## Usage
### Docker Compose
- Run solution using Docker Compose. 
 It will provide you with API, DB and also will run database migrations (via Liquibase).

### Postman Collections
- Import the provided Postman collection to test API endpoints. You can find it in Postman directory.

### API Endpoints
- **GET /items:** Retrieve a list of all marketplace items.
- **POST /items:** Add a new item.
- **POST /orders:** Add a new order.
- **GET /orders?userId={userId}:** Retrieve a list of orders from a specific user.
- **PUT /orders/{id}/pay:** Mark order as paid.
- **PUT /orders/{id}/complete** Mark order as completed.
- **GET /users:** Retrieve a list of possible marketplace users from external API.