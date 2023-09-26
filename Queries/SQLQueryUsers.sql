SELECT * FROM Roles

INSERT INTO Roles VALUES ('Admin', 0)
INSERT INTO Roles VALUES ('User1', 99)


SELECT * FROM Users

INSERT INTO Users VALUES ('Администратор', '+79271112233', 'admin@mail.net', 1, '123456')
INSERT INTO Users VALUES ('Иванов Иван', '+79272223344', 'ivanov@mail.net', 1, '654321')
UPDATE Users SET FullName=N'Иванов Иван' WHERE id=2