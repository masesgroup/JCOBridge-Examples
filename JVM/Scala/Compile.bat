@echo off
mkdir Output

scalac -toolcp "C:\Program Files\MASES Group\JCOB\Core\JCOBridge.jar" -d ./Output .\scalaclass\src\main\scala\*.scala
IF %ERRORLEVEL% NEQ 0 PAUSE