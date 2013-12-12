Option Strict Off
Option Explicit On
Imports WebLEXICON.Lexicon
Friend Class DemoLexicon
    Inherits System.Windows.Forms.Form

    Dim SubCnt As Integer
    Dim endtime As Double
    Dim ttime As Double
    Dim ttim2 As Double

    Sub myThread1()
        Dim buff As String 'TODO: Convert this to an array
        Lexicon.CharPos = 1
        Lexicon.Source = Text1.Text
        Timer.StartTiming()
        Do
            Lexicon.GetToken()
            If Lexicon.Token <> "" Then
                buff = Token & " " & TokType
            End If
        Loop Until (Lexicon.TokType = Lexicon.Tok_Types.EOP)
        endtime = Timer.EndTiming()
        Label1.Text = "You have " & SubCnt & " IDs to process"
        Exit Sub
    End Sub

    Sub myThread2()
        LstView.Items.Clear()
        SubCnt = 0
        Lexicon.CharPos = 1
        Lexicon.Source = Text1.Text
        Timer.StartTiming()
        Do
            Lexicon.GetToken()
            If Lexicon.Token <> "" Then
                SubCnt += 1
                'LstView.Items.Add(Lexicon.Token)
                'LstView.Items.Item(SubCnt - 1).SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Lexicon.GetStrToken(Lexicon.TokType)))
                'LstView.Items.Item(SubCnt - 1).SubItems.Insert(2, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, Lexicon.TokType))
                With Me.LstView.Items.Add(Token)
                    .SubItems.Add(GetStrToken(TokType))
                    .SubItems.Add(TokType)
                End With
            End If
        Loop Until (TokType = Tok_Types.EOP)

        endtime = Timer.EndTiming()
        Label1.Text = "You have " & SubCnt & " IDs to process"
        Exit Sub
    End Sub

    Private Sub DemoLexicon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Lexicon.InvokeKeywords()
        Me.Text = Application.ProductName & " " & Application.ProductVersion & " win32"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        myThread1()
        MsgBox("Finished in: " & endtime & " ms (" & Format(endtime / 1000, "0.###") & " s)")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        myThread2()
        MsgBox("Finished in: " & endtime & " ms (" & Format(endtime / 1000, "0.###") & " s)")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        endtime = 0
        ttim2 = 0
        ttime = 0
        myThread1()
        ttime += endtime
        myThread1()
        ttime += endtime
        myThread1()
        ttime += endtime
        endtime = 0
        myThread2()
        ttim2 += endtime
        myThread2()
        ttim2 += endtime
        myThread2()
        ttim2 += endtime
        endtime = 0
        MsgBox("3 Invisible Scans done in " & ttime & " ms [average " & Format(ttime / 3, "###") & " ms]" & vbNewLine & _
            "3 Visible Scans done in " & ttim2 & " ms [average " & Format(ttim2 / 3, "###") & " ms]" & vbNewLine & _
            "--------------------------------------------------------------" & vbNewLine & _
            "SCORE: " & ((100000 - (ttime + ttim2)) * 100) / 100000 & "/100", MsgBoxStyle.OkOnly, "WL32 Benchmark Results")

    End Sub
End Class

