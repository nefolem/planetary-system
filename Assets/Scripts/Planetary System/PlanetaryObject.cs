using UnityEngine;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    public float Mass { get; private set; }
    public MassClassEnum MassClass { get; private set; }
    public float Radius { get; private set; }

    public void Initialize(float mass)
    {
        Mass = mass;
        MassClass = DetermineMassClass(mass);
        UpdateVisualRepresentation();
    }

    public void RemovePlanet()
    {
        Destroy(gameObject);
    }

    private MassClassEnum DetermineMassClass(float mass)
    {
        return mass switch
        {
            < 0.00001f => MassClassEnum.Asteroidan,
            < 0.1f => MassClassEnum.Mercurian,
            < 0.5f => MassClassEnum.Subterran,
            < 2f => MassClassEnum.Terran,
            < 10f => MassClassEnum.Superterran,
            < 50f => MassClassEnum.Neptunian,
            _ => MassClassEnum.Jovian
        };
    }

    private void UpdateVisualRepresentation()
    {
        float radius = MassClass switch
        {
            MassClassEnum.Asteroidan => Random.Range(0f, 0.03f),
            MassClassEnum.Mercurian => Random.Range(0.03f, 0.7f),
            MassClassEnum.Subterran => Random.Range(0.5f, 1.2f),
            MassClassEnum.Terran => Random.Range(0.8f, 1.9f),
            MassClassEnum.Superterran => Random.Range(1.3f, 3.3f),
            MassClassEnum.Neptunian => Random.Range(2.1f, 5.7f),
            MassClassEnum.Jovian => Random.Range(3.5f, 27f),
            _ => 1f
        };
        transform.localScale = Vector3.one * radius * 2;
        Radius = radius;
    }
}

public enum MassClassEnum
{
    Asteroidan,
    Mercurian,
    Subterran,
    Terran,
    Superterran,
    Neptunian,
    Jovian
}