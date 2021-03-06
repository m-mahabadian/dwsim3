'    NRTL Property Package 
'    Copyright 2008 Daniel Wagner O. de Medeiros
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

Imports DWSIM.DWSIM.SimulationObjects.PropertyPackages
Imports System.Math
Imports DWSIM.DWSIM.ClassesBasicasTermodinamica

Namespace DWSIM.SimulationObjects.PropertyPackages

    <System.Runtime.InteropServices.Guid(NRTLPropertyPackage.ClassId)> _
   <System.Serializable()> Public Class NRTLPropertyPackage

        Inherits DWSIM.SimulationObjects.PropertyPackages.PropertyPackage

        Public Shadows Const ClassId As String = "D42F0157-5750-4c89-A94E-634A04701568"

        Public MAT_KIJ(38, 38)

        Private m_props As New DWSIM.SimulationObjects.PropertyPackages.Auxiliary.PROPS
        Public m_pr As New DWSIM.SimulationObjects.PropertyPackages.Auxiliary.PengRobinson
        Public m_uni As New DWSIM.SimulationObjects.PropertyPackages.Auxiliary.NRTL
        Private m_lk As New DWSIM.SimulationObjects.PropertyPackages.Auxiliary.LeeKesler
        '<System.NonSerialized()> Private m_xn As DLLXnumbers.Xnumbers

        Public Sub New(ByVal comode As Boolean)
            MyBase.New(comode)
            With Me.Parameters
                .Add("PP_IDEAL_VAPOR_PHASE_FUG", 0)
            End With
        End Sub

        Public Sub New()

            MyBase.New()

            With Me.Parameters
                .Add("PP_IDEAL_VAPOR_PHASE_FUG", 0)
            End With

            Me.IsConfigurable = True
            Me.ConfigForm = New FormConfigNRTL
            Me._packagetype = PropertyPackages.PackageType.ActivityCoefficient

        End Sub

        Public Overrides Sub ReconfigureConfigForm()
            MyBase.ReconfigureConfigForm()
            Me.ConfigForm = New FormConfigNRTL
        End Sub

