Module playSound
    Public Sub oneBuzz()
        Try
            'see notes below in "threeBuzz" Sub
            Dim myBuzzer As String = Application.StartupPath & "\buzzer_x.wav"
            My.Computer.Audio.Play(myBuzzer, AudioPlayMode.WaitToComplete)
        Catch
            Dim myBuzzer As String = Application.StartupPath & "\Sound\buzzer_x.wav"
            My.Computer.Audio.Play(myBuzzer, AudioPlayMode.WaitToComplete)
        End Try
    End Sub
    Public Sub twoBuzz()
        Try
            Dim myBuzzer As String = Application.StartupPath & "\buzzer_x.wav"
            'Dim myBuzzer As String = Application.StartupPath & "\Sound\buzzer_x.wav"
            Dim buzzCnt As Integer = 0

            Do
                buzzCnt = buzzCnt + 1
                My.Computer.Audio.Play(myBuzzer, AudioPlayMode.WaitToComplete)
            Loop Until buzzCnt = 2
        Catch
            'Dim myBuzzer As String = Application.StartupPath & "\buzzer_x.wav"
            Dim myBuzzer As String = Application.StartupPath & "\Sound\buzzer_x.wav"
            Dim buzzCnt As Integer = 0

            Do
                buzzCnt = buzzCnt + 1
                My.Computer.Audio.Play(myBuzzer, AudioPlayMode.WaitToComplete)
            Loop Until buzzCnt = 2
        End Try





    End Sub
    Public Sub threeBuzz()
        Try
            'use the below folder in debug mode when building application. When publishing use the above file path, 
            'since VB will place the .wav file into the main project folder with the bin file, obj file, etc.
            Dim myBuzzer As String = Application.StartupPath & "\buzzer3_x.wav"
            'Dim myBuzzer As String = Application.StartupPath & "\Sound\buzzer3_x.wav"
            My.Computer.Audio.Play(myBuzzer, AudioPlayMode.WaitToComplete)
        Catch
            'Dim myBuzzer As String = Application.StartupPath & "\buzzer3_x.wav"
            Dim myBuzzer As String = Application.StartupPath & "\Sound\buzzer3_x.wav"
            My.Computer.Audio.Play(myBuzzer, AudioPlayMode.WaitToComplete)
        Finally

        End Try
    End Sub
End Module
