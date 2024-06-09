To run locally 
1. Setup docker network: *docker network create example-network*
2. Build api image: *docker build -t example-api ./example-api/*
3. Build app image: *docker build -t example-app ./example-app/*  
4. Start api container: *docker run -d --name example-api-container --network example-network -p 8280:8080 -e ASPNETCORE_ENVIRONMENT=Development example-api*
5. Start app container: *docker run -d --name example-app-container --network example-network -p 8282:8085 -e POD_NAME=yaypod -e API_URL="http://example-api-container:8080/api/hello" example-app*
6. Browse the app: *http://localhost:8282/*
