USE [Northwind]
--1.
BEGIN TRY
	BEGIN TRAN
	--Declare variables
	DECLARE @re INT
	DECLARE @terriitory NVARCHAR(20)
	INSERT INTO Region VALUES (5,'Middle Earth')
	SELECT @re = RegionID FROM Region WHERE RegionDescription = 'Middle Earth'
	INSERT INTO Territories VALUES ('12345','Gondor',@re)
	SELECT @terriitory = TerritoryID FROM Territories WHERE TerritoryDescription = 'Gondor'
	INSERT INTO Employees VALUES ('Aragorn','King',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)
	SELECT @re FROM Employees WHERE FirstName = 'Aragorn' AND LastName = 'King'
	INSERT INTO EmployeeTerritories VALUES (@re,@terriitory)
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH

--2.
UPDATE Territories SET TerritoryDescription = 'Arnor' WHERE TerritoryDescription = 'Gondor'

--3.
BEGIN TRY
	BEGIN TRAN
	--Declare variables
	DECLARE @re INT
	SELECT @re = RegionID FROM Region
	;WITH EmployeeAndTerri AS
	(
		SELECT TerritoryID FROM Territories WHERE RegionID = @re
	)
	DELETE EmployeeTerritories
	WHERE TerritoryID IN (SELECT * FROM EmployeeAndTerri)

	DELETE Territories WHERE RegionID = @re
	DELETE Region WHERE RegionID = @re
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH

--4.
CREATE VIEW view_product_order_chuang 
AS
	SELECT p.ProductName, COUNT(dt.OrderID) AS 'Ordered Quantity'
	FROM
		(SELECT d.ProductID, o.OrderID
		FROM Orders AS o
		INNER JOIN [Order Details] AS d ON d.OrderID = o.OrderID) dt
	INNER JOIN Products AS p ON p.ProductID = dt.ProductID
	GROUP BY p.ProductName

--5.
CREATE PROCEDURE [dbo].[sp_product_order_quantity_chuang]
@id INT,
@total INT OUTPUT
AS
	SELECT @total = COUNT(*)
	FROM
		(SELECT d.ProductID, o.OrderID
		FROM Orders AS o
		INNER JOIN [Order Details] AS d ON d.OrderID = o.OrderID AND d.ProductID = @id) dt

--6. 
CREATE PROCEDURE [dbo].[sp_order_city_chuang]
@pname NVARCHAR(40) = 'Maxilaku'
AS
;WITH TopCity AS
(
SELECT dt2.ShipCity
FROM
	(SELECT dt.ShipCity, DENSE_RANK() OVER (ORDER BY num DESC) AS rnk
	FROM
		(SELECT ShipCity, COUNT(*) AS num
		FROM Orders AS o
		INNER JOIN [Order Details] AS d ON o.OrderID = d.OrderID
		INNER JOIN Products AS p ON p.ProductID = d.ProductID AND p.ProductName = @pname
		GROUP BY ShipCity) dt
	) dt2
WHERE rnk <= 5
)
SELECT t.ShipCity, SUM(d.Quantity) AS 'Total Quantity'
FROM Orders AS s, TopCity AS t, [Order Details] AS d, Products AS p
WHERE s.OrderID = d.OrderID AND s.ShipCity = t.ShipCity AND d.ProductID = p.ProductID AND p.ProductName = @pname
GROUP BY t.ShipCity

--7.
DECLARE @num INT
SELECT @num = COUNT(*)
FROM EmployeeTerritories AS et
INNER JOIN Territories AS t ON et.TerritoryID = t.TerritoryID
WHERE t.TerritoryDescription = 'Troy'

IF @num > 0
BEGIN 
	BEGIN TRY
		PRINT('Start')
		BEGIN TRAN
		DECLARE @re INT
		DECLARE @te NVARCHAR(20)
		SELECT @re = RegionID FROM Region WHERE RegionDescription = 'Northern'
		INSERT Territories VALUES ('12365','Stevens Point',@re)
		SELECT @te = TerritoryID FROM Territories WHERE TerritoryDescription = 'Stevens Point'
		UPDATE EmployeeTerritories SET TerritoryID = @te
		WHERE TerritoryID IN (SELECT TerritoryID FROM Territories WHERE TerritoryDescription = 'Troy')
		COMMIT TRAN
		PRINT('END')
	END TRY
	BEGIN CATCH
		PRINT('Failed')
		ROLLBACK TRAN
	END CATCH
END;

