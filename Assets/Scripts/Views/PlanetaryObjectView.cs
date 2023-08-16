using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour, IPlaneteryObject
{
    [SerializeField] MeshRenderer _renderer;

    private double _mass;
    public double Mass 
    { 
        get { return _mass; } 
        private set
        {
            _mass = value;
            if (_mass < 0) Debug.LogWarning("Mass is less than 0");
            else if (_mass > 0 && _mass <= 0.00001)
            {
                Radius = Random.Range(0f, 0.03f);
                MassClass = MassClassEnum.Asteroidan;
            }
            else if (_mass > 0.00001 && _mass <= 0.1)
            {
                Radius = Random.Range(0.03f, 0.7f);
                MassClass = MassClassEnum.Mercurian;
            }
            else if (_mass > 0.1 && _mass <= 0.5)
            {
                Radius = Random.Range(0.5f, 1.2f);
                MassClass = MassClassEnum.Subterran;
            }
            else if (_mass > 0.5 && _mass <= 2)
            {
                Radius = Random.Range(0.8f, 1.9f);
                MassClass = MassClassEnum.Subterran;
            }
            else if (_mass > 2 && _mass <= 10)
            {
                Radius = Random.Range(1.3f, 3.3f);
                MassClass = MassClassEnum.Terran;
            }
            else if (_mass > 10 && _mass <= 50)
            {
                Radius = Random.Range(2.1f, 5.7f);
                MassClass = MassClassEnum.Superterran;
            }
            else if (_mass > 50 && _mass <= 5000)
            {
                Radius = Random.Range(3.5f, 27f);
                MassClass = MassClassEnum.Jovian;
            }
            else Debug.LogWarning("Mass is greater than 5000.");
        }
    }
    public float Radius { get; private set; }
    public MassClassEnum MassClass { get; private set;  }

    public void Construstor(double mass) => Mass = mass;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x * Radius, transform.localScale.y * Radius, transform.localScale.z * Radius);
        _renderer.sharedMaterial.color = ColorService.PlanetRandomColor();
    }

    public Transform GetTransform() => transform;
}
