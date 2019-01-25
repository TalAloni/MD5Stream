set binaryPath=%CD%\..\bin\Release
set outputPath=%CD%\..\bin\ILMerge
IF NOT EXIST "%outputPath%" MKDIR "%outputPath%"
IF ["%programfiles(x86)%"]==[""] SET ilmergePath="%programfiles%\Microsoft\ILMerge"
IF NOT ["%programfiles(x86)%"]==[""] SET ilmergePath="%programfiles(x86)%\Microsoft\ILMerge"
%ilmergePath%\ilmerge /ndebug /target:winexe /out:"%outputPath%\MD5Stream.exe" "%binaryPath%\MD5Stream.exe" "%binaryPath%\System.Core.dll" "%binaryPath%\Trinet.Core.IO.Ntfs.dll"