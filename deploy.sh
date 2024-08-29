#!/bin/bash

az deployment group create \
    --resource-group DefaultResourceGroup-DEWC \
    --template-file container-app-template.json \
    --parameters @parameters.json