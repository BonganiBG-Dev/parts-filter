<h1 align="center"> PC Part Hunter Filter </h1><p align="center">
  Filtering service for PC Part Hunter
</p>
# Table of Content 

- [Introduction](#introduction)
- [Requirements](#requirements)
- [Quick Start](#quick-start)
	- [Docker](#docker)
	- [Dotnet](#.net)
	- [Environment Variables](#environment-variables)

# Introduction
Welcome to the PC Part Hunter Filter, this is the fdata filtering service for the [PC Part Hunter]() system.

This service is used for formatting scrapped data and finding additional information about products from other services. 

# Requirements 
This service can be run locally using [Docker]() and [.NET]() 

## Dependencies 
- [MongoDB]()
- [.NET Core (6)]()

# Quick Start

## Docker
Running the service on docker 

1. Build the docker image 
``` shell
docker build -t part-hunter-filter .
```

2.  Run docker container
``` shell
docker run part-hunter-api
```

## .NET

1. Install the missing packages
``` shell
dotnet restore
```

2. Run the application
``` shell
dotnet run
```

