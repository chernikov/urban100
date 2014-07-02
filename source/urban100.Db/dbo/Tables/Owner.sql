CREATE TABLE [dbo].[Owner]
(
	[ID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [SubTitle] NVARCHAR(150) NULL, 
    [Image] NVARCHAR(150) NULL, 
    [Twitter] NVARCHAR(150) NULL, 
    [Facebook] NVARCHAR(150) NULL, 
    [Google] NVARCHAR(250) NULL, 
    [Instagram] NVARCHAR(150) NULL, 
    [Skype] NVARCHAR(150) NULL,
	[Cell] INT NOT NULL, 
    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([ID] ASC)
)
