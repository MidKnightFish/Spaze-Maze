using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerSinus : MonoBehaviour
{

    public float rotationLength = 3;
    [Range(0.0f, 1.0f)]
    public float shift;

    float glow;
    Light myPointLight;
    [Header("Light")]
    public float lightRangeMax = 2f;
    public float lightRangeMin = 0.4f;
    public float lightIntensityMax = 0.5f;
    public float lightIntensityMin = 0.1f;

    [Header("Emission")]
    public float emissionMin = 0;
    public float emissionMax = 1;
    float emission;

    float strength;
    Material mat;
    Color baseColor;

    // Use this for initialization
    void Start()
    {
        strength = shift * rotationLength;
        myPointLight = GetComponentInChildren<Light>();
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (renderers != null)
        {
            foreach (Renderer randy in renderers) {
                foreach (Material matty in randy.materials) {
                    if (matty.name == "GlowOrange"|| matty.name == "GlowOrange (Instance)"
                        || matty.name == "GlowRed" || matty.name == "GlowRed (Instance)") {
                        mat = matty;
                        baseColor = mat.GetColor("_EmissionColor");
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        strength += Time.deltaTime;
        if (strength > rotationLength) strength = 0;
        glow = (Mathf.Sin(strength/rotationLength *2*Mathf.PI)+1)/2;
        if (myPointLight != null)
        {
            myPointLight.intensity = lightIntensityMin + glow * (lightIntensityMax - lightIntensityMin);
            myPointLight.range = lightRangeMin + glow * (lightRangeMax - lightRangeMin);
        }
        if (mat != null) {
            emission = emissionMin + glow * (emissionMax - emissionMin);
            mat.SetColor("_EmissionColor", baseColor * Mathf.LinearToGammaSpace(emission));
        }
    }
}
