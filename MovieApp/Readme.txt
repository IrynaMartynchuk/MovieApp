Admin credentials:
user: per
password: hansen
url to deployed app: https://movieapplatest.azurewebsites.net/Home/ListMovies
the url does not work, since we do not have access to server now.

NOTE: We have noticed that it sometimes takes time to apply all changes to the deployed version (especially
for the functionalities in the Cart view - i.e. alert that pops out after confirming the order and remove
function).
At the time of delivery all the functionality on both deployed and local version were working correctly.

In order to log changes to the database the following script has to be run to the local database.
On the server solution this script has already been  applied.

CREATE TABLE [dbo].[Log] (
    [ID] [int] IDENTITY (1,1) NOT NULL,
    [User_Id] [nvarchar](100) NULL,
    [Create_Date] [datetime] NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED ([ID] ASC)
);

--CUSTOMER
CREATE TRIGGER customer_update 
ON [dbo].[Customer] AFTER UPDATE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.Id 
    FROM DELETED d;


CREATE TRIGGER customer_insert 
ON [dbo].[Customer] AFTER INSERT
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT i.Id 
    FROM INSERTED i;

CREATE TRIGGER customer_delete 
ON [dbo].[Customer] AFTER DELETE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.Id 
    FROM DELETED d;

--ORDER
CREATE TRIGGER order_update 
ON [dbo].[Order] AFTER UPDATE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.Id 
    FROM DELETED d;

CREATE TRIGGER order_insert 
ON [dbo].[Order] AFTER INSERT
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT i.Id 
    FROM INSERTED i;

CREATE TRIGGER order_delete 
ON [dbo].[Order] AFTER DELETE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.Id 
    FROM DELETED d;

--MOVIE
CREATE TRIGGER movie_update 
ON [dbo].[Movie] AFTER UPDATE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.Id 
    FROM DELETED d;


CREATE TRIGGER movie_insert 
ON [dbo].[Movie] AFTER INSERT
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT i.Id 
    FROM INSERTED i;

--ADMIN
CREATE TRIGGER admin_update 
ON [dbo].[dbAdmins] AFTER UPDATE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.AdminID 
    FROM DELETED d;


CREATE TRIGGER admin_insert 
ON [dbo].[dbAdmins] AFTER INSERT
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT i.AdminID
    FROM INSERTED i;

CREATE TRIGGER admin_delete 
ON [dbo].[dbAdmins] AFTER DELETE
AS 
    INSERT INTO [dbo].[Log] (User_Id)
    SELECT d.AdminID 
    FROM DELETED d;
