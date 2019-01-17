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
SET IDENTITY_INSERT [dbo].[user] ON
INSERT INTO [user]
	([id], [name], [username], [password])
VALUES
	(1, 'John Paulo Santos', 'jsantos', 'jsantos'),
	(2, 'Nicole Reyes', 'nreyes', 'nreyes')
GO
SET IDENTITY_INSERT [dbo].[user] OFF



SET IDENTITY_INSERT [dbo].[recipe] ON
GO

INSERT INTO [recipe]
	([id], [name], [user_id])
VALUES
	(1, 'Grilled Cheese', 1),
	(2, 'Pasta Salad', 1),
	(3, 'Cake', 2),
	(4, 'Macarons', 2)
GO
SET IDENTITY_INSERT [dbo].[recipe] OFF
GO



INSERT INTO [ingredient]
	([recipe_id], [name], [is_checked], [user_id])
VALUES
	(1, 'Bread', 0, 1),
	(1, 'Butter', 0, 1),
	(1, 'Cheese', 0, 1),

	(2, 'Chilled Pasta', 0, 1),
	(2, 'Vinegar', 0, 1),
	(2, 'Oil', 0, 1),
	
	(3, 'Sugar', 0, 2),
	(3, 'Butter', 0, 2),
	(3, 'Flour', 0, 2),
	(3, 'Eggs', 0, 2),
	(3, 'Vanilla Extract', 0, 2),
	(3, 'Milk', 0, 2),
	(3, 'Baking Powder', 0, 2),

	(4, 'Eggs', 0, 2),
	(4, 'Confectioners Sugar', 0, 2),
	(4, 'Almond Flour', 0, 2),
	(4, 'Salt', 0, 2),
	(4, 'Castor Sugar', 0, 2)
GO
