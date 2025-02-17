# 📌 Project: SOS - Layered Architecture with SQL Server

## 🛠️ Overview
This project implements a **Layered Architecture** using **C# (.NET)** and **SQL Server**. It follows best practices for **separation of concerns**, **data persistence**, and **scalability**.

## 🏗️ Architecture
```
SOS/
│── SOS.sln                # Visual Studio Solution
│── PresentationLayer/      # Console Application
│── BusinessLayer/         # Business Logic
│── PersistenceLayer/      # Database Access (Entity Framework Core)
│── Models/                # Data Models
│── README.md              # Project Documentation
```

## 🛠️ Tech Stack
- **.NET Framework 4.7.2**
- **C#**
- **Entity Framework Core 5.0**
- **SQL Server**
- **Migrations for Database Management**

## ⚙️ Installation
1. **Clone the repository:**
   ```sh
   git clone https://github.com/your-repo/SOS.git
   cd SOS
   ```
2. **Install required NuGet packages:**
   ```powershell
   Install-Package Microsoft.EntityFrameworkCore -Version 5.0.17
   Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 5.0.17
   ```
3. **Set up the database:**
   ```powershell
   Add-Migration InitialCreate
   Update-Database
   ```
4. **Run the Console App:**
   ```sh
   dotnet run --project PresentationLayer
   ```

## 🛠️ Configuration
Modify **`AppDbContext.cs`** to update your database connection:
```csharp
optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=MYAPP;Trusted_Connection=True;");
```

## 🏗️ Features
✔️ **Layered Architecture (Presentation, Business, Persistence)**  
✔️ **Entity Framework Core for ORM**  
✔️ **SQL Server Database with Migrations**  
✔️ **CRUD Operations for Customers & Orders**  
✔️ **Automatic Database Creation & Updates**  

## 📌 Usage
- **Add Customers & Orders via Console UI**
- **Retrieve Customer Orders**
- **Database updates automatically with migrations**

## 🤝 Contribution
Pull requests are welcome! If you want to contribute:
1. **Fork the repository**
2. **Create a new branch (`feature-branch`)**
3. **Commit your changes**
4. **Push and submit a PR**

## 📜 License
This project is licensed under the **MIT License**.

## 🎯 Contact
📧 Email: your-email@example.com  
🔗 GitHub: [Your GitHub](https://github.com/your-profile)

