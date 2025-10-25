using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : PlayerController
{
    [Header("Cat Super Power")] [SerializeField]
    private float superForce;
    
    // TODO: Bura değişebilir. Şimdilik daha güçlü bir zıplama var
    public override void UseSuperPower()
    { 
        rb.AddForce(Vector2.up*superForce);
    }
}
