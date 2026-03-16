# UKHSA

## Installation

### For Development

1. Clone this repository

2. Install [Docker](https://docs.docker.com/desktop/) following the instructions for your operating system

    1.  In `.env`:
        ```
        POSTGRES_PASSWORD=choose-a-strong-password
        DATA_PROTECTION_PASSWORD=choose-a-different-strong-password
        ```

    2.  For the development profile with hot-reloading:
        ```
        docker compose watch
        ```
        Alternatively, there is the production profile:
        ```
        docker compose --profile prod up
        ```
    3. The default URL is `[::1]:8080`

To apply database migrations use the `docker compose run update` command
