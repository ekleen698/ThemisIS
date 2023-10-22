Imports System.Data.SqlClient
Imports ClassLibrary.GlobalObjects

Public Class Server

    Public ReadOnly Property Name() As String
    Public ReadOnly Property Connection() As New SqlConnection
    Public ReadOnly Property IsConnected() As Boolean = False

    Public Sub New(ServerName As String)
        'Instantiate new Server object by connecting to 'master' database on current server.
        'Throws exception

        Try
            'Create server connection
            _Connection.ConnectionString =
                $"Data Source={ServerName};Initial Catalog=Master;Trusted_Connection=Yes;
                Pooling=False;Connection Timeout=10"
            _Connection.Open()

            'Store server properties once connection opens successfully
            _Name = ServerName
            _IsConnected = True

            Logger.WriteToLog($"Connected to server '{_Name}'.")

        Catch ex As Exception
            _Connection = Nothing
            Logger.WriteToLog($"{ex.GetType} occurred while connecting to '{ServerName}'.")
            Logger.WriteToLog(ex.Message)
            Throw New Exception("Failed to connect to SQL Server.", ex)

        End Try

    End Sub

    Public Sub Close()
        'Close server connection

        Try
            _Name = Nothing
            _Connection.Close()
            _IsConnected = False

        Catch

        Finally
            Logger.WriteToLog("Server disconnected.")

        End Try

    End Sub

    Public Sub DropDB(DBName As String)
        'Drop database on current server.
        ' Throws exception

        ' Kill any processes on the target DB, drop DB, then delete row from Directory
        ' NOTE: DROP DATABASE statement cannot be used inside a user transaction.
        With Connection.CreateCommand
            .CommandTimeout = My.Settings.TimeOutSeconds    'set longer timout value to allow for large databases
            .CommandText = $"
                BEGIN
	                DECLARE c CURSOR FOR
		                SELECT spid
		                FROM sys.sysprocesses t
		                WHERE DB_NAME([dbid])=@Name;
	                DECLARE @id INT;
	                DECLARE @sql NVARCHAR(100);

	                OPEN c; 
	                FETCH NEXT FROM c INTO @id; 
		                WHILE @@FETCH_STATUS = 0  
		                BEGIN  
			                SET @sql = CONCAT(N'KILL ', @id);
			                EXEC sp_executesql @sql
			                FETCH NEXT FROM c INTO @id 
		                END 
	                CLOSE c;
	                DEALLOCATE c;

                    SET @sql = CONCAT(N'DROP DATABASE IF EXISTS [', @Name, N'];');
                    EXEC sp_executesql @sql;

                    IF EXISTS (
	                    SELECT 1 FROM sys.databases
	                    WHERE [name]='mlgSys_ProjDir'
	                    )
	                    DELETE FROM mlgSys_ProjDir.dbo.ProjectDirectory
	                    WHERE ProjectDatabase=@Name;

                END"
            .Parameters.Add("@Name", SqlDbType.NVarChar, 25).Value = DBName
            .ExecuteNonQuery()

        End With

        Logger.WriteToLog($"Project database '{DBName}' deleted")

    End Sub

    Public Sub destroy()

        Dim oReader As SqlDataReader

        If MsgBox("Permanently destroy Directory and all Projects?", vbYesNo + vbCritical,
                  "Destroy All") <> MsgBoxResult.Yes Then Exit Sub

        Logger.WriteToLog("Destroying Directory and all Project databases.")

        With _Connection.CreateCommand
            .CommandText = "
                SELECT [name]
                FROM sys.databases
                WHERE [name] LIKE '%mlg%';"
            oReader = .ExecuteReader
        End With

        Try
            Dim sNames As New List(Of String)
            While oReader.Read()
                sNames.Add(oReader("name"))
            End While
            oReader.Close()

            For Each sName In sNames
                DropDB(sName)
            Next

        Catch ex As Exception
            Debug.WriteLine(ex)
            oReader.Close()

        End Try

    End Sub

End Class
