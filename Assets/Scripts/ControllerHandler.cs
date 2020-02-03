using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
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
                transform.position = controller.InputSource.Pointers[0].Position;
                transform.rotation = controller.InputSource.Pointers[0].Rotation;                
            Debug.Log(controller.InputSource.Pointers[0].Position);
            }
        }
    }
}
