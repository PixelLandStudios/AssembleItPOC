using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    GameObject AssociatedPart;

    public bool IsScrewed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screw"))
        {
            IsScrewed = true;
            this.GetComponent<MeshRenderer>().enabled = false;

            //remove the current part that is being held
            //other.transform.parent.gameObject.SetActive(false);
            Destroy(other.transform.parent.gameObject);

            AssociatedPart.SetActive(true);
        }
    }
}
