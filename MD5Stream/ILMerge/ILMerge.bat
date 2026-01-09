IF ["%programfiles(x86)%"]==[""] SET ilmergePath="%programfiles%\Microsoft\ILMerge"
IF NOT ["%programfiles(x86)%"]==[""] SET ilmergePath="%programfiles(x86)%\Microsoft\ILMerge"

set TargetFramework=%1
if %TargetFramework%==net20 set TargetPlaform=2.0
if %TargetFramework%==net40 set TargetPlaform=4.0
set binaryPath=%CD%\..\bin\Release\%TargetFramework%
set outputPath=%CD%\..\bin\ILMerge\%TargetFramework%
IF NOT EXIST "%outputPath%" MKDIR "%outputPath%"
if %TargetFramework%==net20 %ilmergePath%\ilmerge /targetplatform=%TargetPlaform% /ndebug /target:winexe /out:"%outputPath%\MD5Stream.exe" "%binaryPath%\MD5Stream.exe" "%binaryPath%\System.Core.dll" "%binaryPath%\Trinet.Core.IO.Ntfs.dll"
if %TargetFramework%==net40 %ilmergePath%\ilmerge /targetplatform=%TargetPlaform% /ndebug /target:winexe /out:"%outputPath%\MD5Stream.exe" "%binaryPath%\MD5Stream.exe" "%binaryPath%\Trinet.Core.IO.Ntfs.dll"