using System;
using UnityEngine;
public class Level : MonoBehaviour
{
    [SerializeField] private Material skyboxMaterial;
    [SerializeField] private Material baseSkyMaterial;

    private void Awake()
    {
        InitSkyboxMaterial();
    }
    void InitSkyboxMaterial()
    {
        skyboxMaterial = skyboxMaterial == null ? baseSkyMaterial : skyboxMaterial;
        RenderSettings.skybox = skyboxMaterial;
    }
}
