using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystemFactory : MonoBehaviour, IPlaneterySystemFactory
{
    [SerializeField] PlanetaryObjectView _planetPrefab;
    [SerializeField] StarView _starPrefab;
    [SerializeField] float _minDist, _maxDist;
    [SerializeField] int _minCount, _maxCount;
    [SerializeField] double _totalMass;

    private const float MAX_PLANET_MASS = 5000f;
    private const float MIN_PLANET_MASS = 0.00001f;

    public IPlaneterySystem Create()
    {
        //Planetary System creation
        GameObject go = new("Planetary System", typeof(PlanetarySystemView));
        var planetarySystem = go.GetComponent<PlanetarySystemView>();

        //Star creation
        var star = Instantiate(_starPrefab, Vector3.zero, Quaternion.identity, planetarySystem.transform);
        planetarySystem.Constructor(star);

        //Setting count of planets
        int count = Random.Range(_minCount, _maxCount);
        List<double> randomMasses = new();
        double remainingMass = _totalMass;

        //Set up all masses
        for (int i = 0; i < count; i++)
        {
            double maxAllowedMass = Mathf.Min((float)remainingMass, MAX_PLANET_MASS);
            double randomMass = Random.Range(MIN_PLANET_MASS, (float)maxAllowedMass);

            randomMasses.Add(randomMass);
            remainingMass -= randomMass;
        }
        // The rest of mass
        double lastRandomMass = Mathf.Min((float)remainingMass, MAX_PLANET_MASS);
        randomMasses.Add(lastRandomMass);

        //Spawning planets
        for(int i = 0; i < randomMasses.Count; i++)
        {
            double randomMass = randomMasses[i];

            //Create a planet
            var planet = Instantiate(_planetPrefab, planetarySystem.transform);
            planet.Construstor(randomMass); //Set up mass for planet and all other values

            //Setting a position of planet in planetary system
            if (i == 0) planet.transform.position = SetPlanetPosition(planet.Radius, star.Radius, star.transform.position); //Because first planet resolves around the star
            else planet.transform.position = SetPlanetPosition(planet.Radius, planetarySystem.PlaneteryObjects[i - 1].Radius, 
                                                                planetarySystem.PlaneteryObjects[i - 1].GetTransform().position);

            planetarySystem.PlaneteryObjects.Add(planet);
        }
        return planetarySystem;
    }

    private Vector3 SetPlanetPosition(float radius, float previousRadius, Vector3 previousPlanetPos)
    {
        float minDistance = previousRadius + radius + _minDist;
        float maxDistance = previousRadius + radius + _maxDist;

        float randomDistance = Random.Range(minDistance, maxDistance);

        Vector3 offset = new(randomDistance, 0f, 0f);
        Vector3 newPosition = previousPlanetPos + offset;

        return newPosition;
    }
}
