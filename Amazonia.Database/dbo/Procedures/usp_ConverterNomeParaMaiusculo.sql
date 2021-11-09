CREATE PROCEDURE [dbo].[usp_ConverterNomeParaMaiusculo]
	@param01 VARCHAR(50)
AS
	SELECT UPPER(@param01)
RETURN 0
