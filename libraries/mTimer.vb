Namespace Timer
    Module mTimer
#Region "DECLARATIONS"
        'Timing Routines for debuggin reasons, with 1ms accuracy
        Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
        Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Integer) As Integer
        Declare Function timeGetTime Lib "winmm.dll" () As Integer
        Private m_lT As Integer
#End Region
#Region "FUNCTIONS"
        Public Sub StartTiming()
            timeBeginPeriod(1)
            m_lT = timeGetTime
        End Sub
        Public Function EndTiming() As Integer
            EndTiming = timeGetTime - m_lT
            timeEndPeriod(1)
        End Function
#End Region
    End Module
End Namespace

