dotnet tool restore

dotnet publish /property:PublishProfile="DesktopProfile"

dotnet publish /property:PublishProfile="MacOs64Profile"
dotnet MacOsAppBundler -p bin/publish/MacOs/x64 -n HelloWorld --id com.rehametrics.helloworld --certificate-name "Apple Distribution: Rehametrics Sociedad Limitada (MG63846639)"

dotnet publish /property:PublishProfile="MacOsArmProfile"
dotnet MacOsAppBundler -p bin/publish/MacOs/arm -n HelloWorld --id com.rehametrics.helloworld --certificate-name "Apple Distribution: Rehametrics Sociedad Limitada (MG63846639)"

read -p "pause"