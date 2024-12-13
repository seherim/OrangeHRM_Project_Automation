@ECHO OFF
ECHO OrangeHRM Automation Executed Started.

call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"

VsTest.Console.exe C:\Users\seher\source\repos\OrangeHRM_Project_Automation\OrangeHRM_Project_Automation\bin\Debug\OrangeHRM_Project_Automation.dll

PAUSE