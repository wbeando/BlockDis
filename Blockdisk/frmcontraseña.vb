Public Class frmcontraseña

    Dim vIntento As Integer
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If txtContraseña.Text = "" Then
            vIntento = vIntento + 1
            MsgBox("La contraseña que ingreso es incorrecta intentalo nuevamente", MsgBoxStyle.Information, "Intento" & " " & vIntento)
        ElseIf Encriptar(AlgoritmoDeEncriptacion.MD5, txtContraseña.Text, 3, 3) = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\bckd\cfg", "pswd", Nothing) Then
            frmbloqueardisp.Show()
            Me.Close()
        Else
            vIntento = vIntento + 1
            MsgBox("La contraseña que ingreso es incorrecta, por favor intentelo nuevamente", MsgBoxStyle.Information, "Intento" & " " & vIntento)
        End If
        If vIntento = 3 Then Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class