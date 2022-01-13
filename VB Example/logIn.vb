Public Class logIn

    Public userNames As New ArrayList
    Public passwords As New ArrayList


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If userNames.Contains(TextBox1.Text) And passwords.Contains(TextBox2.Text) Then
            snakeGame.Show()

        Else
            If MessageBox.Show("Wrong!!" & vbNewLine & "User Name or Password", " Snake Game", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = vbCancel Then
                Me.Refresh()

            End If
                

        End If


        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox3.Text = "" Or TextBox4.Text = "" Then
            If MessageBox.Show("Please Input" & vbNewLine & "User Name or Password", " System Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning) = vbAbort Then
                Me.Close()
            End If
        Else
            userNames.Add(TextBox3.Text)
            passwords.Add(TextBox4.Text)

            MessageBox.Show(" Successful Signing Up", " Snake Game", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Delay
            For i As Integer = 1 To 200 ' <--- 2sec
                System.Threading.Thread.Sleep(10)
                System.Windows.Forms.Application.DoEvents()
            Next

            TextBox3.Text = ""
            TextBox4.Text = ""
        End If






    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        HowToPlay.Show()

        'MessageBox.Show("Feed the snake with as many goodies as possible and watch it grow. Use Arrow Keys Up, Down, Right, Left to turn the snake toward food. If the snake runs into its own tail, the game is over.", " How To Play Snake?", MessageBoxButtons.OK, MessageBoxIcon.Question)

        'Delay
        For i As Integer = 1 To 100 ' <--- 1sec
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        'Speech
        Dim sapi
        sapi = CreateObject("SAPI.spvoice")
        sapi.Voice = sapi.GetVoices.Item(0)
        sapi.speak("How to play snake?      Feed the snake with as many goodies as possible and watch it grow. Use Arrow Keys Up, Down, Right, Left to turn the snake toward food. If the snake runs into its own tail, the game is over.")

        'Delay
        For i As Integer = 1 To 100 ' <--- 1sec
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        HowToPlay.Close()

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MessageBox.Show("Are You Sure You Wanna Exit?", " Snake Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Me.Close()
        End If
    End Sub
End Class
