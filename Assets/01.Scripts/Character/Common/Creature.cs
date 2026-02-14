using System.Collections;
using UnityEngine;

public class Creature : MonoBehaviour
{
    protected HP _hp;

    [SerializeField] protected  int normalDamage;
    
    protected virtual void Awake()
    {
        _hp = GetComponent<HP>();
    }

    // Update is called once per frame
    
}
