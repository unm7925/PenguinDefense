using UnityEngine;
public class WeaponInstance
{
        public BaseWeaponData data;
        private float cooldownTimer;
        private int level;
        int maxLevel = 6;

        public WeaponInstance(BaseWeaponData _data)
        {
                data = _data;
                cooldownTimer = 0;
                level = 1;
        }

        public void Tick(float _deltaTime,Transform _playerTransform, TargetSystem _targetSystem)
        {
                cooldownTimer += _deltaTime;
                if (cooldownTimer >= data.baseCooldown) 
                {
                        Attack(_playerTransform, _targetSystem);
                        cooldownTimer = 0;
                }
        }
        private void Attack(Transform _playerTransform, TargetSystem _targetSystem)
        {
                Vector2 pos = _playerTransform.position;
                Enemy target = _targetSystem.GetClosesTarget(pos);
                if (target == null) return;

                Vector2 targetPos = target.transform.position;
                Vector2 direction = ( targetPos - pos).normalized;
                
                if (data.weaponPrefab != null) 
                {
                        GameObject projectilePrefab = GameObject.Instantiate(data.weaponPrefab);
                        
                        Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();

                        if (rb != null) 
                        {
                                rb.linearVelocity = direction * data.projectile.speed;
                        }
                }
        }

        public void LevelUp()
        {
                if (IsMaxLevel()) return;
                level++;
                // 스탯 아직 생각한 테이블 없음.
                cooldownTimer = 0;
        }

        private bool IsMaxLevel()
        {
                
                if (level >= maxLevel) 
                {
                        return true;
                }
                return false;
        }
}
