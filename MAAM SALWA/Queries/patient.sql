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