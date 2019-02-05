Public Class Form1
    Public tmrValue As Integer
    Public lineUp As Boolean
    Public endCount As Integer
    Public practiceCnt As Integer
    Public practiceOver As Boolean
    Public gameOver As Boolean
    Public screenHeight As Single
    Public screenWidth As Single
    Public approachDone As Boolean
    Public endsPerGame As Integer
    Public practiceEnds As Integer
    Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reload()

    End Sub


    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
       
        If tmrTime.Enabled = False Then
            oneBuzz()
            tmrTime.Enabled = True
            btnEdit.Visible = False
            tmrValue = TextBox2.Text
            btnPause.Visible = True
            btnPause.Text = ("PAUSE")
            Label2.Visible = True
            Label7.Visible = False
            'start timer
        Else
            'stop timer
            If CheckBox2.Checked Then
                Me.BackColor = Color.Red
                threeBuzz()
                tmrTime.Enabled = False
                btnPause.Visible = False
                If practiceOver = True Then
                    btnEdit.Visible = True
                End If
            Else
                If lineUp = True Then
                    Me.BackColor = Color.Red
                    threeBuzz()
                    tmrTime.Enabled = False
                    btnPause.Visible = False
                    Label2.Text = TextBox2.Text
                    If practiceOver = True Then
                        btnEdit.Visible = True
                    End If
                Else
                    twoBuzz()
                End If

                tmrValue = TextBox2.Text
                approachDone = False
                upDateCnt()
            End If
        End If

    End Sub

    Private Sub tmrTime_Tick(sender As Object, e As EventArgs) Handles tmrTime.Tick
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        If approachDone = False Then
            screenWidth = Screen.PrimaryScreen.Bounds.Width / 35
            Label4.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
            Label4.Text = "ARCHERS READY"
            Me.BackColor = Color.Red
        ElseIf practiceOver = False Then
            screenWidth = Screen.PrimaryScreen.Bounds.Width / 29
            Label4.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
            Label4.Text = practiceCnt
        Else
            Label4.Text = endCount
        End If
        Label2.Text = tmrValue
        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
        tmrValue = Val(tmrValue) - Val(1)
        If approachDone = True Then
            If tmrValue < 30 Then
                Me.BackColor = Color.Orange
                Label2.ForeColor = Color.Black
            Else
                Me.BackColor = Color.Green
                Label2.ForeColor = Color.Black
            End If
        Else
            Me.BackColor = Color.Red
        End If

        Label2.Text = tmrValue
        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
        'start checkbox2
        If CheckBox2.Checked Then
            If tmrValue < 0 Then
                If approachDone = True Then
                    Label2.Text = tmrValue
                    tmrTime.Enabled = False
                    btnPause.Visible = False
                    Me.BackColor = Color.Red
                    Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
                    threeBuzz()
                    tmrValue = TextBox2.Text
                    Label2.Text = tmrValue
                    Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
                    approachDone = False
                    upDateCnt()
                    If practiceOver = True Then
                        btnEdit.Visible = True
                    End If
                Else
                    approachDone = True
                    oneBuzz()
                    tmrValue = TextBox1.Text
                End If
            End If


        Else    'end checkbox2


            If tmrValue < 0 Then
                If approachDone = True Then
                    If lineUp = True Then
                        tmrTime.Enabled = False
                        btnPause.Visible = False
                        Me.BackColor = Color.Red
                        Label2.Text = tmrValue
                        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
                        threeBuzz()
                        If practiceOver = True Then
                            btnEdit.Visible = True
                        End If
                    Else
                        Label2.Text = tmrValue
                        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
                        twoBuzz()
                    End If

                    tmrValue = TextBox2.Text
                    Label2.Text = tmrValue
                    Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
                    approachDone = False
                    upDateCnt()
                Else
                    approachDone = True
                    oneBuzz()
                    tmrValue = TextBox1.Text
                End If
            End If
        End If
        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)
    End Sub

    Public Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If practiceOver = True Then
            Form2.Visible = True
        End If
        
        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, 10)

    End Sub

    Public Sub upDateCnt()
        If CheckBox2.Checked Then
            If practiceOver = True Then
                endCount = endCount + 1

                If endCount = (endsPerGame / 2) + 1 And CheckBox1.Checked Then
                    Label7.Visible = True
                    Label2.Visible = False
                    Label7.Text = ("SWITCH LINES")
                    Label7.Location = New Point(intX / 2 - Label7.Size.Width / 2, 1)
                ElseIf endCount = endsPerGame + 1 Then
                    Label7.Visible = True
                    Label7.Text = ("GAME OVER")
                    Label7.Location = New Point(intX / 2 - Label7.Size.Width / 2, 1)
                    Label4.Text = ("Finished")

                    gameOver = True
                    Label2.Visible = False
                Else
                    Label7.Visible = False
                    Label2.Visible = True
                    'Label3.Visible = True
                End If
                If gameOver = False Then
                    Label4.Text = endCount
                End If
            Else
                Label4.Text = practiceCnt
                practiceCnt = practiceCnt + 1
                Label4.Text = practiceCnt
            End If
            If practiceOver = False Then
                If practiceCnt > practiceEnds Then
                    practiceOver = True
                    Label6.Text = ("END COUNT")
                    endCount = 1
                    Label4.Text = endCount
                End If
            End If
        Else
            If practiceOver = True Then
                If lineUp = False Then
                    lineUp = True
                    Label1.Text = ("TOP")
                Else
                    lineUp = False
                    Label1.Text = ("BOTTOM")
                    endCount = endCount + 1
                End If
                If lineUp = False And endCount = (endsPerGame / 2) + 1 And CheckBox1.Checked Then
                    Label7.Visible = True
                    Label2.Visible = False
                    Label7.Text = ("SWITCH LINES")
                    Label7.Location = New Point(intX / 2 - Label7.Size.Width / 2, 1)
                ElseIf lineUp = False And endCount = endsPerGame + 1 Then
                    Label7.Visible = True
                    Label7.Text = ("GAME OVER")
                    Label7.Location = New Point(intX / 2 - Label7.Size.Width / 2, 1)
                    Label4.Text = ("Finished")

                    gameOver = True
                    Label2.Visible = False
                Else
                    Label7.Visible = False
                    Label2.Visible = True
                    'Label3.Visible = True
                End If
                If gameOver = False Then
                    Label4.Text = endCount
                End If
            Else
                Label4.Text = practiceCnt

                If lineUp = False Then
                    lineUp = True
                    Label1.Text = ("TOP")
                Else
                    lineUp = False
                    Label1.Text = ("BOTTOM")
                    practiceCnt = practiceCnt + 1
                    Label4.Text = practiceCnt
                End If
                If practiceCnt > practiceEnds And lineUp = False Then
                    practiceOver = True
                    Label6.Text = ("END COUNT")
                    endCount = 1
                    Label4.Text = endCount
                End If
            End If

        End If





    End Sub
    Public Sub Reload()

        Me.WindowState = FormWindowState.Maximized
        practiceCnt = 1
        btnPause.Visible = False
        Button1.Visible = True
        btnEdit.Visible = False
        approachDone = False
        tmrTime.Enabled = False
        Label7.Visible = False
        practiceOver = False
        lineUp = False
        Label2.Visible = True
        gameOver = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        practiceEnds = TextBox4.Text
        Label4.Text = practiceCnt
        endsPerGame = TextBox3.Text
        btnPause.Text = ("PAUSE")
        Label6.Text = ("PRACTICE")
        Label1.Text = ("BOTTOM")
        Label2.Text = TextBox2.Text
        Label1.ForeColor = Color.Black
        Label2.ForeColor = Color.Black
        Me.BackColor = Color.Red
        screenHeight = Screen.PrimaryScreen.Bounds.Height / 5
        screenWidth = Screen.PrimaryScreen.Bounds.Width / 4
        Label2.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
        Label7.Font = New Font("Impact", screenWidth / 2, FontStyle.Bold)
        screenHeight = Screen.PrimaryScreen.Bounds.Height / 20
        screenWidth = Screen.PrimaryScreen.Bounds.Width / 20
        Label1.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
        Label5.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
        screenHeight = Screen.PrimaryScreen.Bounds.Height / 29
        screenWidth = Screen.PrimaryScreen.Bounds.Width / 29
        Label4.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
        Label6.Font = New Font("Lucida Fax", screenWidth, FontStyle.Bold)
        Label2.Location = New Point(intX / 2 - Label2.Size.Width / 2, -75)
        Label7.Location = New Point(intX / 2 - Label7.Size.Width / 2, 1)
        Label5.Location = New Point(5, Label2.Size.Height + 15)
        Label1.Location = New Point(Label5.Size.Width + 5, Label2.Size.Height + 15)
        Label6.Location = New Point(5, Label5.Size.Height + Label5.Location.Y + 5)
        Label4.Location = New Point(Label5.Size.Width + 10, Label5.Size.Height + Label5.Location.Y + 5)
        btnPause.Location = New Point(intX - 150, intY - 310)
        Button1.Location = New Point(intX - 150, intY - 260)
        btnStart.Location = New Point(intX - 150, intY - 210)
        TextBox1.Location = New Point(intX - 250, intY - 190)
        Label8.Location = New Point(intX - 245, intY - 210)
        TextBox2.Location = New Point(intX - 250, intY - 235)
        Label3.Location = New Point(intX - 245, intY - 255)
        CheckBox1.Location = New Point(TextBox2.Location.X - 100, intY - 120)
        CheckBox2.Location = New Point(TextBox2.Location.X - 100, CheckBox1.Location.Y + 20)
        TextBox3.Location = New Point(intX - 250, TextBox1.Location.Y + 45)
        TextBox4.Location = New Point(intX - 250, TextBox3.Location.Y + 45)
        Label9.Location = New Point(intX - 250, TextBox3.Location.Y - 20)
        Label10.Location = New Point(intX - 250, TextBox4.Location.Y - 20)
        btnEdit.Location = New Point(intX - 150, intY - 155)
        btnExit.Location = New Point(intX - 150, intY - 120)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim response = MsgBox("Are you sure you want to reset the entire game?", MsgBoxStyle.YesNo, "Reset Game?")
        If response = MsgBoxResult.Yes Then
            Reload()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        endsPerGame = TextBox3.Text
    End Sub
    Public Sub checkLine()
        

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            Label1.Text = ("ALL")
        Else

            If lineUp = False Then

                Label1.Text = ("BOTTOM")
            Else

                Label1.Text = ("TOP")
            End If
        End If

        


    End Sub




    Public Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If tmrTime.Enabled = False Then
            tmrTime.Enabled = True
            btnPause.Text = ("PAUSE")
        Else
            tmrTime.Enabled = False
            btnPause.Text = ("RESTART")
        End If
    End Sub


    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        endsPerGame = TextBox3.Text
    End Sub
End Class
