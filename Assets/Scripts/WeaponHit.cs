using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
