public class ResourcesPath
{
    public const string ModelChooseButton = "UI/ModelChooseButton";

    private const string PathToModels = "ARModels/";

    private const string NameChair = PathToModels + "Chair";
    private const string NameMixer = PathToModels + "Mixer";

    public static string[] GetAllModelsPath()
    {
        return new string[]
        {
            NameChair,
            NameMixer,
        };
    }
}
