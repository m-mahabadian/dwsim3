<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProps
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProps))
        Me.LblStatusObj = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblTipoObj = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FTSProps = New FarsiLibrary.Win.FATabStrip()
        Me.TSProps = New FarsiLibrary.Win.FATabStripItem()
        Me.PGEx1 = New PropertyGridEx.PropertyGridEx()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TSObj = New FarsiLibrary.Win.FATabStripItem()
        Me.PGEx2 = New PropertyGridEx.PropertyGridEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblNomeObj = New System.Windows.Forms.Label()
        Me.sfdxml1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.FTSProps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FTSProps.SuspendLayout()
        Me.TSProps.SuspendLayout()
        Me.TSObj.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblStatusObj
        '
        resources.ApplyResources(Me.LblStatusObj, "LblStatusObj")
        Me.LblStatusObj.Name = "LblStatusObj"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'LblTipoObj
        '
        resources.ApplyResources(Me.LblTipoObj, "LblTipoObj")
        Me.LblTipoObj.Name = "LblTipoObj"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'FTSProps
        '
        Me.FTSProps.AlwaysShowClose = False
        resources.ApplyResources(Me.FTSProps, "FTSProps")
        Me.FTSProps.Items.AddRange(New FarsiLibrary.Win.FATabStripItem() {Me.TSProps, Me.TSObj})
        Me.FTSProps.Name = "FTSProps"
        Me.FTSProps.SelectedItem = Me.TSProps
        '
        'TSProps
        '
        Me.TSProps.CanClose = False
        Me.TSProps.Controls.Add(Me.PGEx1)
        Me.TSProps.IsDrawn = True
        Me.TSProps.Name = "TSProps"
        Me.TSProps.Selected = True
        resources.ApplyResources(Me.TSProps, "TSProps")
        '
        'PGEx1
        '
        '
        '
        '
        Me.PGEx1.DocCommentDescription.AccessibleName = ""
        Me.PGEx1.DocCommentDescription.AutoEllipsis = True
        Me.PGEx1.DocCommentDescription.BackColor = System.Drawing.Color.Transparent
        Me.PGEx1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx1.DocCommentDescription.ImeMode = CType(resources.GetObject("PGEx1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx1.DocCommentDescription.Location = CType(resources.GetObject("PGEx1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PGEx1.DocCommentDescription.Name = ""
        Me.PGEx1.DocCommentDescription.Size = CType(resources.GetObject("PGEx1.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PGEx1.DocCommentDescription.TabIndex = CType(resources.GetObject("PGEx1.DocCommentDescription.TabIndex"), Integer)
        Me.PGEx1.DocCommentImage = Nothing
        '
        '
        '
        Me.PGEx1.DocCommentTitle.BackColor = System.Drawing.Color.Transparent
        Me.PGEx1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx1.DocCommentTitle.Font = CType(resources.GetObject("PGEx1.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PGEx1.DocCommentTitle.ImeMode = CType(resources.GetObject("PGEx1.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx1.DocCommentTitle.Location = CType(resources.GetObject("PGEx1.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PGEx1.DocCommentTitle.Name = ""
        Me.PGEx1.DocCommentTitle.Size = CType(resources.GetObject("PGEx1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PGEx1.DocCommentTitle.TabIndex = CType(resources.GetObject("PGEx1.DocCommentTitle.TabIndex"), Integer)
        Me.PGEx1.DocCommentTitle.UseMnemonic = False
        resources.ApplyResources(Me.PGEx1, "PGEx1")
        Me.PGEx1.Name = "PGEx1"
        Me.PGEx1.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PGEx1.SelectedObject = CType(resources.GetObject("PGEx1.SelectedObject"), Object)
        Me.PGEx1.ShowCustomProperties = True
        '
        '
        '
        Me.PGEx1.ToolStrip.AccessibleName = resources.GetString("PGEx1.ToolStrip.AccessibleName")
        Me.PGEx1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PGEx1.ToolStrip.AllowMerge = False
        Me.PGEx1.ToolStrip.AutoSize = CType(resources.GetObject("PGEx1.ToolStrip.AutoSize"), Boolean)
        Me.PGEx1.ToolStrip.CanOverflow = False
        Me.PGEx1.ToolStrip.Dock = CType(resources.GetObject("PGEx1.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx1.ToolStrip.Font = CType(resources.GetObject("PGEx1.ToolStrip.Font"), System.Drawing.Font)
        Me.PGEx1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PGEx1.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.PGEx1.ToolStrip.Location = CType(resources.GetObject("PGEx1.ToolStrip.Location"), System.Drawing.Point)
        Me.PGEx1.ToolStrip.Name = ""
        Me.PGEx1.ToolStrip.Padding = CType(resources.GetObject("PGEx1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PGEx1.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.PGEx1.ToolStrip.Size = CType(resources.GetObject("PGEx1.ToolStrip.Size"), System.Drawing.Size)
        Me.PGEx1.ToolStrip.Stretch = True
        Me.PGEx1.ToolStrip.TabIndex = CType(resources.GetObject("PGEx1.ToolStrip.TabIndex"), Integer)
        Me.PGEx1.ToolStrip.TabStop = True
        Me.PGEx1.ToolStrip.Text = resources.GetString("PGEx1.ToolStrip.Text")
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.DWSIM.My.Resources.Resources.disk
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'TSObj
        '
        Me.TSObj.CanClose = False
        Me.TSObj.Controls.Add(Me.PGEx2)
        Me.TSObj.IsDrawn = True
        Me.TSObj.Name = "TSObj"
        resources.ApplyResources(Me.TSObj, "TSObj")
        '
        'PGEx2
        '
        '
        '
        '
        Me.PGEx2.DocCommentDescription.AccessibleName = ""
        Me.PGEx2.DocCommentDescription.AutoEllipsis = True
        Me.PGEx2.DocCommentDescription.BackColor = System.Drawing.Color.Transparent
        Me.PGEx2.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx2.DocCommentDescription.ImeMode = CType(resources.GetObject("PGEx2.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx2.DocCommentDescription.Location = CType(resources.GetObject("PGEx2.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PGEx2.DocCommentDescription.Name = ""
        Me.PGEx2.DocCommentDescription.Size = CType(resources.GetObject("PGEx2.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PGEx2.DocCommentDescription.TabIndex = CType(resources.GetObject("PGEx2.DocCommentDescription.TabIndex"), Integer)
        Me.PGEx2.DocCommentImage = Nothing
        '
        '
        '
        Me.PGEx2.DocCommentTitle.BackColor = System.Drawing.Color.Transparent
        Me.PGEx2.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx2.DocCommentTitle.Font = CType(resources.GetObject("PGEx2.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PGEx2.DocCommentTitle.ImeMode = CType(resources.GetObject("PGEx2.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx2.DocCommentTitle.Location = CType(resources.GetObject("PGEx2.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PGEx2.DocCommentTitle.Name = ""
        Me.PGEx2.DocCommentTitle.Size = CType(resources.GetObject("PGEx2.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PGEx2.DocCommentTitle.TabIndex = CType(resources.GetObject("PGEx2.DocCommentTitle.TabIndex"), Integer)
        Me.PGEx2.DocCommentTitle.UseMnemonic = False
        resources.ApplyResources(Me.PGEx2, "PGEx2")
        Me.PGEx2.DrawFlatToolbar = True
        Me.PGEx2.Name = "PGEx2"
        Me.PGEx2.SelectedObject = CType(resources.GetObject("PGEx2.SelectedObject"), Object)
        Me.PGEx2.ShowCustomProperties = True
        Me.PGEx2.ToolbarVisible = False
        '
        '
        '
        Me.PGEx2.ToolStrip.AccessibleName = resources.GetString("PGEx2.ToolStrip.AccessibleName")
        Me.PGEx2.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PGEx2.ToolStrip.AllowMerge = False
        Me.PGEx2.ToolStrip.AutoSize = CType(resources.GetObject("PGEx2.ToolStrip.AutoSize"), Boolean)
        Me.PGEx2.ToolStrip.CanOverflow = False
        Me.PGEx2.ToolStrip.Dock = CType(resources.GetObject("PGEx2.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx2.ToolStrip.Font = CType(resources.GetObject("PGEx2.ToolStrip.Font"), System.Drawing.Font)
        Me.PGEx2.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PGEx2.ToolStrip.Location = CType(resources.GetObject("PGEx2.ToolStrip.Location"), System.Drawing.Point)
        Me.PGEx2.ToolStrip.Name = ""
        Me.PGEx2.ToolStrip.Padding = CType(resources.GetObject("PGEx2.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PGEx2.ToolStrip.Size = CType(resources.GetObject("PGEx2.ToolStrip.Size"), System.Drawing.Size)
        Me.PGEx2.ToolStrip.TabIndex = CType(resources.GetObject("PGEx2.ToolStrip.TabIndex"), Integer)
        Me.PGEx2.ToolStrip.TabStop = True
        Me.PGEx2.ToolStrip.Text = resources.GetString("PGEx2.ToolStrip.Text")
        Me.PGEx2.ToolStrip.Visible = CType(resources.GetObject("PGEx2.ToolStrip.Visible"), Boolean)
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'LblNomeObj
        '
        resources.ApplyResources(Me.LblNomeObj, "LblNomeObj")
        Me.LblNomeObj.Name = "LblNomeObj"
        '
        'sfdxml1
        '
        Me.sfdxml1.DefaultExt = "xml"
        resources.ApplyResources(Me.sfdxml1, "sfdxml1")
        Me.sfdxml1.RestoreDirectory = True
        '
        'frmProps
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CloseButton = False
        Me.Controls.Add(Me.LblTipoObj)
        Me.Controls.Add(Me.LblStatusObj)
        Me.Controls.Add(Me.FTSProps)
        Me.Controls.Add(Me.LblNomeObj)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "frmProps"
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
        CType(Me.FTSProps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FTSProps.ResumeLayout(False)
        Me.TSProps.ResumeLayout(False)
        Me.TSObj.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblStatusObj As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents LblTipoObj As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents FTSProps As FarsiLibrary.Win.FATabStrip
    Public WithEvents TSProps As FarsiLibrary.Win.FATabStripItem
    Public WithEvents PGEx1 As PropertyGridEx.PropertyGridEx
    Public WithEvents TSObj As FarsiLibrary.Win.FATabStripItem
    Public WithEvents PGEx2 As PropertyGridEx.PropertyGridEx
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LblNomeObj As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Public WithEvents sfdxml1 As System.Windows.Forms.SaveFileDialog
End Class
