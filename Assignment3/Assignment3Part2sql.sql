USE [Northwind]

--1. 	List all cities that have both Employees and Customers.
SELECT DISTINCT c.city
FROM Customers AS c
INNER JOIN Employees AS e ON e.City = c.City

--2.	List all cities that have Customers but no Employee.

--a. Subquery
SELECT CusCity
FROM 
(   SELECT c.city AS CusCity, e.City AS EmpCity
	FROM Customers AS c
	LEFT JOIN Employees AS e ON c.City = e.City
) CusAndEmp
GROUP BY CusCity
--b. Non-subquery
;WITH CusAndEmp AS
(
	SELECT c.city AS CusCity, e.City AS EmpCity
	FROM Customers AS c
	LEFT JOIN Employees AS e ON c.City = e.City
)
SELECT CusCity
FROM CusAndEmp
WHERE EmpCity IS NULL
GROUP BY CusCity

--3.	List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(d.Quantity) AS quantities
FROM [Order Details] AS d
INNER JOIN Products AS p ON d.ProductID = p.ProductID
GROUP BY p.ProductName

--4. 	List all Customer Cities and total products ordered by that city.
SELECT c.City, COUNT(*) AS  'Total Products Order'
FROM Customers AS c
LEFT JOIN Orders AS o ON c.City = o.ShipCity
GROUP BY c.City

--5.	List all Customer Cities that have at least two customers.
--a. 
SELECT City
FROM Customers
UNION 
SELECT City
FROM Customers
--b.
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(*) > 2

--6. List all Customer Cities that have ordered at least two different kinds of products.
;WITH ProductsOfCustomer AS
(
	SELECT o.CustomerID, d.ProductID
	FROM Orders AS o
	INNER JOIN [Order Details] AS d ON o.OrderID = d.OrderID
)
SELECT c.City
FROM Customers AS c
INNER JOIN ProductsOfCustomer AS p ON p.CustomerID = c.CustomerID
GROUP BY c.City
HAVING COUNT(*) > 2

--7.	List all Customers who have ordered products, but have the ¡¥ship city¡¦ on the order different from their own customer cities.
SELECT c.CompanyName
FROM Orders AS o
INNER JOIN Customers AS c ON o.CustomerID = c.CustomerID 
WHERE o.ShipCity <> c.City
GROUP BY c.CompanyName

--8. 	List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT p.ProductName, c.City, AVG(p.UnitPrice), COUNT(*)
FROM
(SELECT dt.ProductID, DENSE_RANK() OVER (ORDER BY total DESC) rnk
FROM
(SELECT d.ProductID, COUNT(*) AS total
FROM Orders AS o
INNER JOIN [Order Details] AS d ON o.OrderID = d.OrderID 
GROUP BY d.ProductID) dt) dt2, [Order Details] AS d, Orders AS o, Customers AS c, Products AS p
WHERE dt2.rnk <= 5 AND dt2.ProductID = d.ProductID AND d.OrderID = o.OrderID AND o.CustomerID = c.CustomerID AND dt2.ProductID = p.ProductID
GROUP BY p.ProductName, c.City

--9. 	List all cities that have never ordered something but we have employees there.
--a.	Use sub-query
SELECT dt.City
FROM
(SELECT e.City, o.ShipCity
FROM Employees AS e
LEFT JOIN Orders AS o ON e.City = o.ShipCity) dt
WHERE dt.ShipCity IS NULL

--b.	Do not use sub-query
WITH NoEmployee AS
(
	SELECT e.City, o.ShipCity
	FROM Employees AS e
	LEFT JOIN Orders AS o ON e.City = o.ShipCity
)
SELECT City
FROM NoEmployee
WHERE ShipCity IS NULL

--10.	List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)


--11. How do you remove the duplicates record of a table?
I will create a temp table that stores the  distinct record (using group by to eliminate duplicated rows). Second, delete the table and insert the temp table to real table.

/*
 Employee 
 ( 
	empid integer, 
	mgrid integer, 
	deptid integer, 
	salary integer
) 
 Dept 
 (
	deptid integer, 
	deptname text
)
*/
--12.Find employees who do not manage anybody
SELECT * FROM Employee WHERE mgrid IS NULL 

--13.
SELECT dt2.deptid, num
FROM
(SELECT dt.deptname, num, DENSE_RANK() OVER (ORDER BY num DESC) rnk
FROM
(SELECT d.deptname, COUNT(*) AS num
FROM Employee AS e
INNER JOIN Dept AS d ON e.deptid = d.deptid
GROUP BY d.deptname) dt) dt2
WHERE rnk = 1

--14. Find top 3 employees (salary based) in every department. 
--Result should have deptname, empid, salary sorted by deptname and then employee with high to low salary.
SELECT dt2.deptname, dt2.empid, dt2.salary
FROM
(SELECT dt.deptname, dt.empid, dt.salary, DENSE_RANK() OVER (PARTITION BY deptname ORDER BY salary DESC) rnk
FROM
(SELECT deptname, e.empid, e.salary
FROM Employee AS e
INNER JOIN Dept AS d ON e.deptid = d.deptid) dt) dt2
WHERE rnk <= 3
ORDER BY deptname ASC, salary DESC