
    using UnityEngine;
    public class Projectile:MonoBehaviour
    {
        
        private int damage;
        private string targetTag;
        
        public void Init(int _damage, float _lifetime, string _tag)
        {
            
            damage = _damage;
            targetTag = _tag;
            Destroy(gameObject, _lifetime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(targetTag)) 
            {
                HP hp = collision.GetComponent<HP>();
                if (hp != null) 
                {
                    hp.TakeDamage(damage);
                    Debug.Log(targetTag + damage);
                    Destroy(gameObject);
                }
            }
        }
    }