#Region "    DWSIM Functions"

        Public Function RET_KIJ(ByVal id1 As String, ByVal id2 As String) As Double
            If Me.m_pr.InteractionParameters.ContainsKey(id1) Then
                If Me.m_pr.InteractionParameters(id1).ContainsKey(id2) Then
                    Return m_pr.InteractionParameters(id1)(id2).kij
                Else
                    If Me.m_pr.InteractionParameters.ContainsKey(id2) Then
                        If Me.m_pr.InteractionParameters(id2).ContainsKey(id1) Then
                            Return m_pr.InteractionParameters(id2)(id1).kij
                        Else
                            Return 0
                        End If
                    Else
                        Return 0
                    End If
                End If
            Else
                Return 0
            End If
        End Function

        Public Overrides Function RET_VKij() As Double(,)

            Dim val(Me.CurrentMaterialStream.Fases(0).Componentes.Count - 1, Me.CurrentMaterialStream.Fases(0).Componentes.Count - 1) As Double
            Dim i As Integer = 0
            Dim l As Integer = 0

            i = 0
            For Each cp As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(0).Componentes.Values
                l = 0
                For Each cp2 As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(0).Componentes.Values
                    val(i, l) = Me.RET_KIJ(cp.Nome, cp2.Nome)
                    l = l + 1
                Next
                i = i + 1
            Next

            Return val

        End Function

        Public Overrides Function DW_CalcCp_ISOL(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal T As Double, ByVal P As Double) As Double
            Select Case fase1
                Case Fase.Liquid
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(1)
                Case Fase.Aqueous
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(1)
                Case Fase.Liquid1
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(1)
                Case Fase.Liquid2
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(1)
                Case Fase.Liquid3
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(1)
                Case Fase.Vapor
                    Return Me.m_props.CpCvR("V", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(1)
            End Select
        End Function

        Public Overrides Function DW_CalcEnergiaMistura_ISOL(ByVal T As Double, ByVal P As Double) As Double

            Dim HM, HV, HL As Double

            HL = Me.m_lk.H_LK_MIX("L", T, P, RET_VMOL(Fase.Liquid), RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, Me.RET_Hid(298.15, T, Fase.Liquid))
            HV = Me.m_lk.H_LK_MIX("V", T, P, RET_VMOL(Fase.Vapor), RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, Me.RET_Hid(298.15, T, Fase.Vapor))
            HM = Me.CurrentMaterialStream.Fases(1).SPMProperties.massfraction.GetValueOrDefault * HL + Me.CurrentMaterialStream.Fases(2).SPMProperties.massfraction.GetValueOrDefault * HV

            Dim ent_massica = HM
            Dim flow = Me.CurrentMaterialStream.Fases(0).SPMProperties.massflow
            Return ent_massica * flow

        End Function

        Public Overrides Function DW_CalcK_ISOL(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal T As Double, ByVal P As Double) As Double
            If fase1 = Fase.Liquid Then
                Return Me.AUX_CONDTL(T)
            ElseIf fase1 = Fase.Vapor Then
                Return Me.AUX_CONDTG(T, P)
            End If
        End Function

        Public Overrides Function DW_CalcMassaEspecifica_ISOL(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal T As Double, ByVal P As Double, Optional ByVal pvp As Double = 0) As Double
            If fase1 = Fase.Liquid Then
                Return Me.AUX_LIQDENS(T)
            ElseIf fase1 = Fase.Vapor Then
                Return Me.AUX_VAPDENS(T, P)
            ElseIf fase1 = Fase.Mixture Then
                Return Me.CurrentMaterialStream.Fases(1).SPMProperties.volumetric_flow.GetValueOrDefault * Me.AUX_LIQDENS(T) / Me.CurrentMaterialStream.Fases(0).SPMProperties.volumetric_flow.GetValueOrDefault + Me.CurrentMaterialStream.Fases(2).SPMProperties.volumetric_flow.GetValueOrDefault * Me.AUX_VAPDENS(T, P) / Me.CurrentMaterialStream.Fases(0).SPMProperties.volumetric_flow.GetValueOrDefault
            End If
        End Function

        Public Overrides Function DW_CalcMM_ISOL(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal T As Double, ByVal P As Double) As Double
            Return Me.AUX_MMM(fase1)
        End Function

        Public Overrides Sub DW_CalcOverallProps()
            MyBase.DW_CalcOverallProps()
        End Sub

        Public Overrides Sub DW_CalcProp(ByVal [property] As String, ByVal phase As Fase)

            Dim result As Double = 0.0#
            Dim resultObj As Object = Nothing
            Dim phaseID As Integer = -1
            Dim state As String = ""

            Dim T, P As Double
            T = Me.CurrentMaterialStream.Fases(0).SPMProperties.temperature
            P = Me.CurrentMaterialStream.Fases(0).SPMProperties.pressure

            Select Case phase
                Case Fase.Vapor
                    state = "V"
                Case Fase.Liquid, Fase.Liquid1, Fase.Liquid2, Fase.Liquid3
                    state = "L"
            End Select

            Select Case phase
                Case PropertyPackages.Fase.Mixture
                    phaseID = 0
                Case PropertyPackages.Fase.Vapor
                    phaseID = 2
                Case PropertyPackages.Fase.Liquid1
                    phaseID = 3
                Case PropertyPackages.Fase.Liquid2
                    phaseID = 4
                Case PropertyPackages.Fase.Liquid3
                    phaseID = 5
                Case PropertyPackages.Fase.Liquid
                    phaseID = 1
                Case PropertyPackages.Fase.Aqueous
                    phaseID = 6
                Case PropertyPackages.Fase.Solid
                    phaseID = 7
            End Select

            Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight = Me.AUX_MMM(phase)

            Select Case [property].ToLower
                Case "compressibilityfactor"
                    result = Me.m_lk.Z_LK(state, T / Me.AUX_TCM(phase), P / Me.AUX_PCM(phase), Me.AUX_WM(phase))(0)
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.compressibilityFactor = result
                Case "heatcapacity", "heatcapacitycp"
                    resultObj = Me.m_lk.CpCvR_LK(state, T, P, RET_VMOL(phase), RET_VKij(), RET_VMAS(phase), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCp = resultObj(1)
                Case "heatcapacitycv"
                    resultObj = Me.m_lk.CpCvR_LK(state, T, P, RET_VMOL(phase), RET_VKij(), RET_VMAS(phase), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCv = resultObj(2)
                Case "enthalpy", "enthalpynf"
                    result = Me.m_lk.H_LK_MIX(state, T, P, RET_VMOL(phase), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Hid(298.15, T, phase))
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy = result
                    result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_enthalpy = result
                Case "entropy", "entropynf"
                    result = Me.m_lk.S_LK_MIX(state, T, P, RET_VMOL(phase), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Sid(298.15, T, P, phase))
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy = result
                    result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_entropy = result
                Case "excessenthalpy"
                    result = Me.m_lk.H_LK_MIX(state, T, P, RET_VMOL(phase), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), 0)
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.excessEnthalpy = result
                Case "excessentropy"
                    result = Me.m_lk.S_LK_MIX(state, T, P, RET_VMOL(phase), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), 0)
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.excessEntropy = result
                Case "enthalpyf"
                    Dim entF As Double = Me.AUX_HFm25(phase)
                    result = Me.m_lk.H_LK_MIX(state, T, P, RET_VMOL(phase), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Hid(298.15, T, phase))
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpyF = result + entF
                    result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpyF.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_enthalpyF = result
                Case "entropyf"
                    Dim entF As Double = Me.AUX_SFm25(phase)
                    result = Me.m_lk.S_LK_MIX(state, T, P, RET_VMOL(phase), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Sid(298.15, T, P, phase))
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropyF = result + entF
                    result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropyF.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_entropyF = result
                Case "viscosity"
                    If state = "L" Then
                        result = Me.AUX_LIQVISCm(T)
                    Else
                        result = Me.AUX_VAPVISCm(T, Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density.GetValueOrDefault, Me.AUX_MMM(phase))
                    End If
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.viscosity = result
                Case "thermalconductivity"
                    If state = "L" Then
                        result = Me.AUX_CONDTL(T)
                    Else
                        result = Me.AUX_CONDTG(T, P)
                    End If
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.thermalConductivity = result
                Case "fugacity", "fugacitycoefficient", "logfugacitycoefficient", "activity", "activitycoefficient"
                    Me.DW_CalcCompFugCoeff(phase)
                Case "volume", "density"
                    If state = "L" Then
                        result = Me.AUX_LIQDENS(T, P, 0.0#, phaseID, False)
                    Else
                        result = Me.AUX_VAPDENS(T, P)
                    End If
                    Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density = result
                Case "surfacetension"
                    Me.CurrentMaterialStream.Fases(0).TPMProperties.surfaceTension = Me.AUX_SURFTM(T)
                Case Else
                    Dim ex As Exception = New CapeOpen.CapeThrmPropertyNotAvailableException
                    ThrowCAPEException(ex, "Error", ex.Message, "ICapeThermoMaterial", ex.Source, ex.StackTrace, "CalcSinglePhaseProp/CalcTwoPhaseProp/CalcProp", ex.GetHashCode)
            End Select

        End Sub

        Public Overrides Sub DW_CalcPhaseProps(ByVal fase As DWSIM.SimulationObjects.PropertyPackages.Fase)

            Dim result As Double
            Dim resultObj As Object
            Dim dwpl As Fase

            Dim T, P As Double
            Dim phasemolarfrac As Double = Nothing
            Dim overallmolarflow As Double = Nothing

            Dim phaseID As Integer
            T = Me.CurrentMaterialStream.Fases(0).SPMProperties.temperature
            P = Me.CurrentMaterialStream.Fases(0).SPMProperties.pressure

            Select Case fase
                Case PropertyPackages.Fase.Mixture
                    phaseID = 0
                    dwpl = PropertyPackages.Fase.Mixture
                Case PropertyPackages.Fase.Vapor
                    phaseID = 2
                    dwpl = PropertyPackages.Fase.Vapor
                Case PropertyPackages.Fase.Liquid1
                    phaseID = 3
                    dwpl = PropertyPackages.Fase.Liquid1
                Case PropertyPackages.Fase.Liquid2
                    phaseID = 4
                    dwpl = PropertyPackages.Fase.Liquid2
                Case PropertyPackages.Fase.Liquid3
                    phaseID = 5
                    dwpl = PropertyPackages.Fase.Liquid3
                Case PropertyPackages.Fase.Liquid
                    phaseID = 1
                    dwpl = PropertyPackages.Fase.Liquid
                Case PropertyPackages.Fase.Aqueous
                    phaseID = 6
                    dwpl = PropertyPackages.Fase.Aqueous
                Case PropertyPackages.Fase.Solid
                    phaseID = 7
                    dwpl = PropertyPackages.Fase.Solid
            End Select

            If phaseID > 0 Then
                overallmolarflow = Me.CurrentMaterialStream.Fases(0).SPMProperties.molarflow.GetValueOrDefault
                phasemolarfrac = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molarfraction.GetValueOrDefault
                result = overallmolarflow * phasemolarfrac
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molarflow = result
                result = result * Me.AUX_MMM(fase) / 1000
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.massflow = result
                result = phasemolarfrac * overallmolarflow * Me.AUX_MMM(fase) / 1000 / Me.CurrentMaterialStream.Fases(0).SPMProperties.massflow.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.massfraction = result
                Me.DW_CalcCompVolFlow(phaseID)
                Me.DW_CalcCompFugCoeff(fase)
            End If

            If phaseID = 3 Or phaseID = 4 Or phaseID = 5 Or phaseID = 6 Then

                result = Me.AUX_LIQDENS(T, P, 0.0#, phaseID, False)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density = result
                result = Me.m_lk.H_LK_MIX("L", T, P, RET_VMOL(dwpl), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Hid(298.15, T, dwpl))
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy = result
                result = Me.m_lk.S_LK_MIX("L", T, P, RET_VMOL(dwpl), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Sid(298.15, T, P, dwpl))
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy = result
                'result = Me.m_pr.Z_PR(T, P, RET_VMOL(dwpl), RET_VKij(), RET_VTC, RET_VPC, RET_VW, "L")
                result = Me.m_lk.Z_LK("L", T / Me.AUX_TCM(dwpl), P / Me.AUX_PCM(dwpl), Me.AUX_WM(dwpl))(0)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.compressibilityFactor = result
                resultObj = Me.m_lk.CpCvR_LK("L", T, P, RET_VMOL(dwpl), RET_VKij(), RET_VMAS(dwpl), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCp = resultObj(1)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCv = resultObj(2)
                result = Me.AUX_MMM(fase)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight = result
                result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_enthalpy = result
                result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_entropy = result
                result = Me.AUX_CONDTL(T)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.thermalConductivity = result
                result = Me.AUX_LIQVISCm(T)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.viscosity = result
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.kinematic_viscosity = result / Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density.Value

            ElseIf phaseID = 2 Then

                result = Me.AUX_VAPDENS(T, P)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density = result
                result = Me.m_lk.H_LK_MIX("V", T, P, RET_VMOL(fase.Vapor), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Hid(298.15, T, fase.Vapor))
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy = result
                result = Me.m_lk.S_LK_MIX("V", T, P, RET_VMOL(fase.Vapor), RET_VKij, RET_VTC(), RET_VPC(), RET_VW(), RET_VMM(), Me.RET_Sid(298.15, T, P, fase.Vapor))
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy = result
                'result = Me.m_pr.Z_PR(T, P, RET_VMOL(fase.Vapor), RET_VKij, RET_VTC, RET_VPC, RET_VW, "V")
                result = Me.m_lk.Z_LK("V", T / Me.AUX_TCM(PropertyPackages.Fase.Vapor), P / Me.AUX_PCM(PropertyPackages.Fase.Vapor), Me.AUX_WM(PropertyPackages.Fase.Vapor))(0)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.compressibilityFactor = result
                result = Me.AUX_CPm(PropertyPackages.Fase.Vapor, T)
                resultObj = Me.m_lk.CpCvR_LK("V", T, P, RET_VMOL(PropertyPackages.Fase.Vapor), RET_VKij(), RET_VMAS(PropertyPackages.Fase.Vapor), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCp = resultObj(1)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCv = resultObj(2)
                result = Me.AUX_MMM(fase)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight = result
                result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_enthalpy = result
                result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_entropy = result
                result = Me.AUX_CONDTG(T, P)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.thermalConductivity = result
                result = Me.AUX_VAPVISCm(T, Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density.GetValueOrDefault, Me.AUX_MMM(fase))
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.viscosity = result
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.kinematic_viscosity = result / Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density.Value

            ElseIf phaseID = 7 Then

                result = Me.AUX_SOLIDDENS
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density = result
                Dim constprops As New List(Of ConstantProperties)
                For Each su As Substancia In Me.CurrentMaterialStream.Fases(0).Componentes.Values
                    constprops.Add(su.ConstantProperties)
                Next
                result = Me.DW_CalcSolidEnthalpy(T, RET_VMOL(PropertyPackages.Fase.Solid), constprops)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy = result
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy = result / T
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.compressibilityFactor = 0.0# 'result
                result = Me.DW_CalcSolidHeatCapacityCp(T, RET_VMOL(PropertyPackages.Fase.Solid), constprops)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCp = result
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.heatCapacityCv = result
                result = Me.AUX_MMM(fase)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight = result
                result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.enthalpy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_enthalpy = result
                result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.entropy.GetValueOrDefault * Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molecularWeight.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.molar_entropy = result
                result = Me.AUX_CONDTG(T, P)
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.thermalConductivity = 0.0# 'result
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.viscosity = 1.0E+20
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.kinematic_viscosity = 1.0E+20

            ElseIf phaseID = 1 Then

                DW_CalcLiqMixtureProps()

            Else

                DW_CalcOverallProps()


            End If

            If phaseID > 0 Then
                result = overallmolarflow * phasemolarfrac * Me.AUX_MMM(fase) / 1000 / Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density.GetValueOrDefault
                Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.volumetric_flow = result
            Else
                'result = Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.massflow.GetValueOrDefault / Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.density.GetValueOrDefault
                'Me.CurrentMaterialStream.Fases(phaseID).SPMProperties.volumetric_flow = result
            End If

        End Sub

        Public Overrides Function DW_CalcPVAP_ISOL(ByVal T As Double) As Double
            Return Me.m_props.Pvp_leekesler(T, Me.RET_VTC(Fase.Liquid), Me.RET_VPC(Fase.Liquid), Me.RET_VW(Fase.Liquid))
        End Function

        Public Overrides Function DW_CalcTensaoSuperficial_ISOL(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal T As Double, ByVal P As Double) As Double
            Return Me.AUX_SURFTM(T)
        End Function

        Public Overrides Sub DW_CalcTwoPhaseProps(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal fase2 As DWSIM.SimulationObjects.PropertyPackages.Fase)

            Dim T As Double

            T = Me.CurrentMaterialStream.Fases(0).SPMProperties.temperature
            Me.CurrentMaterialStream.Fases(0).TPMProperties.surfaceTension = Me.AUX_SURFTM(T)

        End Sub

        Public Overrides Sub DW_CalcVazaoMassica()
            With Me.CurrentMaterialStream
                .Fases(0).SPMProperties.massflow = .Fases(0).SPMProperties.molarflow.GetValueOrDefault * Me.AUX_MMM(Fase.Mixture) / 1000
            End With
        End Sub

        Public Overrides Sub DW_CalcVazaoMolar()
            With Me.CurrentMaterialStream
                .Fases(0).SPMProperties.molarflow = .Fases(0).SPMProperties.massflow.GetValueOrDefault / Me.AUX_MMM(Fase.Mixture) * 1000
            End With
        End Sub

        Public Overrides Sub DW_CalcVazaoVolumetrica()
            With Me.CurrentMaterialStream
                .Fases(0).SPMProperties.volumetric_flow = .Fases(0).SPMProperties.massflow.GetValueOrDefault / .Fases(0).SPMProperties.density.GetValueOrDefault
            End With
        End Sub

        Public Overrides Function DW_CalcViscosidadeDinamica_ISOL(ByVal fase1 As DWSIM.SimulationObjects.PropertyPackages.Fase, ByVal T As Double, ByVal P As Double) As Double
            If fase1 = Fase.Liquid Then
                Return Me.AUX_LIQVISCm(T)
            ElseIf fase1 = Fase.Vapor Then
                Return Me.AUX_VAPVISCm(T, Me.AUX_VAPDENS(T, P), Me.AUX_MMM(Fase.Vapor))
            End If
        End Function
        Public Overrides Function SupportsComponent(ByVal comp As ClassesBasicasTermodinamica.ConstantProperties) As Boolean

            If Me.SupportedComponents.Contains(comp.ID) Then
                Return True
            ElseIf comp.IsHYPO = 1 Then
                Return True
            Else
                Return True
            End If

        End Function

        Function dfidRbb_H(ByVal Rbb, ByVal Kb0, ByVal Vz, ByVal Vu, ByVal sum_Hvi0, ByVal DHv, ByVal DHl, ByVal HT) As Double

            Dim i As Integer = 0
            Dim n = UBound(Vz)

            Dim Vpbb2(n), L2, V2, Kb2 As Double

            i = 0
            Dim sum_pi2 = 0
            Dim sum_eui_pi2 = 0
            Do
                Vpbb2(i) = Vz(i) / (1 - Rbb + Kb0 * Rbb * Exp(Vu(i)))
                sum_pi2 += Vpbb2(i)
                sum_eui_pi2 += Exp(Vu(i)) * Vpbb2(i)
                i = i + 1
            Loop Until i = n + 1
            Kb2 = sum_pi2 / sum_eui_pi2

            L2 = (1 - Rbb) * sum_pi2
            V2 = 1 - L2

            Return L2 * (DHv - DHl) - sum_Hvi0 - DHv + HT * Me.AUX_MMM(Vz)

        End Function

        Function dfidRbb_S(ByVal Rbb, ByVal Kb0, ByVal Vz, ByVal Vu, ByVal sum_Hvi0, ByVal DHv, ByVal DHl, ByVal ST) As Double

            Dim i As Integer = 0
            Dim n = UBound(Vz)

            Dim Vpbb2(n), L, V As Double

            i = 0
            Dim sum_pi2 = 0
            Dim sum_eui_pi2 = 0
            Do
                Vpbb2(i) = Vz(i) / (1 - Rbb + Kb0 * Rbb * Exp(Vu(i)))
                sum_pi2 += Vpbb2(i)
                sum_eui_pi2 += Exp(Vu(i)) * Vpbb2(i)
                i = i + 1
            Loop Until i = n + 1

            L = (1 - Rbb) * sum_pi2
            V = 1 - L

            Return L * (DHv - DHl) - sum_Hvi0 - DHv + ST * Me.AUX_MMM(Vz)

        End Function

#End Region

#Region "    Auxiliary Functions"

        Function RET_VN(ByVal subst As DWSIM.ClassesBasicasTermodinamica.Substancia) As Object

            Dim vn(15) As Integer
            With subst.ConstantProperties
                vn(0) = .UNIFAC_01_CH4
                vn(1) = .UNIFAC_02_CH3
                vn(2) = .UNIFAC_03_CH2
                vn(3) = .UNIFAC_04_CH
                vn(4) = .UNIFAC_05_H2O
                vn(5) = .UNIFAC_06_H2S
                vn(6) = .UNIFAC_07_CO2
                vn(7) = .UNIFAC_08_N2
                vn(8) = .UNIFAC_09_O2
                vn(9) = .UNIFAC_10_OH
                vn(10) = .UNIFAC_11_ACH
                vn(11) = .UNIFAC_12_ACCH2
                vn(12) = .UNIFAC_13_ACCH3
                vn(13) = .UNIFAC_14_ACOH
                vn(14) = .UNIFAC_15_CH3CO
                vn(15) = .UNIFAC_16_CH2CO
            End With

            Return vn

        End Function

        Function RET_VQ() As Object

            Dim subst As DWSIM.ClassesBasicasTermodinamica.Substancia
            Dim VQ(Me.CurrentMaterialStream.Fases(0).Componentes.Count - 1) As Double
            Dim i As Integer = 0

            For Each subst In Me.CurrentMaterialStream.Fases(0).Componentes.Values
                VQ(i) = subst.ConstantProperties.UNIFAC_Qi
                i += 1
            Next

            Return VQ

        End Function

        Function RET_VR() As Object

            Dim subst As DWSIM.ClassesBasicasTermodinamica.Substancia
            Dim VR(Me.CurrentMaterialStream.Fases(0).Componentes.Count - 1) As Double
            Dim i As Integer = 0

            For Each subst In Me.CurrentMaterialStream.Fases(0).Componentes.Values
                VR(i) = subst.ConstantProperties.UNIFAC_Ri
                i += 1
            Next

            Return VR

        End Function

#End Region

#Region "    M�todos Num�ricos"

        Public Function IntegralSimpsonCp(ByVal a As Double, _
                 ByVal b As Double, _
                 ByVal Epsilon As Double, ByVal subst As String) As Double

            Dim Result As Double
            Dim switch As Boolean = False
            Dim h As Double
            Dim s As Double
            Dim s1 As Double
            Dim s2 As Double
            Dim s3 As Double
            Dim x As Double
            Dim tm As Double

            If a > b Then
                switch = True
                tm = a
                a = b
                b = tm
            ElseIf Abs(a - b) < 0.01 Then
                Return 0
            End If

            s2 = 1.0#
            h = b - a
            s = Me.AUX_CPi(subst, a) + Me.AUX_CPi(subst, b)
            Do
                s3 = s2
                h = h / 2.0#
                s1 = 0.0#
                x = a + h
                Do
                    s1 = s1 + 2.0# * Me.AUX_CPi(subst, x)
                    x = x + 2.0# * h
                Loop Until Not x < b
                s = s + s1
                s2 = (s + s1) * h / 3.0#
                x = Abs(s3 - s2) / 15.0#
            Loop Until Not x > Epsilon
            Result = s2

            If switch Then Result = -Result

            IntegralSimpsonCp = Result

        End Function

        Public Function IntegralSimpsonCp_T(ByVal a As Double, _
         ByVal b As Double, _
         ByVal Epsilon As Double, ByVal subst As String) As Double

            'Cp = A + B*T + C*T^2 + D*T^3 + E*T^4 where Cp in kJ/kg-mol , T in K 


            Dim Result As Double
            Dim h As Double
            Dim s As Double
            Dim s1 As Double
            Dim s2 As Double
            Dim s3 As Double
            Dim x As Double
            Dim tm As Double
            Dim switch As Boolean = False

            If a > b Then
                switch = True
                tm = a
                a = b
                b = tm
            ElseIf Abs(a - b) < 0.01 Then
                Return 0
            End If

            s2 = 1.0#
            h = b - a
            s = Me.AUX_CPi(subst, a) / a + Me.AUX_CPi(subst, b) / b
            Do
                s3 = s2
                h = h / 2.0#
                s1 = 0.0#
                x = a + h
                Do
                    s1 = s1 + 2.0# * Me.AUX_CPi(subst, x) / x
                    x = x + 2.0# * h
                Loop Until Not x < b
                s = s + s1
                s2 = (s + s1) * h / 3.0#
                x = Abs(s3 - s2) / 15.0#
            Loop Until Not x > Epsilon
            Result = s2

            If switch Then Result = -Result

            IntegralSimpsonCp_T = Result

        End Function

#End Region

        Public Overrides Function DW_CalcEnthalpy(ByVal Vx As System.Array, ByVal T As Double, ByVal P As Double, ByVal st As State) As Double

            Dim H As Double

            If st = State.Liquid Then
                H = Me.m_lk.H_LK_MIX("L", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, Me.RET_Hid(298.15, T, Vx))
            Else
                H = Me.m_lk.H_LK_MIX("V", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, Me.RET_Hid(298.15, T, Vx))
            End If

            Return H

        End Function

        Public Overrides Function DW_CalcEnthalpyDeparture(ByVal Vx As System.Array, ByVal T As Double, ByVal P As Double, ByVal st As State) As Double
            Dim H As Double

            If st = State.Liquid Then
                H = Me.m_lk.H_LK_MIX("L", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, 0)
            Else
                H = Me.m_lk.H_LK_MIX("V", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, 0)
            End If

            Return H

        End Function

        Public Overrides Function DW_CalcCv_ISOL(ByVal fase1 As Fase, ByVal T As Double, ByVal P As Double) As Double
            Select Case fase1
                Case Fase.Liquid
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(2)
                Case Fase.Aqueous
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(2)
                Case Fase.Liquid1
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(2)
                Case Fase.Liquid2
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(2)
                Case Fase.Liquid3
                    Return Me.m_props.CpCvR("L", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(2)
                Case Fase.Vapor
                    Return Me.m_props.CpCvR("V", T, P, RET_VMOL(fase1), RET_VKij(), RET_VMAS(fase1), RET_VTC(), RET_VPC(), RET_VCP(T), RET_VMM(), RET_VW(), RET_VZRa())(2)
            End Select
        End Function

        Public Overloads Overrides Sub DW_CalcCompPartialVolume(ByVal phase As Fase, ByVal T As Double, ByVal P As Double)
            Select Case phase
                Case Fase.Liquid
                    For Each subst As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(1).Componentes.Values
                        subst.PartialVolume = 1 / 1000 * subst.ConstantProperties.Molar_Weight / Me.m_props.liq_dens_rackett(T, subst.ConstantProperties.Critical_Temperature, subst.ConstantProperties.Critical_Pressure, subst.ConstantProperties.Acentric_Factor, subst.ConstantProperties.Molar_Weight, subst.ConstantProperties.Z_Rackett, P, Me.AUX_PVAPi(subst.Nome, T))
                    Next
                Case Fase.Aqueous
                    For Each subst As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(6).Componentes.Values
                        subst.PartialVolume = 1 / 1000 * subst.ConstantProperties.Molar_Weight / Me.m_props.liq_dens_rackett(T, subst.ConstantProperties.Critical_Temperature, subst.ConstantProperties.Critical_Pressure, subst.ConstantProperties.Acentric_Factor, subst.ConstantProperties.Molar_Weight, subst.ConstantProperties.Z_Rackett, P, Me.AUX_PVAPi(subst.Nome, T))
                    Next
                Case Fase.Liquid1
                    For Each subst As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(3).Componentes.Values
                        subst.PartialVolume = 1 / 1000 * subst.ConstantProperties.Molar_Weight / Me.m_props.liq_dens_rackett(T, subst.ConstantProperties.Critical_Temperature, subst.ConstantProperties.Critical_Pressure, subst.ConstantProperties.Acentric_Factor, subst.ConstantProperties.Molar_Weight, subst.ConstantProperties.Z_Rackett, P, Me.AUX_PVAPi(subst.Nome, T))
                    Next
                Case Fase.Liquid2
                    For Each subst As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(4).Componentes.Values
                        subst.PartialVolume = 1 / 1000 * subst.ConstantProperties.Molar_Weight / Me.m_props.liq_dens_rackett(T, subst.ConstantProperties.Critical_Temperature, subst.ConstantProperties.Critical_Pressure, subst.ConstantProperties.Acentric_Factor, subst.ConstantProperties.Molar_Weight, subst.ConstantProperties.Z_Rackett, P, Me.AUX_PVAPi(subst.Nome, T))
                    Next
                Case Fase.Liquid3
                    For Each subst As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(5).Componentes.Values
                        subst.PartialVolume = 1 / 1000 * subst.ConstantProperties.Molar_Weight / Me.m_props.liq_dens_rackett(T, subst.ConstantProperties.Critical_Temperature, subst.ConstantProperties.Critical_Pressure, subst.ConstantProperties.Acentric_Factor, subst.ConstantProperties.Molar_Weight, subst.ConstantProperties.Z_Rackett, P, Me.AUX_PVAPi(subst.Nome, T))
                    Next
                Case Fase.Vapor
                    Dim partvol As New Object
                    Dim i As Integer = 0
                    partvol = Me.m_pr.CalcPartialVolume(T, P, RET_VMOL(phase), RET_VKij(), RET_VTC(), RET_VPC(), RET_VW(), RET_VTB(), "V", 0.0001)
                    i = 0
                    For Each subst As ClassesBasicasTermodinamica.Substancia In Me.CurrentMaterialStream.Fases(2).Componentes.Values
                        subst.PartialVolume = partvol(i)
                        i += 1
                    Next
            End Select
        End Sub

        Public Overrides Function AUX_VAPDENS(ByVal T As Double, ByVal P As Double) As Double
            Dim val As Double
            Dim Z As Double = Me.m_lk.Z_LK("V", T / Me.AUX_TCM(PropertyPackages.Fase.Vapor), P / Me.AUX_PCM(PropertyPackages.Fase.Vapor), Me.AUX_WM(PropertyPackages.Fase.Vapor))(0)
            val = P / (Z * 8.314 * T) / 1000 * AUX_MMM(Fase.Vapor)
            Return val
        End Function

        Public Overrides Function DW_CalcEntropy(ByVal Vx As System.Array, ByVal T As Double, ByVal P As Double, ByVal st As State) As Double

            Dim S As Double

            If st = State.Liquid Then
                S = Me.m_lk.S_LK_MIX("L", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, Me.RET_Sid(298.15, T, P, Vx))
            Else
                S = Me.m_lk.S_LK_MIX("V", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, Me.RET_Sid(298.15, T, P, Vx))
            End If

            Return S

        End Function

        Public Overrides Function DW_CalcEntropyDeparture(ByVal Vx As System.Array, ByVal T As Double, ByVal P As Double, ByVal st As State) As Double
            Dim S As Double

            If st = State.Liquid Then
                S = Me.m_lk.S_LK_MIX("L", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, 0)
            Else
                S = Me.m_lk.S_LK_MIX("V", T, P, Vx, RET_VKij(), RET_VTC, RET_VPC, RET_VW, RET_VMM, 0)
            End If

            Return S

        End Function

        Public Overrides Function DW_CalcFugCoeff(ByVal Vx As System.Array, ByVal T As Double, ByVal P As Double, ByVal st As State) As Object

            Dim prn As New PropertyPackages.ThermoPlugs.PR

            Dim n As Integer = UBound(Vx)
            Dim lnfug(n), ativ(n) As Double
            Dim fugcoeff(n) As Double
            Dim i As Integer

            Dim Tc As Object = Me.RET_VTC()

            If st = State.Liquid Then
                ativ = Me.m_uni.GAMMA_MR(T, Vx, Me.RET_VNAMES)
                For i = 0 To n
                    If T / Tc(i) >= 1 Then
                        lnfug(i) = Math.Log(Me.AUX_PVAPi(i, T) / P)
                    Else
                        lnfug(i) = Math.Log(ativ(i) * Me.AUX_PVAPi(i, T) / (P))
                    End If
                Next
            Else
                If Not Me.Parameters.ContainsKey("PP_IDEAL_VAPOR_PHASE_FUG") Then Me.Parameters.Add("PP_IDEAL_VAPOR_PHASE_FUG", 0)
                If Me.Parameters("PP_IDEAL_VAPOR_PHASE_FUG") = 1 Then
                    For i = 0 To n
                        lnfug(i) = 0.0#
                    Next
                Else
                    lnfug = prn.CalcLnFug(T, P, Vx, Me.RET_VKij, Me.RET_VTC, Me.RET_VPC, Me.RET_VW, Nothing, "V")
                End If
            End If

            For i = 0 To n
                fugcoeff(i) = Exp(lnfug(i))
            Next

            Return fugcoeff
        End Function

    End Class

End Namespace


