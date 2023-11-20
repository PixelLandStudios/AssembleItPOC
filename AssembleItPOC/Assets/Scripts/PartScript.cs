using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> CompatibleJoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnGrab()
    {
        foreach (var item in CompatibleJoints)
        {
            if (item.GetComponent<SlotScript>().IsScrewed == false)
            {
                item.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

    public void OnRelease()
    {
        foreach (var item in CompatibleJoints)
        {
            if (item.GetComponent<SlotScript>().IsScrewed == false)
            {
                item.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}