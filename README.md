# UKHSA

## Installation
1. Install [Docker](https://docs.docker.com/desktop/) using the instructions for your operating system
2. Download the Docker image from [Releases](https://github.com/bawjames/UKHSA/releases)

### For Development
1. Ensure you have Docker installed, with docker-compose and docker-buildx
2. Clone this repository
3. In the repository root directory, create a `.env` file with the following structure:
    ```
    POSTGRES_PASSWORD=choose-a-strong-password
    DATA_PROTECTION_PASSWORD=choose-a-different-strong-password
    ```
4. `$ docker compose up`

<!-- Need to update this when we create proper releases -->
