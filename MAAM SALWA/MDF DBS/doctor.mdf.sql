Create database hospital_management_system;
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
 
 Create table patient(P_ID int identity(1,1) Not Null, P_Name varchar(50) Null, P_Ph# varchar(50) Null, P_Address varchar(50) Null, P_Dis varchar(50) Null, Primary Key (P_ID));)