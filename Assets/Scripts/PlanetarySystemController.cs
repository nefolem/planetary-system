using UnityEngine;
using UnityEngine.UI;

public class PlanetSystemController : MonoBehaviour
{
    [SerializeField] private Slider _rotationSpeedSlider;
    [SerializeField] private Button _regenerateButton;
    [SerializeField] private float _totalMass;
    private PlanetarySystemFactory _planetarySystemFactory;
    private IPlanetarySystem _planetarySystem;

    private void Start()
    {
        _planetarySystemFactory = GetComponent<PlanetarySystemFactory>();

        CreatePlanetarySystem();
        
        _regenerateButton.onClick.AddListener(OnRegenerateButtonClick);
        _rotationSpeedSlider.onValueChanged.AddListener(OnRotationSpeedChanged);
    }

    private void CreatePlanetarySystem()
    {
        if (_planetarySystem != null)
        {
            Destroy(((PlanetarySystem)_planetarySystem).gameObject);
        }
        
        _planetarySystem = _planetarySystemFactory.Create(_totalMass);
        
        foreach (IPlanetaryObject planet in _planetarySystem.PlanetaryObjects)
        {
            Debug.Log($"Planet with mass: {planet.Mass} and mass class: {planet.MassClass}");
        }
    }
    
    private void OnRotationSpeedChanged(float value)
    {
        _planetarySystem.SetRotationSpeed(value);
    }

    private void OnRegenerateButtonClick()
    {
        CreatePlanetarySystem();
    }
}