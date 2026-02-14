
    using UnityEngine;
    public class Projectile:MonoBehaviour
    {
        
        private int damage;
        
        public void Init(int _damage, float _lifetime)
        {
            
            damage = _damage;
            Destroy(gameObject, _lifetime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy")) 
            {
                HP hp = collision.GetComponent<HP>();
                if (hp != null) 
                {
                    hp.TakeDamage(damage);   
                    Destroy(gameObject);
                }
            }
        }
    }

