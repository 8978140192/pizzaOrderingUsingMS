create database PizzaOrderOrderApi
use PizzaOrderOrderApi

create table Orders(
OrderId int identity(1,1) primary key,
UserId varchar(30) ,
DeliveryCharges float ,
TotalBill float ,
Quatity int,
OrderStatus varchar(20)
)

create table OrderDetails(
ItemId int identity(1,1) primary key,
PizzaId varchar(40) ,
OrderId int foreign key references Orders(orderId)
)

create table OrderToppingDetails(
itemId int foreign key references OrderDetails(itemId),
toppingId varchar(20) ,
primary key(itemId,toppingId)
)

select * from Orders
select * from OrderDetails
select * from OrderToppingDetails

DELETE FROM OrderToppingDetails WHERE toppingId=3;
DELETE FROM OrderDetails WHERE OrderId between 1 and 26;
DELETE FROM Orders WHERE OrderId between 1 and 26;