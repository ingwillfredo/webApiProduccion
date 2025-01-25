--Script para crear base de datos ResenaLibros

Create database DBBookReview

Use DBBookReview

Create Table Authors(
Id_Author Int Primary Key Identity,
Name_Author Varchar(150),
Status_Author Bit,
Author_Creation_Date DateTime
);

Insert Into Authors
Values
('Harper Lee', 1, GETDATE()),
('George Orwell', 1, GETDATE()),
('Gabriel García Márquez', 1, GETDATE()),
('F. Scott Fitzgerald', 1, GETDATE()),
('Jane Austen', 1, GETDATE()),
('Suzanne Collins', 1, GETDATE()),
('J.K. Rowling', 1, GETDATE()),
('Dan Brown', 1, GETDATE()),
('Viktor Frankl', 1, GETDATE()),
('Franz Kafka', 1, GETDATE()),
('Ildefonso Falcones', 1, GETDATE()),
('Paulo Coelho', 1, GETDATE()),
('Stephen King', 1, GETDATE()),
('Yuval Noah Harari', 1, GETDATE()),
('Oscar Wilde', 1, GETDATE()),
('C.S. Lewis', 1, GETDATE()),
('Umberto Eco', 1, GETDATE()),
('Ariana Godoy', 1, GETDATE()),
('Carlos Ruiz Zafón', 1, GETDATE()),
('Roberto Ampuero', 1, GETDATE()),
('Héctor Abad Faciolince', 1, GETDATE()),
('Laura Restrepo', 1, GETDATE()),
('Andrés Caicedo', 1, GETDATE());

Create Table Genres (
Id_Genre Int Primary Key Identity,
Name_Genre Varchar(150),
Status_Genre Bit,
Genre_Creation_Date DateTime
);


Insert Into Genres
Values
('Ficción', 1, GETDATE()),
('Distopía', 1, GETDATE()),
('Realismo Mágico', 1, GETDATE()),
('Religioso', 1, GETDATE()),
('Romance', 1, GETDATE()),
('Ciencia Ficción', 1, GETDATE()),
('Fantasía', 1, GETDATE()),
('Misterio', 1, GETDATE()),
('No Ficción', 1, GETDATE()),
('Histórico', 1, GETDATE()),
('Fantasía', 1, GETDATE()),
('Horror', 1, GETDATE()),
('Ensayo', 1, GETDATE()),
('Clásico', 1, GETDATE()),
('Fantasía Infantil', 1, GETDATE()),
('Policiaco', 1, GETDATE()),
('Juvenil', 1, GETDATE()),
('Suspenso', 1, GETDATE()),
('Novela', 1, GETDATE()),
('Biografía', 1, GETDATE());

Create Table Books(
Id_Book Int Primary Key Identity,
Id_Author Int,
Id_Genre Int,
Name_Book Varchar(150),
Book_Summary Varchar(500),
Status_Book Bit,
Book_Creation_Date DateTime,
Foreign Key (Id_Author) References Authors(Id_Author),
Foreign Key (Id_Genre) References Genres(Id_Genre)
);

