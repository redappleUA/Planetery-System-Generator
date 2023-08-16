using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneteryObject
{
    public MassClassEnum MassClass { get; }
    public double Mass { get; }
    public float Radius { get; }

    /* In this case I'd prefer to use abstract super class instead interface to may acces to transform component 
    and better way to set up star also like planetary object */
    public Transform GetTransform();
}
