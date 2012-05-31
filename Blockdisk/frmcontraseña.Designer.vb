<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcontraseña
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.lblcontraseña = New System.Windows.Forms.Label()
        Me.lblmensaje = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(99, 37)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(181, 20)
        Me.txtContraseña.TabIndex = 6
        '
        'lblcontraseña
        '
        Me.lblcontraseña.AutoSize = True
        Me.lblcontraseña.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcontraseña.ForeColor = System.Drawing.Color.Black
        Me.lblcontraseña.Location = New System.Drawing.Point(9, 37)
        Me.lblcontraseña.Name = "lblcontraseña"
        Me.lblcontraseña.Size = New System.Drawing.Size(81, 17)
        Me.lblcontraseña.TabIndex = 5
        Me.lblcontraseña.Text = "Contraseña:"
        '
        'lblmensaje
        '
        Me.lblmensaje.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmensaje.ForeColor = System.Drawing.Color.Black
        Me.lblmensaje.Location = New System.Drawing.Point(9, 9)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(282, 25)
        Me.lblmensaje.TabIndex = 4
        Me.lblmensaje.Text = "Ingrese su contraseña para realizar cambios."
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(12, 60)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 33)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(186, 60)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 33)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmcontraseña
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(294, 98)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.lblcontraseña)
        Me.Controls.Add(Me.lblmensaje)
        Me.Name = "frmcontraseña"
        Me.Text = "Cambiar configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblcontraseña As System.Windows.Forms.Label
    Friend WithEvents lblmensaje As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
