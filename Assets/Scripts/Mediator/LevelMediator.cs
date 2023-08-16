using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMediator : MonoBehaviour
{
    [SerializeField] PlanetSystemFactory _factory;

    private void Start()
    {
        _factory.Create();
    }
}
