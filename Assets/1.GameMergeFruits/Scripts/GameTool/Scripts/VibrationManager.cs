using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : SingletonMonoBehaviour<VibrationManager>
{
    public void VibrateSelection()
    {
        Vibrate(HapticPatterns.PresetType.Selection);
    }
    public void VibrateSuccess()
    {
        Vibrate(HapticPatterns.PresetType.Success);
    }
    public void VibrateWarning()
    {
        Vibrate(HapticPatterns.PresetType.Warning);
	}
    public void VibrateFailure()
    {
        Vibrate(HapticPatterns.PresetType.Failure);
	}
    public void VibrateLight()
    {
        Vibrate(HapticPatterns.PresetType.LightImpact);
    }
    public void VibrateMedium()
    {
        Vibrate(HapticPatterns.PresetType.MediumImpact);
    }
    public void VibrateHeaving()
    {
        Vibrate(HapticPatterns.PresetType.HeavyImpact);
    }
    public void VibrateRigid()
    {
        Vibrate(HapticPatterns.PresetType.RigidImpact);
    }
    public void VibrateSoft()
    {
        Vibrate(HapticPatterns.PresetType.SoftImpact);
    }

    public void Vibrate(HapticPatterns.PresetType type)
    {
        //if (GameData.I.Vibrate)
        //if (GameData.Vibration)
        //{
            
        //}
        HapticPatterns.PlayPreset(type);
    }


}
