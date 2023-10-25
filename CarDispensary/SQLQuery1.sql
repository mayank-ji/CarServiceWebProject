CREATE TABLE [dbo].[OrderDetail]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CarRegistrationNo] VARCHAR(50) NOT NULL, 
    [ManufacturingYear] VARCHAR(30) NOT NULL, 
    [OdometerReading] VARCHAR(50) NOT NULL, 
    [VehicleModel] VARCHAR(50) NOT NULL, 
    [CustomerName] VARCHAR(50) NOT NULL, 
    [CustMobileNo] VARCHAR(10) NOT NULL, 
    [CustEmail] VARCHAR(50) NULL, 
    [CustAddress] VARCHAR(50) NOT NULL, 
    [VisitMode] VARCHAR(50) NOT NULL, 
    [ServiceId] INT NULL, 
    [GarageName] VARCHAR(50) NOT NULL,

	FOREIGN KEY(ServiceId) REFERENCES Service(ServiceID)
);

