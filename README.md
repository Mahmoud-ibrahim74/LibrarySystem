# 📚 Library Management System API  

## 📝 Overview  
This is a RESTful API for managing a library system built with **ASP.NET Core**. It allows users to browse, borrow books, and manage books with role-based access control.  

## 🚀 Features  
- **Authentication & Authorization** using **ASP.NET Identity** and **JWT**  
- **Role-Based Access Control:**  
  - **Admin:** Can manage books (Add, Update, Delete)  
  - **User:** Can browse and borrow books  
- **Books Management (Admin Only)**  
  - Add, update, delete books  
- **Book Browsing (All Users)**  
  - List books with pagination, sorting, and filtering  
  - View book details  
- **Borrowing System (User Only)**  
  - Borrow books (ensuring availability)  
  - View borrowed books  
- **Business Logic**  
  - Prevent users from borrowing the same book twice  
  - Ensure books are returned within **14 days**  
  - Update **book availability** status  
- **Performance Optimization**  
  - Caching for book listing  
  - Optimized database queries  
- **Testing**  
  - Unit tests for business logic  
  - Integration tests using an **in-memory database**  
- **API Documentation**  
  - **Swagger/OpenAPI** with XML comments  

## 🛠️ Prerequisites  
- **.NET 9 SDK** 
- **SQL Server**  
- **Entity Framework Core**  
- **Postman** (Optional for API testing)  

## ⚡ Setup Instructions  

### 1️⃣ Clone the Repository  
```sh
git clone https://Mahmoud-ibrahim74/LibrarySystem.git
cd library-api
```

### 2️⃣ Configure the Database  
Update the `appsettings.json` file with your **SQL Server connection string**:  
```json
"ConnectionStrings": {
     "LibrarySystemConnection": "Data Source=.;Initial Catalog=LibrarySystemDb;Integrated Security=True;Trust Server Certificate=True"
}
```

### 3️⃣ Apply Database Migrations  
Run the following command to create the database:  
```sh
dotnet ef database update
```

### 4️⃣ Run the Application  
```sh
dotnet run
```
The API will be available at `https://localhost:44327`.

### 5️⃣ Access Swagger Documentation  
Navigate to:  
```
https://localhost:44327/swagger/index.html
```
This provides an **interactive API documentation** for testing endpoints.

---

## 🔗 API Endpoints  

### **Authentication**  
- `POST /api/v1/Users/Add` - Register a new user  
- `POST /api/v1/Users/Login` - Authenticate and receive JWT token  

### **Books Management (Admin Only)**  
- `POST //api/v1/Book/Add` - Add a new book  
- `PUT /api/Book/update/{id}` - Update a book  
- `DELETE /api/books/Delete/{id}` - Remove a book  

### **Books Browsing (All Users)**  
- `GET /api/v1/Book/GetAll` - View books (**pagination, sorting, filtering**)  
- `GET /api/Book/{id}` - View book details  

### **Borrowing Books (User Only)**  
- `POST /api/v1/borrow/Add/{bookId}` - Borrow a book  
- `GET /api/v1/borrow` - View borrowed books  
