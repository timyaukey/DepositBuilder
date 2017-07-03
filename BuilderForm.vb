Option Strict Off
Option Explicit On
Friend Class BuilderForm
	Inherits System.Windows.Forms.Form
	
	Private mstrCashCatKey As String
	Private mdblCashWeight As Double
	Private mstrCardCatKey As String
	Private mdblCardWeight As Double
	Private mdblTotalCatWeight As Double
	
	'UPGRADE_WARNING: Lower bound of array maintCardDelay was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private maintCardDelay(7) As Short
	'UPGRADE_WARNING: Lower bound of array maintCashDelay was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private maintCashDelay(7) As Short
	'UPGRADE_WARNING: Lower bound of array madblDayWeight was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Private madblDayWeight(7) As Double
	Private mdblTotalDayWeight As Double
	Private mintStartSeq As Short
	Private mstrRepeatKey As String
	Private mintTerminalCount As Short
	
	Private mastrInputLines() As String
	Private mintNextInputLine As Short
	
	Private mstrOutputFile As String
    Private mintOutputFile As Short

    Private Structure CardMachineBracket
        Public datStartDate As Date
        Public intMachineCount As Short
    End Structure

    'More than enough brackets
    Private maudtCardMachineBracket(100) As CardMachineBracket
    Private mintCardMachineBrackets As Short
	
	Private Sub BuilderForm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim strText As String
		strText = "startseq;1000" & vbCrLf & "repeatkey;33" & vbCrLf & "cashdelay;mon;1" & vbCrLf & "cashdelay;tue;1" & vbCrLf & "cashdelay;wed;1" & vbCrLf & "cashdelay;thu;1" & vbCrLf & "cashdelay;fri;3" & vbCrLf & "cashdelay;sat;2" & vbCrLf & "cashdelay;sun;1" & vbCrLf
		strText = strText & "carddelay;mon;2" & vbCrLf & "carddelay;tue;2" & vbCrLf & "carddelay;wed;2" & vbCrLf & "carddelay;thu;4" & vbCrLf & "carddelay;fri;3" & vbCrLf & "carddelay;sat;3" & vbCrLf & "carddelay;sun;2" & vbCrLf
		strText = strText & "dayweight;mon;1.25" & vbCrLf & "dayweight;tue;1" & vbCrLf & "dayweight;wed;1" & vbCrLf & "dayweight;thu;1" & vbCrLf & "dayweight;fri;1.5" & vbCrLf & "dayweight;sat;2.5" & vbCrLf & "dayweight;sun;2.0" & vbCrLf & "cashcatkey;003;1" & vbCrLf & "cardcatkey;004;3" & vbCrLf & "week;5/3/2010;30000" & vbCrLf & "week;5/10/2010;32000" & vbCrLf & "week;5/17/2010;33000"
		txtInput.Text = strText
	End Sub

    Private Sub cmdBuild_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuild.Click
        BuildFile(True, "DepositsCash.gen", "_cash", "Daily Cash Deposits", "4")
        BuildFile(False, "DepositsCard.gen", "_card", "Daily Card Deposits", "4")
    End Sub

    Private Sub BuildFile(ByVal blnForCash As Boolean, ByVal strBaseFileName As String, ByVal strKeySuffix As String,
                          ByVal strDescr As String, ByVal strMaxDaysOld As String)

        Dim strLine As String
        Dim astrFields() As String
        Dim strCmd As String
        Dim blnDidFirstWeek As Boolean

        mintCardMachineBrackets = 1
        maudtCardMachineBracket(1).datStartDate = #1/1/1990#
        maudtCardMachineBracket(1).intMachineCount = 1
        mstrOutputFile = My.Application.Info.DirectoryPath & "\" & strBaseFileName
        mintOutputFile = FreeFile()
        FileOpen(mintOutputFile, mstrOutputFile, OpenMode.Output)
        mastrInputLines = Split(txtInput.Text, vbCrLf)
        mintNextInputLine = LBound(mastrInputLines)
        Do
            If blnEndOfInput() Then
                Exit Do
            End If
            strLine = strNextInputLine()
            If Not (strLine.StartsWith("!") Or strLine = "") Then
                astrFields = Split(strLine, ";")
                strCmd = astrFields(0)
                If strCmd = "startseq" Then
                    mintStartSeq = Val(astrFields(1))
                ElseIf strCmd = "repeatkey" Then
                    mstrRepeatKey = astrFields(1) & strKeySuffix
                ElseIf strCmd = "cashdelay" Then
                    maintCashDelay(intGetDOWCode(astrFields(1))) = Val(astrFields(2))
                ElseIf strCmd = "carddelay" Then
                    maintCardDelay(intGetDOWCode(astrFields(1))) = Val(astrFields(2))
                ElseIf strCmd = "dayweight" Then
                    madblDayWeight(intGetDOWCode(astrFields(1))) = Val(astrFields(2))
                    ComputeTotalDayWeight()
                ElseIf strCmd = "cashcatkey" Then
                    mstrCashCatKey = astrFields(1)
                    mdblCashWeight = Val(astrFields(2))
                    ComputeTotalCatWeight()
                ElseIf strCmd = "cardcatkey" Then
                    mstrCardCatKey = astrFields(1)
                    mdblCardWeight = Val(astrFields(2))
                    ComputeTotalCatWeight()
                ElseIf strCmd = "cardmachinecount" Then
                    mintCardMachineBrackets = mintCardMachineBrackets + 1
                    maudtCardMachineBracket(mintCardMachineBrackets).datStartDate = CDate(astrFields(1))
                    maudtCardMachineBracket(mintCardMachineBrackets).intMachineCount = CInt(astrFields(2))
                    If maudtCardMachineBracket(mintCardMachineBrackets).datStartDate <=
                        maudtCardMachineBracket(mintCardMachineBrackets - 1).datStartDate Then
                        MsgBox("Card machine count dates must be in increasing order")
                        End
                    End If
                ElseIf strCmd = "week" Then
                    If Not blnDidFirstWeek Then
                        ConfirmAllSetupDone()
                        WriteLine_Renamed("<generator class=""wccheckbook.list"" description=""" & strDescr & """ enabled=""true""" &
                                          " repeatkey=""" & mstrRepeatKey & """ maxdaysold=""" & strMaxDaysOld & """ startseq=""" & mintStartSeq & """>")
                        blnDidFirstWeek = True
                    End If
                    OutputWeek(astrFields, blnForCash)
                Else
                    MsgBox("Unrecognized command " & strCmd)
                    Exit Sub
                End If
            End If
        Loop
        WriteLine_Renamed("</generator>")
        FileClose(mintOutputFile)

        MsgBox("Done - output written to " & mstrOutputFile)
    End Sub

    Private Function blnEndOfInput() As Boolean
		blnEndOfInput = mintNextInputLine > UBound(mastrInputLines)
	End Function
	
	Private Function strNextInputLine() As String
		strNextInputLine = mastrInputLines(mintNextInputLine)
		mintNextInputLine = mintNextInputLine + 1
	End Function
	
	Private Function intGetDOWCode(ByVal strDOWName As String) As Short
		If strDOWName = "mon" Then
			intGetDOWCode = FirstDayOfWeek.Monday
		ElseIf strDOWName = "tue" Then 
			intGetDOWCode = FirstDayOfWeek.Tuesday
		ElseIf strDOWName = "wed" Then 
			intGetDOWCode = FirstDayOfWeek.Wednesday
		ElseIf strDOWName = "thu" Then 
			intGetDOWCode = FirstDayOfWeek.Thursday
		ElseIf strDOWName = "fri" Then 
			intGetDOWCode = FirstDayOfWeek.Friday
		ElseIf strDOWName = "sat" Then 
			intGetDOWCode = FirstDayOfWeek.Saturday
		ElseIf strDOWName = "sun" Then 
			intGetDOWCode = FirstDayOfWeek.Sunday
		Else
			MsgBox("Unrecognized day of week " & strDOWName)
			End
		End If
	End Function
	
	Private Sub ConfirmAllSetupDone()
		If mdblTotalCatWeight = 0# Then
			MsgBox("No catkey lines found")
			End
		End If
		Dim intDOW As Short
		For intDOW = 1 To 7
			If maintCardDelay(intDOW) = 0 Then
				MsgBox("Missing card deposit delay for day #" & intDOW)
				End
			End If
			If maintCashDelay(intDOW) = 0 Then
				MsgBox("Missing cash deposit delay for day #" & intDOW)
				End
			End If
		Next 
		If mdblTotalDayWeight = 0 Then
			MsgBox("All days have zero weight")
			End
		End If
		If mstrRepeatKey = "" Then
			MsgBox("Missing repeatkey command")
			End
		End If
	End Sub
	
	Private Sub ComputeTotalDayWeight()
		Dim intDOW As Short
		mdblTotalDayWeight = 0
		For intDOW = 1 To 7
			mdblTotalDayWeight = mdblTotalDayWeight + madblDayWeight(intDOW)
		Next 
	End Sub
	
	Private Sub ComputeTotalCatWeight()
		mdblTotalCatWeight = mdblCardWeight + mdblCashWeight
	End Sub

    Private Sub OutputWeek(ByRef astrFields() As String, ByVal blnForCash As Boolean)
        Dim datWeekStart As Date
        Dim curWeekTotal As Decimal
        datWeekStart = CDate(astrFields(1))
        Dim intStartDOW As Short
        intStartDOW = Weekday(datWeekStart)
        If intStartDOW <> FirstDayOfWeek.Monday Then
            MsgBox("Week of " & datWeekStart & " must be a Monday, not a " & WeekdayName(Weekday(datWeekStart)))
            End
        End If
        curWeekTotal = CDec(astrFields(2))
        OutputDay(datWeekStart, FirstDayOfWeek.Monday, curWeekTotal, blnForCash)
        OutputDay(datWeekStart, FirstDayOfWeek.Tuesday, curWeekTotal, blnForCash)
        OutputDay(datWeekStart, FirstDayOfWeek.Wednesday, curWeekTotal, blnForCash)
        OutputDay(datWeekStart, FirstDayOfWeek.Thursday, curWeekTotal, blnForCash)
        OutputDay(datWeekStart, FirstDayOfWeek.Friday, curWeekTotal, blnForCash)
        OutputDay(datWeekStart, FirstDayOfWeek.Saturday, curWeekTotal, blnForCash)
        OutputDay(datWeekStart, FirstDayOfWeek.Sunday, curWeekTotal, blnForCash)
    End Sub

    Private Sub OutputDay(ByVal datWeekStart As Date, ByVal intDOW As Short, ByVal curWeekTotal As Decimal, ByVal blnForCash As Boolean)
        Dim curDayAmount As Decimal
        Dim datSales As Date
        Dim intCardMachineBracket As Short
        Dim intCardMachineCount As Short
        Dim intCardMachineIndex As Short

        If intDOW = FirstDayOfWeek.Sunday Then
            datSales = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 6, datWeekStart)
        Else
            datSales = DateAdd(Microsoft.VisualBasic.DateInterval.Day, intDOW - 2, datWeekStart)
        End If
        curDayAmount = curWeekTotal * madblDayWeight(intDOW) / mdblTotalDayWeight

        WriteLine_Renamed("  <!-- " & WeekdayName(intDOW) & " " & VB6.Format(datSales, "mm/dd/yyyy") & " $" & VB6.Format(curDayAmount, "#######0.00") & " -->")
        If blnForCash Then
            WriteTrx(curDayAmount, mdblCashWeight, mstrCashCatKey, "Cash &amp; Check Deposit", datWeekStart, datSales, intDOW, maintCashDelay)
        End If

        intCardMachineBracket = 1
        Do
            If intCardMachineBracket >= mintCardMachineBrackets Then
                Exit Do
            End If
            If maudtCardMachineBracket(intCardMachineBracket + 1).datStartDate > datSales Then
                Exit Do
            End If
            intCardMachineBracket = intCardMachineBracket + 1
        Loop
        intCardMachineCount = maudtCardMachineBracket(intCardMachineBracket).intMachineCount
        For intCardMachineIndex = 1 To intCardMachineCount
            If Not blnForCash Then
                WriteTrx(curDayAmount / intCardMachineCount, mdblCardWeight, mstrCardCatKey,
                    "Credit Card Deposit (#" & intCardMachineIndex & ")", datWeekStart, datSales, intDOW, maintCardDelay)
            End If
        Next
    End Sub

    Private Sub WriteTrx(ByVal curDayAmount As Decimal, ByVal dblCatWeight As Double, ByVal strCatKey As String, ByVal strDepositType As String, ByVal datWeekStart As Date, ByVal datSales As Date, ByVal intDOW As Short, ByRef aintDelay() As Short)
		
		Dim curTrxAmount As Decimal
		Dim datAvailable As Date
		Dim strLine As String
		
		datAvailable = DateAdd(Microsoft.VisualBasic.DateInterval.Day, aintDelay(intDOW), datSales)
		curTrxAmount = curDayAmount * dblCatWeight / mdblTotalCatWeight
		strLine = "  <normaltrx date=""" & VB6.Format(datAvailable, "mm/dd/yyyy") & """" & " number=""DEP""" & " description=""" & strDepositType & " (" & VB6.Format(datSales, "dd") & " " & WeekDayName(intDOW) & ")""" & " amount=""" & VB6.Format(curTrxAmount, "######0.00") & """" & " catkey=""" & strCatKey & """" & " />"
		WriteLine_Renamed(strLine)
	End Sub
	
	'UPGRADE_NOTE: WriteLine was upgraded to WriteLine_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub WriteLine_Renamed(ByVal strOutput As String)
		PrintLine(mintOutputFile, strOutput)
	End Sub
End Class