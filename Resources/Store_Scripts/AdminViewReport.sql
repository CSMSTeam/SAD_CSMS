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
	SELECT ord.orderid, emp.empname, ord.orderdate, ord.total
	FROM [Order] ord, Employee emp
	WHERE
	ord.orderdate BETWEEN @fromdate AND @todate
	AND
	ord.[status] LIKE @status
	AND
	ord.orderid = emp.orderid

GO


