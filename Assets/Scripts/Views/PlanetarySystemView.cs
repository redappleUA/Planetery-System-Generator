using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystemView : MonoBehaviour, IPlaneterySystem
{
    private readonly float _speed = 8, _decreaseMultiplier = 0.5f;
    public StarView Star { get; private set; }
    public List<IPlaneteryObject> PlaneteryObjects { get; private set; } = new();

    public void Constructor(StarView star)
    {
        Star = star;
    }

    private void Update()
    {
        float speed = _speed;
        //Rotation
        for (int i = 0; i < PlaneteryObjects.Count; i++)
        {
            speed -= i * _decreaseMultiplier;
            PlaneteryObjects[i].GetTransform().RotateAround(Star.transform.position, Star.transform.up, speed * Time.deltaTime);
        }
    }
}
