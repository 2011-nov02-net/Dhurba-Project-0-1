create table Products(
ID       int         not null   primary key,
Name     nvarchar(40) not null,
Price     decimal(20,5) not null
)
insert into Products values
(1,'apple',1.5),(2,'orange',1.7),(3,'mango',1.8)

insert into Products values
(4,'iphone',200)

create table Customers(
ID       int      not null    primary key,
firstName nvarchar(40) not null,
lastName   nvarchar(40)  not null,
CardNumber  float         not null
)
insert into Customers values
(1,'dhurba','ghimire',123456784),
(2,'matt','damon',123456789),
(3,'robert','song', 46789378)
--------------------------------------3
insert into Customer values
(4,'Tina','Smith',78906543)



create table Orders(
ID       int       not null   primary key,
ProductID     int  not null foreign key references Products.ID,
CustomerID    int  not null foreign key references Customers.ID
)



insert into Orders values
(1,1,1),
(2,1,1),
(3,2,2)
---------------------------4
insert into Orders values
(4,4,4)
------------------------5
select p.name,p.price
from Customer as c
inner join orders as o on c.customerId=o.custoerid
inner join products as p on p.productid=o.productid
where c.firstname='tina' and c.lastname='smith';

---------------------6
select sum(p.price)
from orders as o
left join products as p on o.productid=p.productid
group by p.price