'DataBaseServices
'Different services for database connections and queries
'Database is a MariaDB running on a QNap. Connector is the MySQL-Connector from Oracle
'Copyright (C)2019,2020 by Christian Brunner

Imports System
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class service_GetDataBaseInfos

    Public Function _returnConnectionString()
        Static MySQLCS As New MySqlConnectionStringBuilder
        MySQLCS.Server = "?"
        MySQLCS.Port = 50000
        MySQLCS.Database = "?"
        MySQLCS.UserID = "?"
        MySQLCS.Password = "?"
        MySQLCS.UseCompression = vbTrue
        Return MySQLCS.ConnectionString
    End Function

End Class

Public Class service_CheckLogin

    Private Success As Boolean = vbFalse

    Public Sub _checkLogin(UserName As String, Password As String)
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        Connection.ConnectionString = ConnectionString
        Dim hashPassword As New hashString
        Dim HashedPassword As String = hashPassword.returnHashedValue(Password)

        Dim SQLQueryString As String =
            "UPDATE users SET user_last_login = CURRENT_TIMESTAMP
              WHERE user_id = ?PARM_USER_ID AND user_password = ?PARM_USER_PASSWORD AND IFNULL(user_status, '0') = '1'"
        Try
            Connection.Open()
            Dim SQLCommand As New MySqlCommand(SQLQueryString, Connection)
            SQLCommand.Parameters.Add("?PARM_USER_ID", MySqlDbType.VarChar).Value = UserName
            SQLCommand.Parameters.Add("?PARM_USER_PASSWORD", MySqlDbType.VarChar).Value = HashedPassword
            Success = (SQLCommand.ExecuteNonQuery > 0)
            Connection.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            Success = vbFalse
        End Try
    End Sub

    Public Function _returnCheckLogin()
        Return Success
    End Function

End Class

Public Class service_CheckVersion

    Private Success As Boolean = vbFalse
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
            NewExpeditionID = Convert.ToInt32(SQLReader(0).ToString)
            Exit While
        End While
        IDConnection.Close()

        Return NewExpeditionID
    End Function

End Class

Public Class service_GetNewCashFlowID

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
            NewCashFlowID = Convert.ToInt32(SQLReader(0).ToString)
            Exit While
        End While
        IDConnection.Close()

        Return NewCashFlowID
    End Function

End Class

Public Class service_CheckSecurity

    Private Success As Boolean
    Private SecUser As Boolean
    Private SecMember As Boolean
    Private SecExpedition As Boolean
    Private SecCash As Boolean

    Public Sub _checkSecurity(ByVal pUser As String, ByVal pFunction As String)
        Dim Connection As New MySqlConnection
        Dim returnConnection As New service_GetDataBaseInfos
        Dim ConnectionString As String = returnConnection._returnConnectionString()
        Connection.ConnectionString = ConnectionString
        Connection.Open()
        Dim QueryString As String =
            "SELECT IFNULL(user_sec_user, 0), IFNULL(user_sec_member, 0), IFNULL(user_sec_expedition, 0), IFNULL(user_sec_cash, 0)
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
            Exit While
        End While
        Connection.Close()

        If pFunction = "USER" And SecUser Then
            Success = vbTrue
        ElseIf pFunction = "MEMBER" And SecMember Then
            Success = vbTrue
        ElseIf pFunction = "EXPEDITION" And SecExpedition Then
            Success = vbTrue
        ElseIf pFunction = "CASH" And SecCash Then
            Success = vbTrue
        Else
            Success = vbFalse
        End If

    End Sub

    Public Function _returnSecurityCheck()
        Return Success
    End Function


End Class