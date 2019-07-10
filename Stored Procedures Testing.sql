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

-- ReturnedReceipts
INSERT INTO Receipts(client_id, past_balance, receipt_total, paid, new_balance, readable_balance) VALUES (1, 0, 1000, 900, -100, N'مائة جنية')
INSERT INTO Receipts(client_id, past_balance, receipt_total, paid, new_balance, readable_balance) VALUES (2, 0, 1000, 800, -200, N'مائتان جنية')

-- ReturnedReceiptsProducts
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

-- RerurnedReceipts
SELECT * FROM ReturnedReceipts

-- RerurnedReciptsProducts
SELECT * FROM ReturnedReceiptsProducts

-------------------------------     Testing VIEWS        ----------------------------------------------------


-- Products Categories
SELECT * FROM  Products_Categories

-- Receipts Data
SELECT * FROM Receipts_Data
 
-- Receipts Products
SELECT * FROM Receipts_Products

---	----------------------------    EXECUTING PROCEDURES        ----------------------------------------------------
------------ FOR CATEGORIES --------------------------------

-- Create New Category
EXEC Add_Category @new_category = "لاب"

-- Update Existing Category
EXEC Update_category @id = 1, @new_name = "غسالات"

-- Delete Some Category
EXEC Delete_category @id = 2

-- Search Categories BY name
EXEC Search_categories @name = "غس"
-------------------------------------------------------------

------------ FOR Products  --------------------------------

-- Create New Product
EXEC Add_new_product @name = "ديلللللل", @quantity = 4 , @vendor = "سامسونج" , @barcode = "12345678", @price = 500, @category_id = 5

-- Updating Existing Product
EXEC Update_product @id = 1, @name = "تكييف 5 حصان", @quantity = 5 , @vendor = "Union Air" , @barcode = "12345678", @price = 1000, @category_id = 1

-- Delete Some Product with ID
EXEC Delete_product @id = 1

-- Search Product by name
EXEC Search_products_name @name = ""

-- Search Product by Barcode
EXEC Search_products_barcode @barcode = 1000

-- Search Products BY Categoty
EXEC Search_products_category @category_id = 1

-- Search Products BY Vendor
EXEC Search_products_vendor @vendor = "ا"

-- Push Products
EXEC Push_product @product_id = 1, @pushed_quantity = 2

-- Pull Products
EXEC Pull_product @product_id = 1, @pulled_quantity  = 2

-------------------------------------------------------------
------------ FOR Clients  --------------------------------

-- Get Client
	EXEC Get_client @client_id  = 5


-- Add New Client
EXEC Add_client @name = "رؤوده", @phone = "0155265696352", @address = "قاعد على طيزه", @paid = 0, @owed = 0

-- Update Existing Client
Exec Update_client @id = 3, @name = "جدو", @phone = 01515662189, @address = "نب", @paid = 5, @owed = 12

-- Delete Some Client
EXEC Delete_client @id = 1

-- Set Balance
EXEC Set_balance @id = 1

-- Pay Cash
EXEC Pay_cash @id = 5, @new_pay = 400

-------------------------------------------------------------
------------ For Recipts  --------------------------------
-- Generate New Receipt
EXEC Generate_recipt @client_id = 2

-- Create The Receipt
EXEC Create_receipt @receipt_id = 5, @client_id  = 2, @paid = 200, @readable_balance = " كسمك", @notes = "احا ايه الاسعار الحلوه دي"

-- Get Some Receipt Data by id
EXEC Get_receipt_data @receipt_id = 1

-- Search Receipts by client id
EXEC Search_receipts_client @client_id = 2


-------------------------------------------------------------

------------ For ProductsReceipts  --------------------------------

-- Add New Entry
EXEC Add_entry @product_id = 1 , @receipt_id  = 5, @quantity = 2


-------------------------------------------------------------
------------ For ReturnedRecipts  --------------------------------

-- Generate New Returned Receipt
EXEC Generate_Returnedrecipt @client_id = 2

-- Create The ReturnedReceipt
EXEC Create_Returnedreceipt @receipt_id = 2, @client_id  = 2, @received = 100, @readable_balance = " كسمك", @notes = "احا ايه الاسعار الحلوه دي"

-- Get Some ReturnedReceipt Data by id
EXEC Get_Returnedreceipt_data @receipt_id = 1

-- Search ReturnedReceipts by client id
EXEC Search_Returnedreceipts_client @client_id = 2


-------------------------------------------------------------

------------ For ReturnedProductsReceipts  --------------------------------

-- Add New Entry
EXEC Add_Returnedentry @product_id = 1 , @receipt_id  = 2, @quantity = 1


-------------------------------------------------------------
-- History of Receipts
EXEC Receipts_history @client_id = 2
