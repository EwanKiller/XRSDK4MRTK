using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.XRSDK.Input;
using UnityEngine;
using UnityEngine.XR;

namespace Microsoft.MixedReality.Toolkit.XRSDK.InputProvider
{
    [MixedRealityDataProvider(
        typeof(IMixedRealityInputSystem),
        SupportedPlatforms.Android,
        "XR SDK Input Provider Device Manager",
        supportedUnityXRPipelines: SupportedUnityXRPipelines.XRSDK)]
    public class InputProviderDeviceManager : XRSDKDeviceManager
    {
        public InputProviderDeviceManager(
            IMixedRealityInputSystem inputSystem,
            string name = null,
            uint priority = DefaultPriority,
            BaseMixedRealityProfile profile = null) : base(inputSystem, name, priority, profile){ }

        public override bool CheckCapability(MixedRealityCapability capability)
        {
            return capability == MixedRealityCapability.MotionController;
        }

        protected override GenericXRSDKController GetOrAddController(InputDevice inputDevice)
        {
            GenericXRSDKController controller = base.GetOrAddController(inputDevice);
            if (controller is InputProviderController inputProviderController)
            {
                inputProviderController.UseMRTKControllerVisualization = true;
            }

            return controller;
        }

        protected override Type GetControllerType(SupportedControllerType supportedControllerType)
        {
            if (supportedControllerType == SupportedControllerType.WindowsMixedReality)
            {
                return typeof(InputProviderController);
            }
            else
            {
                return base.GetControllerType(supportedControllerType);
            }
        }

        protected override InputSourceType GetInputSourceType(SupportedControllerType supportedControllerType)
        {
            if (supportedControllerType == SupportedControllerType.WindowsMixedReality)
            {
                return InputSourceType.Controller;
            }
            else
            {
                return base.GetInputSourceType(supportedControllerType);
            }
        }

        protected override SupportedControllerType GetCurrentControllerType(InputDevice inputDevice)
        {
            if (inputDevice.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
            {
                return SupportedControllerType.WindowsMixedReality;
            }
            else
            {
                return base.GetCurrentControllerType(inputDevice);
            }
        }

        public override void Enable()
        {
            IsEnabled = true;
            base.Enable();
        }
        
    }
}
