
    using System;
    using UnityEngine;
    public class Projectile:MonoBehaviour
    {
        
        private int damage;
        private string targetTag;
        private IWeaponSetup[] modules;
        
        public event Action OnHit;
        
        public void Init(int _damage, float _lifetime, string _tag)
        {
            
            damage = _damage;
            targetTag = _tag;
            Destroy(gameObject, _lifetime);
        }

        private void Start()
        {
            modules = GetComponents<IWeaponSetup>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(targetTag)) 
            {
                HP hp = other.GetComponent<HP>();
                
                if (hp != null) 
                {
                    hp.TakeDamage(damage);

                    if (modules.Length > 0) 
                    {
                        OnHit?.Invoke();                        
                    }
                    else 
                    {
                        Destroy(gameObject);    
                    }
                    
                }
            }
        }
    }

