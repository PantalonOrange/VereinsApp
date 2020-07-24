'DataBaseServices
'Different services for database connections and queries
'Database is a MariaDB running on a QNap. Connector is the MySQL-Connector from Oracle
'For the future add tls connection to MySQLCS
'Copyright (C)2019,2020 by Christian Brunner

Imports MySql.Data.MySqlClient

Public Class service_GetDataBaseInfos
    'Create and return the connectionstring for db-connection

    Public Function _returnConnectionString()
        Dim DatabaseSettings As StructDataBaseConnect = frmLogin.AppSettings
        Static MySQLCS As New MySqlConnectionStringBuilder
        MySQLCS.Server = DatabaseSettings.Server
        MySQLCS.Port = Convert.ToUInt32(DatabaseSettings.Port)
        MySQLCS.Database = DatabaseSettings.Database
        MySQLCS.UserID = DatabaseSettings.UserID
        MySQLCS.Password = DatabaseSettings.Password
        MySQLCS.UseCompression = True
        Return MySQLCS.ConnectionString
    End Function

End Class

Public Class service_CheckLogin
    'Set the last login date to current user, if fail the user or/and the password was wrong

    Private Success As Boolean = False
    Private HostName As String = Net.Dns.GetHostName()
#Disable Warning BC40000 ' Typ oder Element ist veraltet
    Private IPAddress As String = Net.Dns.GetHostByName(HostName).AddressList(0).ToString()
#Enable Warning BC40000 ' Typ oder Element ist veraltet

    Public Sub _checkLogin(pUserName As String, pPassword As String)
        'Incoming values: Username, Password (md5 hash)
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Connection.ConnectionString = returnConnection._returnConnectionString()
        Dim hashPassword As New service_hashString
        Dim HashedPassword As String = hashPassword.returnHashedValue(pPassword)

        Dim SQLQueryString As String =
            "UPDATE users
                SET user_last_login = CURRENT_TIMESTAMP,
                    user_last_ip = NULLIF(?PARM_LAST_IP, ''),
                    user_last_host = NULLIF(?PARM_LAST_HOST, '')
              WHERE user_id = ?PARM_USER_ID AND user_password = ?PARM_USER_PASSWORD AND IFNULL(user_status, '0') = '1'"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.Add("?PARM_LAST_IP", MySqlDbType.VarChar).Value = IPAddress
            SQLCommand.Parameters.Add("?PARM_LAST_HOST", MySqlDbType.VarChar).Value = HostName
            SQLCommand.Parameters.Add("?PARM_USER_ID", MySqlDbType.VarChar).Value = pUserName
            SQLCommand.Parameters.Add("?PARM_USER_PASSWORD", MySqlDbType.VarChar).Value = HashedPassword
            Success = (SQLCommand.ExecuteNonQuery > 0)
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            Success = False
        End Try
    End Sub

    Public Function _returnCheckLogin()
        Return Success
    End Function

End Class

Public Class service_CheckVersion
    'Check the databaseversion with the app-version

    Private Success As Boolean = False
    Private returnAppVersion As New service_ReturnAppVersion
    Private AppVersion As String = returnAppVersion._appVersion


    Public Sub _checkAppVersion()
        Dim dbAppVersion As String = "0"
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        Connection.ConnectionString = ConnectionString
        Try
            Connection.Open()
            Dim QueryString As String =
                "SELECT sys_value FROM system WHERE sys_key = 'version'"
            Dim QueryCommand As New MySqlCommand(QueryString, Connection)
            Dim SQLReader As MySqlDataReader
            SQLReader = QueryCommand.ExecuteReader
            While (SQLReader.Read)
                dbAppVersion = SQLReader(0).ToString
                Exit While
            End While
            Connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Success = (dbAppVersion = AppVersion)
    End Sub

    Public Function _returnCheckResult()
        Return Success
    End Function

End Class

Public Class service_GetSystemValue
    'Read the systemvalue for submitted key

    Private SystemValue As String

    Public Sub _getSystemValue(ByVal pKey As String)
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        Connection.ConnectionString = ConnectionString
        Try
            Connection.Open()
            Dim QueryString As String =
                "SELECT sys_value FROM system WHERE sys_key = ?PARM_KEY"
            Dim QueryCommand As New MySqlCommand(QueryString, Connection)
            QueryCommand.Parameters.Add("?PARM_KEY", MySqlDbType.VarChar).Value = pKey
            Dim SQLReader As MySqlDataReader
            SQLReader = QueryCommand.ExecuteReader
            While (SQLReader.Read)
                SystemValue = SQLReader(0).ToString
                Exit While
            End While
            Connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Datenbankfehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function _returnSystemValue()
        Return SystemValue
    End Function

