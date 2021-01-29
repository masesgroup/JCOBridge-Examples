@echo off

mkdir Output

"C:\Program Files\Java\%JDKVERSION%\bin\javac.exe" -Xlint:deprecation -Xlint:unchecked -cp "../../CLR/OutputCore/net5.0-windows/JCOBridge.jar" -d ./Output ./src/*.java

PAUSE