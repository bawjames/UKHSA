# UKHSA

## Installation

### For Development
1.  Optionally install [Docker](https://docs.docker.com/desktop/) following the instructions for your operating system
2.  Clone this repository
3.  You have two options for running this webapp:
    1.  In the project root directory:
        ```
        docker compose up --build
        ```

    2.  In the project root directory:
        ```
        dotnet watch run --project App/UKHSA.csproj
        ```

    Option ii is probably preferable for development, because of hot-reloading and faster build times
