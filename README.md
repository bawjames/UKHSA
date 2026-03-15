# UKHSA

## Installation

### For Development
1. Clone this repository

2. You have two options for running this webapp

    1.  #### Dotnet + SQLite (Development)
        ```
        dotnet watch run --project App/UKHSA.csproj
        ```

    2.  #### Docker + PostgreSQL (Production)
        1.  Install [Docker](https://docs.docker.com/desktop/) following the instructions for your operating system

        2.  In `.env`
            ```
            POSTGRES_PASSWORD=choose-a-strong-password
            DATA_PROTECTION_PASSWORD=choose-a-different-strong-password
            ```

        3.  ```
            docker compose up --build
            ```
