using UnityEngine;
using UnityEngine.UI;

public class PlanetSystemController : MonoBehaviour
{
    [SerializeField] private Slider _rotationSpeedSlider;
    [SerializeField] private Button _regenerateButton;
    [SerializeField] private float _totalMass;
    private PlanetarySystemFactory _planetarySystemFactory;
    private IPlanetarySystem _currentPlanetarySystem;

    private void Start()
    {
        _planetarySystemFactory = GetComponent<PlanetarySystemFactory>();
        _currentPlanetarySystem = _planetarySystemFactory.Create(_totalMass);
        _regenerateButton.onClick.AddListener(OnRegenerateButtonClick);
        _rotationSpeedSlider.onValueChanged.AddListener(OnRotationSpeedChanged);
    }
    
    private void OnRotationSpeedChanged(float value)
    {
        _currentPlanetarySystem.SetRotationSpeed(value);
    }

    private void OnRegenerateButtonClick()
    {
        _currentPlanetarySystem.ClearPlanetarySystem();
        _planetarySystemFactory.Create(_totalMass);
    }
}