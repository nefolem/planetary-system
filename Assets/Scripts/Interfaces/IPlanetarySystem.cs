using System.Collections.Generic;

public interface IPlanetarySystem
{
    IEnumerable<IPlanetaryObject> PlanetaryObjects { get; }
    void Initialize(float totalMass);
    void SetRotationSpeed(float speed);
}