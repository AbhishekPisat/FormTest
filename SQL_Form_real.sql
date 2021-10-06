create database registrations
use registrations

create table Employee
( 
First_Name varchar(20),
Last_Name varchar(20),
Email_add varchar(50),
Conts varchar(10),
show_year varchar(5),
Gender varchar(20)
)

select * from Employee

insert into Employee values
('Abhi','pisat','abhishekpisat@gmail.com','9167359402','25','male') 

drop Table Employee