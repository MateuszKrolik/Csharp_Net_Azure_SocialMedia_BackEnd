#! /bin/bash

docker run --platform linux/amd64 \
    -e 'ACCEPT_EULA=Y' \
    -e 'MSSQL_SA_PASSWORD=Mysecretpassword123!' \
    -e "MSSQL_PID=Express" \
    -p 1433:1433 \
    --name mssql \
    -v /Users/mateuszkrolik/Documents/Docker/mssql:/var/opt/mssql/data \
    -v /Users/mateuszkrolik/Documents/Docker/mssql/secrets:/var/opt/mssql/secrets \
    -d mcr.microsoft.com/mssql/server:2022-latest 
