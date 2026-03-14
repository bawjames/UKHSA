# UKHSA

## Installation

+ Install [Docker](https://docs.docker.com/desktop/) using the instructions for your operating system.
+ Download the Docker image from [Releases](https://github.com/bawjames/UKHSA/releases).

### For Development

+ Ensure you have Docker installed, with docker-compose and docker-buildx.
+ Clone this repository
+ In the repository root directory, create a `.env` file with the following structure:
    ```
    POSTGRES_PASSWORD=choose-a-strong-password
    DATA_PROTECTION_PASSWORD=choose-a-different-strong-password
    ```
+ `$ docker compose up`

<!-- Need to update this when we create proper releases -->
