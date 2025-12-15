using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Maui.Storage;

namespace HelloWorldCross.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";


    public IEnumerable<StringPair> EnvFolders => GetFolders();

    private static IEnumerable<StringPair> GetFolders()
    {
        var list = new List<StringPair>();
        foreach (var sf in Enum.GetValues<System.Environment.SpecialFolder>())
        {
            var path = Environment.GetFolderPath(sf);

            list.Add(new StringPair(sf.ToString(), path));
        }

        list.Add(new StringPair("Temp", System.IO.Path.GetTempPath()));
        list.Add(new StringPair("App BaseDirectory", AppContext.BaseDirectory ?? "?"));
        list.Add(new StringPair("App ProcessPath", Environment.ProcessPath ?? "?"));

        list.Add(new StringPair("MauiEssentials Cache", FileSystemEx.Current.CacheDirectory));
        list.Add(new StringPair("MauiEssentials AppData", FileSystemEx.Current.AppDataDirectory));

        return list.OrderBy(item => item.Value);
    }

    public IEnumerable<StringPair> Certificates => GetCertificates();

    private static IEnumerable<StringPair> GetCertificates()
    {
        var items = new List<StringPair>();

        foreach (var storeName in Enum.GetValues<StoreName>())
        {
            

            try
            {

                using var store = new X509Store(storeName, StoreLocation.LocalMachine);

                store.Open(OpenFlags.ReadOnly);

                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    //TODO's

                    var key = $"{storeName} {certificate.FriendlyName}";
                    var val = $"{certificate.Subject} {certificate.Issuer}";

                    items.Add(new StringPair(key, val));
                }
            }
            catch(Exception ex)
            {
                items.Add(new StringPair(storeName.ToString(), "ERROR: Can't create store"));
            }

        
        }

        return items;
    }


    [RelayCommand]
    public async Task LoadResourcesAsync()
    {
        using var s = await OpenAppFileAsync("asset0.txt");

        using var t = new StreamReader(s);

        LoadedResource = await t.ReadToEndAsync();        
    }

    [ObservableProperty]
    private string? loadedResource;

    private static async Task<Stream> OpenAppFileAsync(string path)
    {
        return await FileSystemEx.Current.OpenAppPackageFileAsync(path);
    }
}

/// <summary>
/// <see cref="Microsoft.Maui.Storage.FileSystem"/> with Desktop support
/// </summary>
class FileSystemEx : Microsoft.Maui.Storage.IFileSystem
{
    static FileSystemEx()
    {
        if (OperatingSystem.IsWindows())
        {
            Current = new FileSystemEx();
        }
        else
        {
            Current = Microsoft.Maui.Storage.FileSystem.Current;            
        }
    }

    public static Microsoft.Maui.Storage.IFileSystem Current { get; }

    public FileSystemEx()
    {
        var path = Environment.ProcessPath;
        var bytes = System.Text.Encoding.UTF8.GetBytes(path);
        bytes = System.Security.Cryptography.MD5.HashData(bytes);
        path = System.Convert.ToBase64String(bytes);

        CacheDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), path);
    }

    public string CacheDirectory { get; }

    public string AppDataDirectory => AppContext.BaseDirectory;

    public async Task<Stream> OpenAppPackageFileAsync(string filename)
    {
        filename = System.IO.Path.Combine(AppDataDirectory, "Content", filename);

        return await Task.FromResult(File.OpenRead(filename));
    }

    public async Task<bool> AppPackageFileExistsAsync(string filename)
    {
        filename = System.IO.Path.Combine(AppDataDirectory, "Content", filename);        

        return await Task.FromResult(new FileInfo(filename).Exists);
    }    
}





public partial class StringPair
{
    public StringPair(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; set; }
    public string Value { get; set; }
}
