using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnscrewedPartScript : MonoBehaviour
{
    [SerializeField]
    GameObject AssembledPart;

    [SerializeField]
    GameObject BasePart;

    float partEulerX = 0f;

    float targetValuey = -65f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnGrab()
    {
        partEulerX = this.transform.localEulerAngles.x;
    }

    public void OnRelease()
    {
        float releasedEulerX = this.transform.localEulerAngles.x;

        if ((partEulerX < 100 && releasedEulerX > 250) || (partEulerX < 20 && releasedEulerX > 200)) // it means it made a full rotation
        {
            partEulerX += 360;
        }

        float angle = partEulerX - releasedEulerX;

        Debug.Log(angle);

        if (angle > 50)
        {
            ConfigurableJoint configurableJoint = this.GetComponent<ConfigurableJoint>();
            float yValue = configurableJoint.connectedAnchor.y + 10f;

            configurableJoint.connectedAnchor = new Vector3(configurableJoint.connectedAnchor.x, yValue, configurableJoint.connectedAnchor.z);

            //this mean that the part is assembled correctly
            if (yValue >= targetValuey)
            {
                AssembledPart.SetActive(true);
                //BasePart.GetComponent<XRGrabInteractable>().colliders.Add(AssembledPart.GetComponent<Collider>());
                //StartCoroutine(ReregisterInteractable(BasePart.GetComponent<XRGrabInteractable>()));

                //BasePart.GetComponent<XRGrabInteractable>().interactionManager.UnregisterInteractable(BasePart.GetComponent<XRGrabInteractable>() as IXRInteractable);
                //BasePart.GetComponent<XRGrabInteractable>().interactionManager.RegisterInteractable(BasePart.GetComponent<XRGrabInteractable>() as IXRInteractable);

                Destroy(this.transform.gameObject);
            }
        }
    }

    //private IEnumerator ReregisterInteractable(XRGrabInteractable interactable)
    //{
    //    Debug.Log("AAAAAAAAAAAAAAAAA");

    //    yield return new WaitForSeconds(0.1f);
    //    interactable.interactionManager.UnregisterInteractable(interactable as IXRInteractable);

    //    yield return new WaitForSeconds(0.1f);
    //    interactable.interactionManager.RegisterInteractable(interactable as IXRInteractable);

    //    Debug.Log("BBBBBBBBBBBBBB");

    //    yield return null;
    //}
}
