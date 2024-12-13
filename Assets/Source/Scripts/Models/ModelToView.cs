using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelToView : MonoBehaviour
{
    [SerializeField] private List<string> _animationsName;
    [SerializeField] private ModelToViewAnimator _animator;

    private readonly List<Material> _materials = new();
    private MeshRenderer[] _meshRenderers;

    public Color[] MaterialsColor => _materials.Select(c => c.color).ToArray();
    public bool HasAnimations => _animationsName.Count > 0;
    public string[] AnimationsName => _animationsName.ToArray();

    private void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
#if UNITY_EDITOR
            foreach (Material material in meshRenderer.materials)
            {
                if (_materials.Contains(material) == false)
                {
                    _materials.Add(material);
                }
            }
#else
            foreach (Material material in meshRenderer.sharedMaterials)
            {
                if (_materials.Contains(material) == false)
                {
                    _materials.Add(material);
                }
            }
#endif
        }
    }

    public void SetColor(Color color, int materialIndex)
    {
        _materials[materialIndex].color = color;
    }

    public void ChangeAnimation(string name, float transitionDuration = 0.1f, bool canRepeat = false)
    {
        if (_animator == null)
            return;

        _animator.ChangeAnimation(name, transitionDuration, canRepeat);
    }
}