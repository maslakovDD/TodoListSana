create table category
(id int IDENTITY(1,1) not null primary key,
categoryName nvarchar(25) constraint categoryName_format check(categoryName like'[A-z]%'))



create table taskList
(id int IDENTITY(1,1) not null primary key,
listName nvarchar(25) constraint listName_format check(listName like '[A-z]%'),
categoryId int not null foreign key (categoryId) references dbo.category(id) on delete cascade on update no action)

create table task
(id int IDENTITY(1,1) not null primary key,
taskName nvarchar(25) constraint taskName_format check(taskName like'[A-z]%'),
listId int not null foreign key (listId) references dbo.taskList(id) on delete cascade on update no action,
dueDate date,
completed bit default 0)


insert into category
Values('Home'),('Sport'),('Education'),('Job')

insert into taskList
Values('Training', 2),('Homework', 3),('Cleaning', 1), ('JobTasks', 4)

insert into task
Values
('Run', 1, '2023-04-03',0),('Push-ups', 1, '2023-04-03',0),('Do abs', 1, '2023-04-03',0),
('English', 2, '2023-04-07',0),('Math', 2, '2023-04-05',0),('History', 2, '2023-04-08',0),
('Mop the floor', 3, '2023-04-04',0), ('Wash dishes', 3, '2023-04-03',0),('Vacuum cleaning', 3, '2023-04-04',0),
('First job task', 4, '2023-04-03',0),('Second job task', 4, '2023-04-03',0),('Third job task', 4, '2023-04-03',0)

select * from category
select * from taskList
select * from task


select task.taskName, task.dueDate, task.completed 
from task
inner join taskList on taskList.id = task.listId
inner join category on taskList.categoryId = category.id
where category.categoryName = 'Home'