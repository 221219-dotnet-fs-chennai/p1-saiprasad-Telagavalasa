# Project_0- saiprasad
                    

## PROJECT TITLE : To Find A Trainer Online

Agenda is to create an application to add professional trainers data in a database and these trainers are able to upload their profiles, so that vendors and client can reach out to them to offer business as well get their team trained on required skill sets.


--------------------------------------------------------------------------------------------------------------------------------------
## Technology stack
``` text
Sql Server/Azure Data Services
C#
Ado.Net
```
----------------------------------------------------------------------------------------------------------------------------------------
## List Of Features
```text
1.User can able to create new Account(Signup).
2.User can able to Signin to Existing Account.
3.User should be able to add/modify/delete personal details (Location, fullname, gender).
4.User should be able to add/modify/delete skills
5.User should be able to add/modify/delete companies worked in past
6.ser should be able to add/modify/delete education background
7.User can abe to add/modify/delete Availabiities.
8.Exception handling
9.input validation
10.Logging (to a file not to a console)
```
----------------------------------------------------------------------------------------------------------------------------------------


## Project Flow
```text
At first need to check whether it is connected with the database or not and ensure about the connection string.

After the Console Application it will first show the options for Sign In and Sign Up.

It will validate with the trainer Email ID and Password, If its success it will allow to perform CRUD  operations if its failed it will return to the Sign In and ask for retry.

For Sign Up,if it will be a registered Email ID show Email is already Exist please Sign In please try again.

 User can also view his whole profile, he can also delete his account then he will be redirected to Welcome page .

```
--------------------------------------------------------------------------------------------------------------------------------------

## Future Enhancement


The extension of the project is going to add some filters using concept LINQ where user can able to find trainer based on Name , City etc.. & can able to find which  trainers are availabile on that particular day.


