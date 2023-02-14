namespace DalApi;
using DO;
using System.Xml.Linq;

/// <summary>
/// Class for processing config.xml file and getting from there
/// information which is relevant for initialization of DalApi
/// </summary
static class DalConfig
{
    internal static string? s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    /// <summary>
    /// Static constructor extracts Dal packages list and Dal type from
    /// Dal configuration file config.xml
    /// And represents errors during DalApi initialization
    /// </summary>
    static DalConfig()
    {
        XElement dalConfig = XElement.Load(@"..\xml\dal-config.xml")
            ?? throw new DalConfigException("dal-config.xml file is not found");
        s_dalName = dalConfig?.Element("dal")?.Value
            ?? throw new DalConfigException("<dal> element is missing");
        var packages = dalConfig?.Element("dal-packages")?.Elements()
            ?? throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}
