using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HVLPScript : MonoBehaviour
{
    [SerializeField]
    ParticleSystem paintingParticleSystem;

    [SerializeField]
    P3dHitBetween p3DHitBetween;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressStart()
    {
        paintingParticleSystem.Play();
        p3DHitBetween.enabled = true;
    }

    public void OnPressEnd()
    {
        paintingParticleSystem.Stop();
        p3DHitBetween.enabled = false;
    }
}
