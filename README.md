# UKHSA

## Installation
<ol>
  <li>Install [Docker](https://docs.docker.com/desktop/) using the instructions for your operating system</li>
  <li>Download the Docker image from [Releases](https://github.com/bawjames/UKHSA/releases)</li>
</ol>

### For Development
<ol>
  <li>Ensure you have Docker installed, with docker-compose and docker-buildx</li>
  <li>Clone this repository</li>
  <li>
    In the repository root directory, create a `.env` file with the following structure:
    ```
    POSTGRES_PASSWORD=choose-a-strong-password
    DATA_PROTECTION_PASSWORD=choose-a-different-strong-password
    ```
  </li>
  <li>`$ docker compose up`</li>
<ol>

<!-- Need to update this when we create proper releases -->
