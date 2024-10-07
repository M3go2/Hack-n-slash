using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day-Night Settings")]
    public float dayLengthInSeconds = 60f; // Adjust day length as needed
    public float nightLengthInSeconds = 30f; // Adjust night length as needed
    public Color dayColor = Color.white;
    public Color nightColor = Color.black;
    public Light sunLight;

    private float currentDayLength;
    private float currentNightLength;
    private bool isDay;

    private void Start()
    {
        currentDayLength = dayLengthInSeconds;
        currentNightLength = nightLengthInSeconds;
        isDay = true;
    }

    private void Update()
    {
        if (isDay)
        {
            currentDayLength -= Time.deltaTime;
            if (currentDayLength <= 0)
            {
                isDay = false;
                currentNightLength = nightLengthInSeconds;
                RenderSettings.ambientLight = nightColor;
            }
            else
            {
                RenderSettings.ambientLight = Color.Lerp(nightColor, dayColor, 1 - currentDayLength / dayLengthInSeconds);
            }
        }
        else
        {
            currentNightLength -= Time.deltaTime;
            if (currentNightLength <= 0)
            {
                isDay = true;
                currentDayLength = dayLengthInSeconds;
                RenderSettings.ambientLight = dayColor;
            }
            else
            {
                RenderSettings.ambientLight = Color.Lerp(dayColor, nightColor, 1 - currentNightLength / nightLengthInSeconds);
            }
        }

        // Adjust sun light intensity based on day-night cycle
        sunLight.intensity = Mathf.Lerp(0f, 1f, isDay ? currentDayLength / dayLengthInSeconds : currentNightLength / nightLengthInSeconds);
    }
}