using System.Collections.Generic;

public class ModelsNameDataSource
{
    private readonly Dictionary<string, string> _namesByPath = new()
    {
        [ResourcesPath.NameChair] = "Кресло",
        [ResourcesPath.NameGeoPlanter] = "Кактус",
        [ResourcesPath.NameMixer] = "Миксер",
        [ResourcesPath.NameRobotExpressive] = "Робот",
    };

    public string GetName(string path) =>
        _namesByPath[path];
}
