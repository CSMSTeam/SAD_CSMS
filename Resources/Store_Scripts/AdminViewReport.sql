USE [CSMS2]
GO

/****** Object:  StoredProcedure [dbo].[AdminViewReport]    Script Date: 12/01/2015 22:26:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AdminViewReport]
	@fromdate datetime,
	@todate datetime,
	@status nvarchar(15)
AS
	SELECT ord.orderid, ord.empid, ord.orderdate, ord.total
	FROM [Order] ord
	WHERE
	ord.orderdate BETWEEN @fromdate AND @todate
	AND
	@status LIKE 'Success'

GO


