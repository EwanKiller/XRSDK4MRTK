using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.XRSDK.Input;
using Microsoft.MixedReality.Toolkit.XRSDK.WindowsMixedReality;
using UnityEngine;
using UnityEngine.XR;

namespace Microsoft.MixedReality.Toolkit.XRSDK.InputProvider
{
    [MixedRealityController(
        SupportedControllerType.WindowsMixedReality,
        new[] { Handedness.Left, Handedness.Right })]
    public class InputProviderController : GenericXRSDKController
    {
        public InputProviderController(
            TrackingState trackingState,
            Handedness controllerHandedness,
            IMixedRealityInputSource inputSource = null,
            MixedRealityInteractionMapping[] interactions = null):
            base(trackingState, controllerHandedness, inputSource, interactions, new InputProviderControllerDefinition(controllerHandedness))
        {}
        
        internal bool UseMRTKControllerVisualization
        {
            get
            {
                return Visualizer != null && Visualizer.GameObjectProxy != null && Visualizer.GameObjectProxy.activeSelf;
            }
            set
            {
                if(Visualizer != null && Visualizer.GameObjectProxy)
                {
                    Visualizer.GameObjectProxy.SetActive(value);
                }
            }
        }
    }
}
