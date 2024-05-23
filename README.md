# Employee Management System

This project is an Employee Management System built using Angular for the frontend and .NET for the backend. The system is designed for managers to efficiently manage their employees by providing functionalities to view, add, update, and delete employee records. Employees are displayed in a table format with options to edit or delete each record.

![Employee Management System Screenshot](screenshot.png)

## Features

- **View Employees**: Displays a table with all employees and their details.
- **Add Employee**: Allows the manager to add a new employee with all necessary details.
- **Update Employee**: Enables the manager to update the details of an existing employee.
- **Delete Employee**: Provides the option to delete an employee who has left the company.

## Getting Started

To get started with the Employee Management System, follow these steps:

### Prerequisites

Ensure you have the following installed on your system:
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/RuthCohen3257/Practicum.git
2. **Navigate to the client project directory**:
   ```bash
   cd Practicum/EmployeeManagementSystemClient
3. **Install frontend dependencies**:
     ```bash
     npm install
4. **Navigate to the server project directory and install dependencies**:
   ```bash
    cd ../EmployeeManagementSystemServer
    dotnet restore
    update-database
   
### Running the Application

1. **Start the backend server:**
   ```bash
   cd Practicum/EmployeeManagementSystemServer
   dotnet run
2. **Start the Angular application:**
   ```bash
   cd ../EmployeeManagementSystemClient
   ng serve -o
   
The Angular application will be served on (http://localhost:4200/)
## Usage

- **View Employees**:  Navigate to the main page to see the list of employees.
- **Add Employee**: Click on the "Add Employee" button and fill in the required details.
- **Update Employee**:  Click on the pencil icon next to the employee you wish to edit and update the details.
- **Delete Employee**: Click on the trash bin icon next to the employee you wish to delete.

### Additional Information

- Ensure the backend server is running before accessing the Angular application to enable proper data fetching and operations.
- The project structure includes separate directories for the frontend (client) and backend (server) code to maintain a clean architecture.

### Contribution
If you wish to contribute to this project, please fork the repository and submit a pull request with your changes. Ensure your code follows the project's coding standards and includes relevant tests.

### License
This project is licensed under the MIT License.

By following these instructions, you should be able to set up and run the Employee Management System on your local machine successfully. If you encounter any issues, please refer to the project documentation or open an issue on GitHub.
