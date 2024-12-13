using UnityEngine;

public class SwitchMaterialButtonFactory
{
    private readonly SwitchMaterialButton _prefab = Resources.Load<SwitchMaterialButton>(ResourcesPath.SwitchColorButton);

    public SwitchMaterialButton Create(ModelColorSwitcher modelColorSwitcher, Transform parent, int index)
    {
        SwitchMaterialButton switchMaterialButton = Object.Instantiate(_prefab, parent);
        switchMaterialButton.Init(index, modelColorSwitcher);

        return switchMaterialButton;
    }
}
