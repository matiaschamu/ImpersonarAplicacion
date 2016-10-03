<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inicio))
        Me.TextBoxAplicacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonSelectPath = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxLineaComandos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxUsuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxContraseña = New System.Windows.Forms.TextBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxRetardo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBoxAplicacion
        '
        Me.TextBoxAplicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxAplicacion.Location = New System.Drawing.Point(15, 25)
        Me.TextBoxAplicacion.Name = "TextBoxAplicacion"
        Me.TextBoxAplicacion.Size = New System.Drawing.Size(227, 20)
        Me.TextBoxAplicacion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Aplicacion"
        '
        'ButtonSelectPath
        '
        Me.ButtonSelectPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectPath.Location = New System.Drawing.Point(248, 23)
        Me.ButtonSelectPath.Name = "ButtonSelectPath"
        Me.ButtonSelectPath.Size = New System.Drawing.Size(24, 23)
        Me.ButtonSelectPath.TabIndex = 2
        Me.ButtonSelectPath.Text = "..."
        Me.ButtonSelectPath.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Linea de comandos"
        '
        'TextBoxLineaComandos
        '
        Me.TextBoxLineaComandos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLineaComandos.Location = New System.Drawing.Point(15, 64)
        Me.TextBoxLineaComandos.Name = "TextBoxLineaComandos"
        Me.TextBoxLineaComandos.Size = New System.Drawing.Size(257, 20)
        Me.TextBoxLineaComandos.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nombre Usuario"
        '
        'TextBoxUsuario
        '
        Me.TextBoxUsuario.Location = New System.Drawing.Point(15, 103)
        Me.TextBoxUsuario.Name = "TextBoxUsuario"
        Me.TextBoxUsuario.Size = New System.Drawing.Size(160, 20)
        Me.TextBoxUsuario.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Contraseña"
        '
        'TextBoxContraseña
        '
        Me.TextBoxContraseña.Location = New System.Drawing.Point(15, 142)
        Me.TextBoxContraseña.Name = "TextBoxContraseña"
        Me.TextBoxContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxContraseña.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxContraseña.TabIndex = 7
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGuardar.Location = New System.Drawing.Point(207, 181)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(65, 23)
        Me.ButtonGuardar.TabIndex = 9
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "RetardoApertura (mSeg)"
        '
        'TextBoxRetardo
        '
        Me.TextBoxRetardo.Location = New System.Drawing.Point(15, 181)
        Me.TextBoxRetardo.Name = "TextBoxRetardo"
        Me.TextBoxRetardo.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxRetardo.TabIndex = 10
        Me.TextBoxRetardo.Text = "5000"
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 215)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxRetardo)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxContraseña)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxLineaComandos)
        Me.Controls.Add(Me.ButtonSelectPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxAplicacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inicio"
        Me.ShowInTaskbar = False
        Me.Text = "Start"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxAplicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonSelectPath As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxLineaComandos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxContraseña As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRetardo As System.Windows.Forms.TextBox

End Class
