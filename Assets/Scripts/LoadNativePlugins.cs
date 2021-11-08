using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR;

public class LoadNativePlugins : MonoBehaviour
{
    [DllImport("InputProviderSample")]
    private static extern int loadLib();

    private string match = "input0";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(loadLib());

        List<XRInputSubsystemDescriptor> inputs = new List<XRInputSubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(inputs);
        foreach (var input in inputs)
        {
            if (input.id.Contains(match))
            {
                XRInputSubsystem inputInst = input.Create();
                if (inputInst != null)
                {
                    inputInst.Start();
                }
            }
        }
    }

}