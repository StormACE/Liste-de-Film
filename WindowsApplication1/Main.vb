Imports System.IO
Imports Microsoft.Win32
Imports System.Text

''' <summary>
''' Liste de Film 1.1.0.6
''' 17 février 2014 au 1 mars 2016
''' Work on Windows 7 sp1, 8, 8.1, 10. Need .Net Framework 4.0
''' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
''' Changes log:
''' 01/03/2016 By StormAce
''' - Ajouté, Tooltips au controls.
''' - Ajouté, Option pour mettre le dossier du fichier en premier dans la liste.
''' - Ajouté, Option pour mettre les 2 premier sous-dossiers à partir du fichier
''' - Ajouté, Recherche d'extention ".m2ts" et ".iso" 
''' - Réparé, la taille des fichiers
''' - Réparé, Quelques bogues mineurs
''' </summary>


Public Class Main

#Region "Declarations"
    Private Scandir As String
    Dim regKey As RegistryKey
    Dim NumberFilm As Integer = 0
    Dim NomLogiciel As String = "Liste de Film " & String.Format("Version {0}", My.Application.Info.Version.ToString) & "  " & System.IO.File.GetLastWriteTime(System.AppDomain.CurrentDomain.BaseDirectory & "Liste de Film.exe").ToLongDateString() & "  " & My.Application.Info.Copyright
