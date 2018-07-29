Create database hospital_management_system;
/* Doctor ka table*/
create table doctor(Doctor_ID int identity(1,1) Not Null, Doctor_Name varchar(50) Null, Contact_No varchar(50) Null, Doctor_Address varchar(50) Null, Doctor_Designation varchar(50) Null, Primary Key (Doctor_ID));
create table doc_material(Doctor_Name varchar(50) Null, Contact_No varchar(50) Null, Doctor_Address varchar(50) Null, Doctor_Designation varchar(50) Null);
insert into doc_material(Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation)values('DR.LINTA','032548','ABC AREA','SERGEON');
insert into doc_material(Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation)values('DR.ANEES','321328','GULBERG','PHYSICIAN');
insert into doc_material(Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation)values('DR.LINTA','215450','FC AREA','CHILD SPECIALIST');
insert into doc_material(Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation)values('DR.LINTA','778425','NAGAN','GENERAL PHYSICIAN');
insert into doc_material(Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation)values('DR.LINTA','878206','GULSHANE HADEED','SERGEON');
insert into doc_material(Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation)values('DR.LINTA','787451','SAFORA','HEART SPECIALIST');


INSERT INTO doctor (Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation) 
Select Doctor_Name,Contact_No,Doctor_Address,Doctor_Designation from doc_material;

/*ab patient ka table*/
 
 Create table patient(Patient_ID int identity(1,1) Not Null, P_Name varchar(50) Null, P_Address varchar(50) Null, Sex varchar (50)NUll,Age varchar(50)Null,AdmitDate varchar(50) Null,DischargeDate varchar(50) Null, Primary Key (Patient_ID));
 create table p_material(P_Name varchar(50) Null, P_Address varchar(50) Null, Sex varchar (50)NUll,Age varchar(50)Null,AdmitDate varchar(50) Null,DischargeDate varchar(50) Null);
 insert into p_material (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate)values('Tahir','abc','Male','17','1/1/2016','5/1/2016');
 insert into p_material (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate)values('Abid','xyz','Male','11','11/1/2016','25/1/2016');
 insert into p_material (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate)values('Nasia','gef','Female','27','21/1/2016','31/1/2016');
 insert into p_material (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate)values('Hira','aaa','Female','32','12/1/2016','15/1/2016');
 insert into p_material (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate)values('Saim Ullah','ddd','Male','91','1/9/2016','15/9/2016');
 insert into p_material (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate)values('Ali','ghi','Male','52','6/8/2016','7/8/2016');
 
 INSERT INTO patient (P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate) 
Select P_Name,P_Address,Sex,Age,AdmitDate,DischargeDate from p_material;


/* Employee ka table */
create table employee(Employee_ID int identity(1,1) Not Null, Emp_Name varchar(50) Null, Sex varchar(50) Null, Emp_Salary varchar(50) Null, Emp_Qualification varchar(50) Null, Emp_Contact varchar(50) Null)
 ALTER TABLE employee ADD Designation varchar(50)
create table emp_material(Emp_Name varchar(50) Null, Sex varchar(50) Null, Emp_Salary varchar(50) Null, Emp_Qualification varchar(50) Null, Emp_Contact varchar(50) Null);
 ALTER TABLE emp_material ADD Designation varchar(50)
insert into emp_material(Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation)values('Zehra Bano','Female','15000','Inter','65451425','Nurse');
insert into emp_material(Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation)values('Hassan','Male','25000','BA','0242577','Lab Assistant');
insert into emp_material(Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation)values('Zahida Afzal','Female','18000','BSc','2142577','Receptionist');
insert into emp_material(Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation)values('Kanwal Ashar','Female','25000','BCom','0741065','Lab Assistant');
insert into emp_material(Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation)values('John','Male','12000','BA','0884220','Machine Incharge');
insert into emp_material(Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation)values('Abid','Male','27000','BTec','025421','Machine Operator');

 INSERT INTO employee (Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation) 
Select Emp_Name,Sex,Emp_Salary,Emp_Qualification,Emp_Contact,Designation from emp_material;

/* bill*/
create table bill(id int identity(1,1) Not Null, Name_Patient varchar(50)Null, Cost varchar(50)Null);
create table B_cost(cost varchar(50)Null)
insert into B_cost(cost,Name_Patient)values('2800','Tahir');
insert into B_cost(cost ,Name_Patient)values('500','Abid');
insert into B_cost(cost ,Name_Patient)values('32,000','Nasia');
insert into B_cost(cost,Name_Patient)values('1700','Hira');
insert into B_cost(cost,Name_Patient)values('72,000','Saim Ullah');
insert into B_cost(cost,Name_Patient)values('9000','Ali'); 

Alter table B_cost ADD Name_Patient varchar(50)Null
delete from B_cost;

 INSERT INTO Bill (Name_Patient,Cost) 
Select cost, Name_Patient from B_cost;


/* Room */
Create Table Room(Room_id int identity(1,1) Not Null, Room_Type varchar(50)Null);
Insert into Room (Room_Type)values('Semi Private');
Insert into Room (Room_Type)values('Private');
Insert into Room (Room_Type)values('Private');
Insert into Room (Room_Type)values('VIP Suite');
Insert into Room (Room_Type)values('Intensive Care Unit');
Insert into Room (Room_Type)values('Isolation Room');

/* Patient Diagnosed Table */
Create table PDT(Diagnose_No int identity(1,1) Not Null, Diagnose_Details varchar(50)Null,Performance_Remarks varchar(50)Null,Patient_ID varchar(50)Null,Primary Key (Diagnose_No));
insert into PDT(Diagnose_Details,Performance_Remarks,Patient_ID)values('Fever','Good','5');
insert into PDT(Diagnose_Details,Performance_Remarks,Patient_ID)values('Heart Attack','Critical','2');
insert into PDT(Diagnose_Details,Performance_Remarks,Patient_ID)values('Asthma','Better','4');
insert into PDT(Diagnose_Details,Performance_Remarks,Patient_ID)values('Fits','Critical','3');
insert into PDT(Diagnose_Details,Performance_Remarks,Patient_ID)values('Flu','Normal','1');


