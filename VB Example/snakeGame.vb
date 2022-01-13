Public Class snakeGame
    Dim snake(1000) As PictureBox
    Dim length As Integer = -1
    Dim left_right As Integer = 0
    Dim up_down As Integer = 0
    Dim eat As PictureBox
    Dim rand As New Random
    Dim score As Integer = 0
    Dim scr As String = "Score: "
    'Dim w As Integer


    'Snake Head
    Sub Head()
        length += 1
        snake(length) = New PictureBox
        With snake(length)
            .Width = 10
            .Height = 10
            .BackColor = Color.White
            .Left = (Panel1.Width - snake(length).Width) / 2
            .Top = (Panel1.Height + snake(length).Height) / 2
        End With
        Me.Controls.Add(snake(length))
        snake(length).BringToFront()
    End Sub


    'Snake Body
    Sub snake_length()
        length += 1
        snake(length) = New PictureBox
        With snake(length)
            .Width = 10
            .Height = 10
            .BackColor = Color.Green
            .Top = snake(length - 1).Top            'Susundun nya yung previous na Picture Box - Top,Bot
            .Left = snake(length - 1).Left + 10     'Susundun nya yung previous na Picture Box - Left, Right
        End With
        Me.Controls.Add(snake(length))
        snake(length).BringToFront()
    End Sub


    'Snake Food
    Sub Snake_Eat()
        eat = New PictureBox
        With eat
            .Width = 10
            .Height = 10
            .BackColor = Color.Maroon
            .Top = rand.Next(Panel1.Top, Panel1.Bottom - 10)
            .Left = rand.Next(Panel1.Left, Panel1.Right - 10)
        End With
        Me.Controls.Add(eat)
        eat.BringToFront()
    End Sub


    'Pass_Through_Wall
    Sub Pass_Through_Wall()


        'Left pass to right
        If snake(0).Left < Panel1.Left Then
            snake(0).Left = Panel1.Width - snake(0).Width

            'Right pass to left
        ElseIf snake(0).Right > Panel1.Right Then
            snake(0).Left = Panel1.Left

            'Top pass to bottom
        ElseIf snake(0).Top < Panel1.Top Then
            snake(0).Top = Panel1.Bottom - snake(0).Height

            'Bottom pass to top
        ElseIf snake(0).Bottom > Panel1.Bottom Then
            snake(0).Top = Panel1.Top

        End If

    End Sub


    'collision_with_eat
    Sub collision_with_eat()
        If snake(0).Bounds.IntersectsWith(eat.Bounds) Then
            score += 1
            snake_length()
            Label3.Text = scr & score

            'If snake collide to food, Food spawn again in random place
            eat.Top = rand.Next(Panel1.Top, Panel1.Bottom - 10)
            eat.Left = rand.Next(Panel1.Left, Panel1.Right - 10)
        End If

        For i = 1 To length
            If snake(0).Bounds.IntersectsWith(snake(i).Bounds) Then
                Timer1.Stop()

                Dim refGame As Form = Application.OpenForms("snakeGame")


                If MessageBox.Show("Game Over", " Snake Game", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) = vbRetry Then
                    'Application.Restart()
                    'resetform(Me)
                    refGame = New snakeGame
                    Me.Close()
                    refGame.Show()
                Else
                    'Application.Exit()
                    'Application.Restart()
                    Me.Close()
                End If
            End If
        Next
    End Sub


    'Main Code
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Head()
        Snake_Eat()
        snake_length()
        snake_length()
        snake_length()
        Timer2.Start() 'Press Enter Animation
    End Sub


    'Snake Animation
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'Snake Body Movement
        For i = length To 1 Step -1
            snake(i).Top = snake(i - 1).Top
            snake(i).Left = snake(i - 1).Left
        Next

        snake(0).Top += up_down
        snake(0).Left += left_right

        Pass_Through_Wall()
        collision_with_eat()


    End Sub

    'Control Keys
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            'Controls
            Case Keys.Up
                up_down = -10
                left_right = 0
            Case Keys.Down
                up_down = 10
                left_right = 0
            Case Keys.Left
                left_right = -10
                up_down = 0
            Case Keys.Right
                left_right = 10
                up_down = 0
            Case Keys.Enter
                Timer1.Start() 'Snake Animation
                left_right = -10
                up_down = 0
            Case Keys.R
                Timer1.Start()
            Case Keys.S
                Timer1.Stop()
            Case Keys.X
                Timer1.Stop()
                left_right = -10
                up_down = 0
                If MessageBox.Show("Are You Sure You Wanna Exit?", " Snake Game", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = vbOK Then
                    Me.Close()
                Else
                    Timer1.Start() 
                End If

                'Game Mode
            Case Keys.E
                Timer1.Interval = 200 'Easy
            Case Keys.N
                Timer1.Interval = 100 'Normal
            Case Keys.H
                Timer1.Interval = 50  'hard
        End Select
    End Sub

    
    'Game Mode
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        MessageBox.Show(" Press E for Easy" & vbNewLine & " Press N for Normal" & vbNewLine & " Press H for Hard", " Game Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Press Enter Animation
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'w = 669 ' Width Of Form
        'If (w = Label2.Right) Then
        'Label2.Left = -356
        'Else
        'Label2.Left = Label2.Left + 2
        'End If


        'Pag lumampas yung right ng label2 sa size ng panel papantay sya sa left ng panel - width ng label2
        If Label2.Left > Panel1.Right Then
            Label2.Left = Panel1.Left - Label2.Width
        Else
            Label2.Left = Label2.Left + 5 'Animation Speed
        End If

    End Sub

   
End Class
