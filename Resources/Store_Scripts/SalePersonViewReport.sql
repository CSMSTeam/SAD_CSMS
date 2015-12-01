USE [CSMS2]
GO

/****** Object:  StoredProcedure [dbo].[SalePersonViewReport]    Script Date: 12/01/2015 22:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SalePersonViewReport]
	@empid int, 
	@fromdate datetime, 
	@todate datetime
AS
	SELECT ord.orderid, ord.orderdate, ord.orderadress, ord.cusphone, ord.total 
	FROM [Order] ord
	WHERE
	ord.[status] LIKE 'Success'
	AND
	ord.empid = @empid
	AND
	ord.orderdate BETWEEN @fromdate AND @todate

GO


