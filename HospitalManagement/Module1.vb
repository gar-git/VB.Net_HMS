Imports System.Data
Imports System.Data.OleDb
Module Module1
    Public Adminid As Integer
    Public AdminName As String
    Public AdminPass As String
    Public RecepID As Integer
    Public RecepName As String
    Public con As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\HospitalManagement\HospitalManagement\Hospital.accdb")
    Public cmd As OleDbCommand
    Public myr As OleDbDataReader
    Public da As OleDbDataAdapter
End Module
