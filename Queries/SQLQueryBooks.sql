-- Пример извлечения связанных данных по книгам при помощи JOIN
SELECT A.FirstName + ' ' + A.LastName AS 'Автор',
	   B.Title AS 'Название', B.Price AS 'Цена',
	   B.YearPublish AS 'Год публикации',
	   C.Title AS 'Категория'
FROM Books AS B JOIN AuthorBook AS AB
ON AB.BooksId = B.Id JOIN Authors AS A
ON AB.AuthorsId = A.Id JOIN BookCategory AS BC
ON BC.BooksId = B.Id JOIN Categories AS C
ON C.Id = BC.CategoriesId
