Imports System.Security.Cryptography
Imports System.Text

Module mfunciones

    ' Se verifica si existe el valor en start para los dispositivos USB - CDROM
    Public vValorUSB As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\USBSTOR", "start", Nothing)
    Public vValorCD As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\cdrom", "start", Nothing)

    ' Se reasigna los nuevos valores despues de la actualización
    ' TIENE QUE SER REVISADO. POSIBLEMENTE TOME LOS VALORES DE LA VERIFICACION DEL ARCHIVO
    Public Sub Reasignarvalores()
        vValorUSB = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\USBSTOR", "start", Nothing)
        vValorCD = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\cdrom", "start", Nothing)
    End Sub

    'Variables usadas para la encriptación MD5
    Private des As New TripleDESCryptoServiceProvider 'Algorithmo TripleDES
    Private hashmd5 As New MD5CryptoServiceProvider 'objeto md5
    Private myKey As String '= "MyKey2012" 'Clave secreta(puede alterarse)

    'Funcion para el Encriptado de Cadenas de Texto
    Private Function Encriptar(ByVal texto As String) As String

        If Trim(texto) = "" Then
            Encriptar = ""
        Else
            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(myKey))
            des.Mode = CipherMode.ECB
            Dim encrypt As ICryptoTransform = des.CreateEncryptor()
            Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(texto)
            Encriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
        End If
        Return Encriptar
    End Function

    Public Sub ValRegistros()
        'Valida Si existe el registro BCDK donde iran las configuraciones y contraseña
        Dim vbcdkReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\bckd\\cfg", True)
        'Valida Si existe el registro MYDEVICES donde se guardara una copia del estado de los dispositivos asi evitar las modificaciones 
        'manuales en el registro de windows y verifica si la contraseña no ha sido modificada o eliminada.
        Dim vmydevicesReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\mydevices", True)

        'Verifica si el registro INSTALL existe asi validar el ingreso de la contraseña en el primer uso de la aplicacion.
        Dim vInstallrev As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\install", True)

        Dim vInstall As Integer 'Variable que almacena el valor de estado si es la primera vez que se ejecuta(0) o si ya tiene 
        'agregada la contraseña
        If vInstallrev Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\install\", "state", "0", Microsoft.Win32.RegistryValueKind.DWord)
        Else
            CrearRegApp()
            vInstall = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\install\", "state", Nothing)
            Select Case vInstall
                Case 0
                    frmcrearcontraseña.ShowDialog()
                Case 1
                    If vbcdkReg Is Nothing Or vmydevicesReg Is Nothing Then
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\USBSTOR", "start", "4", Microsoft.Win32.RegistryValueKind.DWord)
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\cdrom", "start", "4", Microsoft.Win32.RegistryValueKind.DWord)
                        MsgBox("La aplicación ha sufrido cambios no permitidos, esto dejara bloqueado los dispositivos hasta que te pongas en contacto con soporte tecnico", MsgBoxStyle.Critical, "Registros modificados ilegalmente")
                    End If
            End Select
        End If
        
    End Sub

    'Verifica si existe el registro caso contrario lo creara
    Public Sub CrearRegApp()
        Dim vApp As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\bckd\\cfg", True)
        If vApp Is Nothing Then
            My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\bckd\cfg", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\mydevices\", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            'My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\bckd\cfg", "ruta", Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\bckd\cfg", "pswd", "", Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mydevices\", "cdrom", "0", Microsoft.Win32.RegistryValueKind.DWord)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mydevices\", "usbstor", "0", Microsoft.Win32.RegistryValueKind.DWord)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mydevices\", "valpswd", "", Microsoft.Win32.RegistryValueKind.String)

        End If
        'vApp = Nothing
    End Sub


    'Se verificara que el registro de windows para la contraseña existe caso contrario se creara dicho registro
    'con el nombre encriptado. Se recuerda que los nombres de los registros estaran encriptados para evitar posibles modificaciones
    'del usuario.
    Private Sub RevContraseña()

    End Sub


End Module

'Public Class Form1
'    Dim times As Integer = 1
'    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'        If e.CloseReason = CloseReason.UserClosing Then
'            e.Cancel = True
'            MsgBox("Creo que no!", MsgBoxStyle.Critical, "Error!")
'        ElseIf e.CloseReason = CloseReason.ApplicationExitCall Then
'            e.Cancel = True
'            MsgBox(" La aplicacion no se puede finalizar !", MsgBoxStyle.Critical, "Error!")
'ElseIf e.CloseReason = CloseReason.TaskManagerClosing Then e.Cancel = True
'MsgBox("Administrador de tareas? no vale!") Application.DoEvents() 
'        End If
'    End Sub
'Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 
'        MyBase.Load()
'    End Sub
'    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'Dim newform1 As New Form1 newform1.Text = "Virus Webon" & times.ToString newform1.Show() times += 1 
'    End Sub
'Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 
'        PictureBox1.Click()
'        End
'    End Sub


'End Class