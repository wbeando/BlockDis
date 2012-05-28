Imports Microsoft.Win32.RegistryKey
Public Class frmbloqueardisp

    '* EJEMPLO DE VALIDAR SI UN REGISTRO DE WINDOWS EXISTE
    '*******************************************
    '* Dim regVersion As Microsoft.Win32.RegistryKey
    '* regVersion = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\TestApp\\1.0", True)
    '* If regVersion Is Nothing Then
    '* regVersion =     '*Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\TestApp\\1.0")
    '* End If
    '******************************************
    'Donde:
    ' 1 ==> verificación
    ' 2 ==> modificar
    ' 3 ==> ?
    Public Sub RevCDROM(ByVal vAccion As Integer) 'Muestra el estado del registro para Unidades Opticas 
        Dim vTextCdrom As String = ""
        Select Case vValorCD
            Case 2
            Case 3 'Habilitado
                Select Case vAccion
                    Case 1
                        vTextCdrom = "UNIDAD CD/DVD Activado"
                    Case 2
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\cdrom", "start", "4", Microsoft.Win32.RegistryValueKind.DWord)
                        vTextCdrom = "UNIDAD CD/DVD Desactivado"
                End Select
            Case 4 'Deshabilitado
                Select Case vAccion
                    Case 1
                        vTextCdrom = "UNIDAD CD/DVD Desactivado"
                    Case 2
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\cdrom", "start", "3", Microsoft.Win32.RegistryValueKind.DWord)
                        vTextCdrom = "UNIDAD CD/DVD Activado"
                End Select
        End Select
        Me.btnCDROM.Text = vTextCdrom
    End Sub

    Public Sub RevUSB(ByVal vAccion As Integer)
        Dim vTextusb As String = ""
        Select Case vValorUSB
            Case 2
            Case 3 'Habilitado
                Select Case vAccion
                    Case 1
                        vTextusb = "USB Activado"
                    Case 2
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\USBSTOR", "start", "4", Microsoft.Win32.RegistryValueKind.DWord)

                        vTextusb = "USB Desactivado"
                End Select
            Case 4 'Deshabilitado
                Select Case vAccion
                    Case 1
                        vTextusb = "USB Desactivado"
                    Case 2
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\USBSTOR", "start", "3", Microsoft.Win32.RegistryValueKind.DWord)
                        vTextusb = "USB Activado"
                End Select
        End Select
        Me.btnUSB.Text = vTextusb
    End Sub

    Private Sub frmbloqueardisp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'RevisarReg()
        ValRegistros()
    End Sub

    Private Sub btnUSB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSB.Click
        Reasignarvalores()
        RevUSB(2)
    End Sub

    Private Sub btnCDROM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCDROM.Click
        Reasignarvalores()
        RevCDROM(2)
    End Sub

    Private Sub btnaplicar_Click(sender As System.Object, e As System.EventArgs) Handles btnaplicar.Click
        Process.Start("shutdown.exe", " -s -t 0 -f")
    End Sub
End Class