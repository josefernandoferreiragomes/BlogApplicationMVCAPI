CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NCHAR(50) NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    [Category_CategoryId] INT NULL, 
    CONSTRAINT [FK_Products_ToTable] FOREIGN KEY ([Category_CategoryId]) REFERENCES [Category]([Id])
)
