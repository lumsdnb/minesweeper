using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    public GameObject leftHand, rightHand;
    private IMixedRealityInputSystem inputSystem = null;
    protected IMixedRealityInputSystem InputSystem
    {
        get
        {
            if(inputSystem == null)
            {
                MixedRealityServiceRegistry.TryGetService<IMixedRealityInputSystem>(out inputSystem);
            }
            return inputSystem;
        }
    }

    void Update()
    {
        foreach(IMixedRealityController controller in InputSystem.DetectedControllers)
        {
            if(controller.ControllerHandedness.IsRight())
            {
                rightHand.transform.position = controller.InputSource.Pointers[0].Position;
                rightHand.transform.rotation = controller.InputSource.Pointers[0].Rotation;                
            }
            if (controller.ControllerHandedness.IsLeft())
            {
                leftHand.transform.position = controller.InputSource.Pointers[0].Position;
                leftHand.transform.rotation = controller.InputSource.Pointers[0].Rotation;
            }
        }
    }
}
