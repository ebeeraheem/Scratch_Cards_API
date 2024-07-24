# Scratch_Cards_API

## Setup and Installation

1. Clone the repository: 
   ```bash
   git clone https://github.com/yourusername/scratch-cards-api.git
   cd scratch-cards-api
   ```
2. Restore the NuGet packages:
   ``` bash
   dotnet restore
   ```
3. Update the 'appsettings.json' file with your database connection string

4. Apply the database migrations:
   ```bash
   dotnet ef database update
   ```
5. Run the app:
   ```bash
    dotnet run
    ```
## Running the Application
- Open your browser and navigate to https://localhost:7163/swagger to access the Swagger UI.
- Use the Swagger UI to test the various API endpoints.
