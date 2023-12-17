# Alliant Test Project

## Requirements
- .Net Core 6 
- Visual Studio 2022 or Visual Studio Code
- SQL Server Express LocalDB ([Click Here to learn how to install](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16))
> **Note:** I installed LocalDB through the Visual Studio Installer, as part of the **Data Storage and Processing workload**. To Install it, Open Visual Studio, select Tools > Get Tools and Features..., which opens the Visual Studio Installer. Once there, scroll down to the **Other Toolsets** and select the *Data Storage and Processing workload*


## How to run the app
Once you have downloaded the code, whether by cloning the repository or by downloading the .zip, open the folder in **Visual Studio 2022** or **Visual Studio Code** and press the key **F5** to run the project.

## Project Documentation

### Project Structure
The project uses the estructure recomended by the Microsoft documentation, organized as follows:
- **Areas**: Groups the visual components by area.
- **Data**: Contains all the components related to data access.
  - Models: Contains the class representation of the tables in the DB
  - Services: Components used to access/retrieve data.
- **Pages**: Simple pages. E.g.: Index.razor
- **Shared**: Contains componets that are used by multiple pages

### Technologies Used
- Frontend: Blazor
- Backend: .Net Core / C#
- Database: Sql Server

### Database Schema
![Alliant Product Management System DB drawio](https://github.com/jarbisme/AlliantTestProject/assets/52365128/fd650a30-f209-4dc1-a100-d8ed1378b33e)
