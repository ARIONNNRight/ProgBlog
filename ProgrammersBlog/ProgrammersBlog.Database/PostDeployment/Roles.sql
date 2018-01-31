/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [ProgrammersBlog]
GO

Declare @IsExist bit
Select @IsExist =count (*) from [dbo].[Roles]
where [RoleName]='System Administrator' or [RoleName]='Default User'

if (@IsExist=0)
Begin
INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description]
           ,[Deleted])
     VALUES
           ('System Administrator'
		   ,'Allows users, Roles, and Permissions management'
           ,0),
		   ('Default User'
		   ,'Allows add Posts and Comments'
           ,0)
 end
GO