#End Region

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateRegKey()

        ListView1.Columns(0).Tag = "String"
        ListView1.Columns(1).Tag = "String"

        regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\DossierScan", True)
        If regKey IsNot Nothing Then
            Scandir = regKey.GetValue("", "")
            LabelDossierText.Text = Scandir
        Else
            LabelDossierText.Text = "Chemin du dossier à scanner"
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\EffacerListe", True)
        If regKey IsNot Nothing Then
            CheckBoxEffacerListe.Checked = regKey.GetValue("", "")
        Else
            CheckBoxEffacerListe.Checked = True
        End If

        Text = NomLogiciel & "    Film : " & NumberFilm

        Dim ButtonFolderToolTip As New ToolTip
        ButtonFolderToolTip.ToolTipTitle = "Choisir la Source"
        ButtonFolderToolTip.ToolTipIcon = ToolTipIcon.Info
        ButtonFolderToolTip.UseFading = True
        ButtonFolderToolTip.UseAnimation = True
        ButtonFolderToolTip.IsBalloon = True
        ButtonFolderToolTip.ShowAlways = True
        ButtonFolderToolTip.AutoPopDelay = 5000
        ButtonFolderToolTip.InitialDelay = 1000
        ButtonFolderToolTip.ReshowDelay = 500
        ButtonFolderToolTip.SetToolTip(ButtonFolder, "Un Dossier ou un Disque.")

        Dim ButtonScanToolTip As New ToolTip
        ButtonScanToolTip.ToolTipTitle = "Scanner"
        ButtonScanToolTip.ToolTipIcon = ToolTipIcon.Info
        ButtonScanToolTip.UseFading = True
        ButtonScanToolTip.UseAnimation = True
        ButtonScanToolTip.IsBalloon = True
        ButtonScanToolTip.ShowAlways = True
        ButtonScanToolTip.AutoPopDelay = 5000
        ButtonScanToolTip.InitialDelay = 1000
        ButtonScanToolTip.ReshowDelay = 500
        ButtonScanToolTip.SetToolTip(ButtonScan, "Le dossier ou le disque choisi")

        Dim CheckBoxEffacerToolTip As New ToolTip
        CheckBoxEffacerToolTip.ToolTipTitle = "Effacer"
        CheckBoxEffacerToolTip.ToolTipIcon = ToolTipIcon.Info
        CheckBoxEffacerToolTip.UseFading = True
        CheckBoxEffacerToolTip.UseAnimation = True
        CheckBoxEffacerToolTip.IsBalloon = True
        CheckBoxEffacerToolTip.ShowAlways = True
        CheckBoxEffacerToolTip.AutoPopDelay = 5000
        CheckBoxEffacerToolTip.InitialDelay = 1000
        CheckBoxEffacerToolTip.ReshowDelay = 500
        CheckBoxEffacerToolTip.SetToolTip(CheckBoxEffacerListe, "La Liste avant le Scan")


        Dim CheckBoxDossierToolTip As New ToolTip
        CheckBoxDossierToolTip.ToolTipTitle = "Ajouter les Dossiers"
        CheckBoxDossierToolTip.ToolTipIcon = ToolTipIcon.Info
        CheckBoxDossierToolTip.UseFading = True
        CheckBoxDossierToolTip.UseAnimation = True
        CheckBoxDossierToolTip.IsBalloon = True
        CheckBoxDossierToolTip.ShowAlways = True
        CheckBoxDossierToolTip.AutoPopDelay = 5000
        CheckBoxDossierToolTip.InitialDelay = 1000
        CheckBoxDossierToolTip.ReshowDelay = 500
        CheckBoxDossierToolTip.SetToolTip(CheckBoxDossier, "En premier dans la Liste")

        Dim ButtonExportToolTip As New ToolTip
        ButtonExportToolTip.ToolTipTitle = "Exporter"
        ButtonExportToolTip.ToolTipIcon = ToolTipIcon.Info
        ButtonExportToolTip.UseFading = True
        ButtonExportToolTip.UseAnimation = True
        ButtonExportToolTip.IsBalloon = True
        ButtonExportToolTip.ShowAlways = True
        ButtonExportToolTip.AutoPopDelay = 5000
        ButtonExportToolTip.InitialDelay = 1000
        ButtonExportToolTip.ReshowDelay = 500
        ButtonExportToolTip.SetToolTip(ButtonExport, "La Liste en Format "".txt""")

        Dim LabelDossierTextToolTip As New ToolTip
        LabelDossierTextToolTip.ToolTipTitle = "Dossier"
        LabelDossierTextToolTip.ToolTipIcon = ToolTipIcon.Info
        LabelDossierTextToolTip.UseFading = True
        LabelDossierTextToolTip.UseAnimation = True
        LabelDossierTextToolTip.IsBalloon = True
        LabelDossierTextToolTip.ShowAlways = True
        LabelDossierTextToolTip.AutoPopDelay = 5000
        LabelDossierTextToolTip.InitialDelay = 1000
        LabelDossierTextToolTip.ReshowDelay = 500
        LabelDossierTextToolTip.SetToolTip(LabelDossierText, "Choisi pour Scanner")
    End Sub

    Private Sub ListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        SortMyListView(Me.ListView1, e.Column, , True)
    End Sub

    Private Sub ListView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim FilePath As String = ListView1.SelectedItems(0).SubItems(3).Text
            Process.Start(FilePath)
        End If
    End Sub

    Private Sub ButtonFolder_Click(sender As Object, e As EventArgs) Handles ButtonFolder.Click
        FolderBrowserDialog.Description = "Choisisser le dossier contenant vos Films (Vidéos)"
        FolderBrowserDialog.SelectedPath = LabelDossierText.Text
        Dim dlgResult As DialogResult = FolderBrowserDialog.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Scandir = FolderBrowserDialog.SelectedPath & "\"
            LabelDossierText.Text = Scandir
            regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\DossierScan", True)
            If regKey IsNot Nothing Then
                regKey.SetValue("", Scandir)
            Else
                regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options", True)
                regKey.CreateSubKey("DossierScan")
                regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\DossierScan", True)
                If regKey IsNot Nothing Then
                    regKey.SetValue("", Scandir)
                End If
            End If
        End If
    End Sub

    Private Sub ButtonScan_Click(sender As Object, e As EventArgs) Handles ButtonScan.Click
        If Scandir IsNot Nothing Then
            If CheckBoxEffacerListe.Checked = True Then
                ListView1.Items.Clear()
                NumberFilm = 0
            End If

            GetFiles(Scandir)
            Text = NomLogiciel & "    Film : " & NumberFilm
        Else
            MessageBox.Show("Vous devez choisir un dossier avant de scanner!", NomLogiciel, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        Dim count = ListView1.Items.Count
        If count > 0 Then
            SaveFileDialog.Title = NomLogiciel & " Exporter vers un fichier text"
            SaveFileDialog.DefaultExt = "txt"
            SaveFileDialog.Filter = "Fichier Texte (*.txt)|*.txt"
            SaveFileDialog.FilterIndex = 1
            SaveFileDialog.ShowDialog()

            If SaveFileDialog.FileName = "" Then Exit Sub
            Dim sb As New StringBuilder()
            For Each lvItem As ListViewItem In ListView1.Items
                If CheckBoxDossier.Checked = False And CheckBoxGet2FirstFolders.Checked = False Then
                    sb.AppendLine(lvItem.Text & " " & lvItem.SubItems(1).Text & " " & lvItem.SubItems(2).Text)
                ElseIf CheckBoxDossier.Checked = True And CheckBoxGet2FirstFolders.Checked = False Then
                    sb.AppendLine(lvItem.SubItems(3).Text & " " & lvItem.Text & " " & lvItem.SubItems(1).Text & "  Format : " & lvItem.SubItems(2).Text)
                ElseIf CheckBoxDossier.Checked = False And CheckBoxGet2FirstFolders.Checked = True Then
                    Dim path As String = GetFirstFoldername(lvItem.SubItems(3).Text)
                    sb.AppendLine(path & " " & lvItem.Text & " " & lvItem.SubItems(1).Text & "  Format : " & lvItem.SubItems(2).Text)
                End If
            Next

            Using outfile As New StreamWriter(SaveFileDialog.FileName, False, System.Text.Encoding.Default)
                outfile.Write(sb.ToString())
            End Using
            MessageBox.Show("La liste a été exporté avec succès!", NomLogiciel, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Il n'y a aucun Film dans la liste, Exportation avortée!!", NomLogiciel, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function GetFirstFoldername(path As String) As String
        Dim position As Integer = InStrRev(path, "\")
        position = InStrRev(path, "\", position - 1)
        position = InStrRev(path, "\", position - 1)
        Return Strings.Right(path, Strings.Len(path) - position + 1)
    End Function

    Private Sub GetFiles(ByVal folder As String)

        For Each file As String In Directory.GetFiles(folder)
            Dim FileName As String = Path.GetFileNameWithoutExtension(file)
            Dim objItem As ListViewItem

            Dim Xtension As String = Path.GetExtension(file) 'determine extension

            If Xtension.ToLower = ".avi" OrElse Xtension = ".mkv" OrElse Xtension = ".mp4" OrElse Xtension = ".m4v" OrElse Xtension = ".mov" OrElse Xtension = ".flv" OrElse Xtension = ".mpg" OrElse Xtension = ".mpeg" OrElse Xtension = ".3gp" OrElse Xtension = ".wmv" OrElse Xtension = ".iso" OrElse Xtension = ".m2ts" Then
                Dim size As Double = Getsize(file)


                If size >= 1073741824.0 Then
                    size = (((size / 1024) / 1024) / 1024)
                    'Add to listview
                    objItem = ListView1.Items.Add(FileName)
                    With objItem
                        .SubItems.Add(size.ToString("F2") & " GB")
                        .SubItems.Add(Xtension.ToLower.Remove(0, 1))
                        .SubItems.Add(file)
                    End With
                Else
                    size = ((size / 1024) / 1024)
                    'Add to listview
                    objItem = ListView1.Items.Add(FileName)
                    With objItem
                        .SubItems.Add(size.ToString("F2") & " MB")
                        .SubItems.Add(Xtension.ToLower.Remove(0, 1))
                        .SubItems.Add(file)
                    End With
                End If
                NumberFilm += 1
            End If
        Next file

        For Each subfolder As String In Directory.GetDirectories(folder)
            Me.GetFiles(subfolder)
        Next subfolder
    End Sub

    Private Sub CreateRegKey()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software", True)
            regKey.CreateSubKey("Liste de Film")
        End If
        regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film", True)
            regKey.CreateSubKey("Options")
        End If
    End Sub

    Private Function Getsize(file As String) As Double
        Dim myFile As New FileInfo(file)
        Dim sizeInBytes As Double = myFile.Length
        Return sizeInBytes
    End Function

    Friend Sub SortMyListView(ByVal ListViewToSort As ListView, ByVal ColumnNumber As Integer, Optional ByVal Resort As Boolean = False, Optional ByVal ForceSort As Boolean = False)
        ' Sorts a list view column by string, number, or date.  The three types of sorts must be specified within the listview columns "tag" property unless the ForceSort option is enabled.
        ' ListViewToSort - The listview to sort
        ' ColumnNumber - The column number to sort by
        ' Resort - Resorts a listview in the same direction as the last sort
        ' ForceSort - Forces a sort even if no listview tag data exists and assumes a string sort.  If this is false (default) and no tag is specified the procedure will exit
        Dim SortOrder As SortOrder
        Static LastSortColumn As Integer = -1
        Static LastSortOrder As SortOrder = SortOrder.Ascending
        If Resort = True Then
            SortOrder = LastSortOrder
        Else
            If LastSortColumn = ColumnNumber Then
                If LastSortOrder = SortOrder.Ascending Then
                    SortOrder = SortOrder.Descending
                Else
                    SortOrder = SortOrder.Ascending
                End If
            Else
                SortOrder = SortOrder.Ascending
            End If
        End If

        ' In case a tag wasn't specified check if we should force a string sort
        If String.IsNullOrEmpty(CStr(ListViewToSort.Columns(ColumnNumber).Tag)) Then
            If ForceSort = True Then
                ListViewToSort.Columns(ColumnNumber).Tag = "String"
            Else
                ' don't sort since no tag was specified.
                Exit Sub
            End If
        End If

        Select Case ListViewToSort.Columns(ColumnNumber).Tag.ToString
            Case "Numeric"
                ListViewToSort.ListViewItemSorter = New ListViewNumericSort(ColumnNumber, SortOrder)
            Case "Date"
                ListViewToSort.ListViewItemSorter = New ListViewDateSort(ColumnNumber, SortOrder)
            Case "String"
                ListViewToSort.ListViewItemSorter = New ListViewStringSort(ColumnNumber, SortOrder)
        End Select
        LastSortColumn = ColumnNumber
        LastSortOrder = SortOrder
        ListViewToSort.ListViewItemSorter = Nothing
    End Sub

    Private Sub CheckBoxEffacerListe_Click(sender As Object, e As EventArgs) Handles CheckBoxEffacerListe.Click
        If CheckBoxEffacerListe.Checked = True Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\EffacerListe", True)
            If regKey IsNot Nothing Then
                regKey.SetValue("", True)
            Else
                regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options", True)
                regKey.CreateSubKey("EffacerListe")
                regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\EffacerListe", True)
                If regKey IsNot Nothing Then
                    regKey.SetValue("", True)
                End If
            End If
        Else
            regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\EffacerListe", True)
            If regKey IsNot Nothing Then
                regKey.SetValue("", False)
            Else
                regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options", True)
                regKey.CreateSubKey("EffacerListe")
                regKey = Registry.CurrentUser.OpenSubKey("Software\Liste de Film\Options\EffacerListe", True)
                If regKey IsNot Nothing Then
                    regKey.SetValue("", False)
                End If
            End If
        End If
    End Sub

    Private Sub CheckBoxGet2FirstFolders_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGet2FirstFolders.CheckedChanged
        If CheckBoxGet2FirstFolders.Checked = True Then
            CheckBoxDossier.Checked = False
        End If
    End Sub

    Private Sub CheckBoxDossier_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDossier.CheckedChanged
        If CheckBoxDossier.Checked = True Then
            CheckBoxGet2FirstFolders.Checked = False
        End If
    End Sub
End Class
