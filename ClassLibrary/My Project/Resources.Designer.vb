﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("ClassLibrary.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''/*  Drop Sequence and Table if they exist  */
        '''DROP TABLE IF EXISTS [dbo].[sys_LicenseKeys];
        '''DROP TABLE IF EXISTS [dbo].[sys_DirectoryInfo];
        '''DROP TABLE IF EXISTS [dbo].[ProjectHistory];
        '''DROP TABLE IF EXISTS [dbo].[ProjectDirectory];
        '''DROP SEQUENCE IF EXISTS [dbo].[sProjectDirectory_PK];
        '''
        '''
        '''/*  Create Project Directory table  */
        '''BEGIN TRANSACTION
        '''CREATE SEQUENCE [sProjectDirectory_PK] 
        ''' AS [int]
        ''' START WITH 1
        ''' INCREMENT BY 1
        ''' MINVALUE 1
        ''' MAXVALUE 999
        ''' NO CACHE ;
        '''
        '''CREATE TABLE [dbo].[ProjectD [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property CreateDirectory() As String
            Get
                Return ResourceManager.GetString("CreateDirectory", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to /* CREATE ALL DATABASE OBJECTS */
        '''DECLARE @SQLString NVARCHAR(MAX);
        '''
        '''
        '''/* Create Types  */
        '''CREATE TYPE dbo.TVP AS TABLE (ID int, [Description] varchar(255));
        '''
        '''
        '''/* Create Sequences */
        '''CREATE SEQUENCE dbo.sFiles_PK AS INTEGER START WITH 1 INCREMENT BY 1;
        '''CREATE SEQUENCE dbo.sPSTFolders_PK AS INTEGER START WITH 1 INCREMENT BY 1;
        '''CREATE SEQUENCE dbo.sInbox_PK AS INTEGER START WITH 1 INCREMENT BY 1;
        '''CREATE SEQUENCE dbo.sAttachments_PK AS INTEGER START WITH 1 INCREMENT BY 1;
        '''
        '''
        '''/* Create Tables */
        '''- [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property CreateTables() As String
            Get
                Return ResourceManager.GetString("CreateTables", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to --Used by frmEmailExemption, frmAttachments, frmSearchUpdate 
        '''--Insert new row(s) into Attachment Exemption Status table
        '''CREATE OR ALTER PROCEDURE [dbo].[fAttachExemption]
        '''@AttachID INT
        ''', @Exemptions TVP READONLY --custom type (TABLE)
        '''
        '''AS
        '''BEGIN
        '''	BEGIN TRANSACTION
        '''	--Updates all Attachments for Emails in search criteria
        '''	IF @AttachID = -1
        '''		BEGIN
        '''			-- Delete any existing Exemptions for each Attachment
        '''			DELETE FROM dbo.[AttachExemptStatus] 
        '''			WHERE AttachID IN (
        '''				SELECT att.ID
        '''				FROM  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fAttachExemption() As String
            Get
                Return ResourceManager.GetString("fAttachExemption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''--Drop and create all indexes in the Database
        '''
        '''CREATE OR ALTER PROCEDURE [dbo].[fCreateIndexes]
        '''AS
        '''BEGIN
        '''	--DROP all indexes and FULLTEXT INDEX objects if they exist
        '''	EXEC dbo.fDropIndexes;
        '''
        '''	--Create indexes for all Foreign Keys
        '''	CREATE INDEX IDX_Attachments_EmailID ON dbo.Attachments(EmailID);
        '''	CREATE INDEX IDX_Inbox_FileID ON dbo.Inbox(FileID);
        '''	CREATE INDEX IDX_Inbox_ChkSum ON dbo.Inbox(ChkSum);
        '''	CREATE INDEX IDX_PSTFolders_FileID ON dbo.PSTFolders(FileID);
        '''	CREATE INDEX IDX_EmailExemptSt [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fCreateIndexes() As String
            Get
                Return ResourceManager.GetString("fCreateIndexes", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''-- Iterate over each search term in dbo.SearchTerms and add rows to dbo.DisplayTerms
        '''-- containing the keywords from the Full Text Index.
        '''
        '''CREATE OR ALTER PROCEDURE [dbo].[fDisplayTerms]
        '''@DBName NVARCHAR(50)
        '''AS
        '''BEGIN
        '''	DECLARE curr CURSOR FOR
        '''		SELECT search_term 
        '''		FROM dbo.SearchTerms;
        '''	DECLARE @Term VARCHAR(255);
        '''
        '''	OPEN curr; 
        '''	FETCH NEXT FROM curr INTO @Term; 
        '''		WHILE @@FETCH_STATUS = 0  
        '''		BEGIN  
        '''			--Skip insert if term already exists in table
        '''			IF NOT EXISTS (SELECT 1 FROM [Displa [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fDisplayTerms() As String
            Get
                Return ResourceManager.GetString("fDisplayTerms", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''--Drop all indexes in the Database
        '''
        '''CREATE OR ALTER PROCEDURE [dbo].[fDropIndexes]
        '''AS
        '''BEGIN
        '''	--DROP indexes
        '''	DROP INDEX IF EXISTS IDX_Attachments_EmailID ON dbo.Attachments;
        '''	DROP INDEX IF EXISTS IDX_Inbox_FileID ON dbo.Inbox;
        '''	DROP INDEX IF EXISTS IDX_Inbox_ChkSum ON dbo.Inbox;
        '''	DROP INDEX IF EXISTS IDX_PSTFolders_FileID ON dbo.PSTFolders;
        '''	DROP INDEX IF EXISTS IDX_EmailExemptStatus_EmailID ON dbo.EmailExemptStatus;
        '''	DROP INDEX IF EXISTS IDX_EmailExemptStatus_ExemptionID ON dbo.EmailExemptStat [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fDropIndexes() As String
            Get
                Return ResourceManager.GetString("fDropIndexes", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to --Used by frmEmail, frmEmailDupe, frmEmailExemptions, frmSearchUpdate
        '''--Insert new row(s) into Email Exemption Status table
        '''CREATE OR ALTER   PROCEDURE [dbo].[fEmailExemption]
        '''@EmailID INT
        ''', @Exemptions TVP READONLY --custom type (TABLE)
        '''
        '''AS
        '''BEGIN
        '''	BEGIN TRANSACTION
        '''
        '''	--Updates all Emails in search criteria
        '''	IF @EmailID = -1
        '''		BEGIN
        '''			-- Delete any existing Exemptions for each Email
        '''			DELETE FROM dbo.[EmailExemptStatus] 
        '''			WHERE EmailID IN (
        '''				SELECT EmailID
        '''				FROM dbo.DisplayEmailID [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fEmailExemption() As String
            Get
                Return ResourceManager.GetString("fEmailExemption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to -- Imported Redacted pdf files
        '''CREATE OR ALTER   PROCEDURE [dbo].[fRedactedImport]
        '''@EmailID INT,
        '''@FileName NVARCHAR(255),
        '''@FilePath NVARCHAR(255)
        '''
        '''AS
        '''BEGIN
        '''	IF EXISTS(SELECT 1 FROM dbo.vRedactedFiles WHERE EmailID=@EmailID)
        '''	BEGIN
        '''		DECLARE @Seq INT = (select isnull(max(Seq),0)+1 from dbo.RedactedFiles where emailid=@EmailID);
        '''		DECLARE @SQL NVARCHAR(MAX) = N&apos;
        '''			INSERT INTO [RedactedFiles] (EmailID, Seq, [FileName], [FileStream])
        '''			SELECT @P1, @P2, @P3, CAST(bulkcolumn AS VARBINARY(MAX))
        '''			 [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fRedactedImport() As String
            Get
                Return ResourceManager.GetString("fRedactedImport", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''-- Used by ProjectDirectory to drop and re-create sequence for PK
        '''CREATE OR ALTER PROCEDURE [dbo].[fResetSeq]
        '''AS
        '''BEGIN
        '''	IF EXISTS(SELECT 1 FROM sys.default_constraints WHERE &quot;name&quot;=&apos;DF_ProjectDirectory_PK&apos;)
        '''		ALTER TABLE [dbo].[ProjectDirectory] DROP CONSTRAINT [DF_ProjectDirectory_PK];
        '''
        '''	DROP SEQUENCE IF EXISTS [dbo].[sProjectDirectory_PK];
        '''
        '''	DECLARE @ID INT = (SELECT MAX(ID)+1 FROM dbo.ProjectDirectory);
        '''	SET @ID = COALESCE(@ID,1);
        '''	DECLARE @SQL NVARCHAR(MAX) = CONCAT(
        '''	N&apos;CREATE SEQUENCE [db [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fResetSeq() As String
            Get
                Return ResourceManager.GetString("fResetSeq", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to --Used in frmProjDetails, frmBasicSearch, frmPatternSearch
        '''--Updates list of EmailID&apos;s in DisplayEmailIDs
        '''--DisplayEmailIDs is the data source for frmEmail
        '''
        '''CREATE OR ALTER PROCEDURE [dbo].[fUpdate_DisplayEmailIDs]
        '''@Where NVARCHAR(MAX),	--Where clause conditions
        '''@Unreviewed BIT,		--Include unreviewed emails
        '''@Reviewed BIT,			--Include reviewed emails
        '''@Types NVARCHAR(100),	--Exemption Types
        '''@Flagged BIT,			--Filter for only emails with Flag in EmailExemptionStatus
        '''@FilterOption TINYINT   --0=Email&amp;A [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fUpdate_DisplayEmailIDs() As String
            Get
                Return ResourceManager.GetString("fUpdate_DisplayEmailIDs", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''-- Updates Inbox.Duplicate to 1 indicating that this is a duplicate email
        '''CREATE OR ALTER   PROCEDURE [dbo].[fUpdateDuplicates]
        '''AS
        '''BEGIN
        '''	-- Reset indicator
        '''	UPDATE dbo.Inbox SET Duplicate=0;
        '''	-- Update indicator
        '''	UPDATE dbo.Inbox
        '''	SET Duplicate=1
        '''	WHERE emailid IN (
        '''		SELECT sub.EmailID
        '''		FROM (
        '''			SELECT ib.ChkSum
        '''				, COUNT(ib.EmailID) OVER (PARTITION BY ChkSum) &quot;ChkSum_Count&quot;
        '''				, ib.EmailID
        '''				-- Prioritize emails with Email/Attachment Exemptions
        '''				, ROW_NUMBER() OVER(PARTITION B [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fUpdateDuplicate() As String
            Get
                Return ResourceManager.GetString("fUpdateDuplicate", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to --Used by frmEmailExemption
        '''--Remove multiple rows from email and attachment exemption tables
        '''CREATE OR ALTER PROCEDURE [dbo].[fUpdateReset]
        '''AS
        '''BEGIN
        '''	--Delete any already existing email exemptions
        '''	DELETE FROM dbo.EmailExemptStatus
        '''	WHERE [EmailID] IN (SELECT [EmailID] FROM dbo.DisplayEmailIDs);
        '''
        '''	--Delete any already existing attachment exemptions
        '''	DELETE dbo.AttachExemptStatus
        '''    WHERE [AttachID] IN (
        '''		SELECT [ID] 
        '''		FROM Attachments 
        '''		WHERE [EmailID] IN (SELECT [EmailID] FROM dbo.Displa [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property fUpdateReset() As String
            Get
                Return ResourceManager.GetString("fUpdateReset", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''/*
        '''This function returns the current user name.
        '''*/
        '''CREATE FUNCTION [dbo].[fUsername]() 
        '''RETURNS VARCHAR(50)
        '''AS
        '''BEGIN
        '''	RETURN (SELECT nt_username FROM sys.sysprocesses WHERE spid = @@SPID);
        '''END;.
        '''</summary>
        Friend ReadOnly Property fUsername() As String
            Get
                Return ResourceManager.GetString("fUsername", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
