# Gymgenius

**Gymgenius** is a fitness-focused project designed to provide a streamlined and efficient way to manage your gym or fitness-related data. This project leverages Docker for seamless deployment and scaling.

## Prerequisites

Before running the project, make sure you have the following installed:

- [Docker](https://www.docker.com/) (latest version recommended)
- Visual studio with .Net 8
- SSMS

---

## How to Run the Project

Follow these steps to set up and run the project locally:

1. **Clone the Repository**  
   Clone this repository to your local machine using the following command:
   ```bash
   git clone https://github.com/ShakedOren/Gymgenius.git
   cd Gymgenius
   ```
2. **Open the project with Visual Studio**
3. **Run The Docker Compose Project**
4. **All the dockers will start running**
5. **Run the `example_script_for_db.sql` to add data and users**

## Accessing the Application

Once the project is running, you can access the following services:

### Backend Service for Swagger:
https://localhost/swagger/index.html

### Web UI:
http://localhost:8080/

After running the script you will have the following users:
1. `Admin:guest`
2. `trainer:guest`
3. `trainee:guest`

### DB:
Listening on 127.0.0.1:1433
Credentials: `sa:Qwer1234!`
