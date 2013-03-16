Imports System.IO

Public Class ShellParse
    Public Structure ShellCode
        Public KeyLength As Integer
        Public OutputLocation As String
    End Structure
    Public Function ByteXorExecutable(ByVal InputString As String, ByVal XorKey As String, ByVal VariableName As String, ByVal VariableLineLength As Integer) As ShellCode 'Very poorly made function to parse and encrypt files
        Dim OutputShellCode As ShellCode
        Dim XorBuilder As New System.Text.StringBuilder()
        Dim XorNum As Integer = Integer.Parse(XorKey, Globalization.NumberStyles.HexNumber)
        Dim LengthCounter As Integer = 0
        For Each numhex As String In InputString.Split(","c)
            LengthCounter += 1
            Dim num As Integer = Integer.Parse(numhex, Globalization.NumberStyles.HexNumber)
            XorBuilder.Append((num Xor XorNum).ToString("X2")).Append(",")
        Next
        Dim HexList As ArrayList = New ArrayList
        Dim XorDone As String = XorBuilder.ToString
        For Each item As String In XorDone.Split(","c)
            If item.Length >= 1 Then
                HexList.Add("0" & item & "h,")
            End If
        Next
        OutputShellCode.OutputLocation = System.IO.Path.GetTempFileName
        Dim OutputWriter As StreamWriter = New StreamWriter(OutputShellCode.OutputLocation)
        Dim OutputLength As Integer = 0
        OutputWriter.WriteLine(VariableName & " \")
        OutputWriter.Write("db ")
        For Each Value In HexList
            If OutputLength = VariableLineLength Then
                OutputWriter.Write(vbNewLine)
                OutputWriter.Write("db ")
                OutputWriter.Write(Value)
                OutputLength = 0
            Else
                If OutputLength = VariableLineLength - 1 Then
                    OutputWriter.Write(Value.SubString(0, 4))
                Else
                    OutputWriter.Write(Value)
                End If

            End If
            OutputLength = OutputLength + 1
        Next
        OutputWriter.Close()
        OutputShellCode.KeyLength = LengthCounter
        Return OutputShellCode
    End Function
    Public Function ParseExe(ByVal ExeLocation As String) 'Brings in the executable file and parses it into a common format
        Dim InputBytes() As Byte = IO.File.ReadAllBytes(ExeLocation)
        Dim HexString As String = BytesToHex(InputBytes)
        Dim SplitHex As String() = HexString.Split(New Char() {"$"c})
        Dim OutputArray As ArrayList = New ArrayList
        For Each Value In SplitHex
            OutputArray.Add(Value)
        Next
        Return String.Join(",", TryCast(OutputArray.ToArray(GetType(String)), String()))
    End Function
    Public Function BytesToHex(ByVal value As Byte()) 'Quick and dirty byte to hex converter
        Dim buffer As String = BitConverter.ToString(value)
        Return buffer.Replace("-", "$")
    End Function
End Class
