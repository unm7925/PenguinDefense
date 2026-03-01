using System;
using System.Collections.Generic;
using UnityEngine;
public class WeaponInstance
{
        private BaseWeaponData data;
        private float cooldownTimer;
        
        private int count;
        private float speed;
        private float spreadAngle;
        private float cooldown;
        private int damage;
        private float lifetime;

        private int bounceCount;
        private int pierceCount;
        private int aoeRadius;
        
        public int BounceCount => bounceCount;
        public int PierceCount => pierceCount;
        public int AOERadius => aoeRadius;
        public int Damage => damage;
        public float Speed => speed;
        
        Dictionary<UpgradeType, Action<float>> upgradeActions;
        
        private int level;
        int maxLevel = 6;
        // hard
        private string targetTag = "Enemy";

        public WeaponInstance(BaseWeaponData _data)
        {
                data = _data;
                cooldownTimer = 0;
                level = 0;

                damage = _data.damage;
                count = _data.projectile.count;
                speed = _data.projectile.speed;
                spreadAngle = _data.projectile.spreadAngle;
                lifetime = _data.projectile.lifetime;
                cooldown = _data.baseCooldown;

                if(_data.bounce !=null) 
                {
                        bounceCount = _data.bounce.bounceCount;
                }
                if(_data.pierce !=null) 
                {
                        pierceCount = _data.pierce.pierceCount;
                }
                if(_data.aoe !=null) 
                {
                        aoeRadius = _data.aoe.radius;
                }

                upgradeActions = new Dictionary<UpgradeType, Action<float>>
                {
                        { UpgradeType.Damage, v => damage += (int)v },
                        { UpgradeType.Cooldown, v => cooldown -= v },
                        { UpgradeType.ProjectileSpeed, v => speed += v },
                        { UpgradeType.ProjectileCount, v => count += (int)v },
                        { UpgradeType.PierceCount, v => pierceCount += (int)v },
                        { UpgradeType.BounceCount, v => bounceCount += (int)v },
                        { UpgradeType.AoERadius, v => aoeRadius += (int)v },
                };
        }

        public void Tick(float _deltaTime,Transform _playerTransform, TargetSystem _targetSystem)
        {
                cooldownTimer += _deltaTime;
                if (cooldownTimer >= cooldown) 
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
                        projectile.Init(damage, lifetime,targetTag);
                }
                
                Rigidbody2D rb2 = weapon.GetComponent<Rigidbody2D>();
                if (rb2 != null) 
                {
                        rb2.linearVelocity = direction.normalized * speed;        
                }

                foreach (var setup in weapon.GetComponents<IWeaponSetup>()) 
                {
                        setup.Init(this);
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
        

        public bool IsMaxLevel()
        {
                
                if (level >= data.upgradeOptions.Count) 
                {
                        return true;
                }
                return false;
        }
        public BaseWeaponData GetWeaponData()
        {
                return data;
        }

        public void ApplyUpgrade()
        {
                if (upgradeActions.TryGetValue(data.upgradeOptions[level].type, out var action)) 
                {
                        action(data.upgradeOptions[level].value);
                }
        }

        public UpgradeOption GetNextUpgrade()
        {
                return data.upgradeOptions[level];
        }
        
}
