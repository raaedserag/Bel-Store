-- Table: Categories
CREATE TABLE Categories (
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(100) UNIQUE 
);

-- Table: Clients
CREATE TABLE Clients(
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(100) ,
	phone varchar(15),
	address nvarchar(100),
	paid float DEFAULT 0.0,
	owed float DEFAULT 0.0,
	balance float DEFAULT 0.0,
);

-- Table: Products
CREATE TABLE Products(
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(100) ,
	quantity int DEFAULT 0,
	vendor nvarchar(100),
	barcode varchar(50),
	price float ,
	category_id int ,
	FOREIGN KEY (category_id) REFERENCES Categories(id) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Table: Receipts
CREATE TABLE Receipts(
	id int IDENTITY(1,1) PRIMARY KEY,
	receipt_date datetime default CURRENT_TIMESTAMP,
	client_id int ,
	FOREIGN KEY (client_id) REFERENCES Clients(id) ON DELETE SET NULL ON UPDATE CASCADE,
	past_balance float ,
	receipt_total float,
	paid float,
	new_balance float,
	readable_balance nvarchar(100),
	notes nvarchar(400) DEFAULT NULL
);

-- Table ReceiptsProducts
CREATE TABLE ReceiptsProducts(
	id int IDENTITY(1,1) PRIMARY KEY,
	product_id int,
	FOREIGN KEY (product_id) REFERENCES Products(id) ON DELETE SET NULL ON UPDATE CASCADE,
	receipt_id int,
	FOREIGN KEY (receipt_id) REFERENCES Receipts(id) ON DELETE SET NULL ON UPDATE CASCADE,
	quantity int
);

-- Table: ReturnedReceipts
CREATE TABLE ReturnedReceipts(
	id int IDENTITY(1,1) PRIMARY KEY,
	receipt_date date default CURRENT_TIMESTAMP,
	client_id int,
	FOREIGN KEY (client_id) REFERENCES Clients(id) ON DELETE SET NULL ON UPDATE CASCADE,
	past_balance float,
	receipt_total float,
	paid float,
	new_balance float,
	readable_balance nvarchar(100),
	notes nvarchar(400) DEFAULT NULL
);

-- Table ReturnedReceiptsProducts
CREATE TABLE ReturnedReceiptsProducts(
	id int IDENTITY(1,1) PRIMARY KEY,
	product_id int,
	FOREIGN KEY (product_id) REFERENCES Products(id) ON DELETE SET NULL ON UPDATE CASCADE,
	receipt_id int,
	FOREIGN KEY (receipt_id) REFERENCES Receipts(id) ON DELETE SET NULL ON UPDATE CASCADE,
	quantity int
);

-------------------------------     Creating VIEWS        ----------------------------------------------------


-- Products Categories
GO
CREATE VIEW Products_Categories
AS
SELECT p.id, c.name as category, p.name, p.vendor, p.quantity, p.price
FROM Products as p
LEFT JOIN Categories as c
ON p.category_id = c.id

-- Receipts Data
GO
CREATE VIEW Receipts_Data
AS
SELECT Receipts.id as receipt_id, Receipts.receipt_date, Clients.name as client_name, Clients.phone, Clients.address,
Receipts.past_balance, Receipts.receipt_total, Receipts.paid, Receipts.new_balance, Receipts.readable_balance, Receipts.notes
FROM Receipts
LEFT JOIN Clients ON Receipts.client_id  = Clients.id

-- Receipts_Products
GO

CREATE VIEW Receipts_Products
AS
SELECT Products_Categories.category, Products_Categories.name, Products_Categories.vendor, Products_Categories.price, ReceiptsProducts.receipt_id, ReceiptsProducts.quantity 
FROM ReceiptsProducts
LEFT JOIN Products_Categories ON ReceiptsProducts.product_id = Products_Categories.id
GO

-- ReturnedReceipts Data
GO
CREATE VIEW ReturnedReceipts_Data
AS
SELECT ReturnedReceipts.id as receipt_id, ReturnedReceipts.receipt_date, Clients.name as client_name, Clients.phone, Clients.address,
ReturnedReceipts.past_balance, ReturnedReceipts.receipt_total, ReturnedReceipts.paid, ReturnedReceipts.new_balance, ReturnedReceipts.readable_balance, ReturnedReceipts.notes
FROM ReturnedReceipts
LEFT JOIN Clients ON ReturnedReceipts.client_id  = Clients.id

-- ReturnedReceipts_Products
GO

CREATE VIEW ReturnedReceipts_Products
AS
SELECT Products_Categories.category, Products_Categories.name, Products_Categories.vendor, Products_Categories.price, ReturnedReceiptsProducts.receipt_id, ReturnedReceiptsProducts.quantity 
FROM ReturnedReceiptsProducts
LEFT JOIN Products_Categories ON ReturnedReceiptsProducts.product_id = Products_Categories.id
GO

-------------------------------    CREATING PROCEDURES        ----------------------------------------------------

------------ FOR CATEGORIES --------------------------------

-- Get ALL Categories
GO
CREATE PROCEDURE Get_categories 
AS 
SELECT * FROM Categories	

-- Create New Category
GO
CREATE PROCEDURE Add_Category @new_category nvarchar(100)
AS
INSERT INTO Categories(name) VALUES (@new_category)

-- Update Existing Category
GO
CREATE PROCEDURE Update_category @id int, @new_name nvarchar(100)
AS
UPDATE Categories
SET name = @new_name
WHERE id = @id
GO

-- Delete Some Category
CREATE PROCEDURE Delete_category @id int
AS
DELETE FROM Categories WHERE id = @id;
GO

-- Search Categories BY name
CREATE PROCEDURE Search_categories @name nvarchar(100)
AS
SELECT * 
FROM Categories
WHERE name LIKE '%' + @name + '%'
GO
-------------------------------------------------------------

------------ FOR Products --------------------------------

-- Get ALL Categories
GO
CREATE PROCEDURE Get_products
AS 
SELECT * FROM Products

-- Create New Product
GO
CREATE PROCEDURE Add_new_product @name nvarchar(100), @quantity int, @vendor nvarchar(100), @barcode varchar(50), @price float, @category_id int
AS
INSERT INTO Products(name, quantity, vendor, barcode, price, category_id) VALUES (@name, @quantity, @vendor, @barcode, @price, @category_id)
GO

-- Updating existing prouduct
CREATE PROCEDURE Update_product @id int, @name nvarchar(100), @quantity int, @vendor nvarchar(100), @barcode varchar(50), @price float, @category_id int
AS
UPDATE Products
SET  name = @name, quantity = @quantity, vendor = @vendor, barcode = @barcode, price = @price, category_id = @category_id
WHERE id = @id
GO

-- Delete Some Product
CREATE PROCEDURE Delete_product @id int
AS
DELETE FROM Products WHERE id = @id;
GO

-- Search Products BY name
CREATE PROCEDURE Search_products_name @name nvarchar(100)
AS
SELECT * 
FROM Products
WHERE name LIKE '%' + @name + '%'
GO

-- Search Products BY Barcode
CREATE PROCEDURE Search_products_barcode @barcode varchar(50)
AS
SELECT * 
FROM Products
WHERE barcode = @barcode
GO

-- Search Products BY Categoty
CREATE PROCEDURE Search_products_category @category_id int
AS
SELECT Categories.name as category_name, Products.name, Products.vendor, Products.quantity, Products.price
FROM Products
LEFT JOIN Categories ON Products.category_id = Categories.id
WHERE Products.category_id = @category_id
GO

-- Search Products BY Vendor
CREATE PROCEDURE Search_products_vendor @vendor nvarchar(100)
AS
SELECT Categories.name as category_name, Products.name, Products.vendor, Products.quantity, Products.price
FROM Products
LEFT JOIN Categories ON Products.category_id = Categories.id
WHERE Products.vendor LIKE '%' + @vendor + '%'
GO

-- Push Products
CREATE PROCEDURE Push_product @product_id int, @pushed_quantity int
AS
UPDATE Products
SET quantity = quantity + @pushed_quantity
WHERE id = @product_id
GO

-- Pull Products
CREATE PROCEDURE Pull_product @product_id int, @pulled_quantity int
AS
UPDATE Products
SET quantity = quantity - @pulled_quantity
WHERE id = @product_id
GO



-------------------------------------------------------------
------------ FOR Clients  --------------------------------
-- Search Clients By Name
CREATE PROCEDURE Search_clients_name @name nvarchar(100)
AS
SELECT * 
FROM Clients
WHERE name LIKE '%' + @name + '%'
GO


-- Get Client
CREATE PROCEDURE Get_client @client_id int
AS
SELECT *
FROM Clients 
WHERE id = @client_id 
GO

-- Add New Client
CREATE PROCEDURE Add_client @name nvarchar(100), @phone varchar(15), @address nvarchar(100), @paid float, @owed float
AS
INSERT INTO Clients(name, phone, address, paid, owed, balance) VALUES(@name, @phone, @address, @paid, @owed, @paid-@owed)
Go

-- Update Existing Client
ALTER PROCEDURE Update_client @id int, @name nvarchar(100), @phone varchar(15), @address nvarchar(100), @paid float, @owed float
AS

UPDATE Clients
SET  name = @name, phone = @phone, address = @address, paid = @paid, owed = @owed, balance = @paid - @owed
WHERE id = @id 
GO

 -- Get Current Balance
 CREATE PROCEDURE  Get_balance @client_id int
 AS
 SELECT paid, owed, balance
 FROM Clients
 WHERE id = @client_id
 GO

-- SET BALANCE
CREATE PROCEDURE Set_balance @id int
AS
UPDATE Clients 
SET Balance = paid - owed
WHERE id = @id
GO

-- Update Client balance
CREATE PROCEDURE Update_balance @client_id int, @new_paid float, @new_owed float
AS
UPDATE Clients
SET paid = paid + @new_paid, owed = owed + @new_owed
WHERE id = @client_id
EXEC Set_balance @id = @client_id
GO

-- Update Returned Client balance
CREATE PROCEDURE Update_Returnedbalance @client_id int, @new_received float, @new_owed float
AS
UPDATE Clients
SET paid = paid - @new_received, owed = owed - @new_owed
WHERE id = @client_id
EXEC Set_balance @id = @client_id
GO

-- Delete Some Client
CREATE PROCEDURE Delete_client @id int
AS
DELETE FROM Clients WHERE id = @id;
GO

-- Pay Cash
CREATE PROCEDURE Pay_cash @id int, @new_pay float
AS
Update Clients
SET paid = paid + @new_pay
WHERE id = @id
EXEC Set_balance @id = @id
EXEC Get_balance @client_id = @id
GO
-------------------------------------------------------------

------------ For Recipts  --------------------------------

-- Generate New Receipt
CREATE PROCEDURE Generate_recipt @client_id int
AS
DECLARE @client_balance float 
SET @client_balance =  (SELECT balance FROM Clients WHERE id = @client_id) 
INSERT INTO Receipts(client_id, past_balance, receipt_total, paid, new_balance, readable_balance, notes) VALUES(@client_id, @client_balance, 0, 0, 0, 'hk', N'معلش')
GO


-- Create The Receipt
CREATE PROCEDURE Create_receipt @receipt_id int, @client_id int,  @paid float, @readable_balance nvarchar(100), @notes nvarchar(400)
AS
DECLARE @receipt_total float  
SET @receipt_total = (SELECT  SUM(Products.price * ReceiptsProducts.quantity) AS total_price
FROM Products
LEFT JOIN ReceiptsProducts ON Products.id = ReceiptsProducts.product_id
WHERE ReceiptsProducts.receipt_id = @receipt_id
)
UPDATE Receipts
SET receipt_total = @receipt_total, paid = @paid, readable_balance = @readable_balance, notes = @notes, new_balance = past_balance - @receipt_total + @paid
WHERE id = @receipt_id
EXEC Update_balance @client_id = @client_id, @new_paid = @paid, @new_owed = @receipt_total
GO

-- Get Receipt Data
CREATE PROCEDURE Get_receipt_data @receipt_id int
AS
SELECT * 
FROM Receipts_Data
LEFT JOIN Receipts_Products ON Receipts_Data.receipt_id = Receipts_Products.receipt_id
WHERE Receipts_Data.receipt_id = @receipt_id 
GO

-- Search Receipts by client id
CREATE PROCEDURE Search_receipts_client @client_id nvarchar(100)
AS
SELECT Receipts.* 
FROM Receipts 
WHERE client_id = @client_id
GO


------------ For ProductsReceipts  --------------------------------

-- Add New Entry
CREATE PROCEDURE Add_entry @product_id int, @receipt_id int, @quantity int
AS
EXEC Pull_product @product_id = @product_id, @pulled_quantity = @quantity
INSERT INTO ReceiptsProducts(product_id, receipt_id, quantity) VALUES (@product_id, @receipt_id, @quantity)
GO

------------ For ReturnedRecipts  --------------------------------
-- Generate New ReturnedReceipt
CREATE PROCEDURE Generate_Returnedrecipt @client_id int
AS
DECLARE @client_balance float 
SET @client_balance =  (SELECT balance FROM Clients WHERE id = @client_id) 
INSERT INTO ReturnedReceipts(client_id, past_balance, receipt_total, paid, new_balance, readable_balance, notes) VALUES(@client_id, @client_balance, 0, 0, 0, 'hk', N'معلش')
GO


-- Create The Returned Receipt
CREATE PROCEDURE Create_Returnedreceipt @receipt_id int, @client_id int,  @received float, @readable_balance nvarchar(100), @notes nvarchar(400)
AS
DECLARE @receipt_total float  
SET @receipt_total = (SELECT  SUM(Products.price * ReturnedReceiptsProducts.quantity) AS total_price
FROM Products
LEFT JOIN ReturnedReceiptsProducts ON Products.id = ReturnedReceiptsProducts.product_id
WHERE ReturnedReceiptsProducts.receipt_id = @receipt_id
)
UPDATE ReturnedReceipts
SET receipt_total = @receipt_total, paid = @received, readable_balance = @readable_balance, notes = @notes, new_balance = past_balance + @receipt_total - @received
WHERE id = @receipt_id
EXEC Update_Returnedbalance @client_id = @client_id, @new_received =  @received, @new_owed = @receipt_total
GO

-- Get Returned Receipt Data
CREATE PROCEDURE Get_Returnedreceipt_data @receipt_id int
AS
SELECT * 
FROM ReturnedReceipts_Data
LEFT JOIN ReturnedReceipts_Products ON ReturnedReceipts_Data.receipt_id = ReturnedReceipts_Products.receipt_id
WHERE ReturnedReceipts_Data.receipt_id = @receipt_id 
GO

-- Search Returned Receipts by client id
CREATE PROCEDURE Search_Returnedreceipts_client @client_id nvarchar(100)
AS
SELECT ReturnedReceipts.* 
FROM ReturnedReceipts 
WHERE client_id = @client_id
GO


------------ For ReturnedProductsReceipts  --------------------------------

-- Add New Entry
CREATE PROCEDURE Add_Returnedentry @product_id int, @receipt_id int, @quantity int
AS
EXEC Push_product @product_id = @product_id, @pushed_quantity = @quantity
INSERT INTO ReturnedReceiptsProducts(product_id, receipt_id, quantity) VALUES (@product_id, @receipt_id, @quantity)
GO
-- History of Receipts
CREATE PROCEDURE Receipts_history @client_id int
AS
SELECT * FROM Receipts WHERE client_id = @client_id 
UNION
SELECT * FROM ReturnedReceipts WHERE client_id = @client_id 
ORDER BY receipt_date
GO




SELECT * FROM Clients