# RaceDayApi-PROG6212-Part-3
## Docker Setup

To run this application using Docker, ensure you have Docker Desktop installed and running. Open a terminal in the root directory (where the `docker-compose.yml` file is located) and run:

```bash
docker-compose up --build
# RaceDay Web Application

This is a full-stack application consisting of an ASP.NET Core Web API (backend) and an ASP.NET Core MVC application (frontend). The application allows Organisers to create events and Participants to enroll and track their results.

## Setup Instructions (Local Run)
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Ensure your SQL Server LocalDB is running.
4. In the Package Manager Console, run `Update-Database` to create the database.
5. Set both `RaceDayApi` and `RaceDayWeb` as Startup Projects.
6. Press F5 to run. The Swagger UI will open, and the Web App will open in another tab.

## Docker Setup
To run this application using Docker, ensure you have Docker Desktop installed and running. Open a terminal in the root directory (where the `docker-compose.yml` file is located) and run:

```bash
docker-compose up --build
