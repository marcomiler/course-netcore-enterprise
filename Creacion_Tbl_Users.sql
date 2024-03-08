--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Users](
--	[UserID] INT NOT NULL,
--	[FirstName] VARCHAR(50) NOT NULL,
--	[LastName] VARCHAR(50) NOT NULL,
--	[UserName] VARCHAR(50) NOT NULL,
--	[Password] VARCHAR(50) NOT NULL

--	CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED
--	(
--		[UserID] ASC
--	) WITH (
--		PAD_INDEX = OFF,
--		STATISTICS_NORECOMPUTE = OFF,
--		IGNORE_DUP_KEY = OFF,
--		ALLOW_ROW_LOCKS = ON,
--		ALLOW_PAGE_LOCKS = ON
--	) ON [PRIMARY]
--)
--GO

--INSERT INTO [dbo].[Users]
--(
--	UserID,
--	FirstName,
--	LastName,
--	UserName,
--	[Password]
--) VALUES
--(
--	1,
--	'ALEX',
--	'ESPEJO',
--	'AESPEJO',
--	'123456'
--)
--GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersGetByUserAndPassword]
	@UserName VARCHAR(50),
	@Password VARCHAR(50)
AS
BEGIN
	SELECT
		UserID,
		FirstName,
		LastName,
		UserName,
		NULL AS [Password]
	FROM [Users]
	WHERE UserName = @UserName
	AND [Password] = @Password
END
GO

EXEC [dbo].[UsersGetByUserAndPassword] 'AESPEJO', '123456'