Insert Into Books
Values
(1, 1, 'Matar a un ruiseñor', 'La historia de una niña en el sur de EE.UU que aprende sobre el racismo y la justicia mientras su padre defiende a un hombre negro acusado de violación.', 1, GETDATE()),
(2, 2, '1984', 'Una crítica al totalitarismo, donde un estado opresivo controla todos los aspectos de la vida de sus ciudadanos.', 1, GETDATE()),
(3, 3, 'Cien años de soledad', 'La fascinante crónica multigeneracional de la familia Buendía en el pueblo ficticio de Macondo.', 1, GETDATE()),
(4, 14, 'El gran Gatsby', 'La trágica historia de Jay Gatsby y su amor imposible con Daisy Buchanan en la decadente era del jazz.', 1, GETDATE()),
(5, 5, 'Orgullo y prejuicio', 'La relación en evolución entre Elizabeth Bennet y el Sr. Darcy, explorando temas de amor, clase y moralidad.', 1, GETDATE()),
(6, 6, 'Los juegos del hambre', 'La joven Katniss Everdeen debe participar en un torneo mortal que es televisado a toda la nación.', 1, GETDATE()),
(7, 7, 'Harry Potter y la piedra filosofal', 'Un joven descubre que es un mago y asiste a la escuela de Hogwarts, haciendo amigos y enfrentando peligros.', 1, GETDATE()),
(8, 8, 'El código Da Vinci', 'El profesor Robert Langdon desentraña un secreto escondido en las obras de Leonardo Da Vinci.', 1, GETDATE()),
(9, 4, 'El hombre en busca de sentido', 'El testimonio de un psiquiatra sobre su experiencia en campos de concentración nazis y su teoría sobre la búsqueda de sentido.', 1, GETDATE()),
(10, 1, 'La metamorfosis', 'La extraña historia de Gregor Samsa, quien se despierta un día transformado en un insecto gigante.', 1, GETDATE()),
(11, 10, 'La catedral del mar', 'La vida de un siervo en la Barcelona medieval, mientras se construye la gran catedral de Santa María del Mar.', 1, GETDATE()),
(12, 11, 'El alquimista', 'La búsqueda espiritual de un joven pastor que viaja en busca de un tesoro y descubre su destino.', 1, GETDATE()),
(13, 12, 'El resplandor', 'La vida de una familia que se enfrenta a eventos sobrenaturales en un hotel aislado durante el invierno.', 1, GETDATE()),
(14, 13, 'Sapiens: De animales a dioses', 'Un recorrido histórico y científico desde los inicios de la humanidad hasta la era moderna.', 1, GETDATE()),
(15, 14, 'El retrato de Dorian Gray', 'La historia de un joven cuya apariencia se mantiene eternamente joven mientras su retrato envejece y muestra su corrupción.', 1, GETDATE()),
(16, 15, 'Las crónicas de Narnia: El león, la bruja y el armario', 'Niños descubren un mundo mágico y luchan contra la tiranía de la Bruja Blanca.', 1, GETDATE()),
(17, 8, 'El nombre de la rosa', 'Frailes investigan extraños asesinatos en una abadía italiana del siglo XIV.', 1, GETDATE()),
(19, 8, 'La sombra del viento', 'Un joven encuentra un libro misterioso que lo lleva a descubrir secretos oscuros e intrigas.', 1, GETDATE()),
(18, 17, 'A través de mi ventana', 'La historia de un amor joven y los desafíos que enfrentan los adolescentes en su camino.', 1, GETDATE()),
(20, 6, 'Zona Roja', 'Thriller ambientado en una sociedad dominada por la tecnología y el control estatal.', 1, GETDATE()),
(3, 18, 'Crónica de una muerte anunciada', 'Basada en hechos reales, cuenta la historia de Santiago Nasar, quien es asesinado por los hermanos Vicario para vengar el honor de su hermana. La novela reconstruye los hechos que condujeron a su muerte.', 1, GETDATE()),
(21, 20, 'El olvido que seremos', 'Escrita por el hijo del médico y activista Héctor Abad Gómez, esta obra relata la vida y el asesinato de su padre en 1987. Es una conmovedora reflexión sobre la memoria, el amor y la lucha por los derechos humanos en Colombia.', 1, GETDATE()),
(22, 19, 'Delirio', 'La historia sigue a Agustina, una mujer que busca a su esposo desaparecido en medio de un contexto de violencia y corrupción en Bogotá. La novela es una crítica social y política que mantiene al lector en vilo hasta el final.', 1, GETDATE()),
(3, 19, 'El coronel no tiene quien le escriba', 'El coronel, un veterano de guerra, espera durante años la llegada de una pensión prometida por el gobierno. A través de su espera y su relación con su esposa, se aborda la desesperanza y la dignidad.', 1, GETDATE()),
(23, 19, '¡Que viva la música!', 'Ambientada en la Bogotá de los años 70, esta novela sigue la vida de un grupo de jóvenes que buscan escapar de la realidad a través de la música, el amor y las drogas. Es una obra que retrata fielmente la generación de Caicedo y su búsqueda de identidad y libertad.', 1, GETDATE()),
(3, 5, 'El amor en los tiempos del cólera', 'Relata la vida de Florentino Ariza y Fermina Daza, y su amor que perdura a lo largo de más de cincuenta años, a pesar de las dificultades y la distancia. Es una reflexión sobre el amor en sus múltiples formas.', 1, GETDATE());

Create Table Users(
Id_User Int Primary Key Identity,
Name_User Varchar(150),
Email_User Varchar(100),
Status_User Bit,
User_Creation_Date DateTime
);

Create Table UserLogin(
Id_UserLogin Int Primary Key Identity,
Id_User Int,
Password_UserLogin NVarchar(max),
Status_UserLogin Bit,
UserLogin_Creation_Date DateTime,
Foreign Key (Id_User) References Users(Id_User)
);

Create Table Reviews(
Id_Review Int Primary Key Identity,
Id_Book Int,
Id_User Int,
Name_Review Varchar(150),
Review NVarchar(500),
Rating Int,
Status_Review Bit,
Review_Creation_Date DateTime,
Foreign Key (Id_Book) References Books(Id_Book),
Foreign Key (Id_User) References Users(Id_User)
);


--///////  Procedimientos almacenados////////




-- Creado por: Willfredo Martinez
-- Fecha 21/01/2025
-- Agrega Reseña

CREATE Procedure [dbo].[AddReview]
@Id_Book Int,
@Id_User Int,
@Name_Review Varchar(150),
@Review NVarchar(500),
@Rating Int
AS

Declare @NewId Int
Set @NewId = 0

Declare @Result Bit
Set @Result = 0;

Insert Into Reviews
Values
(@Id_Book, @Id_User, @Name_Review, @Review, 1, GETDATE(), @Rating)

Select @NewId = @@IDENTITY

If(@NewId > 0)
	Begin
		Set @Result = 1;
	End
Else
	Begin
		Set @Result = 0;
	End;

Select @Result AS Result
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- Creado por: Willfredo Martinez
-- Fecha 20/01/2025
-- Crea nuevo usuario

