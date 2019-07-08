-- Table: Categories
CREATE TABLE Categories (
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(100) UNIQUE
);

-- Table: Clients
CREATE TABLE Clients(
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(100),
	phone varchar(15),
	address nvarchar(100),
	paid float DEFAULT 0.0,
	owed float DEFAULT 0.0,
	balance float DEFAULT 0.0,
);

-- Table: Products
CREATE TABLE Products(
	id int IDENTITY(1,1) PRIMARY KEY,
	name nvarchar(100),
	quantity int,
	vendor nvarchar(100),
	barcode varchar(50),
	price float,
	category_id int,
	FOREIGN KEY (category_id) REFERENCES Categories(id) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Table: Receipts
CREATE TABLE Receipts(
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

-- Table ReceiptsProducts
CREATE TABLE ReceiptsProducts(
	id int IDENTITY(1,1) PRIMARY KEY,
	product_id int,
	FOREIGN KEY (product_id) REFERENCES Products(id) ON DELETE SET NULL ON UPDATE CASCADE,
	receipt_id int,
	FOREIGN KEY (receipt_id) REFERENCES Receipts(id) ON DELETE SET NULL ON UPDATE CASCADE,
	quantity int
);

-------------------------------     INSERTIONS        ----------------------------------------------------


-- Categories
INSERT INTO Categories(name) VALUES (N'غسالة')
INSERT INTO Categories(name) VALUES (N'بوتجاز')
INSERT INTO Categories(name) VALUES (N'مروحة')

-- Clients
INSERT INTO Clients(name, phone, address) VALUES (N'لؤي', '01027004107', N'هناك كدا')
INSERT INTO Clients(name, phone, address) VALUES (N'نادر', '012000000', N'في الجيش')

-- Products
INSERT INTO Products(name, quantity, vendor, barcode, price, category_id) VALUES (N'كريازي', 1, N'رائد', 5200.26, 123456, 1)
INSERT INTO Products(name, quantity, vendor, barcode, price, category_id) VALUES (N'فووورن', 2, N'احمد', 1000, 1234567, 2)
INSERT INTO Products(name, quantity, vendor, barcode, price, category_id) VALUES (N'توشيبا', 3, N'نل', 150.50, 12345678, 3)

-- Receipts
INSERT INTO Receipts(client_id, past_balance, receipt_total, paid, new_balance, readable_balance) VALUES (1, 0, 1000, 900, -100, N'مائة جنية')
INSERT INTO Receipts(client_id, past_balance, receipt_total, paid, new_balance, readable_balance) VALUES (2, 0, 1000, 800, -200, N'مائتان جنية')

-- ReceiptsProducts
INSERT INTO ReceiptsProducts(product_id, receipt_id, quantity) VALUES(1,1,12)
INSERT INTO ReceiptsProducts(product_id, receipt_id, quantity) VALUES(2,1,22)
INSERT INTO ReceiptsProducts(product_id, receipt_id, quantity) VALUES(3,1,33)
INSERT INTO ReceiptsProducts(product_id, receipt_id, quantity) VALUES(1,2,111)
INSERT INTO ReceiptsProducts(product_id, receipt_id, quantity) VALUES(2,2,222)

-------------------------------     SHOWS        ----------------------------------------------------


-- Categories
SELECT * FROM Categories

-- Clients
SELECT * FROM Clients

-- Products
SELECT * FROM Products

-- Receipts
SELECT * FROM Receipts

-- ReciptsProducts
SELECT * FROM ReceiptsProducts

-------------------------------     Creating VIEWS        ----------------------------------------------------


-- Products Categories
CREATE VIEW Products_Categories
AS
SELECT p.id, c.name as category, p.name, p.vendor, p.quantity, p.price
FROM Products as p
LEFT JOIN Categories as c
ON p.category_id = c.id

-- Receipts Data
CREATE VIEW Receipts_Data
AS
SELECT Receipts.id as receipt_id, Receipts.receipt_date, Clients.name as client_name, Clients.phone, Clients.address,
Receipts.past_balance, Receipts.receipt_total, Receipts.paid, Receipts.new_balance, Receipts.readable_balance, Receipts.notes
FROM Receipts
LEFT JOIN Clients ON Receipts.client_id  = Clients.id

-- Receipts_Products
CREATE VIEW Receipts_Products
AS
SELECT Products_Categories.category, Products_Categories.name, Products_Categories.vendor, Products_Categories.price, ReceiptsProducts.receipt_id, ReceiptsProducts.quantity 
FROM ReceiptsProducts
LEFT JOIN Products_Categories ON ReceiptsProducts.product_id = Products_Categories.id


-------------------------------     Testing VIEWS        ----------------------------------------------------


-- Products Categories
SELECT * FROM  Products_Categories

-- Receipts Data
SELECT * FROM Receipts_Data
 
-- Receipts Products
SELECT * FROM Receipts_Products

-------------------------------    CREATING PROCEDURES        ----------------------------------------------------

------------ FOR CATEGORIES --------------------------------

-- Create New Category
CREATE PROCEDURE Add_Category @new_category nvarchar(100)
AS
INSERT INTO Categories(name) VALUES (@new_category)
GO;

-- Update Existing Category
CREATE PROCEDURE Update_category @id int, @new_name nvarchar(100)
AS
UPDATE Categories
SET name = @new_name
WHERE id = @id
GO;

-- Delete Some Category
CREATE PROCEDURE Delete_category @id int
AS
DELETE FROM Categories WHERE id = @id;
GO;

-- Search Categories BY name
CREATE PROCEDURE Search_categories @name nvarchar(100)
AS
SELECT * 
FROM Categories
WHERE name LIKE '%' + @name + '%'
GO;
-------------------------------------------------------------

------------ FOR Products --------------------------------
-- Create New Product
CREATE PROCEDURE Add_new_product @name nvarchar(100), @quantity int, @vendor nvarchar(100), @barcode varchar(50), @price float, @category_id int
AS
INSERT INTO Products(name, quantity, vendor, barcode, price, category_id) VALUES (@name, @quantity, @vendor, @barcode, @price, @category_id)
GO;

-- Updating existing prouduct
CREATE PROCEDURE Update_product @id int, @name nvarchar(100), @quantity int, @vendor nvarchar(100), @barcode varchar(50), @price float, @category_id int
AS
UPDATE Products
SET  name = @name, quantity = @quantity, vendor = @vendor, barcode = @barcode, price = @price, category_id = @category_id
WHERE id = @id
GO;

-- Delete Some Product
CREATE PROCEDURE Delete_product @id int
AS
DELETE FROM Products WHERE id = @id;
GO;

-- Search Products BY name
CREATE PROCEDURE Search_products_name @name nvarchar(100)
AS
SELECT * 
FROM Products
WHERE name LIKE '%' + @name + '%'
GO;

-- Search Products BY Barcode
CREATE PROCEDURE Search_products_barcode @barcode varchar(50)
AS
SELECT * 
FROM Products
WHERE barcode = @barcode
GO;

-------------------------------------------------------------

-- Get Receipt Data
CREATE PROCEDURE Get_receipt_data @receipt_id int
AS
SELECT * 
FROM Receipts_Data
LEFT JOIN Receipts_Products ON Receipts_Data.receipt_id = Receipts_Products.receipt_id
WHERE Receipts_Data.receipt_id = @receipt_id 
GO;

---	----------------------------    EXECUTING PROCEDURES        ----------------------------------------------------
------------ FOR CATEGORIES --------------------------------

-- Create New Category
EXEC Add_Category @new_category = "ggg"

-- Update Existing Category
EXEC Update_category @id = 1, @new_name = "غسالات"

-- Delete Some Category
EXEC Delete_category @id = 2

-- Search Categories BY name
EXEC Search_categories @name = "غس"
-------------------------------------------------------------

------------ FOR Products  --------------------------------

-- Create New Product
EXEC Add_new_product @name = "تكييف 4 حصان", @quantity = 4 , @vendor = "Union Air" , @barcode = "12345678", @price = 12563.523, @category_id = 4

-- Updating Existing Product
EXEC Update_product @id = 4, @name = "تكييف 5 حصان", @quantity = 4 , @vendor = "Union Air" , @barcode = "12345678", @price = 12563.523, @category_id = 4

-- Delete Some Product with ID
EXEC Delete_product @id = 1

-- Search Product by name
EXEC Search_products_name @name = "و"

-- Search Product by Barcode
EXEC Search_products_barcode @barcode = 1000
-------------------------------------------------------------
-- Get Some Receipt Data by id
EXEC Get_receipt_data @receipt_id = 1


