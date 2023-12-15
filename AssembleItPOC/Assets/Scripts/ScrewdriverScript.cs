using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverScript : MonoBehaviour
{
    [SerializeField]
    Transform HeadTransform;

    [SerializeField]
    AudioSource screwdriverSFX;

    float rotationSpeed = 500;

    public bool IsScrewing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (IsScrewing)
            HeadTransform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public void OnButtonPressStart()
    {
        screwdriverSFX.Play();
        IsScrewing = true;
    }

    public void OnButtonPressEnd()
    {
        screwdriverSFX.Stop();
        IsScrewing = false;
    }
}
