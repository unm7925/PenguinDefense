using System.Collections;
using UnityEngine;

public class Creature : MonoBehaviour
{
    protected HP _hp;
    
    protected virtual void Awake()
    {
        _hp = GetComponent<HP>();
    }
    
}
