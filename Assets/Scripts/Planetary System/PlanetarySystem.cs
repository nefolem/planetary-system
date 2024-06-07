using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    private float _planetSpeed;
    private readonly List<IPlanetaryObject> _planets = new();
    

    public IEnumerable<IPlanetaryObject> PlanetaryObjects => _planets;
    public GameObject PlanetPrefab { get; set; }

    public void Initialize(float totalMass)
    {
        _planetSpeed = 30f;
        GeneratePlanetarySystem(totalMass);
    }

    public void SetRotationSpeed(float planetSpeed)
    {
        _planetSpeed = planetSpeed;
    }

    void Update()
    {
        UpdateOrbit(_planetSpeed);
    }
    
    private void GeneratePlanetarySystem(float totalMass)
    {
        double remainingMass = totalMass;
        int numberOfPlanets = Random.Range(1, 10);

        for (int i = 0; i < numberOfPlanets; i++)
        {
            float planetMass = Random.Range(0.00001f, (float)(remainingMass / (numberOfPlanets - i)));
            remainingMass -= planetMass;
            
            float randomOrbitRadius = Random.Range(50f, 800f);
            float randomAngle = Random.Range(0f, 360f);

            Vector3 randomPosition = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), 0f, Mathf.Sin(randomAngle * Mathf.Deg2Rad)) * randomOrbitRadius;
            
            PlanetaryObject planet = CreatePlanetaryObject(planetMass, randomPosition);
            _planets.Add(planet);
        }
    }

    private void UpdateOrbit(float planetSpeed)
    {
        foreach (var planet in _planets)
        {
            (planet as PlanetaryObject).transform.RotateAround(Vector3.zero, Vector3.up, planetSpeed / planet.Radius * Time.deltaTime);
        }
    }


    private PlanetaryObject CreatePlanetaryObject(float mass, Vector3 position)
    {
        GameObject planetObject = Instantiate(PlanetPrefab, position, Quaternion.identity, transform);
        PlanetaryObject planet = planetObject.GetComponent<PlanetaryObject>();
        if (planet == null)
        {
            planet = planetObject.AddComponent<PlanetaryObject>();
        }
        planet.Initialize(mass);

        return planet;
    }

    public void ClearPlanetarySystem()
    {
        foreach (var planet in _planets)
        {
            planet.RemovePlanet();
        }
    }
}