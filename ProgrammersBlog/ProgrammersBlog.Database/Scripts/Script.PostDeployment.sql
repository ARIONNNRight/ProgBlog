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


INSERT INTO [dbo].[User]
           ([UserName]
           ,[Email]
           ,[Password]
           ,[BirthDay]
           ,[Avatar]
           ,[FirstName]
           ,[LastName]
           ,[Inactive])
SELECT		'Publisher'
           ,'publisher@pblog.com'
           ,'12345'
           ,GETDATE()
           ,NULL
           ,'Publisher'
           ,'Smith'
           ,0
WHERE NOT EXISTS ( SELECT * FROM [User] WHERE UserName = 'Publisher')

GO

USE [ProgrammersBlog]
GO

INSERT INTO [dbo].[Post]
           ([Title]
           ,[Body]
           ,[Deleted]
           ,[UserId])
SELECT
           'MOLDOVA IT PARK – primul parc IT din Republica Moldova'
           ,'Scopul principal al inițiativei este crearea premiselor necesare pentru impulsionarea dezvoltării industriei tehnologiei informației, prin crearea noilor locuri de muncă şi atragerea de investiţii autohtone şi străine.'
           ,0
           ,2
WHERE NOT EXISTS ( SELECT * FROM [Post] WHERE [Title] = 'MOLDOVA IT PARK – primul parc IT din Republica Moldova')
GO

USE [ProgrammersBlog]
GO

INSERT INTO [dbo].[Comment]
           ([Body]
           ,[PostId]
           ,[Deleted]
           ,[UserId])
SELECT
           'Awesome!!! Ut nec interdum libero. Sed felis lorem, venenatis sed malesuada vitae, tempor vel turpis. Mauris in dui velit, vitae mollis risus. Cras lacinia lorem sit amet augue mattis vel cursus enim laoreet. Vestibulum faucibus scelerisque nisi vel sodales. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pellentesque massa ac justo tempor eu pretium massa accumsan. In pharetra mattis mi et ultricies. Nunc vel eleifend augue. Donec venenatis egestas iaculis.'
           ,1
           ,0
           ,2
WHERE NOT EXISTS ( SELECT * FROM [Comment] WHERE [Body] LIKE 'Awesome!!!%')
GO

USE [ProgrammersBlog]
GO

INSERT INTO [dbo].[Reply]
           ([Body]
           ,[Deleted]
           ,[ParentReplyId]
           ,[UserId]
           ,[CommentId])
SELECT
           'This is reply to the comment'
           ,0
           ,NULL
           ,2
           ,1
WHERE NOT EXISTS ( SELECT * FROM [Reply] WHERE [Body] = 'This is reply to the comment')
GO

USE [ProgrammersBlog]
GO

INSERT INTO [dbo].[Reply]
           ([Body]
           ,[Deleted]
           ,[ParentReplyId]
           ,[UserId]
           ,[CommentId])
SELECT
           'Good news, everyone!'
           ,0
           ,1
           ,2
           ,NULL
WHERE NOT EXISTS ( SELECT * FROM [Reply] WHERE [Body] = 'Good news, everyone!')
GO