CREATE DATABASE shoppingcartdb;

USE shoppingcartdb;

CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    Description VARCHAR(255),
    Price DECIMAL(10,2),
    ImageUrl VARCHAR(255)
);

CREATE TABLE CartItems(
Id INT AUTO_INCREMENT PRIMARY KEY,
ProductId INT,
Quantity INT,
FOREIGN KEY (ProductId) REFERENCES Products(Id)
);