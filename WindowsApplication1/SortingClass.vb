Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewColumnSorter
    Implements IComparer
    Public Enum SortOrder
        Ascending
        Descending
    End Enum

    Private mSortColumn As Integer
    Private mSortOrder As SortOrder

    Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)
        mSortColumn = sortColumn
        mSortOrder = sortOrder
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim Result As Integer
        Dim ItemX As ListViewItem
        Dim ItemY As ListViewItem
        ItemX = CType(x, ListViewItem)
        ItemY = CType(y, ListViewItem)
        If mSortColumn = 0 Then
            Result = DateTime.Compare(CType(ItemX.Text, DateTime), CType(ItemY.Text, DateTime))
        Else
            Result = DateTime.Compare(CType(ItemX.SubItems(mSortColumn).Text, DateTime), CType(ItemY.SubItems(mSortColumn).Text, DateTime))
        End If

        If mSortOrder = SortOrder.Descending Then
            Result = -Result
        End If
        Return Result
    End Function
End Class

Public Class ListViewStringSort
    Implements IComparer
    Private mSortColumn As Integer
    Private mSortOrder As SortOrder

    Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)
        mSortColumn = sortColumn
        mSortOrder = sortOrder
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim Result As Integer
        Dim ItemX As ListViewItem
        Dim ItemY As ListViewItem
        ItemX = CType(x, ListViewItem)
        ItemY = CType(y, ListViewItem)
        If mSortColumn = 0 Then
            Result = ItemX.Text.CompareTo(ItemY.Text)
        Else
            Result = ItemX.SubItems(mSortColumn).Text.CompareTo(ItemY.SubItems(mSortColumn).Text)
        End If
        If mSortOrder = SortOrder.Descending Then
            Result = -Result
        End If
        Return Result
    End Function
End Class

Public Class ListViewNumericSort
    Implements IComparer
    Private mSortColumn As Integer
    Private mSortOrder As SortOrder

    Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)
        mSortColumn = sortColumn
        mSortOrder = sortOrder
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim Result As Integer
        Dim ItemX As ListViewItem
        Dim ItemY As ListViewItem
        ItemX = CType(x, ListViewItem)
        ItemY = CType(y, ListViewItem)
        If mSortColumn = 0 Then
            Result = Decimal.Compare(CType(ItemX.Text, Decimal), CType(ItemY.Text, Decimal))
        Else
            Result = Decimal.Compare(CType(ItemX.SubItems(mSortColumn).Text, Decimal), CType(ItemY.SubItems(mSortColumn).Text, Decimal))
        End If
        If mSortOrder = SortOrder.Descending Then
            Result = -Result
        End If
        Return Result
    End Function
End Class

Public Class ListViewDateSort
    Implements IComparer
    Private mSortColumn As Integer
    Private mSortOrder As SortOrder

    Public Sub New(ByVal sortColumn As Integer, ByVal sortOrder As SortOrder)
        mSortColumn = sortColumn
        mSortOrder = sortOrder
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim Result As Integer
        Dim ItemX As ListViewItem
        Dim ItemY As ListViewItem
        ItemX = CType(x, ListViewItem)
        ItemY = CType(y, ListViewItem)
        If mSortColumn = 0 Then
            Result = DateTime.Compare(CType(ItemX.Text, DateTime), CType(ItemY.Text, DateTime))
        Else
            Result = DateTime.Compare(CType(ItemX.SubItems(mSortColumn).Text, DateTime), CType(ItemY.SubItems(mSortColumn).Text, DateTime))
        End If
        If mSortOrder = SortOrder.Descending Then
            Result = -Result
        End If
        Return Result
    End Function
End Class