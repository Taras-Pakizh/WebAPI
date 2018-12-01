use SoftwareDB;
go

CREATE TABLE Departments
(
	departmentID int primary key,
	dname nvarchar(50),
);

CREATE TABLE Positions
(
	positionID int primary key,
	positionName nvarchar(50),
	salary float
);

CREATE TABLE Employees
(
	employeeID int primary key,
	firstname nvarchar(50),
	lastname nvarchar(50),
	position int foreign key references Positions(positionID),
	birthday date,
	gender char(1),
	department int foreign key references Departments(departmentID)
);

CREATE TABLE OrderTypes
(
	orderTypeID int primary key,
	orderName nvarchar(50)
);

CREATE TABLE EmployeeOrders
(
	orderID int primary key,
	orderDate date,
	Employee int foreign key references Employees(employeeID),
	orderType int foreign key references OrderTypes(orderTypeID),
	orderDescription nvarchar(50)
);