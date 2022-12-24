using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimationController : MonoBehaviour
{
    public InputDeviceCharacteristics controllerType;
    public InputDevice inputDevice;

    private Animator animator;
    private bool isControllerFound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Initialize();
    }

    void Initialize()
    {
        List<InputDevice> inputDevices = new();
        InputDevices.GetDevicesWithCharacteristics(controllerType, inputDevices);

        if (inputDevices.Count > 0)
        {
            inputDevice = inputDevices[0];
            isControllerFound = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isControllerFound)
            Initialize();
        else
        {
            if(inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                animator.SetFloat("Trigger", triggerValue);
            }

            if (inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                animator.SetFloat("Grip", gripValue);
            }
        }
    }
}