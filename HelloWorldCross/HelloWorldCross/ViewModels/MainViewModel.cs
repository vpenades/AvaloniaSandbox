using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
