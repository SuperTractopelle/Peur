Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - Me.Width, Screen.PrimaryScreen.Bounds.Height - Me.Height - (Me.Height / 2)) 'on place l'application en bas à droite de l'écran principal
        Timer1.Start() 'on démarre le timer
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Application.DoEvents() 'on demande à l'appli de traiter tout ce qui pourrait être en attente avant de faire le reste
        For Each app As Process In Process.GetProcessesByName("Peur") 'pour chaque application sous le nom de Peur (le nom de ce projet)
            AppActivate(app.Id) 'on la place par dessus les autres applications
            Application.DoEvents() 'traitement de la file d'attente avant de continuer
        Next
        Me.TopMost = True 'on demande à l'appli de rester par dessus tout
    End Sub

    Dim Counter As Int16 = 6 'on définit le compteur à 6 secondes (la durée du gif)
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Counter = 0 Then 'arrivé à 0 on ferme l'application
            Me.Close()
        Else
            Counter -= 1
        End If
    End Sub

End Class
