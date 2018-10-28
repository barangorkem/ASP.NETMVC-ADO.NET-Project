CREATE PROCEDURE postCategoriesListDetails(@PostId int)
AS
BEGIN
SELECT DISTINCT p.PostId,p.PostTitle,p.PostContent,c.CategoryId,c.CategoryName FROM PostCategories pc JOIN Posts p ON p.PostId=pc.PostId  JOIN Categories c ON pc.CategoryId=c.CategoryId  WHERE pc.PostId=@PostId;
END

