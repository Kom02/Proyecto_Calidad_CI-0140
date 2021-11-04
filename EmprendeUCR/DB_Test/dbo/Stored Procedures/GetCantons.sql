CREATE PROCEDURE GetCantons(@province varchar(15))
AS
BEGIN
	SELECT Province_Name, Name 
	FROM Canton
	WHERE Canton.Province_Name = @province
	RETURN
END;