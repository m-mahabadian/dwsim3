﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOptimization
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOptimization))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnDeleteCase = New System.Windows.Forms.Button
        Me.btnSaveCase = New System.Windows.Forms.Button
        Me.btnCopyCase = New System.Windows.Forms.Button
        Me.btnNewCase = New System.Windows.Forms.Button
        Me.lbCases = New System.Windows.Forms.ListBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.tbCaseDesc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbCaseName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgVariables = New System.Windows.Forms.DataGridView
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbAddVar = New System.Windows.Forms.ToolStripButton
        Me.tsbDelVar = New System.Windows.Forms.ToolStripButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.rbVariable = New System.Windows.Forms.RadioButton
        Me.rbExpression = New System.Windows.Forms.RadioButton
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.rbMinimize = New System.Windows.Forms.RadioButton
        Me.rbMaximize = New System.Windows.Forms.RadioButton
        Me.tbToleranceValue = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbMaxIterations = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnVerify = New System.Windows.Forms.Button
        Me.tbCurrentValue = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbExpression = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.tbH = New System.Windows.Forms.TextBox
        Me.tbBarrierMultiplier = New System.Windows.Forms.TextBox
        Me.rb4PointDeriv = New System.Windows.Forms.RadioButton
        Me.rb2PointDeriv = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnRun = New System.Windows.Forms.Button
        Me.btnAbort = New System.Windows.Forms.Button
        Me.btnRestore = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.grProgress = New ZedGraph.ZedGraphControl
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.AccessibleDescription = Nothing
        Me.GroupBox2.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.BackgroundImage = Nothing
        Me.GroupBox2.Controls.Add(Me.btnDeleteCase)
        Me.GroupBox2.Controls.Add(Me.btnSaveCase)
        Me.GroupBox2.Controls.Add(Me.btnCopyCase)
        Me.GroupBox2.Controls.Add(Me.btnNewCase)
        Me.GroupBox2.Controls.Add(Me.lbCases)
        Me.GroupBox2.Font = Nothing
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'btnDeleteCase
        '
        Me.btnDeleteCase.AccessibleDescription = Nothing
        Me.btnDeleteCase.AccessibleName = Nothing
        resources.ApplyResources(Me.btnDeleteCase, "btnDeleteCase")
        Me.btnDeleteCase.BackgroundImage = Nothing
        Me.btnDeleteCase.Font = Nothing
        Me.btnDeleteCase.Name = "btnDeleteCase"
        Me.btnDeleteCase.UseVisualStyleBackColor = True
        '
        'btnSaveCase
        '
        Me.btnSaveCase.AccessibleDescription = Nothing
        Me.btnSaveCase.AccessibleName = Nothing
        resources.ApplyResources(Me.btnSaveCase, "btnSaveCase")
        Me.btnSaveCase.BackgroundImage = Nothing
        Me.btnSaveCase.Font = Nothing
        Me.btnSaveCase.Name = "btnSaveCase"
        Me.btnSaveCase.UseVisualStyleBackColor = True
        '
        'btnCopyCase
        '
        Me.btnCopyCase.AccessibleDescription = Nothing
        Me.btnCopyCase.AccessibleName = Nothing
        resources.ApplyResources(Me.btnCopyCase, "btnCopyCase")
        Me.btnCopyCase.BackgroundImage = Nothing
        Me.btnCopyCase.Font = Nothing
        Me.btnCopyCase.Name = "btnCopyCase"
        Me.btnCopyCase.UseVisualStyleBackColor = True
        '
        'btnNewCase
        '
        Me.btnNewCase.AccessibleDescription = Nothing
        Me.btnNewCase.AccessibleName = Nothing
        resources.ApplyResources(Me.btnNewCase, "btnNewCase")
        Me.btnNewCase.BackgroundImage = Nothing
        Me.btnNewCase.Font = Nothing
        Me.btnNewCase.Name = "btnNewCase"
        Me.btnNewCase.UseVisualStyleBackColor = True
        '
        'lbCases
        '
        Me.lbCases.AccessibleDescription = Nothing
        Me.lbCases.AccessibleName = Nothing
        resources.ApplyResources(Me.lbCases, "lbCases")
        Me.lbCases.BackgroundImage = Nothing
        Me.lbCases.Font = Nothing
        Me.lbCases.FormattingEnabled = True
        Me.lbCases.Name = "lbCases"
        '
        'GroupBox3
        '
        Me.GroupBox3.AccessibleDescription = Nothing
        Me.GroupBox3.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.BackgroundImage = Nothing
        Me.GroupBox3.Controls.Add(Me.tbCaseDesc)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.tbCaseName)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = Nothing
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'tbCaseDesc
        '
        Me.tbCaseDesc.AccessibleDescription = Nothing
        Me.tbCaseDesc.AccessibleName = Nothing
        resources.ApplyResources(Me.tbCaseDesc, "tbCaseDesc")
        Me.tbCaseDesc.BackgroundImage = Nothing
        Me.tbCaseDesc.Font = Nothing
        Me.tbCaseDesc.Name = "tbCaseDesc"
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = Nothing
        Me.Label4.AccessibleName = Nothing
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Font = Nothing
        Me.Label4.Name = "Label4"
        '
        'tbCaseName
        '
        Me.tbCaseName.AccessibleDescription = Nothing
        Me.tbCaseName.AccessibleName = Nothing
        resources.ApplyResources(Me.tbCaseName, "tbCaseName")
        Me.tbCaseName.BackgroundImage = Nothing
        Me.tbCaseName.Font = Nothing
        Me.tbCaseName.Name = "tbCaseName"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = Nothing
        Me.GroupBox1.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackgroundImage = Nothing
        Me.GroupBox1.Controls.Add(Me.dgVariables)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Font = Nothing
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'dgVariables
        '
        Me.dgVariables.AccessibleDescription = Nothing
        Me.dgVariables.AccessibleName = Nothing
        Me.dgVariables.AllowUserToAddRows = False
        Me.dgVariables.AllowUserToDeleteRows = False
        Me.dgVariables.AllowUserToResizeRows = False
        resources.ApplyResources(Me.dgVariables, "dgVariables")
        Me.dgVariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgVariables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgVariables.BackgroundImage = Nothing
        Me.dgVariables.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgVariables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgVariables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVariables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column7, Me.Column10, Me.Column5, Me.Column9})
        Me.dgVariables.Font = Nothing
        Me.dgVariables.Name = "dgVariables"
        Me.dgVariables.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        '
        'Column8
        '
        resources.ApplyResources(Me.Column8, "Column8")
        Me.Column8.Name = "Column8"
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.Sorted = True
        '
        'Column4
        '
        Me.Column4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        resources.ApplyResources(Me.Column4, "Column4")
        Me.Column4.Name = "Column4"
        '
        'Column6
        '
        resources.ApplyResources(Me.Column6, "Column6")
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column7
        '
        resources.ApplyResources(Me.Column7, "Column7")
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column10
        '
        resources.ApplyResources(Me.Column10, "Column10")
        Me.Column10.Name = "Column10"
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        resources.ApplyResources(Me.Column5, "Column5")
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column9
        '
        resources.ApplyResources(Me.Column9, "Column9")
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AccessibleDescription = Nothing
        Me.ToolStrip1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.BackgroundImage = Nothing
        Me.ToolStrip1.Font = Nothing
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAddVar, Me.tsbDelVar})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'tsbAddVar
        '
        Me.tsbAddVar.AccessibleDescription = Nothing
        Me.tsbAddVar.AccessibleName = Nothing
        resources.ApplyResources(Me.tsbAddVar, "tsbAddVar")
        Me.tsbAddVar.BackgroundImage = Nothing
        Me.tsbAddVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddVar.Image = Global.DWSIM.My.Resources.Resources.add
        Me.tsbAddVar.Name = "tsbAddVar"
        '
        'tsbDelVar
        '
        Me.tsbDelVar.AccessibleDescription = Nothing
        Me.tsbDelVar.AccessibleName = Nothing
        resources.ApplyResources(Me.tsbDelVar, "tsbDelVar")
        Me.tsbDelVar.BackgroundImage = Nothing
        Me.tsbDelVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelVar.Image = Global.DWSIM.My.Resources.Resources.delete1
        Me.tsbDelVar.Name = "tsbDelVar"
        '
        'GroupBox4
        '
        Me.GroupBox4.AccessibleDescription = Nothing
        Me.GroupBox4.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.BackgroundImage = Nothing
        Me.GroupBox4.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox4.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox4.Controls.Add(Me.tbToleranceValue)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.tbMaxIterations)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Font = Nothing
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AccessibleDescription = Nothing
        Me.FlowLayoutPanel2.AccessibleName = Nothing
        resources.ApplyResources(Me.FlowLayoutPanel2, "FlowLayoutPanel2")
        Me.FlowLayoutPanel2.BackgroundImage = Nothing
        Me.FlowLayoutPanel2.Controls.Add(Me.rbVariable)
        Me.FlowLayoutPanel2.Controls.Add(Me.rbExpression)
        Me.FlowLayoutPanel2.Font = Nothing
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        '
        'rbVariable
        '
        Me.rbVariable.AccessibleDescription = Nothing
        Me.rbVariable.AccessibleName = Nothing
        resources.ApplyResources(Me.rbVariable, "rbVariable")
        Me.rbVariable.BackgroundImage = Nothing
        Me.rbVariable.Checked = True
        Me.rbVariable.Font = Nothing
        Me.rbVariable.Name = "rbVariable"
        Me.rbVariable.TabStop = True
        Me.rbVariable.UseVisualStyleBackColor = True
        '
        'rbExpression
        '
        Me.rbExpression.AccessibleDescription = Nothing
        Me.rbExpression.AccessibleName = Nothing
        resources.ApplyResources(Me.rbExpression, "rbExpression")
        Me.rbExpression.BackgroundImage = Nothing
        Me.rbExpression.Font = Nothing
        Me.rbExpression.Name = "rbExpression"
        Me.rbExpression.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AccessibleDescription = Nothing
        Me.FlowLayoutPanel1.AccessibleName = Nothing
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.BackgroundImage = Nothing
        Me.FlowLayoutPanel1.Controls.Add(Me.rbMinimize)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbMaximize)
        Me.FlowLayoutPanel1.Font = Nothing
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'rbMinimize
        '
        Me.rbMinimize.AccessibleDescription = Nothing
        Me.rbMinimize.AccessibleName = Nothing
        resources.ApplyResources(Me.rbMinimize, "rbMinimize")
        Me.rbMinimize.BackgroundImage = Nothing
        Me.rbMinimize.Checked = True
        Me.rbMinimize.Font = Nothing
        Me.rbMinimize.Name = "rbMinimize"
        Me.rbMinimize.TabStop = True
        Me.rbMinimize.UseVisualStyleBackColor = True
        '
        'rbMaximize
        '
        Me.rbMaximize.AccessibleDescription = Nothing
        Me.rbMaximize.AccessibleName = Nothing
        resources.ApplyResources(Me.rbMaximize, "rbMaximize")
        Me.rbMaximize.BackgroundImage = Nothing
        Me.rbMaximize.Font = Nothing
        Me.rbMaximize.Name = "rbMaximize"
        Me.rbMaximize.UseVisualStyleBackColor = True
        '
        'tbToleranceValue
        '
        Me.tbToleranceValue.AccessibleDescription = Nothing
        Me.tbToleranceValue.AccessibleName = Nothing
        resources.ApplyResources(Me.tbToleranceValue, "tbToleranceValue")
        Me.tbToleranceValue.BackgroundImage = Nothing
        Me.tbToleranceValue.Font = Nothing
        Me.tbToleranceValue.Name = "tbToleranceValue"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = Nothing
        Me.Label6.AccessibleName = Nothing
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Font = Nothing
        Me.Label6.Name = "Label6"
        '
        'tbMaxIterations
        '
        Me.tbMaxIterations.AccessibleDescription = Nothing
        Me.tbMaxIterations.AccessibleName = Nothing
        resources.ApplyResources(Me.tbMaxIterations, "tbMaxIterations")
        Me.tbMaxIterations.BackgroundImage = Nothing
        Me.tbMaxIterations.Font = Nothing
        Me.tbMaxIterations.Name = "tbMaxIterations"
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = Nothing
        Me.Label5.AccessibleName = Nothing
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Font = Nothing
        Me.Label5.Name = "Label5"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = Nothing
        Me.Label3.AccessibleName = Nothing
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Font = Nothing
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Font = Nothing
        Me.Label2.Name = "Label2"
        '
        'GroupBox6
        '
        Me.GroupBox6.AccessibleDescription = Nothing
        Me.GroupBox6.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.BackgroundImage = Nothing
        Me.GroupBox6.Controls.Add(Me.btnClear)
        Me.GroupBox6.Controls.Add(Me.btnVerify)
        Me.GroupBox6.Controls.Add(Me.tbCurrentValue)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.tbExpression)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Font = Nothing
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = Nothing
        Me.btnClear.AccessibleName = Nothing
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.BackgroundImage = Nothing
        Me.btnClear.Font = Nothing
        Me.btnClear.Image = Global.DWSIM.My.Resources.Resources.cross
        Me.btnClear.Name = "btnClear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnVerify
        '
        Me.btnVerify.AccessibleDescription = Nothing
        Me.btnVerify.AccessibleName = Nothing
        resources.ApplyResources(Me.btnVerify, "btnVerify")
        Me.btnVerify.BackgroundImage = Nothing
        Me.btnVerify.Font = Nothing
        Me.btnVerify.Image = Global.DWSIM.My.Resources.Resources.tick1
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'tbCurrentValue
        '
        Me.tbCurrentValue.AccessibleDescription = Nothing
        Me.tbCurrentValue.AccessibleName = Nothing
        resources.ApplyResources(Me.tbCurrentValue, "tbCurrentValue")
        Me.tbCurrentValue.BackgroundImage = Nothing
        Me.tbCurrentValue.Font = Nothing
        Me.tbCurrentValue.Name = "tbCurrentValue"
        Me.tbCurrentValue.ReadOnly = True
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = Nothing
        Me.Label8.AccessibleName = Nothing
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Font = Nothing
        Me.Label8.Name = "Label8"
        '
        'tbExpression
        '
        Me.tbExpression.AccessibleDescription = Nothing
        Me.tbExpression.AccessibleName = Nothing
        resources.ApplyResources(Me.tbExpression, "tbExpression")
        Me.tbExpression.BackgroundImage = Nothing
        Me.tbExpression.Font = Nothing
        Me.tbExpression.Name = "tbExpression"
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = Nothing
        Me.Label7.AccessibleName = Nothing
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Font = Nothing
        Me.Label7.Name = "Label7"
        '
        'Panel1
        '
        Me.Panel1.AccessibleDescription = Nothing
        Me.Panel1.AccessibleName = Nothing
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackgroundImage = Nothing
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox8)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Font = Nothing
        Me.Panel1.Name = "Panel1"
        '
        'GroupBox8
        '
        Me.GroupBox8.AccessibleDescription = Nothing
        Me.GroupBox8.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox8, "GroupBox8")
        Me.GroupBox8.BackgroundImage = Nothing
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.tbH)
        Me.GroupBox8.Controls.Add(Me.tbBarrierMultiplier)
        Me.GroupBox8.Controls.Add(Me.rb4PointDeriv)
        Me.GroupBox8.Controls.Add(Me.rb2PointDeriv)
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.ComboBox1)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.btnRun)
        Me.GroupBox8.Controls.Add(Me.btnAbort)
        Me.GroupBox8.Controls.Add(Me.btnRestore)
        Me.GroupBox8.Font = Nothing
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.TabStop = False
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = Nothing
        Me.Label12.AccessibleName = Nothing
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Font = Nothing
        Me.Label12.Name = "Label12"
        '
        'tbH
        '
        Me.tbH.AccessibleDescription = Nothing
        Me.tbH.AccessibleName = Nothing
        resources.ApplyResources(Me.tbH, "tbH")
        Me.tbH.BackgroundImage = Nothing
        Me.tbH.Font = Nothing
        Me.tbH.Name = "tbH"
        '
        'tbBarrierMultiplier
        '
        Me.tbBarrierMultiplier.AccessibleDescription = Nothing
        Me.tbBarrierMultiplier.AccessibleName = Nothing
        resources.ApplyResources(Me.tbBarrierMultiplier, "tbBarrierMultiplier")
        Me.tbBarrierMultiplier.BackgroundImage = Nothing
        Me.tbBarrierMultiplier.Font = Nothing
        Me.tbBarrierMultiplier.Name = "tbBarrierMultiplier"
        '
        'rb4PointDeriv
        '
        Me.rb4PointDeriv.AccessibleDescription = Nothing
        Me.rb4PointDeriv.AccessibleName = Nothing
        resources.ApplyResources(Me.rb4PointDeriv, "rb4PointDeriv")
        Me.rb4PointDeriv.BackgroundImage = Nothing
        Me.rb4PointDeriv.Font = Nothing
        Me.rb4PointDeriv.Name = "rb4PointDeriv"
        Me.rb4PointDeriv.TabStop = True
        Me.rb4PointDeriv.UseVisualStyleBackColor = True
        '
        'rb2PointDeriv
        '
        Me.rb2PointDeriv.AccessibleDescription = Nothing
        Me.rb2PointDeriv.AccessibleName = Nothing
        resources.ApplyResources(Me.rb2PointDeriv, "rb2PointDeriv")
        Me.rb2PointDeriv.BackgroundImage = Nothing
        Me.rb2PointDeriv.Font = Nothing
        Me.rb2PointDeriv.Name = "rb2PointDeriv"
        Me.rb2PointDeriv.TabStop = True
        Me.rb2PointDeriv.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = Nothing
        Me.Label11.AccessibleName = Nothing
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Font = Nothing
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = Nothing
        Me.Label10.AccessibleName = Nothing
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Font = Nothing
        Me.Label10.Name = "Label10"
        '
        'ComboBox1
        '
        Me.ComboBox1.AccessibleDescription = Nothing
        Me.ComboBox1.AccessibleName = Nothing
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.BackgroundImage = Nothing
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = Nothing
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2"), resources.GetString("ComboBox1.Items3"), resources.GetString("ComboBox1.Items4"), resources.GetString("ComboBox1.Items5"), resources.GetString("ComboBox1.Items6"), resources.GetString("ComboBox1.Items7"), resources.GetString("ComboBox1.Items8"), resources.GetString("ComboBox1.Items9"), resources.GetString("ComboBox1.Items10")})
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = Nothing
        Me.Label9.AccessibleName = Nothing
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Font = Nothing
        Me.Label9.Name = "Label9"
        '
        'btnRun
        '
        Me.btnRun.AccessibleDescription = Nothing
        Me.btnRun.AccessibleName = Nothing
        resources.ApplyResources(Me.btnRun, "btnRun")
        Me.btnRun.BackgroundImage = Nothing
        Me.btnRun.Font = Nothing
        Me.btnRun.Name = "btnRun"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnAbort
        '
        Me.btnAbort.AccessibleDescription = Nothing
        Me.btnAbort.AccessibleName = Nothing
        resources.ApplyResources(Me.btnAbort, "btnAbort")
        Me.btnAbort.BackgroundImage = Nothing
        Me.btnAbort.Font = Nothing
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'btnRestore
        '
        Me.btnRestore.AccessibleDescription = Nothing
        Me.btnRestore.AccessibleName = Nothing
        resources.ApplyResources(Me.btnRestore, "btnRestore")
        Me.btnRestore.BackgroundImage = Nothing
        Me.btnRestore.Font = Nothing
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.AccessibleDescription = Nothing
        Me.GroupBox7.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.BackgroundImage = Nothing
        Me.GroupBox7.Controls.Add(Me.grProgress)
        Me.GroupBox7.Font = Nothing
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'grProgress
        '
        Me.grProgress.AccessibleDescription = Nothing
        Me.grProgress.AccessibleName = Nothing
        resources.ApplyResources(Me.grProgress, "grProgress")
        Me.grProgress.BackgroundImage = Nothing
        Me.grProgress.IsAntiAlias = True
        Me.grProgress.IsAutoScrollRange = True
        Me.grProgress.Name = "grProgress"
        Me.grProgress.ScrollGrace = 0
        Me.grProgress.ScrollMaxX = 0
        Me.grProgress.ScrollMaxY = 0
        Me.grProgress.ScrollMaxY2 = 0
        Me.grProgress.ScrollMinX = 0
        Me.grProgress.ScrollMinY = 0
        Me.grProgress.ScrollMinY2 = 0
        '
        'FormOptimization
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.Panel1)
        Me.Font = Nothing
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = Nothing
        Me.Name = "FormOptimization"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents btnDeleteCase As System.Windows.Forms.Button
    Public WithEvents btnSaveCase As System.Windows.Forms.Button
    Public WithEvents btnCopyCase As System.Windows.Forms.Button
    Public WithEvents btnNewCase As System.Windows.Forms.Button
    Public WithEvents lbCases As System.Windows.Forms.ListBox
    Public WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents tbCaseDesc As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents tbCaseName As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents rbExpression As System.Windows.Forms.RadioButton
    Public WithEvents rbVariable As System.Windows.Forms.RadioButton
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents rbMaximize As System.Windows.Forms.RadioButton
    Public WithEvents rbMinimize As System.Windows.Forms.RadioButton
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents tbToleranceValue As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents tbMaxIterations As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Public WithEvents tbCurrentValue As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents tbExpression As System.Windows.Forms.TextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents btnVerify As System.Windows.Forms.Button
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents btnRun As System.Windows.Forms.Button
    Public WithEvents btnRestore As System.Windows.Forms.Button
    Public WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Public WithEvents grProgress As ZedGraph.ZedGraphControl
    Public WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Public WithEvents dgVariables As System.Windows.Forms.DataGridView
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents tsbAddVar As System.Windows.Forms.ToolStripButton
    Public WithEvents tsbDelVar As System.Windows.Forms.ToolStripButton
    Public WithEvents btnAbort As System.Windows.Forms.Button
    Public WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Public WithEvents tbBarrierMultiplier As System.Windows.Forms.TextBox
    Public WithEvents rb4PointDeriv As System.Windows.Forms.RadioButton
    Public WithEvents rb2PointDeriv As System.Windows.Forms.RadioButton
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents tbH As System.Windows.Forms.TextBox
End Class
