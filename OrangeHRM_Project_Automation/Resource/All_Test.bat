@ECHO OFFS
ECHO OrangeHRM Automation Executed Started.

set summaryPath=C:\Users\seher\source\repos\OrangeHRM_Project_Automation\OrangeHRM_Project_Automation\TestSummaryReport


call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"

VSTest.Console.exe C:\Users\seher\source\repos\OrangeHRM_Project_Automation\OrangeHRM_Project_Automation\bin\Debug\OrangeHRM_Project_Automation.dll
/Logger:"trx;LogFileName=C:\Users\seher\source\repos\OrangeHRM_Project_Automation\OrangeHRM_Project_Automation\TestSummaryReport\Login_Valid_TC001.trx"

cd C:\Users\seher\source\repos\OrangeHRM_Project_Automation\OrangeHRM_Project_Automation\bin\Debug\

TrxerConsole.exe %summaryPath%

PAUSE