using UnityEngine;
public class WeaponInstance
{
        private BaseWeaponData data;
        private float cooldownTimer;
        private int level;
        private int count;
        int maxLevel = 6;
        private float speed;
        private float spreadAngle;
        
        // hard
        private string targetTag = "Enemy";

        public WeaponInstance(BaseWeaponData _data)
        {
                data = _data;
                cooldownTimer = 0;
                level = 1;
                count = _data.projectile.count;
                speed = _data.projectile.speed;
                spreadAngle = _data.projectile.spreadAngle;
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
                
                Vector2 baseDirection = GetDirection(_playerTransform, target);
                float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg;
                float angleOffset;
                float angleStep;

                for (int i = 0; i < count; i++) 
                {
                        if (count == 1)
                        {
                                angleOffset = 0;
                        }
                        else
                        {
                                angleStep = spreadAngle / (count - 1);
                                angleOffset = -spreadAngle/2 + (angleStep * i);
                        }
                        float finalAngle = baseAngle + angleOffset;
                
                        Vector2 direction = new Vector2(Mathf.Cos(finalAngle*Mathf.Deg2Rad), Mathf.Sin(finalAngle*Mathf.Deg2Rad));
                
                        if (data.weaponPrefab != null) 
                        {
                                GameObject weapon = SpawnProjectile(pos);

                                SetupWeapon(weapon, direction);
                        }
                }
        }
        private void SetupWeapon(GameObject weapon, Vector2 direction)
        {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg- 90f;
                weapon.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                
                Projectile projectile = weapon.GetComponent<Projectile>();
                if (projectile != null)
                { 
                        projectile.Init(data.damage, data.projectile.lifetime,targetTag);
                }
                
                Rigidbody2D rb2 = weapon.GetComponent<Rigidbody2D>();
                if (rb2 != null) 
                {
                        rb2.linearVelocity = direction.normalized * speed;        
                }

                foreach (var setup in weapon.GetComponents<IWeaponSetup>()) 
                {
                        setup.Init(data);
                }
        }
        private GameObject SpawnProjectile(Vector2 _pos)
        {
                return GameObject.Instantiate(data.weaponPrefab, _pos, Quaternion.identity);
        }
        private Vector2 GetDirection(Transform playerTransform, Enemy target)
        {
                return target.transform.position - playerTransform.position;
        }

        public void LevelUp()
        {
                if (IsMaxLevel()) return;
                level++;
                count++;
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
        public BaseWeaponData GetWeaponData()
        {
                return data;
        }
}
