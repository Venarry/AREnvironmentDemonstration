using System.Collections.Generic;
using UnityEngine;

public class ModelToView : MonoBehaviour
{
    [SerializeField] private List<string> _animationsName;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Material _material;

    public Color MaterialColor => _material.color;

    private void Awake()
    {
        _material = _meshRenderer.sharedMaterial;
    }

    public void SetColor(Color color)
    {
        _material.color = color;
    }
}
