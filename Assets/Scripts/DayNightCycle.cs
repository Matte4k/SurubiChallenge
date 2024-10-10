using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight; // Sunlight (Directional Light)

    public float dayDuration = 30f; // Duration of day in seconds
    public float nightDuration = 15f; // Duration of night in seconds

    [Range(0, 24)] public float timeOfDay = 12f; // Current time of day (0 is midnight, 12 is noon)

    public Gradient skyColor; // Gradient for sky colors during day and night
    public Gradient fogColor; // Gradient for fog colors during day and night
    public AnimationCurve sunIntensityCurve; // Intensity curve for the sun
    public AnimationCurve exposureCurve; // Curve for smoother skybox exposure transitions

    private float dayNightSpeed; // Speed of time progression

    void Start()
    {
        if (sunLight == null)
        {
            Debug.LogError("Sun or Moon Light not assigned!");
        }

        // Calculate time progression speed based on day and night durations
        dayNightSpeed = 24f / (dayDuration + nightDuration);
    }

    void Update()
    {
        // Update the time of day
        timeOfDay += Time.deltaTime * dayNightSpeed;
        if (timeOfDay >= 24f) timeOfDay = 0f;

        // Update the sun and moon positions
        UpdateSunAndMoonRotation();

        // Adjust lighting intensities for both sun and moon
        AdjustSunAndMoonIntensity();

        // Change skybox based on time of day
        BlendSkyboxes();

        // Change ambient lighting based on the time of day
        RenderSettings.ambientLight = skyColor.Evaluate(timeOfDay / 24f);

        // Change fog color based on the time of day
        UpdateFogColor();
    }

    // Update the sun and moon rotations based on time of day
    private void UpdateSunAndMoonRotation()
    {
        float sunAngle = (timeOfDay / 24f) * 360f - 90f; // Rotate the sun (0-24 hour range)
        sunLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle, -30f, 0f));
    }

    // Adjust the intensities of sun and moon based on time of day
    private void AdjustSunAndMoonIntensity()
    {
        sunLight.intensity = sunIntensityCurve.Evaluate(timeOfDay / 24f); // Adjust sun intensity
    }

    // Blend between day and night skyboxes smoothly
    private void BlendSkyboxes()
    {
        float blendFactor = Mathf.Clamp01((timeOfDay - 6f) / 12f); // Blend between 6am and 6pm

        // If using a procedural skybox, adjust the exposure for day/night cycle
        if (RenderSettings.skybox.HasProperty("_CubemapTransition"))
        {
            float normalizedTime = timeOfDay / 24f; // Normalize timeOfDay to range from 0 to 1
            float transitionValue = exposureCurve.Evaluate(normalizedTime); // Get the exposure value from the curve

            RenderSettings.skybox.SetFloat("_CubemapTransition", transitionValue);
        } 
        else
        {
            Debug.LogError("Property not found!");
        }
    }

    // Update the fog color based on the time of day
    private void UpdateFogColor()
    {
        // Get the color from the fog gradient based on the time of day
        Color currentFogColor = fogColor.Evaluate(timeOfDay / 24f);
        RenderSettings.fogColor = currentFogColor;
    }
}