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

INSERT INTO [user]
VALUES
	(1, 'John Paulo Santos', 'jsantos', 'jsantos'),
	(2, 'Nicole Reyes', 'nreyes', 'nreyes')
GO

INSERT INTO [recipe]
VALUES
	(1, 'Grilled Cheese', 1),
	(2, 'Pasta Salad', 1),
	(3, 'Cake', 2),
	(4, 'Macarons', 2)
GO

INSERT INTO [ingredient]
VALUES
	(1, 1, 'Bread', 0, 1),
	(2, 1, 'Butter', 0, 1),
	(3, 1, 'Cheese', 0, 1),

	(4, 2, 'Chilled Pasta', 0, 1),
	(5, 2, 'Vinegar', 0, 1),
	(6, 2, 'Oil', 0, 1),
	
	(7, 3, 'Sugar', 0, 2),
	(8, 3, 'Butter', 0, 2),
	(9, 3, 'Flour', 0, 2),
	(10, 3, 'Eggs', 0, 2),
	(11, 3, 'Vanilla Extract', 0, 2),
	(12, 3, 'Milk', 0, 2),
	(13, 3, 'Baking Powder', 0, 2),

	(14, 4, 'Eggs', 0, 2),
	(15, 4, 'Confectioners Sugar', 0, 2),
	(16, 4, 'Almond Flour', 0, 2),
	(17, 4, 'Salt', 0, 2),
	(18, 4, 'Castor Sugar', 0, 2)
GO
