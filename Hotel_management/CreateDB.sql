USE [master]
GO

/*******************************************************************************
   Drop database if it exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'HotelManagement')
BEGIN
	ALTER DATABASE HotelManagement SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE HotelManagement SET ONLINE;
	DROP DATABASE HotelManagement;
END

GO

CREATE DATABASE HotelManagement
GO

USE HotelManagement
GO

/*******************************************************************************
	Drop tables if exists
*******************************************************************************/

CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    RoleID INT FOREIGN KEY REFERENCES Roles(RoleID),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber NVARCHAR(10) NOT NULL UNIQUE,
    RoomType NVARCHAR(50),
    Price DECIMAL(10,2),
    Description NVARCHAR(255),
    IsAvailable BIT DEFAULT 1
);

CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    GuestID INT FOREIGN KEY REFERENCES Guests(GuestID),
    RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID), 
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Booked' 
);

CREATE UNIQUE INDEX UX_RoomBooking 
ON Bookings(RoomID, CheckInDate, CheckOutDate) 
WHERE Status = 'Booked';


/*******************************************************************************
	Insert data
*******************************************************************************/

INSERT INTO Roles (RoleName) VALUES 
('Admin'), 
('Staff'), 
('Customer');

INSERT INTO Users (Username, PasswordHash, FullName, RoleID) VALUES
('admin1', 'admin123', 'Dong Minh Tam', 1),
('staff1', 'staff123', 'Nguyen Minh Anh', 2),
('customer1', 'cust123', 'Chu Đức Thắng', 3);

INSERT INTO Rooms (RoomNumber, RoomType, Price, Description, IsAvailable) VALUES
('101', 'Single', 500000, 'Single room with window', 1),
('102', 'Double', 800000, 'Single room with balcony', 1),
('103', 'Suite', 1500000, 'Vip room, beach view', 1);

INSERT INTO Guests (FullName, Phone, Email) VALUES
('Khach hang A', '0912345678', 'khhaa@example.com'),
('Khach hang B', '0987654321', 'khhab@example.com');

INSERT INTO Bookings (GuestID, RoomID, UserID, CheckInDate, CheckOutDate, Status) VALUES
(1, 1, 3, '2025-07-20', '2025-07-22', 'Booked'),
(2, 2, 3, '2025-07-22', '2025-07-24', 'Booked');

