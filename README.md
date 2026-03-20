# UKHSA

## Installation

### For Development

1. Clone this repository

2. Install [Docker](https://docs.docker.com/desktop/) following the instructions for your operating system

3.  In `.env`:
    ```
    POSTGRES_PASSWORD=choose-a-strong-password
    DATA_PROTECTION_PASSWORD=choose-a-different-strong-password
    ```

4.  Initialize the database:
    ```
    docker compose up update --build
    ```

5.  For the development profile with hot reloading:
    ```
    docker compose up
    ```
    Alternatively, there is the production profile:
    ```
    docker compose --profile prod up
    ```

6. The default URL is `[::1]:8080`

Any changes to the database require you to repeat Step 2
Not all changes can be hot reloaded. It works best for changes to Views
