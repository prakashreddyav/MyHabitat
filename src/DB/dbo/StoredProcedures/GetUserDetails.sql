CREATE PROCEDURE [dbo].[GetUserDetails]
(
	@userName			VARCHAR(50),
	@po_var_ErrorCode	VARCHAR(120)	OUTPUT
)
AS 
BEGIN
	SET	NOCOUNT	ON 
	SET @po_var_ErrorCode = 'NONE'
	
	BEGIN TRY	

	SELECT * FROM dbo.[User] WHERE UserName=@userName

	END TRY
	BEGIN CATCH
		IF(ERROR_NUMBER() >= 51000)
			SET	@po_var_ErrorCode = ERROR_MESSAGE()
        ELSE
			SET	@po_var_ErrorCode = 'DB_ERROR_IN_EXECUTING_QUERY'
	END CATCH
END
