# FamilyTree Project

FamilyTree is a full-stack application. It combines a .NET API with a Next.js web application.

## Demo

Check out the live demo at [FamilyTree Demo](https://full-stack-take-home-assignment.vercel.app).

## Prerequisites

- [Docker](https://docs.docker.com/get-docker/) – Ensure Docker is installed and running on your machine.

## Project Structure

- **api**: The FamilyTree API built with .NET.
- **app**: The FamilyTree web application built with Next.js.
- **compose.yaml**: Docker Compose configuration file for orchestrating the containers.

## Running the Project Locally

1. **Navigate to the Project Root:**  
   Open a terminal and `cd` into the project root where `compose.yaml` is located.

2. **Build and Run with Docker Compose:**  
   Execute the following command to build the images and start the containers:

   ```bash
   docker-compose -f compose.yaml up --build
   ```

   This command will start the services and you should see log output indicating that the containers are running.

3. **Access the Applications:**  
   - FamilyTree API is available at [http://localhost:5251](http://localhost:5251).  
   - FamilyTree Web Application is available at [http://localhost:3000](http://localhost:3000).

4. **Stopping the Containers:**  
   To stop all running services, press `CTRL+C` in the terminal and then run:

   ```bash
   docker-compose -f compose.yaml down
   ```