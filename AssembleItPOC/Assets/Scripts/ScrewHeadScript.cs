using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewHeadScript : MonoBehaviour
{
    [SerializeField]
    Transform RaycastBase;

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
            transform.parent.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            transform.parent.Translate(Vector3.down * 0.02f * Time.deltaTime);

            // Get the direction between the two objects
            Vector3 direction = RaycastBase.position - this.transform.position;

            RaycastHit hitInfo;
            // Cast a ray from object1 to object2
            if (Physics.Raycast(this.transform.position, direction, out hitInfo, Mathf.Infinity))
            {
                // Check if the ray hits object2
                if (hitInfo.transform == RaycastBase)
                {
                    // Calculate the distance between object1 and object2
                    float distance = Vector3.Distance(this.transform.position, RaycastBase.position);
                    Debug.Log("Distance between object1 and object2: " + distance);

                    if (distance < 0.16035)
                    {
                        //replace with visuals only that is screwed
                        isScrewedCorrectly = true;
                    }
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
}
