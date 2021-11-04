CREATE PROCEDURE User_Register
	 @Email varchar(100)
	,@OperationType int

AS
BEGIN TRAN
	
	IF(@OperationType = 1) --Signup
	BEGIN
		SET @Email = (SELECT COUNT(*) FROM [User]) + 1

		INSERT INTO [User] (Email)
			            VALUES(@Email)

		SELECT * FROM [User] WHERE Email=@Email

	END
	ELSE IF(@OperationType = 2) --Confirm Mail
	BEGIN
		IF (@Email = null OR @Email = '')
		BEGIN
			ROLLBACK
				RAISERROR (N'Invalid user. Please create account. !!!~',16,1);	
			RETURN
		END

		UPDATE [User] SET Email_Confirmation=1
					   WHERE Email=@Email

		SELECT * FROM [User] WHERE Email=@Email
	END
COMMIT TRAN