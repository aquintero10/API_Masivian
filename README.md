# API Masivian
Repository por masivian test backend developer

# To deploy

API_Masivian can be run either using docker or as a web api.

The docker version builds and runs the API as a container and also an instance of Redis.
It asumes a network called "masivian" exists in the local environment,
you can create that network with the following command:

```
docker network create masivian
```

## Run in Swagger

API_Masivian has Swagger documentation to inspect API methods and try out each one.
To access the Swagger you could run docker-compose and enter via port 62937
http://localhost:62937/swagger/index.html
Or running the web api locally via port 8090
http://localhost:8090/swagger/index.html
