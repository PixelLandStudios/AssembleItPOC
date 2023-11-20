using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    GameObject AssociatedPart;

    [SerializeField]
    string ComparedTag;

    public bool IsScrewed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ComparedTag))
        {
            IsScrewed = true;
            this.GetComponent<MeshRenderer>().enabled = false;

            //remove the current part that is being held
            Destroy(other.transform.root.gameObject);

            AssociatedPart.SetActive(true);
        }
    }
}
