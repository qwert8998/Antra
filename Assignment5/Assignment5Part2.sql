/*1.	Write an sql statement that will display the name of each customer and the sum of order totals placed by that customer 
		during the year 2002
		Create table customer (cust_id int,  iname varchar (50)) 
		create table order (order_id int,cust_id int,amount money,order_date smalldatetime)
*/

CREATE TABLE Customers 
(
	Cust_id INT,
	IName VARCHAR(50)
);

CREATE TABLE [Order]
(
	Order_id INT,
	Cust_id INT,
	Amount MONEY,
	Order_date SMALLDATETIME
);

SELECT c.IName, COUNT(o.order_id) AS 'Total Orders'
FROM Customers AS c
INNER JOIN [Order] AS o ON c.Cust_id = o.Cust_id
WHERE DATEPART(YEAR,o.Order_date) = 2020
GROUP BY c.IName

/* 2.  The following table is used to store information about company・s personnel:
		Create table person (id int, firstname varchar(100), lastname varchar(100)) 
		write a query that returns all employees whose last names  start with ：A；.
*/
CREATE TABLE Person
(
	Id INT,
	FirstName VARCHAR(100),
	LastName VARCHAR(100)
);

SELECT * 
FROM Person
WHERE LastName LIKE 'A%'

/*3. The information about company・s personnel is stored in the following table:
	Create table person(person_id int primary key, manager_id int null, name varchar(100)not null) 
	The filed managed_id contains the person_id of the employee・s manager.
	Please write a query that would return the names of all top managers
	(an employee who does not have  a manger, and the number of people that report directly to this manager.)
*/

CREATE TABLE Person1
(
	Person_id INT PRIMARY KEY,
	Manager_id INT NULL,
	[Name] VARCHAR(100) NOT NULL
);
WITH TopManager AS
(
	SELECT Person_id
	FROM Person1
	EXCEPT
	SELECT Manager_id
	FROM Person1
)
SELECT p.Name
FROM Person1 AS p
INNER JOIN TopManager AS t ON t.Person_id = p.Person_id

/*4. List all events that can cause a trigger to be executed.*/
--When the table is updated, inserted, or deleted data, all situations can cause triggerw.

/*5. Generate a destination schema in 3rd Normal Form.  
Include all necessary fact, join, and dictionary tables, and all Primary and Foreign Key relationships.  
The following assumptions can be made:

a. Each Company can have one or more Divisions.
b. Each record in the Company table represents a unique combination 
c. Physical locations are associated with Divisions.
d. Some Company Divisions are collocated at the same physical of Company Name and Division Name.
e. Contacts can be associated with one or more divisions and the address, but are differentiated by suite/mail drop records.status of each association should be separately maintained and audited.
*/
CREATE TABLE Company
(
	Id INT NOT NULL IDENTITY(1,1) UNIQUE,
	[Name] NVARCHAR(20) UNIQUE,
);
CREATE TABLE Divisions
(
	Id INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(20),
	[Location] NVARCHAR(20),
	PRIMARY KEY (Id)
);
CREATE TABLE CompanyToDivisions
(
	CompanyId INT NOT NULL,
	CompanyName NVARCHAR(20) NOT NULL,
	DivisionId INT NOT NULL,
	PRIMARY KEY (CompanyId, CompanyName, DivisionId),
	FOREIGN KEY (CompanyId) REFERENCES Company(Id),
	FOREIGN KEY (CompanyName) REFERENCES Company([Name]),
	FOREIGN KEY (DivisionId) REFERENCES Divisions(Id)
);
CREATE TABLE Contracts
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	SuiteMail NVARCHAR(20)
);
CREATE TABLE ContractToDivisions
(
	ContractId INT NOT NULL,
	DivisionId INT NOT NULL,
	Status NVARCHAR(10),
	PRIMARY KEY (ContractId, DivisionId),
	FOREIGN KEY (ContractId) REFERENCES Contracts(Id),
	FOREIGN KEY (DivisionId) REFERENCES Divisions(Id)
);