# Car Service Management System

## Overview
A comprehensive web application for managing car service operations, built with ASP.NET Core MVC. The system provides tools for managing car repairs, client information, and service operations.

## Features
- Car management and tracking
- Repair case management
- Client information management
- Service scheduling
- User authentication and authorization
- Data export capabilities
- Mobile-responsive design

## Technology Stack
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- JavaScript/jQuery
- HTML5/CSS3

## Project Structure
```
CarServiceApp/
├── Controllers/     # MVC Controllers
├── Models/         # Data Models
├── Views/          # Razor Views
├── Data/           # Database Context and Migrations
├── wwwroot/        # Static Files (CSS, JS, Images)
└── Migrations/     # Database Migrations
```

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- SQL Server
- Visual Studio 2022 or Visual Studio Code

### Installation
1. Clone the repository
```bash
git clone https://github.com/yourusername/CarServiceApp.git
```

2. Navigate to the project directory
```bash
cd CarServiceApp
```

3. Restore dependencies
```bash
dotnet restore
```

4. Update database
```bash
dotnet ef database update
```

5. Run the application
```bash
dotnet run
```

## Configuration
The application uses the following configuration files:
- `appsettings.json` - Main configuration file
- `appsettings.Development.json` - Development-specific settings

## Database
The application uses Entity Framework Core with SQL Server. The database schema is managed through migrations.

## Contributing
1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Future Development
See [Future Patches Planning](2.1_Future_Patches_Planning.md) for detailed information about upcoming features and improvements.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Contact
Your Name - your.email@example.com
Project Link: [https://github.com/yourusername/CarServiceApp](https://github.com/yourusername/CarServiceApp)
