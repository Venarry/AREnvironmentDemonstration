public class ResourcesPath
{
    public const string ModelChooseButton = "UI/ModelChooseButton";
    public const string SwitchColorButton = "UI/SwitchMaterialButton";
    public const string AnimationButton = "UI/AnimationButton";

    private const string PathToModels = "ARModels/";

    public const string NameChair = PathToModels + "Chair";
    public const string NameMixer = PathToModels + "Mixer";
    public const string NameGeoPlanter = PathToModels + "GeoPlanter";
    public const string NameRobotExpressive = PathToModels + "RobotExpressive";

    public static string[] GetAllModelsPath()
    {
        return new string[]
        {
            NameChair,
            NameMixer,
            NameGeoPlanter,
            NameRobotExpressive,
        };
    }
}
