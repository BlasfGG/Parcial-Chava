using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ControlPost : MonoBehaviour
{
   
    private float saturation = 0.5f;
    private float bloomIntensity = 0.5f;

    private Volume volume;
    private ColorAdjustments colorAdjustments;
    private Bloom bloom;

    [SerializeField] private Slider saturationSlider; // Referencia al Slider

    [SerializeField] private Slider bloomSlider;

    void Start()
    {
        volume = FindAnyObjectByType<Volume>(); // Busca el componente Volume en la escena

        if (volume.profile.TryGet<ColorAdjustments>(out var adjustments))
        {
            colorAdjustments = adjustments;
            colorAdjustments.saturation.value = saturation;

            // Configura el Slider con los valores iniciales
            if (saturationSlider != null)
            {
                saturationSlider.minValue = -100f;
                saturationSlider.maxValue = 100f;
                saturationSlider.value = saturation;
                saturationSlider.onValueChanged.AddListener(UpdateSaturation); // Vincula el evento
            }
        }



        if (volume.profile.TryGet<Bloom>(out var bloomEffect))
        {
            bloom = bloomEffect;
            bloom.intensity.value = bloomIntensity;

            // Configura el Slider con los valores iniciales
            if (bloomSlider != null)
            {
                bloomSlider.minValue = 0f; // Valor mínimo de intensidad
                bloomSlider.maxValue = 10f; // Valor máximo de intensidad
                bloomSlider.value = bloomIntensity;
                bloomSlider.onValueChanged.AddListener(UpdateBloomIntensity); // Vincula el evento
            }

        }
       
    }
   
    private void UpdateSaturation(float value)
    {
        saturation = value;
        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = saturation;
        }
        Debug.Log("Saturation updated: " + saturation);
    }

    private void UpdateBloomIntensity(float value)
    {
        bloomIntensity = value;
        if (bloom != null)
        {
            bloom.intensity.value = bloomIntensity;
        }
        Debug.Log("Bloom intensity updated: " + bloomIntensity);
    }
}
