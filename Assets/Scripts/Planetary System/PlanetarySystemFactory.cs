using UnityEngine;

public class PlanetarySystemFactory : MonoBehaviour, IPlanetarySystemFactory
{
    [SerializeField] private GameObject _planetPrefab;
    
    public IPlanetarySystem Create(float mass)
    {
        GameObject planetarySystemGO = new GameObject("PlanetarySystem");
        var planetarySystem = planetarySystemGO.AddComponent<PlanetarySystem>();
        planetarySystem.PlanetPrefab = _planetPrefab; 
        planetarySystem.Initialize(mass);
        return planetarySystem;
    }
}