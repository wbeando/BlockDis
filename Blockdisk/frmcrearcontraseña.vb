﻿Public Class frmcrearcontraseña

    Function Compararcontraseña(ByVal contraseña As String, ByVal confirmar As String) As Boolean
        Dim comparacion As Boolean
        Dim campovacio As Boolean
        Dim tamañocontra As Boolean
        Dim X As Boolean
        If contraseña = confirmar Then comparacion = True Else comparacion = False
        If contraseña Is Nothing Or confirmar Is Nothing Then campovacio = False Else campovacio = True
        If contraseña.Length >= 5 Or confirmar.Length >= 5 Then tamañocontra = True Else tamañocontra = False
        If comparacion And campovacio And tamañocontra Then X = True
        'Regresa el valor true si todos las verificiaciones son verdaderas
        Return X
    End Function

#Region "Asignar contraseña"
    Sub RegistrarContra()
        Dim vEncripwd As String = Nothing
        If Compararcontraseña(txtcontraseña.Text, txtconfcontraseña.Text) = True Then
            'MsgBox("ok")
            vEncripwd = Encriptar(AlgoritmoDeEncriptacion.MD5, txtcontraseña.Text, 3, 3)
            MsgBox(vEncripwd)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\bckd\cfg\", "pswd", vEncripwd, Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mydevices\", "valpswd", vEncripwd, Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\install\", "state", "1", Microsoft.Win32.RegistryValueKind.DWord)
            frmbloqueardisp.Show()
            Me.Close()
        Else
            txtconfcontraseña.Clear()
            txtcontraseña.Clear()
            txtcontraseña.Focus()
            MsgBox("La contraseña no coinciden, dejaste en blanco algun campo o la contraseña es menor a 5 caracteres. Intenta ingresar la contraseña nuevamente.", MsgBoxStyle.Information, "Registro contraseña")
            Exit Sub
        End If

        'If txtcontraseña.Text.CompareTo(txtconfcontraseña.Text) = 1  Then 'COMPARA LAS CADENAS DE TEXTO DE CONTRASEÑA y CONFIRMAR CONTRASEÑA. ADEMAS VERIFICA SI LAS CAJAS DE TEXTO ESTAN VACIAS
        '    txtconfcontraseña.BackColor = Color.Red
        '    txtcontraseña.BackColor = Color.Red
        '    txtconfcontraseña.Clear()
        '    txtcontraseña.Clear()
        '    txtcontraseña.Focus()
        '    MsgBox("La contraseña no coinciden o has dejado en blanco algun campo, intenta ingresar las contraseñas nuevamente.", vbBack, "Registro contraseña")
        '    Exit Sub
        'Else
        '    txtconfcontraseña.BackColor = Color.Yellow
        '    txtcontraseña.BackColor = Color.Yellow
        'End If
    End Sub
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        RegistrarContra()
    End Sub

#Region "Cerrar aplicacion"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("Debe ingresar una contraseña para activar Blocdisk. Si desea cerrar el programa sin configurar haga click en Si caso contrario haga click en No", MsgBoxStyle.YesNo, "Esta cerrando la aplicación sin ingresar la contraseña") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
#End Region

    Private Sub frmcrearcontraseña_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'MessageBox.Show(e.CloseReason.ToString()) 'Mostramos el motivo de cierre
        'If Not e.CloseReason = CloseReason.WindowsShutDown Then 'Si no es por motivo de cierre de sistema
        '    e.Cancel = True 'Cancelamos el cierre
        'End If
    End Sub
End Class

