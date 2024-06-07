public interface IPlanetaryObject
{
    MassClassEnum MassClass { get; }
    float Mass { get; }
    float Radius { get; }
    void Initialize(float mass);
    
    void RemovePlanet();
}