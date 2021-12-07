

CREATE TABLE [dbo].[tblLocations](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[MaxSpaces] [int] NULL,
 CONSTRAINT [PK_tblLocations] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblLocations] ADD  CONSTRAINT [DF_tblLocations_Description]  DEFAULT ('') FOR [Description]
GO

ALTER TABLE [dbo].[tblLocations] ADD  CONSTRAINT [DF_tblLocations_Max]  DEFAULT ((0)) FOR [MaxSpaces]
GO


/****** Object:  Table [dbo].[tblSpaces]    Script Date: 12/7/2021 8:01:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSpaces](
	[LocationID] [int] NOT NULL,
	[Space] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tblSpaces] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC,
	[Space] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblSpaces] ADD  CONSTRAINT [DF_tblSpaces_Space]  DEFAULT ('') FOR [Space]
GO




IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_GetLocations'))
   exec('CREATE PROCEDURE [dbo].[usp_GetLocations] AS BEGIN SET NOCOUNT ON; END')
GO

alter proc usp_GetLocations
AS
	select loc.LocationID, Description, MaxSpaces, count(Space) as Count
	from tblLocations loc
		left join tblSpaces s on s.LocationID=loc.LocationID
	group by loc.LocationID, Description, MaxSpaces
GO


if NOT EXISTS( select 1 from tblLocations )
begin
	insert tblLocations(description, MaxSpaces) values( 'RDU Central Level One' , 10)
	insert tblLocations(description, MaxSpaces) values( 'RDU Central Level Two' , 20)
end 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_insertSpace'))
   exec('CREATE PROCEDURE [dbo].[usp_insertSpace] AS BEGIN SET NOCOUNT ON; END')
GO

alter proc usp_InsertSpace(@LocationID int, @Space varchar(30))
AS
	insert into tblSpaces(LocationID, Space) values(@LocationID, @Space)
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_DeleteSpace'))
   exec('CREATE PROCEDURE [dbo].[usp_DeleteSpace] AS BEGIN SET NOCOUNT ON; END')
GO

alter proc usp_DeleteSpace(@LocationID int, @Space varchar(30))
AS
	delete from tblSpaces where LocationID =@LocationID and [Space]= @Space
GO


