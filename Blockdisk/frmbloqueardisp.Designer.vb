<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbloqueardisp
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
        Me.btnUSB = New System.Windows.Forms.Button()
        Me.btnCDROM = New System.Windows.Forms.Button()
        Me.lblmensaje = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnUSB
        '
        Me.btnUSB.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUSB.Location = New System.Drawing.Point(16, 71)
        Me.btnUSB.Name = "btnUSB"
        Me.btnUSB.Size = New System.Drawing.Size(120, 70)
        Me.btnUSB.TabIndex = 0
        Me.btnUSB.Text = "USB Activado"
        Me.btnUSB.UseVisualStyleBackColor = True
        '
        'btnCDROM
        '
        Me.btnCDROM.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCDROM.Location = New System.Drawing.Point(159, 71)
        Me.btnCDROM.Name = "btnCDROM"
        Me.btnCDROM.Size = New System.Drawing.Size(120, 70)
        Me.btnCDROM.TabIndex = 1
        Me.btnCDROM.Text = "UNIDAD CD/DVD Activado"
        Me.btnCDROM.UseVisualStyleBackColor = True
        '
        'lblmensaje
        '
        Me.lblmensaje.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmensaje.ForeColor = System.Drawing.Color.Red
        Me.lblmensaje.Location = New System.Drawing.Point(13, 144)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(266, 41)
        Me.lblmensaje.TabIndex = 2
        Me.lblmensaje.Text = "Despues de modificar estas opciones el equipo se reiniciara. Asegurese de guardar" & _
    " todos sus archivos."
        '
        'frmbloqueardisp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.btnCDROM)
        Me.Controls.Add(Me.btnUSB)
        Me.Name = "frmbloqueardisp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bloquear acceso a dispositivos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUSB As System.Windows.Forms.Button
    Friend WithEvents btnCDROM As System.Windows.Forms.Button
    Friend WithEvents lblmensaje As System.Windows.Forms.Label

End Class
