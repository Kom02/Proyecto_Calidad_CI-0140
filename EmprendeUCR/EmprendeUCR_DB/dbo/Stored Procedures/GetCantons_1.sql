CREATE PROCEDURE GetCantons(@province varchar(15))
AS
BEGIN
	SELECT Canton.Name
	FROM Canton
	WHERE Canton.Province_Name = @province
	RETURN
END;