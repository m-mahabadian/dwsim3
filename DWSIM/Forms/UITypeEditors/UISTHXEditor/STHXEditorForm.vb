﻿Public Class STHXEditorForm

    Public props As DWSIM.SimulationObjects.UnitOps.Auxiliary.HeatExchanger.STHXProperties

    Dim su As DWSIM.SistemasDeUnidades.Unidades = My.Application.ActiveSimulation.Options.SelectedUnitSystem
    Dim cv As New DWSIM.SistemasDeUnidades.Conversor
    Dim nf As String = My.Application.ActiveSimulation.Options.NumberFormat

    Private Sub STHXEditorForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        With props
            .Shell_BaffleCut = tbBaffleCut.Text
            .Shell_BaffleSpacing = cv.ConverterParaSI(su.thickness, tbBaffleSpacing.Text)
            .Shell_NumberOfPasses = tbNumberOfShellPasses.Text
            .Tube_NumberPerShell = tbNumberOfTubesPerShell.Text
            .Shell_Di = cv.ConverterParaSI(su.diameter, tbShellDi.Text)
            .Shell_Fouling = cv.ConverterParaSI(su.foulingfactor, tbShellFoulingFactor.Text)
            .Shell_NumberOfShellsInSeries = tbShellsInSeries.Text
            .Tube_De = cv.ConverterParaSI(su.diameter, tbTubeDe.Text)
            .Tube_Di = cv.ConverterParaSI(su.diameter, tbTubeDi.Text)
            .Tube_Roughness = cv.ConverterParaSI(su.diameter, tbTubeRoughness.Text)
            .Tube_Fouling = cv.ConverterParaSI(su.foulingfactor, tbTubeFoulingFactor.Text)
            .Tube_Length = cv.ConverterParaSI(su.distance, tbTubeLength.Text)
            .Tube_PassesPerShell = tbTubePassesPerShell.Text
            .Tube_Pitch = cv.ConverterParaSI(su.thickness, tbTubePitch.Text)
            .Tube_ThermalConductivity = cv.ConverterParaSI(su.spmp_thermalConductivity, tbTubeThermalCond.Text)
            .Shell_BaffleOrientation = cbBaffleOrientation.SelectedIndex
            .Shell_BaffleType = cbBaffleType.SelectedIndex
            .Tube_Layout = cbTubeLayout.SelectedIndex
            If rbCold.Checked Then
                .Tube_Fluid = 0
                .Shell_Fluid = 1
            Else
                .Tube_Fluid = 1
                .Shell_Fluid = 0
            End If
        End With

    End Sub

    Private Sub STHXEditorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With props
            tbBaffleCut.Text = Format(.Shell_BaffleCut, nf)
            tbBaffleSpacing.Text = Format(cv.ConverterDoSI(su.thickness, .Shell_BaffleSpacing), nf)
            tbNumberOfShellPasses.Text = .Shell_NumberOfPasses
            tbNumberOfTubesPerShell.Text = .Tube_NumberPerShell
            tbShellDi.Text = Format(cv.ConverterDoSI(su.diameter, .Shell_Di), nf)
            tbShellFoulingFactor.Text = cv.ConverterDoSI(su.foulingfactor, .Shell_Fouling)
            tbShellsInSeries.Text = .Shell_NumberOfShellsInSeries
            tbTubeDe.Text = Format(cv.ConverterDoSI(su.diameter, .Tube_De), nf)
            tbTubeDi.Text = Format(cv.ConverterDoSI(su.diameter, .Tube_Di), nf)
            tbTubeFoulingFactor.Text = cv.ConverterDoSI(su.foulingfactor, .Tube_Fouling)
            tbTubeLength.Text = Format(cv.ConverterDoSI(su.distance, .Tube_Length), nf)
            tbTubePassesPerShell.Text = .Tube_PassesPerShell
            tbTubePitch.Text = Format(cv.ConverterDoSI(su.thickness, .Tube_Pitch), nf)
            tbTubeRoughness.Text = cv.ConverterDoSI(su.diameter, .Tube_Roughness)
            tbTubeThermalCond.Text = cv.ConverterDoSI(su.spmp_thermalConductivity, .Tube_ThermalConductivity)
            cbBaffleOrientation.SelectedIndex = .Shell_BaffleOrientation
            cbBaffleType.SelectedIndex = .Shell_BaffleType
            cbTubeLayout.SelectedIndex = .Tube_Layout
            If .Tube_Fluid = 0 Then
                rbCold.Checked = True
            Else
                rbCold.Checked = False
            End If
        End With

        lbTubeDe.Text = su.diameter
        lbuTubeDi.Text = su.diameter
        lbTubeRoughness.Text = su.diameter
        lbuShellDi.Text = su.diameter
        lbuBaffleCut.Text = "%"
        lbuBaffleSpacing.Text = su.thickness
        lbuShellFoulingFactor.Text = su.foulingfactor
        lbuTubeFoulingFactor.Text = su.foulingfactor
        lbuTubeLength.Text = su.distance
        lbuTubePitch.Text = su.thickness
        lbuTubeThermalCond.Text = su.spmp_thermalConductivity

    End Sub

End Class