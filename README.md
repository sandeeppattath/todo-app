
<!-- ABOUT THE PROJECT -->
## ToDo Application



This is a web application developed on dotnet 8 and Angular 16 for List, Add and Modify ToDo List.

Here's the main features:
* This application has a Angular frontend and .NET Web API backend.
* You can login into the system using credentials and List, Add and Modify ToDo Lists.
* The ToDo details are stored in a SQL Server Express LocalDB and deliver using API for angular frontend.
* Implemented JWT based token authenticaion(user name: 'user', password : 'password'). 
* Integrated Entity framework core in code first approch. 




### Built With

* Angular 16
* C# 
* Dotnet 8
* SQL Server Express LocalDB
* Entity Framework Core(Code First)
* Dependency Injection



<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

Dotnet 8 is required to run the project. 

### Installation

## Backend
1. Open ToDoApplication solution(ToDo-backend) on visual studio 
2. Check the localdb connectionstring on appsettings.json in the ToDoApplicationAPI project.
3. Apply Update database script from package manger console 
    
      Update-Database
4. Run the ToDoApplicationAPI project. Swagger will open and then check the select the port and URL

## Frontend
1. Open TODO-APP project(ToDo-frontend) on vscode
2. Verify the node modules are available 
3. Modify todo.service.ts with the port that open backend API
      private apiBaseUrl = 'http://localhost:5280/Todo'; 

4. Modify auth.service.ts with the port that open backend API
      private apiUrl = 'http://localhost:5280/Login/login'; 
5. Excecute command `ng server` to run angular application and open the url on browser



<!-- USAGE EXAMPLES -->
## Usage
* Open angular application on http://localhost:4200/
* provide login credentials and submit
```sh
  username : user
  password : password
  ```
* Add new Todo Title
* Complete the todo by clicking complete button
* Delete the todo by clicking delete button
* Verify the todo listing
* Log out from the application



