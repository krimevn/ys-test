using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVehicle : MonoBehaviour //this use for both player and enemies
{
    public Body body;

    public Wheel FrontWheel;
    
    public Wheel BackWheel;

    public List<Weapon> weaponList;
    public List<StickerData> stickerList;

    public bool IsDestroyed = false;

    public void Attack()
    { 
    
    }

    public void TakeDamage(float amount)
    { 
        
    }
}
