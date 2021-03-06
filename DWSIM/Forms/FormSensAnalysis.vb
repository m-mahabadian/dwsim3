﻿'    Sensitivity Analysis Classes
'    Copyright 2009 Daniel Wagner O. de Medeiros
'
'    This file is part of DWSIM.
'
'    DWSIM is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    DWSIM is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with DWSIM.  If not, see <http://www.gnu.org/licenses/>.

Imports DWSIM.DWSIM.ClassesBasicasTermodinamica
Imports DWSIM.DWSIM.Optimization
Imports DWSIM.DWSIM.SimulationObjects
Imports Microsoft.MSDN.Samples
Imports Ciloci.Flee
Imports DWSIM.DWSIM.Flowsheet.FlowsheetSolver
Imports System.Linq

Public Class FormSensAnalysis

    Public nf As String
    Public su As DWSIM.SistemasDeUnidades.Unidades
    Public cv As DWSIM.SistemasDeUnidades.Conversor
    Public form As FormFlowsheet

    Public abortCalc As Boolean = False
    Public selectedindex As Integer = 0
    Public selectedsacase As SensitivityAnalysisCase
    Private selected As Boolean = False

    Public cbc2, cbc3, cbc0, cbc1 As DataGridViewComboBoxCell

    Private Sub FormSensAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        form = My.Application.ActiveSimulation

        cv = New DWSIM.SistemasDeUnidades.Conversor
        su = form.Options.SelectedUnitSystem
        nf = form.Options.NumberFormat

        Me.lbCases.Items.Clear()

        If form.Collections.OPT_SensAnalysisCollection Is Nothing Then form.Collections.OPT_SensAnalysisCollection = New List(Of DWSIM.Optimization.SensitivityAnalysisCase)

        For Each sacase As DWSIM.Optimization.SensitivityAnalysisCase In form.Collections.OPT_SensAnalysisCollection
            Me.lbCases.Items.Add(sacase.name)
        Next

        Me.cbObjIndVar1.Items.Clear()
        Me.cbObjIndVar2.Items.Clear()
        Me.cbPropIndVar1.Items.Clear()
        Me.cbPropIndVar2.Items.Clear()

        For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
            Me.cbObjIndVar1.Items.Add(obj.GraphicObject.Tag)
            Me.cbObjIndVar2.Items.Add(obj.GraphicObject.Tag)
        Next

        cbc0 = New DataGridViewComboBoxCell
        cbc0.Sorted = True
        cbc0.MaxDropDownItems = 10
        For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
            cbc0.Items.Add(obj.GraphicObject.Tag)
        Next
        cbc1 = New DataGridViewComboBoxCell
        cbc1.MaxDropDownItems = 10

        cbc2 = New DataGridViewComboBoxCell
        cbc2.Sorted = True
        cbc2.MaxDropDownItems = 10
        For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
            cbc2.Items.Add(obj.GraphicObject.Tag)
        Next
        cbc3 = New DataGridViewComboBoxCell
        cbc3.MaxDropDownItems = 10

        Dim tbc1 As New DataGridViewTextBoxCell()
        Dim tbc2 As New DataGridViewTextBoxCell()
        Dim tbc3 As New DataGridViewTextBoxCell()
        With tbc1
            .Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        With tbc2
            .Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        With tbc3
            .Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Style.BackColor = Color.FromKnownColor(KnownColor.Control)
        End With

        With Me.dgDepVariables
            .Columns(1).CellTemplate = cbc0
            .Columns(2).CellTemplate = cbc1
        End With

        With Me.dgVariables
            .Columns(0).CellTemplate = tbc1
            .Columns(1).CellTemplate = tbc1
            .Columns(2).CellTemplate = cbc2
            .Columns(3).CellTemplate = cbc3
            .Columns(4).CellTemplate = tbc2
            .Columns(5).CellTemplate = tbc3
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        If Me.lbCases.Items.Count > 0 Then Me.lbCases.SelectedIndex = Me.lbCases.Items.Count - 1

    End Sub

    Private Function ReturnProperties(ByVal objectTAG As String, ByVal dependent As Boolean) As String()

        For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
            If objectTAG = obj.GraphicObject.Tag Then
                If dependent Then
                    Return obj.GetProperties(SimulationObjects_BaseClass.PropertyType.ALL)
                Else
                    Return obj.GetProperties(SimulationObjects_BaseClass.PropertyType.WR)
                End If
                Exit Function
            End If
        Next

        Return Nothing

    End Function

    Private Sub cbObjIndVar2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbObjIndVar2.SelectedIndexChanged
        Me.cbPropIndVar2.Items.Clear()
        If Not Me.cbObjIndVar2.SelectedItem Is Nothing Then
            If Me.cbObjIndVar2.SelectedItem.ToString <> "" Then
                Dim props As String() = Me.ReturnProperties(Me.cbObjIndVar2.SelectedItem.ToString, False)
                For Each prop As String In props
                    Me.cbPropIndVar2.Items.Add(DWSIM.App.GetPropertyName(prop))
                Next
            End If
        End If
    End Sub

    Private Sub cbObjIndVar1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbObjIndVar1.SelectedIndexChanged
        Me.cbPropIndVar1.Items.Clear()
        If Not Me.cbObjIndVar1.SelectedItem Is Nothing Then
            If Me.cbObjIndVar1.SelectedItem.ToString <> "" Then
                Dim props As String() = Me.ReturnProperties(Me.cbObjIndVar1.SelectedItem.ToString, False)
                For Each prop As String In props
                    Me.cbPropIndVar1.Items.Add(DWSIM.App.GetPropertyName(prop))
                Next
            End If
        End If
    End Sub

    Private Sub cbPropIndVar1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropIndVar1.SelectedIndexChanged
        Dim props As String() = Me.ReturnProperties(Me.cbObjIndVar1.SelectedItem.ToString, False)
        For Each prop As String In props
            If DWSIM.App.GetPropertyName(prop) = Me.cbPropIndVar1.SelectedItem.ToString Then
                For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
                    If Me.cbObjIndVar1.SelectedItem.ToString = obj.GraphicObject.Tag Then
                        Me.tbUnitIndVar1.Text = obj.GetPropertyUnit(prop, su)
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub cbPropIndVar2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropIndVar2.SelectedIndexChanged
        Dim props As String() = Me.ReturnProperties(Me.cbObjIndVar2.SelectedItem.ToString, False)
        For Each prop As String In props
            If DWSIM.App.GetPropertyName(prop) = Me.cbPropIndVar2.SelectedItem.ToString Then
                For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
                    If Me.cbObjIndVar2.SelectedItem.ToString = obj.GraphicObject.Tag Then
                        Me.tbUnitIndVar2.Text = obj.GetPropertyUnit(prop, su)
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub btnNewCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCase.Click

        Dim sacase As New DWSIM.Optimization.SensitivityAnalysisCase

        sacase.name = "SACase" & form.Collections.OPT_SensAnalysisCollection.Count

        Me.lbCases.Items.Add(sacase.name)
        Me.lbCases.SelectedItem = sacase.name

        form.Collections.OPT_SensAnalysisCollection.Add(sacase)

    End Sub

    Private Sub PopulateForm(ByRef sacase As DWSIM.Optimization.SensitivityAnalysisCase)

        With sacase
            Me.tbCaseName.Text = sacase.name
            Me.tbCaseDesc.Text = sacase.description
            With sacase.iv1
                Me.cbObjIndVar1.SelectedItem = .objectTAG
                Me.cbPropIndVar1.SelectedItem = DWSIM.App.GetPropertyName(.propID)
                Me.tbLowerLimIndVar1.Text = .lowerlimit.GetValueOrDefault
                Me.tbUpperLimIndVar1.Text = .upperlimit.GetValueOrDefault
                Me.nuNumPointsIndVar1.Value = .points
            End With
            With sacase.iv2
                Me.cbObjIndVar2.SelectedItem = .objectTAG
                Me.cbPropIndVar2.SelectedItem = DWSIM.App.GetPropertyName(.propID)
                Me.tbLowerLimIndVar2.Text = .lowerlimit.GetValueOrDefault
                Me.tbUpperLimIndVar2.Text = .upperlimit.GetValueOrDefault
                Me.nuNumPointsIndVar2.Value = .points
            End With
            Me.dgDepVariables.Rows.Clear()
            For Each var As SAVariable In .depvariables.Values
                With var
                    Me.dgDepVariables.Rows.Add()
                    Dim dgrow As DataGridViewRow = Me.dgDepVariables.Rows(Me.dgDepVariables.Rows.Count - 1)
                    dgrow.Cells(0).Value = .id
                    dgrow.Cells(1).Value = .objectTAG
                    dgrow.Cells(2).Value = DWSIM.App.GetPropertyName(.propID)
                    dgrow.Cells(3).Value = .unit
                End With
            Next
            Me.dgvResults.Rows.Clear()
            For Each result As Double() In .results
                Me.dgvResults.Rows.Add(New Object() {Format(cv.ConverterDoSI(sacase.iv1.unit, result(0)), nf), Format(cv.ConverterDoSI(sacase.iv2.unit, result(1)), nf), Format(cv.ConverterDoSI(sacase.dv.unit, result(2)), nf)})
            Next
            Me.tbStats.Text = .stats
            Me.tbExpression.Text = .expression
            If .numvar = 2 Then Me.chkIndVar2.Checked = True Else Me.chkIndVar2.Checked = False
            If .depvartype = SADependentVariableType.Expression Then rbExp.Checked = True Else rbExp.Checked = False
            Me.dgVariables.Rows.Clear()
            For Each var As SAVariable In .variables.Values
                With var
                    Me.dgVariables.Rows.Add()
                    Dim dgrow As DataGridViewRow = Me.dgVariables.Rows(Me.dgVariables.Rows.Count - 1)
                    dgrow.Cells(0).Value = .id
                    dgrow.Cells(1).Value = .name
                    dgrow.Cells(2).Value = .objectTAG
                    dgrow.Cells(3).Value = DWSIM.App.GetPropertyName(.propID)
                    dgrow.Cells(4).Value = cv.ConverterDoSI(.unit, .currentvalue)
                    dgrow.Cells(5).Value = .unit
                End With
            Next
        End With

    End Sub

    Private Sub lbCases_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCases.SelectedIndexChanged

        Me.selectedindex = Me.lbCases.SelectedIndex

        If Not Me.lbCases.SelectedItem Is Nothing Then
            For Each sacase As DWSIM.Optimization.SensitivityAnalysisCase In form.Collections.OPT_SensAnalysisCollection
                If sacase.name = Me.lbCases.SelectedItem.ToString Then
                    Me.selectedsacase = sacase
                    Me.PopulateForm(sacase)
                End If
            Next
        End If

        selected = True

    End Sub

    Private Sub btnCopyCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyCase.Click
        Dim sacase2 As New DWSIM.Optimization.SensitivityAnalysisCase
        Dim found As Boolean = False
        For Each sacase As DWSIM.Optimization.SensitivityAnalysisCase In form.Collections.OPT_SensAnalysisCollection
            If sacase.name = Me.lbCases.SelectedItem.ToString Then
                sacase2 = sacase.Clone
                sacase2.name = sacase.name & "_1"
                found = True
                Exit For
            End If
        Next
        If found Then
            Me.lbCases.Items.Add(sacase2.name)
            Me.lbCases.SelectedItem = sacase2.name
            form.Collections.OPT_SensAnalysisCollection.Add(sacase2)
        End If
    End Sub

    Private Sub btnSaveCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCase.Click

        For Each sacase As DWSIM.Optimization.SensitivityAnalysisCase In form.Collections.OPT_SensAnalysisCollection
            If sacase.name = Me.lbCases.SelectedItem.ToString Then
                SaveForm(sacase)
            End If
        Next

    End Sub

    Private Sub SaveForm(ByRef sacase As DWSIM.Optimization.SensitivityAnalysisCase)

        With sacase
            sacase.name = Me.tbCaseName.Text
            sacase.description = Me.tbCaseDesc.Text
            With sacase.iv1
                .objectTAG = Me.cbObjIndVar1.SelectedItem.ToString
                .objectID = CType(FormFlowsheet.SearchSurfaceObjectsByTag(.objectTAG, form.FormSurface.FlowsheetDesignSurface), GraphicObjects.GraphicObject).Name
                Dim props As String() = Me.ReturnProperties(.objectTAG, False)
                For Each prop As String In props
                    If DWSIM.App.GetPropertyName(prop) = Me.cbPropIndVar1.SelectedItem.ToString Then
                        .propID = prop
                    End If
                Next
                .lowerlimit = Me.tbLowerLimIndVar1.Text
                .upperlimit = Me.tbUpperLimIndVar1.Text
                .points = Me.nuNumPointsIndVar1.Value
                .unit = Me.tbUnitIndVar1.Text
            End With
            If Me.chkIndVar2.Checked Then
                With sacase.iv2
                    .objectTAG = Me.cbObjIndVar2.SelectedItem
                    .objectID = CType(FormFlowsheet.SearchSurfaceObjectsByTag(.objectTAG, form.FormSurface.FlowsheetDesignSurface), GraphicObjects.GraphicObject).Name
                    Dim props As String() = Me.ReturnProperties(.objectTAG, False)
                    For Each prop As String In props
                        If DWSIM.App.GetPropertyName(prop) = Me.cbPropIndVar2.SelectedItem.ToString Then
                            .propID = prop
                        End If
                    Next
                    .lowerlimit = Me.tbLowerLimIndVar2.Text
                    .upperlimit = Me.tbUpperLimIndVar2.Text
                    .points = Me.nuNumPointsIndVar2.Value
                    .unit = Me.tbUnitIndVar2.Text
                End With
            End If
            If Me.rbVar.Checked Then
                If .depvariables Is Nothing Then .depvariables = New Dictionary(Of String, SAVariable)
                .depvariables.Clear()
                For Each dgrow As DataGridViewRow In Me.dgDepVariables.Rows
                    Dim var As New SAVariable
                    With var
                        .id = dgrow.Cells(0).Value
                        .objectTAG = dgrow.Cells(1).Value
                        .objectID = Me.ReturnObject(dgrow.Cells(1).Value).Nome
                        .propID = Me.ReturnPropertyID(.objectID, dgrow.Cells(2).Value)
                        .unit = dgrow.Cells(3).Value
                    End With
                    .depvariables.Add(var.id, var)
                Next
            End If
            Try
                .results.Clear()
                For Each row As DataGridViewRow In Me.dgvResults.Rows
                    .results.Add(New Double() {row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value})
                Next
            Catch ex As Exception
                form.WriteToLog(ex.Message, Color.BurlyWood, DWSIM.FormClasses.TipoAviso.Aviso)
            End Try
            .stats = Me.tbStats.Text
            If Me.chkIndVar2.Checked Then .numvar = 2 Else .numvar = 1
            .expression = Me.tbExpression.Text
            .variables.Clear()
            If Me.rbExp.Checked Then .depvartype = DWSIM.Optimization.SADependentVariableType.Expression Else .depvartype = DWSIM.Optimization.SADependentVariableType.Variable
            For Each dgrow As DataGridViewRow In Me.dgVariables.Rows
                Dim var As New SAVariable
                With var
                    .id = dgrow.Cells(0).Value
                    .name = dgrow.Cells(1).Value
                    .objectTAG = dgrow.Cells(2).Value
                    .objectID = Me.ReturnObject(dgrow.Cells(2).Value).Nome
                    .propID = Me.ReturnPropertyID(.objectID, dgrow.Cells(3).Value)
                    .currentvalue = cv.ConverterParaSI(dgrow.Cells(5).Value, dgrow.Cells(4).Value)
                    .unit = dgrow.Cells(5).Value
                End With
                .variables.Add(var.id, var)
            Next
        End With

    End Sub

    Private Sub btnDeleteCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCase.Click
        Dim idx As Integer = 0
        For Each sacase As DWSIM.Optimization.SensitivityAnalysisCase In form.Collections.OPT_SensAnalysisCollection
            If sacase.name = Me.lbCases.SelectedItem.ToString Then
                idx = form.Collections.OPT_SensAnalysisCollection.IndexOf(sacase)
                Exit For
            End If
        Next
        form.Collections.OPT_SensAnalysisCollection.RemoveAt(idx)
        Me.lbCases.Items.Remove(Me.lbCases.SelectedItem)
        Me.lbCases.SelectedIndex = Me.lbCases.Items.Count - 1
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click

        Dim idx As Integer = 0
        Dim iv1ll, iv1ul, iv1np, iv2ll, iv2ul, iv2np, dvval, iv1val, iv2val, iv1val0, iv2val0 As Double
        Dim iv1id, iv2id, iv1prop, iv2prop, dvid, dvprop As String
        Dim i, j, counter As Integer
        Dim res As New ArrayList

        Me.lbCases.SelectedIndex = Me.selectedindex

        For Each sacase2 As DWSIM.Optimization.SensitivityAnalysisCase In form.Collections.OPT_SensAnalysisCollection
            If sacase2.name = Me.lbCases.SelectedItem.ToString Then
                idx = form.Collections.OPT_SensAnalysisCollection.IndexOf(sacase2)
                Exit For
            End If
        Next

        Dim sacase As DWSIM.Optimization.SensitivityAnalysisCase = form.Collections.OPT_SensAnalysisCollection(idx)

        SaveForm(sacase)

        With sacase
            iv1ll = cv.ConverterParaSI(.iv1.unit, .iv1.lowerlimit)
            iv1ul = cv.ConverterParaSI(.iv1.unit, .iv1.upperlimit)
            iv1np = .iv1.points - 1
            iv1id = .iv1.objectID
            iv1prop = .iv1.propID
            If chkIndVar2.Checked Then
                iv2ll = cv.ConverterParaSI(.iv2.unit, .iv2.lowerlimit)
                iv2ul = cv.ConverterParaSI(.iv2.unit, .iv2.upperlimit)
                iv2np = .iv2.points - 1
                iv2id = .iv2.objectID
                iv2prop = .iv2.propID
            Else
                iv2id = ""
                iv2prop = ""
            End If
            dvid = .dv.objectID
            dvprop = .dv.propID
        End With

        Try
            Me.btnRun.Enabled = False
            Me.btnAbort.Enabled = True
            Me.abortCalc = False
            res.Clear()
            counter = 0
            Me.tbStats.Text = ""
            With Me.dgvResults
                .Columns.Clear()
                .Columns.Add("IV1", "")
                .Columns.Add("IV2", "")
                .Rows.Clear()
                If Me.tbUnitIndVar1.Text <> "" Then
                    .Columns(0).HeaderText = Me.cbObjIndVar1.SelectedItem.ToString & " - " & Me.cbPropIndVar1.SelectedItem.ToString & " (" & Me.tbUnitIndVar1.Text & ")"
                Else
                    .Columns(0).HeaderText = Me.cbObjIndVar1.SelectedItem.ToString & " - " & Me.cbPropIndVar1.SelectedItem.ToString
                End If
                If chkIndVar2.Checked Then
                    .Columns(1).Visible = True
                    If Me.tbUnitIndVar2.Text <> "" Then
                        .Columns(1).HeaderText = Me.cbObjIndVar2.SelectedItem.ToString & " - " & Me.cbPropIndVar2.SelectedItem.ToString & " (" & Me.tbUnitIndVar2.Text & ")"
                    Else
                        .Columns(1).HeaderText = Me.cbObjIndVar2.SelectedItem.ToString & " - " & Me.cbPropIndVar2.SelectedItem.ToString
                    End If
                Else
                    .Columns(1).Visible = False
                End If
                If Me.rbExp.Checked Then
                    .Columns.Add("DV", "EXP Val")
                Else
                    For Each var As SAVariable In selectedsacase.depvariables.Values
                        .Columns.Add(var.propID, var.objectTAG & " - " & DWSIM.App.GetPropertyName(var.propID) & " (" & var.unit & ")")
                    Next
                End If
            End With
            'store original values
            iv1val0 = form.Collections.ObjectCollection(iv1id).GetPropertyValue(iv1prop)
            If Me.chkIndVar2.Checked Then iv2val0 = form.Collections.ObjectCollection(iv2id).GetPropertyValue(iv2prop) Else iv2val0 = 0
            For i = 0 To iv1np
                For j = 0 To iv2np
                    iv1val = iv1ll + i * (iv1ul - iv1ll) / iv1np
                    If Me.chkIndVar2.Checked Then iv2val = iv2ll + j * (iv2ul - iv2ll) / iv2np Else iv2val = 0
                    'set object properties
                    form.Collections.ObjectCollection(iv1id).SetPropertyValue(iv1prop, iv1val)
                    If Me.chkIndVar2.Checked Then form.Collections.ObjectCollection(iv2id).SetPropertyValue(iv2prop, iv2val)
                    'run simulation
                    CalculateAll(form)
                    'get the value of the dependent variable
                    If rbExp.Checked Then
                        Me.selectedsacase.econtext = New ExpressionContext
                        Me.selectedsacase.expression = Me.tbExpression.Text
                        With Me.selectedsacase.econtext
                            .Imports.ImportStaticMembers(GetType(System.Math))
                            For Each var As SAVariable In selectedsacase.variables.Values
                                .Variables.DefineVariable(var.name, GetType(Double))
                                .Variables.SetVariableValue(var.name, cv.ConverterDoSI(var.unit, form.Collections.ObjectCollection(var.objectID).GetPropertyValue(var.propID)))
                            Next
                        End With
                        Me.selectedsacase.exbase = ExpressionFactory.CreateGeneric(Of Double)(Me.selectedsacase.expression, Me.selectedsacase.econtext)
                        dvval = Me.selectedsacase.exbase.Evaluate
                        'store results
                        res.Add(New Double() {iv1val, iv2val, dvval})
                    Else
                        'store results
                        Dim currresults As New ArrayList
                        currresults.Add(iv1val)
                        currresults.Add(iv2val)
                        For Each var As SAVariable In selectedsacase.depvariables.Values
                            var.currentvalue = form.Collections.ObjectCollection(var.objectID).GetPropertyValue(var.propID)
                            currresults.Add(var.currentvalue)
                        Next
                        res.Add(currresults.ToArray(Type.GetType("System.Double")))
                    End If
                    If rbExp.Checked Then
                        Me.dgvResults.Rows.Add(New Object() {Format(cv.ConverterDoSI(sacase.iv1.unit, iv1val), nf), Format(cv.ConverterDoSI(sacase.iv2.unit, iv2val), nf), Format(dvval, nf)})
                    Else
                        Dim formattedvalues As New ArrayList
                        Dim k = 0
                        formattedvalues.Add(Format(cv.ConverterDoSI(sacase.iv1.unit, iv1val), nf))
                        formattedvalues.Add(Format(cv.ConverterDoSI(sacase.iv2.unit, iv2val), nf))
                        For Each var As SAVariable In selectedsacase.depvariables.Values
                            formattedvalues.Add(Format(cv.ConverterDoSI(var.unit, var.currentvalue), nf))
                        Next
                        Me.dgvResults.Rows.Add(formattedvalues.ToArray())
                    End If
                    Me.dgvResults.FirstDisplayedScrollingRowIndex = Me.dgvResults.Rows.Count - 1
                    counter += 1
                    Me.tbStats.Text += "Run #" & counter & " completed..." & vbCrLf
                    Me.tbStats.SelectionStart = Me.tbStats.Text.Length - 1
                    Me.tbStats.SelectionLength = 1
                    Me.tbStats.ScrollToCaret()
                    If Me.abortCalc Then Exit Sub
                Next
            Next
        Catch ex As Exception
            Me.tbStats.Text += "Error: " & ex.Message.ToString & vbCrLf
        Finally
            Me.btnRun.Enabled = True
            Me.btnAbort.Enabled = False
            're-run simulation to restore original state
            Me.tbStats.Text += "Restoring simulation to its original state..." & vbCrLf
            Me.tbStats.SelectionStart = Me.tbStats.Text.Length - 1
            Me.tbStats.SelectionLength = 1
            Me.tbStats.ScrollToCaret()
            form.Collections.ObjectCollection(iv1id).SetPropertyValue(iv1prop, iv1val0)
            If Me.chkIndVar2.Checked Then form.Collections.ObjectCollection(iv2id).SetPropertyValue(iv2prop, iv2val0)
            CalculateAll(form)
            Me.tbStats.Text += "Done!" & vbCrLf
            Me.tbStats.SelectionStart = Me.tbStats.Text.Length - 1
            Me.tbStats.SelectionLength = 1
            Me.tbStats.ScrollToCaret()

            If FormMain.UtilityPlugins.ContainsKey("DF7368D6-5A06-4856-9B7A-D7F09D81F71F") Then

                btnRegressData.Enabled = True

            End If

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        abortCalc = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Process.Start("http://www.zunzun.com")
    End Sub

    Private Sub chkIndVar2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndVar2.CheckedChanged
        If Me.chkIndVar2.Checked Then
            Me.pnIndvar2.Enabled = True
        Else
            Me.pnIndvar2.Enabled = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVar.CheckedChanged, rbExp.CheckedChanged
        If Me.rbVar.Checked Then
            gbExp.Enabled = False
            gbVar.Enabled = True
        Else
            gbExp.Enabled = True
            gbVar.Enabled = False
        End If
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        Try
            Dim econtext As New ExpressionContext
            econtext.Imports.ImportStaticMembers(GetType(System.Math))
            For Each row As DataGridViewRow In Me.dgVariables.Rows
                With econtext
                    .Variables.DefineVariable(row.Cells(1).Value, GetType(Double))
                    .Variables.SetVariableValue(row.Cells(1).Value, CDbl(row.Cells(4).Value))
                End With
            Next
            Dim exbase As IGenericExpression(Of Double) = ExpressionFactory.CreateGeneric(Of Double)(Me.tbExpression.Text, econtext)
            Me.tbCurrentValue.Text = exbase.Evaluate
        Catch ex As Exception
            Me.tbCurrentValue.Text = ex.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.tbExpression.Text = ""
    End Sub

    Private Sub tsbAddVar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAddVar.Click
        Me.dgVariables.Rows.Add()
        Me.dgVariables.Rows(Me.dgVariables.Rows.Count - 1).HeaderCell.Value = Me.dgVariables.Rows.Count.ToString
        Me.dgVariables.Rows(Me.dgVariables.Rows.Count - 1).Cells(0).Value = Guid.NewGuid.ToString
    End Sub

    Private Sub tsbDelVar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelVar.Click
        If Me.dgVariables.SelectedRows.Count > 0 Then
            For i As Integer = 0 To Me.dgVariables.SelectedRows.Count - 1
                Me.dgVariables.Rows.Remove(Me.dgVariables.SelectedRows(0))
            Next
        End If
    End Sub

    Private Sub dgVariables_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVariables.CellValueChanged
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 2
                    Dim cbc As DataGridViewComboBoxCell = Me.dgVariables.Rows(e.RowIndex).Cells(e.ColumnIndex + 1)
                    cbc.Items.Clear()
                    With cbc.Items
                        If Me.dgVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString <> "" Then
                            Dim props As String()
                            props = Me.ReturnProperties(Me.dgVariables.Rows(e.RowIndex).Cells(2).Value, True)
                            For Each prop As String In props
                                .Add(DWSIM.App.GetPropertyName(prop))
                            Next
                        End If
                    End With
                Case 3
                    If Not Me.dgVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
                        Dim tbc0 As DataGridViewTextBoxCell = Me.dgVariables.Rows(e.RowIndex).Cells(4)
                        Dim tbc1 As DataGridViewTextBoxCell = Me.dgVariables.Rows(e.RowIndex).Cells(5)
                        Dim props As String() = Me.ReturnProperties(Me.dgVariables.Rows(e.RowIndex).Cells(2).Value, True)
                        For Each prop As String In props
                            If DWSIM.App.GetPropertyName(prop) = Me.dgVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString Then
                                Dim obj As SimulationObjects_BaseClass = ReturnObject(Me.dgVariables.Rows(e.RowIndex).Cells(2).Value)
                                tbc0.Value = Format(obj.GetPropertyValue(prop, su), nf)
                                tbc1.Value = obj.GetPropertyUnit(prop, su)
                            End If
                        Next
                    End If
            End Select
        End If
    End Sub

    Private Sub dgDepVariables_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDepVariables.CellValueChanged
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 1
                    Dim cbc As DataGridViewComboBoxCell = Me.dgDepVariables.Rows(e.RowIndex).Cells(e.ColumnIndex + 1)
                    cbc.Items.Clear()
                    With cbc.Items
                        If Me.dgDepVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString <> "" Then
                            Dim props As String()
                            props = Me.ReturnProperties(Me.dgDepVariables.Rows(e.RowIndex).Cells(1).Value, True)
                            For Each prop As String In props
                                .Add(DWSIM.App.GetPropertyName(prop))
                            Next
                        End If
                    End With
                    cbc.Sorted = True
                Case 2
                    If Not Me.dgDepVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is Nothing Then
                        Dim tbc0 As DataGridViewTextBoxCell = Me.dgDepVariables.Rows(e.RowIndex).Cells(3)
                        Dim props As String() = Me.ReturnProperties(Me.dgDepVariables.Rows(e.RowIndex).Cells(1).Value, True)
                        For Each prop As String In props
                            If DWSIM.App.GetPropertyName(prop) = Me.dgDepVariables.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString Then
                                Dim obj As SimulationObjects_BaseClass = ReturnObject(Me.dgDepVariables.Rows(e.RowIndex).Cells(1).Value)
                                tbc0.Value = obj.GetPropertyUnit(prop, su)
                            End If
                        Next
                    End If
            End Select
        End If
    End Sub

    Private Function ReturnObject(ByVal objectTAG As String) As SimulationObjects_BaseClass

        For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
            If objectTAG = obj.GraphicObject.Tag Then
                Return obj
                Exit Function
            End If
        Next

        Return Nothing

    End Function

    Private Function ReturnPropertyID(ByVal objectID As String, ByVal propTAG As String) As String

        Dim props As String() = form.Collections.ObjectCollection(objectID).GetProperties(SimulationObjects_BaseClass.PropertyType.ALL)
        For Each prop As String In props
            If DWSIM.App.GetPropertyName(prop) = propTAG Then
                Return prop
            End If
        Next

        Return Nothing

    End Function

    Private Sub dgVariables_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgVariables.DataError

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.dgDepVariables.Rows.Add()
        Me.dgDepVariables.Rows(Me.dgDepVariables.Rows.Count - 1).HeaderCell.Value = Me.dgDepVariables.Rows.Count.ToString
        Me.dgDepVariables.Rows(Me.dgDepVariables.Rows.Count - 1).Cells(0).Value = Guid.NewGuid.ToString
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.dgDepVariables.SelectedRows.Count > 0 Then
            For i As Integer = 0 To Me.dgDepVariables.SelectedRows.Count - 1
                Me.dgDepVariables.Rows.Remove(Me.dgDepVariables.SelectedRows(0))
            Next
        End If
    End Sub

    Private Sub tbCaseName_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbCaseName.TextChanged
        If selected Then
            Me.lbCases.Items(Me.lbCases.SelectedIndex) = Me.tbCaseName.Text
        End If
    End Sub

    Private Sub dgDepVariables_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDepVariables.DataError

    End Sub

    Private Sub dgvResults_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvResults.DataError

    End Sub

    Private Sub btnRegressData_Click(sender As System.Object, e As System.EventArgs) Handles btnRegressData.Click

        'data fitting plugin is available
        Dim myUPlugin As Interfaces.IUtilityPlugin = FormMain.UtilityPlugins.Item("DF7368D6-5A06-4856-9B7A-D7F09D81F71F")

        myUPlugin.SetFlowsheet(form)

        Dim pform As Form = myUPlugin.UtilityForm

        dgvResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        dgvResults.SelectAll()
        pform.Tag = TryCast(dgvResults.GetClipboardContent(), DataObject).GetText()
        dgvResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText
        pform.ShowDialog(Me)

    End Sub

End Class