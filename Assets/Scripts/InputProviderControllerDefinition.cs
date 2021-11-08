using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class InputProviderControllerDefinition : BaseInputSourceDefinition
{
    public InputProviderControllerDefinition(Handedness handedness) : base(handedness)
    {
        if (handedness != Handedness.Left && handedness != Handedness.Right)
        {
            throw new System.ArgumentException($"Unsupported Handedness ({handedness}). The InputProviderControllerDefinition supports Left and Right.");
        }
    }

    protected override MixedRealityInputActionMapping[] DefaultMappings => new[]
    {
        new MixedRealityInputActionMapping("Spatial Pointer", AxisType.SixDof, DeviceInputType.SpatialPointer)
    };
}
