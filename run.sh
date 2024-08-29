#! /bin/bash 

docker build --platform linux/amd64 \
    -t mateuszkrolik/places-social-media .

docker run --platform linux/amd64 \
    -p 8080:8080 \
    mateuszkrolik/places-social-media