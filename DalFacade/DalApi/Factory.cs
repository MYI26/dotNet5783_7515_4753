namespace DalApi;

using DalApi.DO;
using System.Reflection;
using static DalApi.DalConfig;

// <summary>
/// Static Factory class for creating Dal tier implementation object according to
/// configuration in file dal-config.xml
/// </summary>
public static class Factory
{
    /// <summary>
    /// The function creates Dal tier implementation object according to Dal type
    /// as appears in "dal" element in the configuration file dal-config.xml.<br/>
    /// The configuration file also includes element "dal-packages" with list
    /// of available packages (.dll files) per Dal type.<br/>
    /// Each Dal package must use "Dal" namespace and it must include internal access
    /// singleton class with the same name as package's name.<br/>
    /// The singleton class must include public static property called "Instance"
    /// which must contain the single instance of the class.
    /// </summary>
    /// <returns>Dal tier implementation object</returns>
    public static IDal? Get()
    {
        string dalType = s_dalName
            ?? throw new DalConfigException($"DAL name is not extracted from the configuration");
        string dal = s_dalPackages[dalType]
           ?? throw new DalConfigException($"Package for {dalType} is not found in packages list");

        try
        {
            Assembly.Load(dal ?? throw new DalConfigException($"Package {dal} is null"));
        }
        catch (Exception)
        {
            throw new DalConfigException("Failed to load {dal}.dll package");
        }

        Type? type = Type.GetType($"Dal.{dal}, {dal}")
            ?? throw new DalConfigException($"Class Dal.{dal} was not found in {dal}.dll");

        return type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static)?
                   .GetValue(null) as IDal
            ?? throw new DalConfigException($"Class {dal} is not singleton or Instance property not found");
    }
}


