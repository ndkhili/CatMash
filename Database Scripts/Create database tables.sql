
if exists ( select 1 from sysobjects where id = OBJECT_ID('Votes') and type = 'U')
drop table Votes
Go


if exists ( select 1 from sysobjects where id = OBJECT_ID('Cats') and type = 'U')
drop table Cats
Go


CREATE TABLE [Cats] (
    [CatId] INT NOT NULL IDENTITY,
    [Url] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY ([CatId]),
);
GO

CREATE TABLE [Votes] (
    [VoteId] int NOT NULL IDENTITY,
    [WinCatId] int NOT NULL,
	[LostCatId] int NOT NULL,
    [CreationDate] datetime NULL
    CONSTRAINT [PK_Vote] PRIMARY KEY ([VoteId]),
    CONSTRAINT [FK_Vote_WinCat_CatId] FOREIGN KEY ([WinCatId]) REFERENCES [Cats] ([CatId]),
	CONSTRAINT [FK_Vote_LostCat_CatId] FOREIGN KEY ([LostCatId]) REFERENCES [Cats] ([CatId])
);
GO