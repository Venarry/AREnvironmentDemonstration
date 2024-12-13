using System.Collections.Generic;

public class ModelsNameDataSource
{
    private readonly Dictionary<string, string> _namesByPath = new()
    {
        [ResourcesPath.NameChair] = "������",
        [ResourcesPath.NameGeoPlanter] = "������",
        [ResourcesPath.NameMixer] = "������",
        [ResourcesPath.NameRobotExpressive] = "�����",
    };

    public string GetName(string path) =>
        _namesByPath[path];
}
