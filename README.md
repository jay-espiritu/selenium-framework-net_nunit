# Selenium Framework : NUnit
#### Cloning repository
1. `git clone git@github.com:jay-espiritu/selenium-framework-net_nunit.git`

#### OPTIONAL - Enabling [Report Portal](https://reportportal.io/) for logging
1. Install [Docker](https://www.docker.com/products/docker-desktop)
2. After installation, start up Docker and set at resources with the following:
* CPU = 4
* Memory = 5GBs (at least)
3. Spin up the docker file by executing `docker-compose up -d --force-recreate`

#### Executing tests
2. Rebuild the project
3. In Test Explorer, right-click the test class/method and select `run`

#### OPTIONAL - Accessing Report Portal Logs
1. Navigate to http://localhost:8080/ui/
2. Log in using the default credentials
* Username: `superadmin`
* Password: `erebus`
3. Navigate to launch and examine the logs
