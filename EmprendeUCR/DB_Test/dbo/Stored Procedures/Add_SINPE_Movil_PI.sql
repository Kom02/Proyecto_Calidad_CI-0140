CREATE PROCEDURE Add_SINPE_Movil_PI(
    @incomingPhoneNumber int
)
AS
IF @incomingPhoneNumber >= 0 AND @incomingPhoneNumber <= 99999999
BEGIN
	DECLARE @lastID int = -1;
	IF NOT EXISTS (SELECT Payment_Info_Id FROM SINPE_Movil_PI WHERE @incomingPhoneNumber = Phone_Number)
	BEGIN
		--Insertar en Payment_Info
		INSERT INTO Payment_Info
		DEFAULT VALUES
		--Insertar en SINPE_Movil_PI
		SELECT @lastID = SCOPE_IDENTITY();
		INSERT INTO SINPE_Movil_PI
		VALUES (@incomingPhoneNumber,'SINPE Movil', @lastID)
	END
	ELSE
	BEGIN
		PRINT 'El número telefónico ya se encuentra guardado en el sistema'
	END
END
ELSE
BEGIN
	PRINT 'El número telefónico ingresado no es valido, por favor revise que sea de 8 digitos'
END;