CREATE PROCEDURE [dbo].[SpGetPageOfProducts]
	@RowsPerPage int = 0,
	@PageNumber int=0,
	@NameFilter varchar(50)=NULL
AS
	BEGIN
		DECLARE @BEGINROWSET bigint=0
		DECLARE @ENDROWSET bigint=0
		SET @BEGINROWSET = ((@PageNumber-1)*@RowsPerPage)+1
		SET @ENDROWSET = @PageNumber*@RowsPerPage
		;WITH CTE AS(
			SELECT P.Id, P.[Description], P.Price, C.[Description] AS CategoryDescription, ROW_NUMBER() OVER (ORDER BY P.Id) AS RowId  FROM DBO.Products P LEFT JOIN dbo.Category C ON P.Category_CategoryId = C.Id
			WHERE @NameFilter IS NULL OR P.[Description] like '%'+@NameFilter+'%'
		)
		SELECT Id, [Description],Price, RowId FROM CTE WHERE RowId BETWEEN @BEGINROWSET AND @ENDROWSET
	END
RETURN 0
