using UnityEngine;

public class PlayerAttack:MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private float speed = 5;
    private float cooldown = 3;
    private float timer = 0f;
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer < cooldown) return;
        
        
        Enemy target = GameManager.Instance.TargetSystem.GetClosesTarget(transform.position);
        if (target == null) return;
        Throw(target.transform.position);
    }

    private void Throw(Vector2 direction)
    {
        GameObject throwWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        throwWeapon.GetComponent<Rigidbody2D>().linearVelocity = direction * speed * Time.fixedDeltaTime;
        timer = 0;
    }
}
