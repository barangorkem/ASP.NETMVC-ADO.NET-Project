CREATE TABLE PostCategories(
PostCategoriesId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
CategoryId int NOT NULL,
PostId INT NOT NULL,
CONSTRAINT postcategories_categoryid_fk FOREIGN KEY(CategoryId) REFERENCES Categories(CategoryId),
CONSTRAINT postcategories_PostId_fk FOREIGN KEY(PostId) REFERENCES Posts(PostId)

)