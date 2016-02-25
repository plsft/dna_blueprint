create table Customers
(
	ID int identity(1,1) not null primary key,
	Firstname varchar(32),
	Lastname varchar(32),
	Address1 varchar(32), 
	City varchar(32), 
	[State] varchar(2), 
	Zip varchar(8),
	Phone varchar(32), 
	Email varchar(96), 
	Created smalldatetime not null default(getdate()),
	LastUpdate smalldatetime null
)

create table Parts 
(
	ID int identity(1,1) not null primary key,
	Descr varchar(64),
	Amount float,
	[Status] int, 
	Created smalldatetime,
	LastUpdate smalldatetime, 
	Borrowed bit not null default(0)
)


create table History 
(
	ID int identity(1,1) not null primary key, 
	PartId int references Parts(ID) not null, 
	[Status] int, 
	UserId int references Users(ID) not null, 
	Created smalldatetime not null default(getdate())
)

create table Invoices
(
	ID int identity(1,1) not null primary key,
	CustomerId int references Customers(ID), 
	PartId int references Parts(ID),
	Amount float,
	Due date, 
	[Status] int,
	Created smalldatetime not null default(getdate())
)

create table Users
(
	ID int identity(1,1) not null primary key, 
	Username varchar(64), 
	Email varchar(128),
	Pwd varchar(128),
	Created smalldatetime not null default(getdate())
)

create table Roles 
(
	ID int identity(1,1) not null primary key, 
	RoleName varchar(64)	
)

create table Users_Roles
(
	ID int identity(1,1) not null primary key, 
	UserId int references Users(ID),
	RoleId int references Roles(ID),
	Created smalldatetime not null default(getdate())

)

create table [Sessions] 
(
	ID int identity(1,1) not null primary key,
	Token varchar(32), 
	Nonce int,
	Device varchar(256), 
	Created smalldatetime not null default(getdate()),
	LastSeen smalldatetime null
)

create nonclustered index ix_sessions_token on  Sessions(Token)



CREATE TABLE [dbo].[Settings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SettingName] [varchar](32) NULL,
	[SettingValue] [varchar](64) NULL,
	[Created] [smalldatetime] NOT NULL DEFAULT (getdate()),
	[Enabled] [bit] NOT NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


create table ApiHealth
(
	ID int identity(1,1) not null primary key, 
	Domain varchar(64), 
	Status bit, 
	Message varchar(64), 
	Token varchar(16), 
	QueryTimeMs int, 
	Code int,
	Hostname varchar(64),
	RequestId varchar(64),
	Created smalldatetime not null default(getdate()) 
)
