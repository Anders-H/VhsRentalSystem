USE [VHS-rental]

DELETE FROM dbo.Cassette
DELETE FROM dbo.Company
DELETE FROM dbo.Customer
DELETE FROM dbo.[Event]
DELETE FROM dbo.Movie
DELETE FROM dbo.RentalEvent
DELETE FROM dbo.Setting
DELETE FROM dbo.Staff

DECLARE @ID INT

EXEC dbo.SetSetting 'DatabaseVersion', '1.0', 0.0, 100
EXEC dbo.SetSetting 'DefaultCustomerPrice', '', 25.0, 0
EXEC dbo.SetSetting 'DefaultCompanyCommission', '', 12.0, 0

EXEC dbo.RegisterCompany 'Fictive Company'
EXEC dbo.RegisterCompany 'Another Company'

SET @ID=(SELECT TOP 1 ID FROM dbo.Company WHERE [Name]='Fictive Company')
EXEC dbo.RegisterMovie 512895128971, 'Ombytta roller', 1983, @ID, 3
EXEC dbo.RegisterMovie 512895128972, 'Ghostbusters - Spökligan', 1984, @ID, 4
SET @ID=(SELECT TOP 1 ID FROM dbo.Company WHERE [Name]='Another Company')
EXEC dbo.RegisterMovie 512895128973, 'Galaxy Quest', 1999, @ID, 5
EXEC dbo.RegisterMovie 512895128974, 'Cook Off!', 2007, @ID, 1
EXEC dbo.RegisterMovie 512895128975, 'Eyes Wide Shut', 1999, @ID, 2

EXEC dbo.RegisterCustomer 'Sven Persson', '112233-4455', '', '', '', '', '', ''
EXEC dbo.RegisterCustomer 'Conny Karlsson', '223344-5566', '', '', '', '', '', ''

EXEC dbo.RegisterStaff 'Andy McAndy', '334455-6677'
EXEC dbo.RegisterStaff 'Pandy McPandy', '445566-7788'
