CREATE DATABASE xsxx;  

USE xsxx;

DROP TABLE IF EXISTS SC       /*成绩*/
DROP TABLE IF EXISTS Student  /*学生信息*/
DROP TABLE IF EXISTS Course   /*课程*/
DROP TABLE IF EXISTS StudentUser  /*学生用户信息*/
DROP TABLE IF EXISTS Administrator  /*管理员用户信息*/
DROP TABLE IF EXISTS SysLog   /*注册日志*/
DROP TABLE IF EXISTS SysLog1   /*登陆日志*/

CREATE TABLE StudentUser          
 (	
 ID NCHAR(20) PRIMARY KEY,               /*学号*/  
 PassWord NCHAR(32) ,					/*密码*/
 Sex CHAR(2) ,							/*性别*/
 StudentBirthday datetime,				/*生日*/
 UserMobile NCHAR(11),					/*电话号码*/
 UserPhoto image						/*照片*/
 ); 
 CREATE TABLE Administrator          
 (	
 ID NCHAR(20) PRIMARY KEY,               /*工号*/  
 PassWord NCHAR(32) ,             /*密码*/
 Sex CHAR(2),							/*性别*/
 StudentBirthday datetime,				/*生日*/
 UserMobile NCHAR(11),					/*电话号码*/
 UserPhoto image						/*照片*/
 );

 CREATE TABLE SysLog          
 (	
 UserID NCHAR(20) ,  /*id*/
 dentity CHAR(20),  /*学生或管理员*/
 DateAndTime datetime,  /*注册时间*/
 UserOperation NCHAR(200)  /*操作方式*/
 ); 
CREATE TABLE SysLog1          
 (	
 UserID NCHAR(20) ,  /*id*/
 dentity CHAR(20),  /*学生或管理员*/
 DateAndTime datetime,  /*登陆时间*/
 UserOperation NCHAR(200)  /*登陆操作方式*/
 );

CREATE TABLE Student          
 (	
 Sno CHAR(9) PRIMARY KEY,        /* 列级完整性约束条件,Sno是主码*/                  
 Sname CHAR(20) UNIQUE,             /* Sname取唯一值*/
 Ssex CHAR(2),					/*性别*/
 Sage SMALLINT,					/*年龄*/
 Sdept CHAR(20)					/*专业*/
 ); 

CREATE TABLE  Course
 (	
 Cno CHAR(4) PRIMARY KEY,
 Cname CHAR(40),            
 Cpno CHAR(4),               	                      
 Ccredit SMALLINT,
 FOREIGN KEY (Cpno) REFERENCES  Course(Cno) 
 ); 

CREATE TABLE  SC
 (
 Sno CHAR(9), 
 Cno CHAR(4),  
 Grade SMALLINT,
 PRIMARY KEY (Sno,Cno),                     /* 主码由两个属性构成，必须作为表级完整性进行定义*/
 FOREIGN KEY (Sno) REFERENCES Student(Sno),  /* 表级完整性约束条件，Sno是外码，被参照表是Student */
 FOREIGN KEY (Cno)REFERENCES Course(Cno)     /* 表级完整性约束条件， Cno是外码，被参照表是Course*/
 ); 

INSERT  INTO  StudentUser VALUES ('20181101111','123456','女',1999-1-1,'13812345678',NULL);
INSERT  INTO  Administrator VALUES ('2018110',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32),'女',1989-1-1,'13812345687',NULL);
INSERT  INTO  Administrator VALUES ('2018111',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32),'女',1989-2-1,'13812655687',NULL);


INSERT  INTO  Student (Sno,Sname,Ssex,Sdept,Sage) VALUES ('201215121','李勇','男','CS',20);
INSERT  INTO  Student (Sno,Sname,Ssex,Sdept,Sage) VALUES ('201215122','刘晨','女','CS',19);
INSERT  INTO  Student (Sno,Sname,Ssex,Sdept,Sage) VALUES ('201215123','王敏','女','MA',18);
INSERT  INTO  Student (Sno,Sname,Ssex,Sdept,Sage) VALUES ('201215125','张立','男','IS',19);
INSERT  INTO  Student (Sno,Sname,Ssex,Sdept,Sage) VALUES ('201215128','陈冬','男','IS',20);

SELECT * FROM Student

INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('1','数据库',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('2','数学',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('3','信息系统',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('4','操作系统',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('5','数据结构',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('6','数据处理',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('7','Pascal语言',NULL,4);

UPDATE Course SET Cpno = '5' WHERE Cno = '1' 
UPDATE Course SET Cpno = '1' WHERE Cno = '3' 
UPDATE Course SET Cpno = '6' WHERE Cno = '4' 
UPDATE Course SET Cpno = '7' WHERE Cno = '5' 
UPDATE Course SET Cpno = '6' WHERE Cno = '7' 

SELECT * FROM Course

INSERT  INTO SC(Sno,Cno,Grade) VALUES ('201215121 ','1',92);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('201215121 ','2',85);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('201215121 ','3',88);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('201215122 ','2',90);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('201215122 ','3',80);

SELECT * FROM SC

-- 当管理员信息更新，触发器启动，将更新的内容存至注册日志
IF(OBJECT_ID('regist_recorder1') is not null)        -- 判断名为 regist_recorder 的触发器是否存在
DROP TRIGGER regist_recorder1        -- 删除触发器
GO
CREATE TRIGGER regist_recorder1
ON StudentUser  	         
AFTER
INSERT
AS 
	declare @UserName    nchar(20)
	declare @DateTime    datetime
	declare @UserOperation nchar(200)
	declare @dentity CHAR(20)

	select @UserName = ID FROM StudentUser
	select @DateTime = CONVERT(datetime,GETDATE(),120) 
	select @dentity ='StudentUser'

	declare @op varchar(10)
	select @op=case when exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Update'
                   when exists(select 1 from inserted) and not exists(select 1 from deleted)
                   then 'Insert'
                   when not exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Delete' end
                   
	
	select @UserOperation = @op
	

	INSERT INTO SysLog(UserID,dentity,DateAndTime,UserOperation)
	VALUES (@UserName,@dentity,@DateTime,@UserOperation)

-- 当管理员信息更新，触发器启动，将更新的内容存至注册日志
IF(OBJECT_ID('regist_recorder2') is not null)        -- 判断名为 regist_recorder 的触发器是否存在
DROP TRIGGER regist_recorder2        -- 删除触发器
GO
CREATE TRIGGER regist_recorder2
ON Administrator  	         
AFTER
INSERT
AS 
	declare @UserName    nchar(20)
	declare @DateTime    datetime
	declare @UserOperation nchar(200)
	declare @dentity CHAR(20)

	select @UserName = ID FROM Administrator
	select @DateTime = CONVERT(datetime,GETDATE(),120) 
	select @dentity ='Administrator'

	declare @op varchar(10)
	select @op=case when exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Update'
                   when exists(select 1 from inserted) and not exists(select 1 from deleted)
                   then 'Insert'
                   when not exists(select 1 from inserted) and exists(select 1 from deleted)
                   then 'Delete' end
                   
	
	select @UserOperation = @op
	

	INSERT INTO SysLog(UserID,dentity,DateAndTime,UserOperation)
	VALUES (@UserName,@dentity,@DateTime,@UserOperation)


-- 建一个表存储各科平均分
CREATE TABLE AVG
	(
		Cname CHAR(10),   /* 科目*/	
		avg INT
	);
INSERT  INTO AVG(Cname,avg)	VALUES ('数据库',NULL);
INSERT  INTO AVG(Cname,avg)	VALUES ('数学',NULL);
INSERT  INTO AVG(Cname,avg)	VALUES ('信息系统',NULL);
INSERT  INTO AVG(Cname,avg)	VALUES ('操作系统',NULL);
INSERT  INTO AVG(Cname,avg)	VALUES ('数据结构',NULL);
INSERT  INTO AVG(Cname,avg)	VALUES ('数据处理',NULL);
INSERT  INTO AVG(Cname,avg)	VALUES ('Pascal语言',NULL);

-- 将成绩信息通过下列存储过程算出各科平均分并存储至AVG表
IF (exists (select * from sys.objects where name = 'COURSE_AVG'))
DROP PROCEDURE COURSE_AVG
GO
CREATE  PROCEDURE COURSE_AVG
AS
BEGIN TRANSACTION TRANS  
DECLARE 
	@SX INT,    /* 数学总分 */
	@XXXT INT,    /* 信息系统总分 */
	@CZXT INT,    /* 操作系统总分 */
	@SJJG INT,    /* 数据结构总分 */
	@SJK_C INT,   /* 数据库总分 */
	@SJCL INT,   /*数据处理总分*/
	@P INT       /*Pascal语言*/
SELECT @SX=AVG(Grade) FROM SC
					WHERE  Cno='2 '

SELECT @XXXT=AVG(Grade) FROM SC
					WHERE  Cno='3'

SELECT @CZXT=AVG(Grade) FROM SC
					WHERE  Cno='4'

SELECT @SJJG=AVG(Grade) FROM SC
					WHERE  Cno='5'

SELECT @SJK_C=AVG(Grade) FROM SC
					WHERE  Cno='1'
SELECT @SJCL=AVG(Grade) FROM SC
					WHERE  Cno='6'
SELECT @P=AVG(Grade) FROM SC
					WHERE  Cno='7'
BEGIN 
UPDATE AVG SET avg=@SJK_C WHERE Cname='数据库'
UPDATE AVG SET avg=@SX WHERE Cname='数学'
UPDATE AVG SET avg=@XXXT WHERE Cname='信息系统'
UPDATE AVG SET avg=@CZXT WHERE Cname='操作系统'
UPDATE AVG SET avg=@SJJG WHERE Cname='数据结构'
UPDATE AVG SET avg=@SJCL WHERE Cname='数据处理'
UPDATE AVG SET avg=@P WHERE Cname='Pascal语言'
COMMIT TRANSACTION TRANS; 
END
