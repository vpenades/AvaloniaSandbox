dotnet tool restore

dotnet publish /property:PublishProfile="MacOsArmProfile"
dotnet MacOsAppBundler -p bin/publish/MacOs/arm -n HelloWorld --id com.rehametrics.helloworld --certificate-name $1

read -p "pause"