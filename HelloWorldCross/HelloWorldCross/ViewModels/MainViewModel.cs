using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace HelloWorldCross.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";


    public IEnumerable<StringPair> EnvFolders
    {
        get
        {
            return GetFolders();
        }
    }

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
