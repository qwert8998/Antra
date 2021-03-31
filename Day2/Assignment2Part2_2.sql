Use Northwind

--14. 	List all Products that has been sold at least once in last 25 years.
;WITH Last25Years AS
(
	SELECT d.ProductID
	FROM Orders AS o
	INNER JOIN [Order Details] AS d ON d.OrderID = o.OrderID
	WHERE DATEDIFF(YEAR, OrderDate, GETDATE()) < 25	
	GROUP BY d.ProductID	--eliminate duplicated productId
)
SELECT p.*
FROM Products AS p
INNER JOIN Last25Years AS l ON p.ProductID = l.ProductID

--15. 	List top 5 locations (Zip Code) where the products sold most.
;WITH CountOrder AS
(
	SELECT COUNT(*) AS num, ShipPostalCode
	FROM Orders
	GROUP BY ShipPostalCode
)
SELECT TOP 5 ShipPostalCode
FROM CountOrder
ORDER BY num DESC

--16. 	List top 5 locations (Zip Code) where the products sold most in last 20 years.
;WITH Last25YearsMostSold AS
(
	SELECT COUNT(*) AS num, ShipPostalCode
	FROM Orders 
	WHERE DATEDIFF(YEAR, OrderDate, GETDATE()) < 25	
	GROUP BY ShipPostalCode
)
SELECT TOP 5 ShipPostalCode
FROM Last25YearsMostSold
ORDER BY num DESC

--17.List all city names and number of customers in that city.
SELECT City, COUNT(*) AS num 
FROM Customers
GROUP BY City

--18. 	List city names which have more than 10 customers, and number of customers in that city 
SELECT City, COUNT(*) AS num
FROM Customers
GROUP BY City
HAVING COUNT(*) > 10

--19.	List the names of customers who placed orders after 1/1/98 with order date
;WITH OrdersAfter AS
(
	SELECT CustomerID
	FROM Orders
	WHERE OrderDate > CONVERT(DATETIME, '1998-01-01 00:00:00', 20)
	GROUP BY CustomerID
)
SELECT c.CompanyName
FROM Customers AS c
INNER JOIN OrdersAfter AS o ON c.CustomerID = o.CustomerID

--20. 	List the names of all customers with most recent order dates 
;WITH RecentOrder AS
(
	SELECT CustomerID, MAX(OrderDate) AS recent
	FROM Orders
	GROUP BY CustomerID
)
SELECT c.CompanyName, r.recent
FROM Customers AS c
INNER JOIN RecentOrder AS r ON r.CustomerID = c.CustomerID

--21.	Display the names of all customers  along with the  count of products they bought
;WITH CountProducts AS
(
	SELECT CustomerID, COUNT(*) AS num 
	FROM Orders
	GROUP BY CustomerID
)
SELECT c.CompanyName, p.num
FROM Customers AS c
INNER JOIN CountProducts AS p ON p.CustomerID = c.CustomerID

--22. 	Display the customer ids who bought more than 100 Products with count of products.
;WITH CountProducts AS
(
	SELECT CustomerID, COUNT(*) AS num 
	FROM Orders
	GROUP BY CustomerID
	HAVING COUNT(*) > 100
)
SELECT CustomerID
FROM CountProducts

--23.	List all of the possible ways that suppliers can ship their products. Display the results as below
;WITH SupplierAndShipper AS
(
	SELECT d.ProductID, o.ShipVia
	FROM Orders AS o
	INNER JOIN [Order Details] AS d on o.OrderID = d.OrderID
	GROUP BY d.ProductID, o.ShipVia
)
SELECT  su.CompanyName AS 'supplier company name', sh.CompanyName AS 'Shipping company name'
FROM SupplierAndShipper AS s, Products AS p, Shippers AS sh, Suppliers AS su
WHERE s.ProductID = p.ProductID AND p.SupplierID = su.SupplierID AND s.ShipVia = sh.ShipperID
GROUP BY su.CompanyName, sh.CompanyName

--24.	Display the products order each day. Show Order date and Product Name.
;WITH ProductsEachDay AS
(
	SELECT o.OrderID, d.ProductID, o.OrderDate
	FROM Orders AS o
	INNER JOIN [Order Details] AS d ON d.OrderID = o.OrderID
	GROUP BY o.OrderID, d.ProductID, o.OrderDate
)
SELECT p.ProductName, e.OrderDate
FROM ProductsEachDay AS e
INNER JOIN Products AS p ON e.ProductID = p.ProductID
ORDER BY e.OrderDate

--25.	Displays pairs of employees who have the same job title.
SELECT e1.FirstName, e2.FirstName
FROM Employees AS e1, Employees AS e2
WHERE e1.EmployeeID <> e2.EmployeeID AND e1.Title = e2.Title

--26. 	Display all the Managers who have more than 2 employees reporting to them.
SELECT *
FROM Employees
WHERE ReportsTo > 2

--27. 	Display the customers and suppliers by city. The results should have the following columns
SELECT s.City, s.CompanyName AS [Name], s.ContactName, 'Customer' AS [Type]
FROM Orders AS o 
INNER JOIN Customers AS s ON s.CustomerID = o.CustomerID
GROUP BY s.City, s.CompanyName, s.ContactName
UNION 
SELECT s.City, s.CompanyName AS [Name], s.ContactName, 'Supplier' AS [Type]
FROM Orders AS o, [Order Details] AS d, Products AS p, Suppliers AS s
WHERE o.OrderID = d.OrderID  AND d.ProductID = p.ProductID AND p.SupplierID = s.SupplierID
GROUP BY s.City, s.CompanyName, s.ContactName

--28. 
SELECT *
FROM T1
INNER JOIN T2 ON T1.F1 = T2.F2
The result would be (2,2) and (3,3)

--29.
SELECT *
FROM T1
LEFT JOIN T2 ON T1.F1 = T2.F2
The result would be (1, NULL),(2,2) and (3,3)

SELECT *
FROM T2
LEFT JOIN T1 ON T1.F1 = T2.F2
The result would be (2,2), (3,3), (4, NULL)