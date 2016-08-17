%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe  YmsWindowsService.exe
Net Start YmsService
sc config YmsService start= auto
pause