USE [MinionsDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetOlder]    Script Date: 2021/4/24 下午 01:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetOlder] 
	@id int
AS
BEGIN
	
	UPDATE Minions SET Age = Age+1 WHERE Id = @id
END
