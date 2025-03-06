# Followers

A tutorial project for displaying users and their followers, developed in ASP .NET Core Web API and Angular.

![screenshot](screenshot.gif)

## Summary

This project demonstrates creating a full-stack web application using ASP .NET Core Web API for the backend service with Angular and Material Design for the frontend client. The application displays an SQLite database of people and their followers. A person can follow another person, which is displayed upon selecting a name from the list.

## Quick Start

### Prerequisites
- .NET 6.0 SDK or later
- Angular CLI

### Backend Setup
1. Navigate to the backend project directory:
    ```sh
    cd /Service
    ```
2. Create a file `/Service/.env` with the following contents.
    ```
    ConnectionString="Data Source=data.sqlite;"
    ```
3. Restore the dependencies:
    ```sh
    dotnet restore
    ```
4. Run the backend service:
    ```sh
    dotnet run
    ```
5. Open your browser and navigate to the Swagger API explorer `http://localhost:5122/swagger`.

### Frontend Setup
1. Navigate to the frontend project directory:
    ```sh
    cd /Client
    ```
2. Install the dependencies:
    ```sh
    npm install
    ```
3. Run the frontend application:
    ```sh
    ng serve
    ```
4. Open your browser and navigate to `http://localhost:4200`.

## API Methods

### Get All Followers
- **Endpoint:** `GET /api/follower`
- **Description:** Retrieves a list of all followers.
- **Parameters:** `includeDetails` (optional) - boolean to include detailed information.

### Get Followers by Person ID
- **Endpoint:** `GET /api/follower/{personId}`
- **Description:** Retrieves a list of followers for a specific person.
- **Parameters:** `personId` - GUID of the person.

### Add a Follower
- **Endpoint:** `POST /api/follower`
- **Description:** Adds a new follower.
- **Body:** 
    ```json
    {
        "followerId": "GUID",
        "followeeId": "GUID"
    }
    ```

### Remove a Follower
- **Endpoint:** `DELETE /api/follower/{id}`
- **Description:** Removes a follower by ID.
- **Parameters:** `id` - GUID of the follower.

### Get All People
- **Endpoint:** `GET /api/person`
- **Description:** Retrieves a list of all people.
- **Parameters:** `id` - GUID of the follower.

### Get Person by ID
- **Endpoint:** `GET /api/person/{id}`
- **Description:** Retrieves a person by id.
- **Parameters:** `id` - GUID of the person.

### Add a Person
- **Endpoint:** `POST /api/person`
- **Description:** Adds a new person.
- **Body:** 
    ```json
    {
    "id": "GUID",
    "createDate": "2025-03-05T22:02:08.711Z",
    "firstName": "Alice",
    "lastName": "Doe"
    }
    ```

## Deployment

To build a deployment for hosting on a web server, use the following steps.

1. In Visual Studio Code, open a terminal and run the following commands.
    ```
    cd service
    dotnet build
    dotnet publish -c Release -o ./publish
    ```
2. Build the Angular client using the following command.
    ```
    cd ..
    cd client
    ng build
    ```
3. Copy the database file `Service/data.sqlite` into `/publish`.
4. Copy the file `Service/.env` into `/publish`. This file should contain the following line: `ConnectionString="Data Source=data.sqlite;"`
5. Create a folder `publish/wwwroot`.
6. Copy the files `Client/dist/client/browser/*.*` into `/publish/wwwroot`.
7. Run the executable `/publish/follow.exe`

The web application will begin running on port 5000. The executable is a self-contained web server, similar to a node.js application, and may be deployed to a Windows web server or Microsoft Azure.

## Tech-Stack
- **Backend:** ASP .NET Core Web API, Entity Framework, SQLite
- **Frontend:** TypeScript, Angular, Material Design

## License

MIT

## Author

Kory Becker
https://primaryobjects.com