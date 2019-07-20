# WalletKeeper
#### A simple project to practice the microservices architecture using docker containers.


The project idea is a simple expenses tracker that can be used from a web browser or a mobile application client.
##### Note: The project is still work in progress and not all the features are implemented yet.
## Used frameworks and technologies
#### Back-end:
- ASP.NET Core
- Docker
- Entity framework core 
- RabbitMQ
- Ocelot
- Swashbucke / Swagger 
### Web front-end
- Angular 8 
- Angular Material
## Requirements to run
- .NET Core SDK v2.2
- Docker v2.0
- Visual studio 2019 with docker extension or Visual studio code with Docker extension 
- Powershell

## Running the project
#### Using Visual studio 2019:
- Open the solution file 
- Make sure that the docker compose project is the start up project
- Click run
#### Using PowerShell:
- Navigate to the src/ directory in PowerShell
- Execute the "docker-compose up" command
- Wait for the build process to complete
- Navigate to http://localhost:5010/ in your browser 

## Login information
The default user is 

Username: admin

Password: 123 
