Use AdventureWorks2019
--1.	How many products can you find in the Production.Product table?
SELECT COUNT(ProductID) 
FROM Production.Product

--2.	Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

--3. 	How many Products reside in each SubCategory? Write a query to display the results with the following titles.
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID

--4.	How many products that do not have a product subcategory. 
SELECT COUNT(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--5. 	Write a query to list the summary of products in the Production.ProductInventory table.
SELECT TheSum 
FROM Production.ProductInventory

--6. Write a query to list the summary of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID, TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 AND Quantity < 40

--7. 	Write a query to list the summary of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT Shelf, ProductID, TheSum
FROM Production.ProductInventory
WHERE LocationID = 40 AND Quantity < 100

--8. 	Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) 
FROM Production.ProductInventory
WHERE LocationID = 10

--9.	Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT Shelf, ProductID, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY Shelf, ProductID

--10.	Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT Shelf, ProductID, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY Shelf, ProductID

--11.	List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

--12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following. 
SELECT C.Name AS Country, S.Name AS Province
FROM Person.CountryRegion AS C
INNER JOIN Person.StateProvince AS S ON C.CountryRegionCode = S.CountryRegionCode

--13. 	Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT C.Name AS Country, S.Name AS Province
FROM Person.CountryRegion AS C
INNER JOIN Person.StateProvince AS S ON C.CountryRegionCode = S.CountryRegionCode
WHERE C.Name IN ('Canada', 'Germany')

--14. 