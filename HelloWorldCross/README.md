




### MacOS

publish profiles may include:

```xml
<PublishAot>false</PublishAot>  <!-- AOT for ARM is available from Net.9 onwards -->
<UseAppHost>true</UseAppHost>   <!-- fixes executable extension -->
```



when creating bash files, use

```
dotnet publish /property:PublishProfile="MacOsArmProfile"
```

do not use `/p:PublishProfile` because the `/p:` is interpreted as a disk drive instead of /property command.

- [Avalonia MacOS deployment notes](https://docs.avaloniaui.net/docs/deployment/macOS)
- [▶ Mac Os - Avalonia Application with VS Code](https://www.youtube.com/watch?v=pAWftZEBC2E)
- [🐙 avalonia-net6-macos-sample](https://github.com/maxkatz6/avalonia-net6-macos-sample)