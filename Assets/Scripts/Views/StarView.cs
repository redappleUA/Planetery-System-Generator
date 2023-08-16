using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarView : MonoBehaviour
{
    [SerializeField] Renderer _renderer;
    [SerializeField] float _minRadius, _maxRadius;
    public float Radius { get; private set; }
    private void Awake()
    {
        Radius = Random.Range(_minRadius, _maxRadius);
        transform.localScale = new Vector3(transform.localScale.x * Radius, transform.localScale.y * Radius, transform.localScale.z * Radius);
        _renderer.sharedMaterial.SetColor("_BaseColor", ColorService.StarRandomColor());
    }
}
