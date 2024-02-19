USE ROMAN_GEN
GO

SELECT U.nome as 'Nome de usuário', P.titulo 'Titulo Projeto', T.titulo 'Tema' FROM PROJETO P
LEFT JOIN USUARIO U
	ON P.idUsuario = U.idusuario
LEFT JOIN TEMA T
	ON T.idTema = P.idTema

select * from projeto