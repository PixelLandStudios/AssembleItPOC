using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewHeadScript : BasePart
{
    [SerializeField]
    Transform RaycastBase;

    float screwedCorrectlyMargin = 0.02f;

    float rotationSpeed = 500;

    bool isBeingScrewed = false;

    bool isScrewedCorrectly = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (isScrewedCorrectly)
            return;

        if (isBeingScrewed)
        {
            transform.parent.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

            transform.parent.Translate(Vector3.back * 0.02f * Time.deltaTime);

            float distance = Vector3.Distance(this.transform.position, RaycastBase.position);

            ShowDebugText(distance.ToString());

            if (distance <= screwedCorrectlyMargin)
            {
                isScrewedCorrectly = true;
                //call progression system
                if (!string.IsNullOrWhiteSpace(PartName))
                {
                    LevelProgressionSystem.Instance.UpdateProgress(PartName);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScrewdriverHead"))
        {
            if (other.transform.parent.GetComponent<ScrewdriverScript>().IsScrewing)
                isBeingScrewed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ScrewdriverHead"))
        {
            isBeingScrewed = false;
        }
    }

    void ShowDebugText(string text)
    {
        GameObject.Find("DebugLogText").GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }
}
