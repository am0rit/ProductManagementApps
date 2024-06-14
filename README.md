# ProductManagementApplication
Product lifecycle management with CRUD application.


# Running .NET 7 Web API 

This repository contains a setup for integrating a .NET 7 Web API backend.

## Prerequisites

- .NET 7 SDK installed
- Angular CLI installed globally (`npm install -g @angular/cli`)

## Backend Setup (.NET 7 Web API)

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd <repository-folder>
2. cd Backend Folder
3. dotnet restore
   dotnet run
4. Open a web browser and go to https://localhost:xxxx/api/xxx to verify the API is running.


## Notes

-Ensure both the .NET Web API (https://localhost:5001) and Angular application (http://localhost:4200) are running concurrently for proper integration.
-Adjust API endpoints in the Angular application as necessary based on your .NET Web API routes.

if in case of any issue Contact @ami232879@gmail.com

## Performance Consideration

By Following Below Strategies we  could scale with a large number of products

1. Database
- As we are depending now with In Memory JSON File, futher we can move to SQL DB for storing the data.
- We can use Normalization, Indexes, Partitioning of large datasets in DB

2. API
- We can use Pagination and Filtering.
- Rate Limiting to prevent abuse and ensure fair use of the API.
- Asynchronous Operations

3. UI(Frontend)
- Use Lazy Loading
- State Management,use RxJS Liberary.
- Component Reusability

4. Caching
- Server-Side Caching.
- Client-Side Caching.
- Distributed Caching
- We can use Load Balancer in Azure to distribute the Loads.
- We can use Logging and Monitoring like Application Insight in Azure