CREATE Procedure [dbo].[AddUser]
@Name_User Varchar(150),
@Email_User Varchar(100),
@Password_UserLogin Varchar(Max)
AS

Declare @NewId Int
Set @NewId = 0

IF (EXISTS (Select Email_User From Users Where Email_User = @Email_User))
	BEGIN
		SELECT 'El email ya existe' AS Result;
	END
ELSE
	BEGIN
		Insert Into Users
		Values
		(@Name_User, @Email_User, 1, GETDATE());

		Select @NewId = @@IDENTITY;

		Insert Into UserLogin
		Values
		(@NewId, @Password_UserLogin, 1, GETDATE());

		If (@NewId != 0)
			BEGIN
				SELECT 'Se crea el usuario con exito' AS Result;
			END
		Else
			BEGIN
				SELECT 'No se pudo crear el usuario' AS Result;
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[DeleteReview]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Creado por: Willfredo Martinez
-- Fecha 22/01/2025
-- Reseñas por usuario

CREATE Procedure [dbo].[DeleteReview]
@Id_Review Int
AS

Update Reviews Set Status_Review = 0
Where Id_Review = @Id_Review

Select 'Comentario eliminado con exito' AS Result
GO
/****** Object:  StoredProcedure [dbo].[EditReviewById]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Creado por: Willfredo Martinez
-- Fecha 22/01/2025
-- Reseñas por usuario

CREATE Procedure [dbo].[EditReviewById]
@Id_Review Int,
@Name_review Varchar(150),
@Review NVarchar(500),
@Rating Int
AS

Update Reviews Set 
Name_Review = @Name_review,
Review = @Review,
Rating = @Rating
Where Id_Review = @Id_Review

Select 'Comentario Actualizado' As Result
GO
/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Creado por: Willfredo Martinez
-- Fecha 20/01/2025
-- Obtiene Datos de todos los libros

CREATE Procedure [dbo].[GetAllBooks]
AS

SELECT Id_Book, Name_Book, Book_Summary, Name_Author, Name_Genre, Book_Creation_Date FROM Books B
INNER JOIN Authors A ON A.Id_Author = B.Id_Author
INNER JOIN Genres G ON G.Id_Genre = B.Id_Genre;
GO
/****** Object:  StoredProcedure [dbo].[GetAllReviewByBook]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Creado por: Willfredo Martinez
-- Fecha 22/01/2025
-- Obtiene todas los comentarios por libro

CREATE Procedure [dbo].[GetAllReviewByBook]
@Id_Book Int
AS

Select Id_Review, Name_Review, Review, Review_Creation_Date, Rating, Name_User, Name_Book From Reviews R
Inner Join Users U On R.Id_User = U.Id_User
Inner Join Books B On R.Id_Book = B.Id_Book
Where R.Id_Book = @Id_Book
Order by Id_Review Desc
GO
/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Creado por: Willfredo Martinez
-- Fecha 20/01/2025
-- Obtiene Datos de libro por id

CREATE Procedure [dbo].[GetBookById]
@Id_Book Int
AS

SELECT Id_Book, Name_Book, Book_Summary, Name_Author, Name_Genre, Book_Creation_Date FROM Books B
INNER JOIN Authors A ON A.Id_Author = B.Id_Author
INNER JOIN Genres G ON G.Id_Genre = B.Id_Genre
WHERE B.Id_Book = @Id_Book
GO
/****** Object:  StoredProcedure [dbo].[GetReviewsByIdUser]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Creado por: Willfredo Martinez
-- Fecha 21/01/2025
-- Reseñas por usuario

CREATE Procedure [dbo].[GetReviewsByIdUser] 
@Id_User Int
AS

Select Id_Review, Name_Review, Review, Rating, Name_Book, Name_User, Review_Creation_Date From Reviews R
Inner Join Books B ON R.Id_Book = B.Id_Book
Inner Join Users U ON R.Id_User = U.Id_User
Where R.Id_User = @Id_User And Status_Review = 1
Order by Id_Review Desc
GO
/****** Object:  StoredProcedure [dbo].[ValidateEmail]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- Creado por: Willfredo Martinez
-- Fecha 21/01/2025
-- Valida Email

CREATE Procedure [dbo].[ValidateEmail] --'ingwillfredo@gmail.c'
@Email_User Varchar(100)
AS

Declare @Result Bit;
Set @Result = 0;

IF (EXISTS (Select Email_User From Users Where Email_User = @Email_User))
	BEGIN
		Set @Result = 1;
	END
ELSE
	BEGIN
		Set @Result = 0;
	END
	Select @Result AS Result
GO
/****** Object:  StoredProcedure [dbo].[ValidateLogin]    Script Date: 25/01/2025 9:18:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Creado por: Willfredo Martinez
-- Fecha 21/01/2025
-- Valida credenciales

CREATE Procedure [dbo].[ValidateLogin]
@Email_User Varchar(100)
AS

Select U.Id_User, Name_User, Email_User, Password_UserLogin From Users U
Inner Join UserLogin UL On U.Id_User = UL.Id_User
Where Email_User = @Email_User


GO





