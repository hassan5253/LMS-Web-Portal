create database READB;
use READB;
create table tblUsers
(
user_id bigint identity(100,1) primary key,
name varchar(50),
user_type varchar(10),
course_name varchar(20),
batch_no varchar(50),
course_year varchar(5),
course_semester varchar(20),
student_roll_no AS ('rea-'+CONVERT([varchar],[user_id],(0))),   
user_name varchar(20),
user_password varchar(20),
user_status varchar(6)
);

create table tblAssignments
(
a_id bigint identity(10000,1) primary key,	
a_name varchar(50),
a_description varchar(100),
a_file_name varchar(100),
course_name varchar(20),
batch_no varchar(50),
course_year varchar(5),
course_semester varchar(20),
a_assigned_by varchar(50),
user_id bigint foreign key references tblusers(user_id),  --e. Assignment Assigned by [Staff]
a_assigned_date datetime,
a_submit_date datetime
); 

create table tblAssignmentDetails
(
ad_id bigint identity(10000,1) primary key,
a_id bigint foreign key references tblassignments(a_id) on delete cascade,
user_id bigint foreign key references tblusers(user_id) ,  -- e.g assignment uplaoded by [student]
student_roll_no varchar(100),
a_file_name varchar(100),
ad_uploaded_date datetime,               
ad_marks decimal(6,2)
);                  
create table tblQueries
(
q_id bigint identity(10000,1) primary key,
q_parent_id bigint,
user_id bigint foreign key references tblusers(user_id) on delete cascade,  -- it can be staff, student or admin 
q_description varchar(200),
q_date datetime,
);

create table tblFaqs
(
f_id int identity(1,1) primary key,
f_parent_id int,
f_description text,
);

-----------MAKING ADMIN-------
insert into tblusers(name,user_type,user_name,user_password,user_status) values('Raza','Admin','Admin','Admin','true');
-----------MAKING ADMIN-------

select * from tblUsers
select * from tblAssignments
select * from tblAssignmentDetails
select * from tblQueries
select * from tblFaqs



