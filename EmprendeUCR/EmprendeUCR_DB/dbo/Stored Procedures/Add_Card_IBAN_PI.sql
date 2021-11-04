CREATE PROCEDURE Add_Card_IBAN_PI(
    @incomingAccountNumber VARCHAR(100),
	@paymentMethod VARCHAR(100)
)
AS
IF @incomingAccountNumber LIKE 'CR[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
BEGIN
	DECLARE @lastID int = -1;
	IF NOT EXISTS (SELECT Payment_Info_Id FROM Card_PI WHERE @incomingAccountNumber = Account_Number)
	BEGIN
		--Insertar en Payment_Info
		INSERT INTO Payment_Info
		DEFAULT VALUES
		--Insertar en SINPE_Movil_PI
		SELECT @lastID = SCOPE_IDENTITY();
		INSERT INTO Card_PI
		VALUES (@incomingAccountNumber,@paymentMethod, @lastID)
	END
	ELSE
	BEGIN
		PRINT 'El número de cuenta IBAN ya se encuentra guardado en el sistema'
	END
END
ELSE
BEGIN
	PRINT 'Formato de cuenta invalido, la cuenta IBAN debe tener 22 caracteres, los primeros 2 deben ser CR, el resto digitos'
END;