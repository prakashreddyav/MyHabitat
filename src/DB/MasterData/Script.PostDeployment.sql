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

--Relations
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (1,'Mother','F')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (2,'Father','M')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (3,'Husband','M')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (4,'Wife','F')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (5,'Daughter','F')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (6,'Son','M')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (7,'Brother','M')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (8,'Sister','F')
INSERT INTO [dbo].[Relations] ([RelationId],[RelationName],[RelationGender]) VALUES (9,'Friend',null)
--Gender
INSERT INTO [dbo].[Gender] ([GenderCode],[GenderName]) VALUES ('M','Male')
INSERT INTO [dbo].[Gender] ([GenderCode],[GenderName]) VALUES ('F','Female')
--ReverseRelation
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (1,'M',6)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (2,'M',6)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (4,'M',3)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (5,'M',2)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (6,'M',2)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (7,'M',7)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (8,'M',7)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (9,'M',9)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (1,'F',5)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (2,'F',5)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (3,'F',4)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (5,'F',1)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (6,'F',1)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (7,'F',8)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (8,'F',8)
INSERT INTO [dbo].[ReverseRelation] ([RelationID],[SourceGenderCode],[ReverseRelationID]) VALUES (9,'F',9)