Public Class Form2

    Public Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Text = "CONFIRM" & Environment.NewLine & "EDIT"
        ComboBox1.Items.Add("Top")
        ComboBox1.Items.Add("Bottom")
        Dim i As Integer
        Dim x As Integer = My.Forms.Form1.endsPerGame
        For i = 1 To x
            ComboBox2.Items.Add(i)
        Next i


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Forms.Form1.CheckBox2.Checked = False Then
            If ComboBox1.Text = "Top" Then
                My.Forms.Form1.lineUp = True
                My.Forms.Form1.Label1.Text = ("TOP")
            ElseIf ComboBox1.Text = "Bottom" Then
                My.Forms.Form1.lineUp = False
                My.Forms.Form1.Label1.Text = ("Bottom")
            Else
                Label1.BackColor = Color.Red
                MessageBox.Show("You Must Choose a Line to Start", "Select a Line")
                Exit Sub
            End If
        End If
        If ComboBox2.Text = "" Then
            Label2.BackColor = Color.Red
            MessageBox.Show("You Must Choose an End to Start", "Select an End")
            Exit Sub
        Else
            My.Forms.Form1.endCount = ComboBox2.Text
        End If
        My.Forms.Form1.Label4.Text = My.Forms.Form1.endCount
        Me.Close()
    End Sub
End Class