﻿CREATE TABLE [dbo].[Candidate]
(
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR(150) NOT NULL,
	[Phone] NVARCHAR(50) NULL,  
	[Email] NVARCHAR(50) NULL,  
	[Notes] NVARCHAR(MAX) NULL,  
	CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED ([ID] ASC)
)
