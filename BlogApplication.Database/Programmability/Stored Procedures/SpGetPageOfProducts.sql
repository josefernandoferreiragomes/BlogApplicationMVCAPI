CREATE PROCEDURE [dbo].[SpGetPageOfProducts]
	@RowsPerPage int = 0,
	@PageNumber int=0,
	@NameFilter varchar(50)=''
AS
	SELECT * FROM Products
RETURN 0
