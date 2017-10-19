USE [MediaManager]
GO

INSERT INTO [MediaManager].[Movie]
           ([MovieTitle]
           ,[MovieSummary]
           ,[ReleaseDate]
           ,[Poster]
           ,[ImdbId]
           ,[Purchased]
           ,[MPAARatingId]
           ,[FormatId]
           ,[AuditInfo_CreatedAt]
           ,[AuditInfo_CreatedBy]
           ,[AuditInfo_ModifiedAt]
           ,[AuditInfo_ModifiedBy])
     VALUES
           (
		   'The Secret of Navajo Cave aka Legend of Cougar Canyon'
           ,'There are many wonderful and dangerous legends about Cougar Canyon, a sacred Navajo terrain. Two young boys must face the legends and dangers when they go to rescue a lost goat.'
           ,'19 April 1976'
           ,'https://images-na.ssl-images-amazon.com/images/M/MV5BMTY1MTgxMzczNF5BMl5BanBnXkFtZTcwMDgyNzYxMQ@@._V1_SX300.jpg'
           ,'tt0075180'
           ,0
           ,1
           ,2
           ,getdate()
           ,'dcritchlow'
           ,null
           ,null
		   )
GO


