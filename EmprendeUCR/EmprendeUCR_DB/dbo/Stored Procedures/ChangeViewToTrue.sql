CREATE PROCEDURE ChangeViewToTrue(
	@clientEmail	AS VARCHAR(100)
)
AS
	DECLARE @Date_and_hour datetime
	DECLARE Cursor_to_change_view CURSOR FOR
		select Date_and_hour_of_creation
		from OrderNotificationClient
		where Client_Email = @clientEmail
	Open Cursor_to_change_view
	FETCH NEXT From Cursor_to_change_view INTO @Date_and_hour
BEGIN
	while @@FETCH_STATUS = 0
	BEGIN
		update [Order] set [view] = 1 where Client_Email = @clientEmail and Date_and_hour_of_creation = @Date_and_hour
		FETCH NEXT From Cursor_to_change_view INTO @Date_and_hour
	END
END