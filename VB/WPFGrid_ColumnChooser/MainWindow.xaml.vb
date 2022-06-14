Imports DevExpress.Xpf.Grid
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Controls

Namespace WPFGrid_ColumnChooser

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim items As ObservableCollection(Of Item) = New ObservableCollection(Of Item)()
            For i As Integer = 1 To 30 - 1
                items.Add(New Item() With {.Id = i, .Name = "Name" & i})
            Next

            Me.grid.ItemsSource = items
            Me.view.ShowColumnChooser()
        End Sub
    End Class

    Public Class Item

        Public Property Id As Integer

        Public Property Name As String
    End Class

    Public Class HeaderTemplateSelector
        Inherits DataTemplateSelector

        Public Property ColumnChooserTemplate As DataTemplate

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            If ColumnBase.GetHeaderPresenterType(container) = HeaderPresenterType.ColumnChooser AndAlso Equals(CStr(item), NameOf(WPFGrid_ColumnChooser.Item.Id)) Then Return ColumnChooserTemplate
            Return MyBase.SelectTemplate(item, container)
        End Function
    End Class
End Namespace
