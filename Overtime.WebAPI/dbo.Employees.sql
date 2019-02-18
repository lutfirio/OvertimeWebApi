CREATE TABLE [dbo].[Employees] (
    [Id]           INT                IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (MAX)     NULL,
    [Password]     NVARCHAR (MAX)     NULL,
    [First_Name]   NVARCHAR (MAX)     NULL,
    [Last_Name]    NVARCHAR (MAX)     NULL,
    [Address]      NVARCHAR (MAX)     NULL,
    [Postal_Code]  NVARCHAR (MAX)     NULL,
    [Salary]       INT                NOT NULL,
    [Phone]        NVARCHAR (MAX)     NULL,
    [Question]     NVARCHAR (MAX)     NULL,
    [Answer]       NVARCHAR (MAX)     NULL,
    [CreateDate]   DATETIMEOFFSET (7) NOT NULL,
    [UpdateDate]   DATETIMEOFFSET (7) NOT NULL,
    [DeleteDate]   DATETIMEOFFSET (7) NOT NULL,
    [IsDelete]     BIT                NOT NULL,
    [Positions_Id] INT                NULL,
    [Managers_Id]  INT                NULL,
    [Villages_Id]  INT                NULL,
    CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Employees_dbo.Positions_Positions_Id] FOREIGN KEY ([Positions_Id]) REFERENCES [dbo].[Positions] ([Id]),
    CONSTRAINT [FK_dbo.Employees_dbo.Employees_Managers_Id] FOREIGN KEY ([Managers_Id]) REFERENCES [dbo].[Employees] ([Id]),
    CONSTRAINT [FK_dbo.Employees_dbo.Villages_Villages_Id] FOREIGN KEY ([Villages_Id]) REFERENCES [dbo].[Villages] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Villages_Id]
    ON [dbo].[Employees]([Villages_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Positions_Id]
    ON [dbo].[Employees]([Positions_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Managers_Id]
    ON [dbo].[Employees]([Managers_Id] ASC);


