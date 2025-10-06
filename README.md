# UsersApplication
Simple crud for users. Using .NET and SQL server

It has a database with users information. 

You can create a new user using the endpoint POST "api/users". It will create a register into the database, after that, whit it, you can login and get the auth token.
With auth token and other username, you can send messages. 

Currently, I'm developing a frontend to see this messages --> https://github.com/tonatto6/usersChat


DATABASE STRUCTURE:

CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](200) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


CREATE TABLE [dbo].[UsersMessages](
	[IdUserMessage] [int] IDENTITY(1,1) NOT NULL,
	[IdUserSend] [int] NOT NULL,
	[IdUserReceiver] [int] NOT NULL,
	[Message] [varchar](200) NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[ReadDate] [datetime] NULL,
 CONSTRAINT [PK_UsersMessages] PRIMARY KEY CLUSTERED 
(
	[IdUserMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
