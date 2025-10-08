dotnet tool restore

dotnet publish /property:PublishProfile="DesktopProfile"

dotnet publish /property:PublishProfile="MacOs64Profile"
dotnet MacOsAppBundler -p bin/publish/MacOs/x64 -n HelloWorld --id com.rehametrics.helloworld --certificate-name "Mac Developer: Vicente Penades (3CT5433VZF)"

dotnet publish /property:PublishProfile="MacOsArmProfile"
dotnet MacOsAppBundler -p bin/publish/MacOs/arm -n HelloWorld --id com.rehametrics.helloworld --certificate-name "Mac Developer: Vicente Penades (3CT5433VZF)"

read -p "pause"