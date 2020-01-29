using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class ToolSwitchHandler : MonoBehaviour
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
            controller.Visualizer.GameObjectProxy.GetComponent<ToolSwitchReceiver>().pickTool(1);
        }
    }
}
