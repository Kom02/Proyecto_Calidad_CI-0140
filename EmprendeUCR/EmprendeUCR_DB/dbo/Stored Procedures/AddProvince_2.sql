CREATE PROCEDURE AddProvince @Province VARCHAR(15)
AS
BEGIN
	INSERT INTO Province
	values(@Province)
END