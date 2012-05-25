Public Class frmcrearcontraseña

#Region "Cerrar aplicacion"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("Debe ingresar una contraseña para activar Blocdisk. Si desea cerrar el programa sin configurar haga click en Si caso contrario haga click en No", MsgBoxStyle.YesNo, "Esta cerrando la aplicación sin ingresar la contraseña") = MsgBoxResult.Yes Then
            End
        End If
    End Sub
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        CrearRegApp()
        MsgBox("Aun esta en desarrollo ^^")
    End Sub

    Private Sub frmcrearcontraseña_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ''MessageBox.Show(e.CloseReason.ToString()) 'Mostramos el motivo de cierre
        'If Not e.CloseReason = CloseReason.WindowsShutDown Then 'Si no es por motivo de cierre de sistema
        '    e.Cancel = True 'Cancelamos el cierre
        'End If
    End Sub

End Class

