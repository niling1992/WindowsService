net start "vmware nat service" /user:administrator 1234 
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe E:\WindowsServiceTest\WindowsServiceTest\WindowsServiceTestUI\bin\Debug\Service\WindowsServiceTest.exe
Net Start ServiceTest
sc config ServiceTest start= auto
pause