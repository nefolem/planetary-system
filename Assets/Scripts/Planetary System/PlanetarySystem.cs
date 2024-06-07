using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlanetarySystem : MonoBehaviour, IPlanetarySystem
{
    private readonly List<IPlanetaryObject> _planets = new();
    private float _planetSpeed;

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
        UpdateOrbit();
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
            
            PlanetaryObject planet = PlanetaryObject.CreatePlanetaryObject(PlanetPrefab, planetMass, randomPosition, transform);
            _planets.Add(planet);
        }
    }

    private void UpdateOrbit()
    {
        foreach (var planet in _planets)
        {
            (planet as PlanetaryObject).transform.RotateAround(Vector3.zero, Vector3.up, _planetSpeed / planet.Radius * Time.deltaTime);
        }
    }


}