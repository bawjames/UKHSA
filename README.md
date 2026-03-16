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

    2.  For the development profile:
        ```
        docker compose up -w --build
        ```
        Alternatively, there is the lighter production profile:
        ```
        docker compose --profile prod up --build
        ```

To apply database migrations use the `docker compose run update` command.
This is not necessary for development builds, which automatically apply migrations.
