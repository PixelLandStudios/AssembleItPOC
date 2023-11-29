using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerInputScript : MonoBehaviour
{
    [SerializeField]
    GameObject UnassembledChairLeg1;

    List<UnityEngine.XR.InputDevice> rightHandedControllers;
    UnityEngine.XR.InputDeviceCharacteristics desiredCharacteristics;

    // Start is called before the first frame update
    void Start()
    {
        rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
        desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, rightHandedControllers);
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHandedControllers == null || rightHandedControllers.Count == 0)
        {
            UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, rightHandedControllers);
        }
        else
        {
            if (rightHandedControllers.Count == 1)
            {
                bool triggerValue;
                if (rightHandedControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out triggerValue) && triggerValue)
                {
                    //SceneManager.LoadScene("SampleScene");
                    Debug.Log("AAAAAAAAAAAAAAAAA");
                    UnassembledChairLeg1.SetActive(true);
                }
            }
        }
    }
}