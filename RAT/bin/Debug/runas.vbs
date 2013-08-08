Option explicit
Dim oShell
set oShell= Wscript.CreateObject("WScript.Shell")
'Replace the path with the program you wish to run c:\program files...
oShell.Run "RunAs /noprofile /user:administrator ""rat.exe"""
WScript.Sleep 100
'Replace the string --> yourpassword~ with the
'password used on your system. Include the tilde "~"
oShell.Sendkeys "pq97ric#@!~"
Wscript.Quit