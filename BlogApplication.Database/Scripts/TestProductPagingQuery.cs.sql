USE ProductsDatabase
DECLARE @RowsPerPage int = 2
DECLARE	@PageNumber int=2
DECLARE @NameFilter varchar(50)= NULL --'MOUSE'
DECLARE @BEGINROWSET bigint=0
DECLARE @ENDROWSET bigint=0
SET @BEGINROWSET = ((@PageNumber-1)*@RowsPerPage)+1
SET @ENDROWSET = @PageNumber*@RowsPerPage
PRINT CONCAT('BEGINROWSET ',@BEGINROWSET, ' / ', 'ENDROWSET ',@ENDROWSET)
		;WITH CTE AS(
			SELECT P.Id, P.[Description], P.Price, C.[Description] AS CategoryDescription, ROW_NUMBER() OVER (ORDER BY P.Id) AS RowId  FROM DBO.Products P LEFT JOIN dbo.Category C ON P.Category_CategoryId = C.Id
			WHERE @NameFilter IS NULL OR P.[Description] like '%'+@NameFilter+'%'
		)
		

		SELECT [Description],Price, RowId, CategoryDescription FROM CTE WHERE RowId BETWEEN @BEGINROWSET AND @ENDROWSET
