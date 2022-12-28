Create database Employees;
go
create SCHEMA saiprasad;
go
create table  saiprasad.Department(
    Id int PRIMARY key,
    Dname nvarchar(15) not null,
    Location nvarchar(20) not null
);


create table saiprasad.Employee(
    Id int PRIMARY KEY,
    empfirstname nvarchar(10) not null,
    emplastname nvarchar(10) not null,
    ssn bigint UNIQUE,
    depId int not null
);
select * from saiprasad.Employee
select * from saiprasad.Department
select * from saiprasad.Empdetails
update saiprasad.Employee set depId=4 where id=4
go

ALTER TABLE saiprasad.Employee
ADD CONSTRAINT FK_Employee_Department
FOREIGN KEY ( depID ) REFERENCES saiprasad.Department ( Id )


Create table saiprasad.Empdetails(
    Id  int PRIMARY key,
    EmployeeId  int not null,
    salary  money not null,
    Address1 nvarchar(50) not null,
    Address2 nvarchar(50) not null,
    city NVARCHAR(20) not null,
    state nvarchar(20) not null,
    Country nvarchar(20) not null
);
select * from saiprasad.Empdetails
go

ALTER TABLE saiprasad.Empdetails
ADD CONSTRAINT FK_newEmployeeId FOREIGN KEY(EmployeeId) 
    REFERENCES saiprasad.Employee(Id);
GO
--ading atleast 3 records
insert into saiprasad.Department(Id, Dname ,LOCATION) VALUES('2','maths' ,'Vijayawada'),('3','English','Vizag');
insert into saiprasad.Employee(Id,empfirstname,emplastname,ssn,depID) VALUES('2','ram','krishna','67834678','2'),('3','hari','venkat','45632789','3')
insert into saiprasad.Empdetails(Id,EmployeeId,salary,Address1,Address2,city,state,Country) values('4','4','6600',' highway nagar','500144','nellore','ap','India'),
('3','3','90000','It highway nagar','340124','califorina','new jersey','us')


GO
-- add employee tinasmith
insert into saiprasad.Employee(Id,empfirstname,emplastname,ssn,depID) values('4','Tina','smith', '3456789','2');
--add department marketing
insert into saiprasad.Department(Id,Dname,Location) values ('4','Marketing','Chennai')
GO

--list all the employees in marketing
select empfirstname,emplastname from saiprasad.Employee where depId='4'
go


--reporttotal saaryby maraketing
 select sum(salary)as totalsalary from saiprasad.Empdetails
  where employeeId in (select employeeId from saiprasad.Empdetails where EmployeeId='4')

--report total employees by departmnet
 select Employee.empfirstname, Employee.emplastname , Department.Dname from saiprasad.Employee
   inner join saiprasad.Department ON
  saiprasad.Employee.Id  = saiprasad.Department.Id
--increase salary of tina smith
  update  saiprasad.Empdetails 
  set salary = salary+96000 where id='4'