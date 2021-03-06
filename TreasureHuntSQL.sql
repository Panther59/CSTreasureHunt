USE [master]
GO
/****** Object:  Database [TreasureHuntDB]    Script Date: 12-May-2020 12:54:45 ******/
CREATE DATABASE [TreasureHuntDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TreasureHuntDB', FILENAME = N'C:\Users\Utkarsh\TreasureHuntDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TreasureHuntDB_log', FILENAME = N'C:\Users\Utkarsh\TreasureHuntDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TreasureHuntDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TreasureHuntDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TreasureHuntDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TreasureHuntDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TreasureHuntDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TreasureHuntDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TreasureHuntDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TreasureHuntDB] SET  MULTI_USER 
GO
ALTER DATABASE [TreasureHuntDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TreasureHuntDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TreasureHuntDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TreasureHuntDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TreasureHuntDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TreasureHuntDB] SET QUERY_STORE = OFF
GO
USE [TreasureHuntDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [TreasureHuntDB]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 12-May-2020 12:54:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](4000) NOT NULL,
	[QuestionID] [int] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attempts]    Script Date: 12-May-2020 12:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attempts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParticipantID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[AnswerID] [int] NULL,
	[Skipped] [bit] NULL,
	[ProgressedOn] [datetime] NULL,
 CONSTRAINT [PK_Attempts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 12-May-2020 12:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[LoginName] [varchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Participants] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 12-May-2020 12:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](4000) NOT NULL,
	[QuizId] [int] NOT NULL,
	[Sequance] [int] NOT NULL,
	[SkippedDurationSeconds] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Quiz_Seq] UNIQUE NONCLUSTERED 
(
	[QuizId] ASC,
	[Sequance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizzes]    Script Date: 12-May-2020 12:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizzes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Active] [bit] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_QuestionSets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Attempts]  WITH CHECK ADD  CONSTRAINT [FK_Attempts_Answers] FOREIGN KEY([AnswerID])
REFERENCES [dbo].[Answers] ([ID])
GO
ALTER TABLE [dbo].[Attempts] CHECK CONSTRAINT [FK_Attempts_Answers]
GO
ALTER TABLE [dbo].[Attempts]  WITH CHECK ADD  CONSTRAINT [FK_Attempts_Participants] FOREIGN KEY([ParticipantID])
REFERENCES [dbo].[Participants] ([ID])
GO
ALTER TABLE [dbo].[Attempts] CHECK CONSTRAINT [FK_Attempts_Participants]
GO
ALTER TABLE [dbo].[Attempts]  WITH CHECK ADD  CONSTRAINT [FK_Attempts_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Attempts] CHECK CONSTRAINT [FK_Attempts_Questions]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Quiz] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizzes] ([ID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Quiz]
GO
/****** Object:  StoredProcedure [dbo].[GetLiveResult]    Script Date: 12-May-2020 12:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLiveResult]
	@quizId INT,
	@userId INT
AS
BEGIN

	SET NOCOUNT ON;
	
	DECLARE @maxQuestions INT
	SELECT @maxQuestions = MAX(Sequance) FROM Questions (NOLOCK) q WHERE q.QuizId = @quizId

	Create table #tmpOrder
	(
		ParticipantID INT,
		Sequance INT 
	)

	INSERT INTO #tmpOrder
	SELECT  p.ID, MAX(Sequance)
	FROM Attempts (NOLOCK) a
	INNER JOIN Questions (NOLOCK) q on a.QuestionID = q.ID AND q.QuizId = @quizId
	INNER JOIN Participants (NOLOCK) p on p.ID = a.ParticipantID
	GROUP BY p.ID

	SELECT * FROM (
	SELECT  p.*, q.Sequance AS Answered, @maxQuestions AS Total,RANK() OVER (ORDER BY q.Sequance DESC, a.ProgressedOn ASC) AS UserRank
	FROM Attempts (NOLOCK) a
	INNER JOIN Questions (NOLOCK) q on a.QuestionID = q.ID AND q.QuizId = @quizId
	INNER JOIN Participants (NOLOCK) p on p.ID = a.ParticipantID
	INNER JOIN #tmpOrder (NOLOCK) o ON o.ParticipantID = a.ParticipantID AND o.Sequance = q.Sequance
	)x WHERE X.UserRank <= 10 OR x.ID = @userId

	DROP TABLE #tmpOrder
END
GO
/****** Object:  StoredProcedure [dbo].[GetNextQuestion]    Script Date: 12-May-2020 12:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNextQuestion] 
	-- Add the parameters for the stored procedure hereQ
	@participantId INT,
	@quizId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @lastQuestionAnswered INT

	SELECT @lastQuestionAnswered = MAX(qu.Sequance) 
	FROM Attempts a
	INNER JOIN Questions qu ON a.QuestionID = qu.ID
	WHERE a.ParticipantID = @participantId 
	AND qu.QuizId = @quizId


	IF @lastQuestionAnswered IS NULL
	BEGIN
		SELECT * FROM Questions
		WHERE QuizId = @quizId AND Sequance IN (SELECT MIN(Sequance) FROM Questions WHERE QuizId = @quizId )
	END
	ELSE
	BEGIN
		SELECT * FROM Questions
		WHERE QuizId = @quizId AND Sequance IN (SELECT MIN(Sequance) FROM Questions WHERE QuizId = @quizId AND Sequance > @lastQuestionAnswered )
	END

END
GO
USE [master]
GO
ALTER DATABASE [TreasureHuntDB] SET  READ_WRITE 
GO