End Class

Public Class service_GetNewMemberID
    'Get the next member id and return this value

    Private NewMemberID As Integer

    Public Function _getNewMemberID()
        Dim IDConnection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        IDConnection.ConnectionString = ConnectionString
        IDConnection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(NULLIF(MAX(mem_id), 0), 0) + 1 FROM members"
        Dim QueryCommand As New MySqlCommand(QueryString, IDConnection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            NewMemberID = Convert.ToInt32(SQLReader(0).ToString)
            Exit While
        End While
        IDConnection.Close()

        Return NewMemberID
    End Function

End Class

Public Class service_GetNewExpeditionID
    'Get the next expedition id and return this value

    Private NewExpeditionID As Long

    Public Function _getNewExpeditionID()
        Dim IDConnection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        IDConnection.ConnectionString = ConnectionString
        IDConnection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(NULLIF(MAX(exp_id), 0), 0) + 1 FROM expeditions"
        Dim QueryCommand As New MySqlCommand(QueryString, IDConnection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            NewExpeditionID = Convert.ToInt64(SQLReader(0).ToString)
            Exit While
        End While
        IDConnection.Close()

        Return NewExpeditionID
    End Function

End Class

Public Class service_GetNewCashFlowID
    'Get the next cash flow id and return this value

    Private NewCashFlowID As Long

    Public Function _getNewCashFlowID()
        Dim IDConnection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        IDConnection.ConnectionString = ConnectionString
        IDConnection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(NULLIF(MAX(flow_id), 0), 0) + 1 FROM cashflow"
        Dim QueryCommand As New MySqlCommand(QueryString, IDConnection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            NewCashFlowID = Convert.ToInt64(SQLReader(0).ToString)
            Exit While
        End While
        IDConnection.Close()

        Return NewCashFlowID
    End Function

End Class

Public Class service_GetNewDocumentID
    'Get the next document id and return this value

    Private NewDocumentID As Long

    Public Function _getNewDocumentID()
        Dim IDConnection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        IDConnection.ConnectionString = ConnectionString
        IDConnection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(NULLIF(MAX(doc_id), 0), 0) + 1 FROM documents"
        Dim QueryCommand As New MySqlCommand(QueryString, IDConnection)
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            NewDocumentID = Convert.ToInt64(SQLReader(0).ToString)
            Exit While
        End While
        IDConnection.Close()

        Return NewDocumentID
    End Function

End Class

Public Class service_CheckSecurity
    'This function checks the security permission for the user and return the result as boolean success

    Private Success As Boolean
    Private SecUser As Boolean
    Private SecMember As Boolean
    Private SecExpedition As Boolean
    Private SecCash As Boolean
    Private SecDocuments As Boolean

    Public Sub _checkSecurity(ByVal pUser As String, ByVal pFunction As String)
        'Incoming values: Username, Function to check
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(user_sec_user, 0), IFNULL(user_sec_member, 0), IFNULL(user_sec_expedition, 0), 
                    IFNULL(user_sec_cash, 0), IFNULL(user_sec_documents, 0)
               FROM users WHERE user_id = ?PARM_USER_ID"
        Dim QueryCommand As New MySqlCommand(QueryString, Connection)
        QueryCommand.Parameters.Add("?PARM_USER_ID", MySqlDbType.VarChar).Value = pUser
        QueryCommand.Parameters.Add("?PARM_USER_FUNCTION", MySqlDbType.VarChar).Value = pFunction
        Dim SQLReader As MySqlDataReader
        SQLReader = QueryCommand.ExecuteReader
        While (SQLReader.Read)
            SecUser = Convert.ToInt16(SQLReader(0).ToString)
            SecMember = Convert.ToInt16(SQLReader(1).ToString)
            SecExpedition = Convert.ToInt16(SQLReader(2).ToString)
            SecCash = Convert.ToInt16(SQLReader(3).ToString)
            SecDocuments = Convert.ToInt16(SQLReader(4).ToString)
            Exit While
        End While
        Connection.Close()

        If pFunction = "USER" And SecUser Then
            Success = True
        ElseIf pFunction = "MEMBER" And SecMember Then
            Success = True
        ElseIf pFunction = "EXPEDITION" And SecExpedition Then
            Success = True
        ElseIf pFunction = "CASH" And SecCash Then
            Success = True
        ElseIf pFunction = "DOCUMENTS" And SecDocuments Then
            Success = True
        Else
            Success = False
        End If

    End Sub

    Public Function _returnSecurityCheck()
        'Outgoing value: Boolean success
        Return Success
    End Function


End Class