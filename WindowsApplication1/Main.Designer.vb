<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnFormat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnDossier = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonFolder = New System.Windows.Forms.Button()
        Me.LabelDossierText = New System.Windows.Forms.Label()
        Me.ButtonScan = New System.Windows.Forms.Button()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.CheckBoxEffacerListe = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDossier = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGet2FirstFolders = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.SystemColors.Window
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnNom, Me.ColumnSize, Me.ColumnFormat, Me.ColumnDossier, Me.ColumnPath})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(131, 67)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(619, 434)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnNom
        '
        Me.ColumnNom.Text = "Nom du Film :"
        Me.ColumnNom.Width = 340
        '
        'ColumnSize
        '
        Me.ColumnSize.Text = "Taille :"
        Me.ColumnSize.Width = 100
        '
        'ColumnFormat
        '
        Me.ColumnFormat.Text = "Format :"
        '
        'ColumnDossier
        '
        Me.ColumnDossier.DisplayIndex = 4
        Me.ColumnDossier.Text = "Dossier"
        Me.ColumnDossier.Width = 115
        '
        'ColumnPath
        '
        Me.ColumnPath.DisplayIndex = 3
        Me.ColumnPath.Width = 0
        '
        'ButtonFolder
        '
        Me.ButtonFolder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonFolder.Location = New System.Drawing.Point(12, 22)
        Me.ButtonFolder.Name = "ButtonFolder"
        Me.ButtonFolder.Size = New System.Drawing.Size(109, 23)
        Me.ButtonFolder.TabIndex = 1
        Me.ButtonFolder.Text = "Dossier à scanner"
        Me.ButtonFolder.UseVisualStyleBackColor = True
        '
        'LabelDossierText
        '
        Me.LabelDossierText.Location = New System.Drawing.Point(128, 27)
        Me.LabelDossierText.Name = "LabelDossierText"
        Me.LabelDossierText.Size = New System.Drawing.Size(622, 18)
        Me.LabelDossierText.TabIndex = 2
        '
        'ButtonScan
        '
        Me.ButtonScan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonScan.Location = New System.Drawing.Point(12, 67)
        Me.ButtonScan.Name = "ButtonScan"
        Me.ButtonScan.Size = New System.Drawing.Size(109, 23)
        Me.ButtonScan.TabIndex = 3
        Me.ButtonScan.Text = "Scan"
        Me.ButtonScan.UseVisualStyleBackColor = True
        '
        'ButtonExport
        '
        Me.ButtonExport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonExport.Location = New System.Drawing.Point(12, 478)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(109, 23)
        Me.ButtonExport.TabIndex = 4
        Me.ButtonExport.Text = "Exporter"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.FolderBrowserDialog.ShowNewFolderButton = False
        '
        'CheckBoxEffacerListe
        '
        Me.CheckBoxEffacerListe.AutoSize = True
        Me.CheckBoxEffacerListe.Location = New System.Drawing.Point(12, 96)
        Me.CheckBoxEffacerListe.Name = "CheckBoxEffacerListe"
        Me.CheckBoxEffacerListe.Size = New System.Drawing.Size(92, 17)
        Me.CheckBoxEffacerListe.TabIndex = 5
        Me.CheckBoxEffacerListe.Text = "Effacer la liste"
        Me.CheckBoxEffacerListe.UseVisualStyleBackColor = True
        '
        'CheckBoxDossier
        '
        Me.CheckBoxDossier.Location = New System.Drawing.Point(12, 424)
        Me.CheckBoxDossier.Name = "CheckBoxDossier"
        Me.CheckBoxDossier.Size = New System.Drawing.Size(106, 48)
        Me.CheckBoxDossier.TabIndex = 6
        Me.CheckBoxDossier.Text = "Ajouter le chemin du fichier"
        Me.CheckBoxDossier.UseVisualStyleBackColor = True
        '
        'CheckBoxGet2FirstFolders
        '
        Me.CheckBoxGet2FirstFolders.Location = New System.Drawing.Point(12, 368)
        Me.CheckBoxGet2FirstFolders.Name = "CheckBoxGet2FirstFolders"
        Me.CheckBoxGet2FirstFolders.Size = New System.Drawing.Size(106, 50)
        Me.CheckBoxGet2FirstFolders.TabIndex = 7
        Me.CheckBoxGet2FirstFolders.Text = "Garder seulement les 2 premiers dossiers"
        Me.CheckBoxGet2FirstFolders.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(766, 513)
        Me.Controls.Add(Me.CheckBoxGet2FirstFolders)
        Me.Controls.Add(Me.CheckBoxDossier)
        Me.Controls.Add(Me.CheckBoxEffacerListe)
        Me.Controls.Add(Me.ButtonExport)
        Me.Controls.Add(Me.ButtonScan)
        Me.Controls.Add(Me.LabelDossierText)
        Me.Controls.Add(Me.ButtonFolder)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liste de Film"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnNom As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnFormat As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonFolder As System.Windows.Forms.Button
    Friend WithEvents LabelDossierText As System.Windows.Forms.Label
    Friend WithEvents ButtonScan As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ColumnPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents CheckBoxEffacerListe As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnDossier As ColumnHeader
    Friend WithEvents CheckBoxDossier As CheckBox
    Friend WithEvents CheckBoxGet2FirstFolders As CheckBox
End Class
