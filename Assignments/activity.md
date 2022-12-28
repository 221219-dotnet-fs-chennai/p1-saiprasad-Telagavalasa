# Stored Procedures
 A stored procedure is a prepared SQL code that you can save, so the code can be reused over and over again.collection of pre-compiled SQL statements . It begins to start executing when we call it (like functions in programming language).
 # Why stored procedures
 So if you have an SQL query that you write over and over again, save it as a stored procedure, and then just call it to execute it.

You can also pass parameters to a stored procedure, so that the stored procedure can act based on the parameter value(s) that is passed.

procedures can have input or output parameters or return values but return values returns the single value with datatype  int .
 ## syntax for creating stored procedure
```text
create procedure procedure_name
As
Begin
**sql statements
End;
```
### example
```text
create procedure spemployees
As
Begin
select empname,gender from employees where gender='male'
End;
``` 
### Alter the procedure
```text
Alter procedure procedure_name
As
Begin
**sql statements
End;
```
### exmaple 
```text
Alter procedure spemployees
As
Begin
select empname,gender from employees where gender='female'
End;
```
### Excecuting stored procedure
``` text
EXEC     procedure_name;
ExECUTE  procedure_name;
procedure_name;
```
### creating procedure with multiple parameters
``` text
Create proc procedure_name 
@variable datatype ,
@variable datatype
AS
Begin
  -Sql statements;
End;
``` 
### example
``` text 
create proc  spgetemployeesbygender
@Id int ,
@gender varchar(10)
As
Begin
Select id,gender from employees where id= @Id and gender = @gender
end;
``` 
### dropping the stored procedures
```text
drop proc procedure_name;
```
### Example 
```text
drop proc spgetemployeesbygender
```
### Rules for creating procedures
``` text 
should not write the procedure name which starts with "sp_"
Because stored procedures has some system stored procedures
```
### system stored procedures
``` text 
sp_helptext	: It provides the text of a stored procedure reside in SQL Server
sp_depends	: It provides the details of all database objects that depend on the specific database object.
sp_help     :	It provides details on any database object.
```
### protection of the stored procedure
``` text 
create procedure spemployees
WITH ENCRYPTION
As
Begin
select empname,gender from employees where gender='male
End;

```
### Example
```text 
create proc spemployee
WITH ENCRYPTION
AS
Select * from employees;
Begin
```
### prons 
``` text 
code resuability
provides better security
reuces N/W traffic 
```
### cons
``` text 
it is difficult to debug stored procedure
Testing of a logic which is encapsulated inside a stored procedure is very difficult.
```