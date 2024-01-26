using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnscrewedPartScript : BasePart
{
    [SerializeField]
    GameObject AssembledPart;

    [SerializeField]
    GameObject BasePart;

    [SerializeField]
    float targetValuey = -65f;

    [SerializeField]
    bool IsChairLeg;

    [SerializeField]
    AudioSource tighteningSFX;

    float partEulerX = 0f;

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

        tighteningSFX.Stop();
        tighteningSFX.Play();

        if (angle > 30)
        {
            ConfigurableJoint configurableJoint = this.GetComponent<ConfigurableJoint>();
            float yValue = 0;

            if (IsChairLeg)
                yValue = configurableJoint.connectedAnchor.y + 10f;
            else
                yValue = configurableJoint.connectedAnchor.y - 10f;

            configurableJoint.connectedAnchor = new Vector3(configurableJoint.connectedAnchor.x, yValue, configurableJoint.connectedAnchor.z);

            //this mean that the part is assembled correctly
            if (CompareWithTargetValue(yValue))
            {
                AssembledPart.SetActive(true);
                BasePart.GetComponent<XRGrabInteractable>().colliders.Add(AssembledPart.GetComponent<Collider>());

                BasePart.GetComponent<XRGrabInteractable>().interactionManager.UnregisterInteractable(BasePart.GetComponent<XRGrabInteractable>() as IXRInteractable);
                BasePart.GetComponent<XRGrabInteractable>().interactionManager.RegisterInteractable(BasePart.GetComponent<XRGrabInteractable>() as IXRInteractable);

                //check if this assembled part has "PartName" then it means it's fully assembled, and I need to update game progress
                if (!string.IsNullOrWhiteSpace(PartName))
                {
                    LevelProgressionSystem.Instance.UpdateProgress(PartName);
                }

                Destroy(this.transform.gameObject);
            }
        }
    }

    bool CompareWithTargetValue(float yValue)
    {
        if (IsChairLeg)
        {
            if (yValue >= targetValuey)
                return true;
            else
                return false;
        }
        else
        {
            if (yValue <= targetValuey)
                return true;
            else
                return false;
        }
    }
}
