#! /bin/bash 

dotnet publish \
    --os linux \
    --arch x64 \
    -p:PublishProfile=DefaultContainer \
    -p:ContainerRepository=mateuszkrolik/places-social-media \
    -c Release