--8.
CREATE TRIGGER movetoTroy
ON EmployeeTerritories
AFTER INSERT
AS
BEGIN
	DECLARE @cnt INT
	DECLARE @te NVARCHAR(20)
	SELECT @cnt = COUNT(*) 
	FROM EmployeeTerritories 
	WHERE TerritoryID = (SELECT TerritoryID FROM Territories WITH(NOLOCK) WHERE TerritoryDescription = 'Stevens Point')
	IF @cnt > 100
	BEGIN
		SELECT @te = TerritoryID FROM Territories WITH(NOLOCK) WHERE TerritoryDescription = 'Troy'
		UPDATE EmployeeTerritories SET TerritoryID = @te 
		WHERE EmployeeID = (SELECT EmployeeID FROM inserted) AND TerritoryID = (SELECT TerritoryID FROM inserted)
	END
END

DROP TRIGGER IF EXISTS movetoTroy

--9.
CREATE TABLE people_chuang
(
	Id INT NOT NULL,
	[Name] NVARCHAR(50),
	City INT
);
INSERT people_chuang VALUES ('1','Aaron Rodgers,','2'),('2','Russell Wilson','1'),('3','Jody Nelson','2')
CREATE TABLE city_chuang
(
	Id INT NOT NULL PRIMARY KEY,
	City NVARCHAR(20)
);
INSERT city_chuang VALUES ('1','Seattle'),('2','Green Bay')

DECLARE @cnt INT
SELECT @cnt = COUNT(*)
FROM people_chuang
WHERE City = (SELECT Id FROM city_chuang WHERE City = 'Seattle')

IF @cnt > 0
BEGIN
	BEGIN TRY
		BEGIN TRAN
		DECLARE @ci INT
		INSERT city_chuang VALUES ('3','Madison')
		SELECT @ci = Id FROM city_chuang WHERE City = 'Madison'
		UPDATE people_chuang SET City = @ci
		WHERE City = (SELECT Id FROM city_chuang WHERE City = 'Seattle')
		DELETE city_chuang  WHERE City = 'Seattle'
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END

CREATE VIEW Packer_chuang
AS
	SELECT [Name]
	FROM people_chuang
	WHERE City IN (SELECT Id FROM city_chuang WHERE City = 'Green Bay')

DROP TABLE people_chuang
DROP TABLE city_chuang
DROP VIEW Packer_chuang

--10.
CREATE PROCEDURE sp_birthday_employees_chuang
AS
	SELECT *
	INTO birthday_employees_chuang
	FROM Employees
	WHERE MONTH(BirthDate) = 2

	SELECT * FROM birthday_employees_chuang

	DROP TABLE birthday_employees_chuang

--11.
CREATE PROCEDURE sp_chuang_1
AS
	;WITH ProductByCustomer AS
	(
		SELECT s.CustomerID,d.ProductID, COUNT(*) AS num
		FROM Orders AS s
		INNER JOIN [Order Details] AS d ON d.OrderID = s.OrderID
		GROUP BY s.CustomerID,d.ProductID
	),
	CustomerByCity AS
	(
		SELECT CustomerID, COUNT(*) AS num1
		FROM ProductByCustomer 
		WHERE num <= 1
		GROUP BY CustomerID
	)
	SELECT c.City
	FROM Customers AS c
	INNER JOIN CustomerByCity AS cb ON cb.CustomerID = c.CustomerID
	WHERE num1 < 2

CREATE PROCEDURE sp_chuang_2
AS
	SELECT c.City
	FROM Customers AS c
	INNER JOIN
	(SELECT CustomerID, COUNT(*) AS num1
	FROM
	(SELECT s.CustomerID,d.ProductID, COUNT(*) AS num
	FROM Orders AS s
	INNER JOIN [Order Details] AS d ON d.OrderID = s.OrderID
	GROUP BY s.CustomerID,d.ProductID) dt
	WHERE num <= 1
	GROUP BY CustomerID) dt2 ON dt2.CustomerID = c.CustomerID
	WHERE num1 < 2

--13.
DECLARE @Ta TABLE 
(
	FirstName NVARCHAR(10),
	LastName NVARCHAR(10),
	MiddleName NVARCHAR(10)
)
INSERT @Ta VALUES ('John','Green', NULL),('Milk','White','M')

SELECT FirstName + ' ' + LastName + ' ' + CASE WHEN MiddleName IS NULL THEN '' ELSE MiddleName + '.' END AS FullName
FROM @Ta

--14.
DECLARE @Ta1 TABLE
(
	Student NVARCHAR(20),
	Marks INT,
	Sex CHAR(1)
)

INSERT @Ta1 VALUES
('Ci',70,'F'),
('Bob',80,'M'),
('Li',90,'F'),
('Mi',95,'M')

SELECT Student
FROM
(SELECT Student, ROW_NUMBER() OVER (ORDER BY Marks DESC) AS rnk
FROM @Ta1
WHERE Sex = 'F') dt
WHERE rnk = 1

--15.
SELECT *
FROM @Ta1
ORDER BY Sex ASC, Marks DESC