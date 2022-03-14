DECLARE @ID INT

EXEC dbo.SetSetting 'DatabaseVersion', '1.0', 0.0, 100
EXEC dbo.SetSetting 'DefaultCustomerPrice', '', 25.0, 0
EXEC dbo.SetSetting 'DefaultCompanyCommission', '', 12.0, 0

EXEC dbo.RegisterCompany 'Fictive Company'
EXEC dbo.RegisterCompany 'Another Company'

SET @ID=(SELECT TOP 1 ID FROM dbo.Company WHERE [Name]='Fictive Company')
EXEC dbo.RegisterMovie 512895128971, 'Ombytta roller', 1983, @ID
EXEC dbo.RegisterMovie 512895128972, 'Ghostbusters - Spökligan', 1984, @ID
SET @ID=(SELECT TOP 1 ID FROM dbo.Company WHERE [Name]='Another Company')
EXEC dbo.RegisterMovie 512895128973, 'Galaxy Quest', 1999, @ID

SET @ID=(SELECT TOP 1 ID FROM dbo.Movie WHERE EAN=512895128971)
EXEC dbo.RegisterCassette @ID, 511734916651
EXEC dbo.RegisterCassette @ID, 511734916652
SET @ID=(SELECT TOP 1 ID FROM dbo.Movie WHERE EAN=512895128972)
EXEC dbo.RegisterCassette @ID, 511734916653
SET @ID=(SELECT TOP 1 ID FROM dbo.Movie WHERE EAN=512895128973)
EXEC dbo.RegisterCassette @ID, 511734916654
EXEC dbo.RegisterCassette @ID, 511734916655
EXEC dbo.RegisterCassette @ID, 511734916656

EXEC dbo.RegisterCustomer 'Sven Persson', '112233-4455', '', '', '', '', '', ''
EXEC dbo.RegisterCustomer 'Conny Karlsson', '223344-5566', '', '', '', '', '', ''

EXEC dbo.RegisterStaff 'Andy McAndy', '334455-6677'
EXEC dbo.RegisterStaff 'Pandy McPandy', '445566-7788'
