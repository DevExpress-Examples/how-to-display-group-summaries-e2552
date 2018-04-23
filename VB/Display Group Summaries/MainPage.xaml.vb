Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Controls
Imports DevExpress.Data
Imports DevExpress.Xpf.Data
Imports DevExpress.Xpf.Grid

Namespace Display_Group_Summaries
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = New AccountList().GetData()
			grid.GroupBy(grid.Columns("Married"), ColumnSortOrder.Ascending)
		End Sub
		Private Sub CreateGroupSummaries()
			grid.GroupSummary.Add(New GridSummaryItem() With {.FieldName = "Age", .SummaryType = SummaryItemType.Min})
			grid.GroupSummary.Add(New GridSummaryItem() With {.FieldName = "Age", .SummaryType = SummaryItemType.Max})
		End Sub

		Private Sub grid_CustomSummaryExists(ByVal sender As Object, ByVal e As CustomSummaryExistEventArgs)
			e.Exists = e.GroupLevel = 0
		End Sub
	End Class

	Public Class AccountList
		Public Function GetData() As List(Of Account)
			Return CreateAccounts()
		End Function
		Private Function CreateAccounts() As List(Of Account)
			Dim list As New List(Of Account)()
			list.Add(New Account() With {.UserName = "Nick White", .RegistrationDate = DateTime.Today, .Married = True, .Age = 42})
			list.Add(New Account() With {.UserName = "Jack Rodman", .RegistrationDate = New DateTime(2009, 5, 10), .Married = False, .Age = 30})
			list.Add(New Account() With {.UserName = "Sandra Sherry", .RegistrationDate = New DateTime(2008, 12, 22), .Married = False, .Age = 18})
			list.Add(New Account() With {.UserName = "Sabrina Vilk", .RegistrationDate = DateTime.Today, .Married = True, .Age = 24})
			list.Add(New Account() With {.UserName = "Mike Pearson", .RegistrationDate = New DateTime(2008, 10, 18), .Married = True, .Age = 37})
			Return list
		End Function
	End Class
	Public Class Account
		Private privateUserName As String
		Public Property UserName() As String
			Get
				Return privateUserName
			End Get
			Set(ByVal value As String)
				privateUserName = value
			End Set
		End Property
		Private privateRegistrationDate As DateTime
		Public Property RegistrationDate() As DateTime
			Get
				Return privateRegistrationDate
			End Get
			Set(ByVal value As DateTime)
				privateRegistrationDate = value
			End Set
		End Property
		Private privateMarried As Boolean
		Public Property Married() As Boolean
			Get
				Return privateMarried
			End Get
			Set(ByVal value As Boolean)
				privateMarried = value
			End Set
		End Property
		Private privateAge As Integer
		Public Property Age() As Integer
			Get
				Return privateAge
			End Get
			Set(ByVal value As Integer)
				privateAge = value
			End Set
		End Property
	End Class
End Namespace
