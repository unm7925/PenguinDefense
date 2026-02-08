using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected HP _hp;

    [SerializeField] protected  int normalDamage;
    
    protected void Awake()
    {
        _hp = GetComponent<HP>();
    }

    // Update is called once per frame
    
}
