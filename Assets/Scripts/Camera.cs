using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;
    public Player player;

    [Header("Noise Profiles")]
    public NoiseSettings originalNoise;
    public NoiseSettings shakeNoise;
    public NoiseSettings widangle;

    private CinemachineBasicMultiChannelPerlin noiseComponent;

    void Awake()
    {
        player = GetComponent<Player>();
        // Grab the Perlin noise component from the Cinemachine camera
        noiseComponent = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();


        noiseComponent.NoiseProfile = originalNoise;
    }

    private void Update()
    {
        if (noiseComponent != null) {
            Debug.Log(noiseComponent.NoiseProfile);
        }
    }


    public void Shaking()
    {
        noiseComponent.NoiseProfile = shakeNoise;
        StartCoroutine(StopShaking(0.5f));
    }

    public void Widangle()
    {
        if (noiseComponent.NoiseProfile == null && noiseComponent.NoiseProfile != shakeNoise)
        {
            noiseComponent.NoiseProfile = widangle;
        }
    }

    public void Original()
    {
        if (noiseComponent.NoiseProfile != null && noiseComponent.NoiseProfile != shakeNoise)
        {
            noiseComponent.NoiseProfile = originalNoise;
        }
    }

    IEnumerator StopShaking(float time)
    {
        yield return new WaitForSeconds(time);
        noiseComponent.NoiseProfile = originalNoise;
    }
}
