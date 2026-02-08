using UnityEngine;

public class NaturalRecovery : MonoBehaviour
{
    private HP _hp;
    private MP _mp;
    
    [SerializeField] private int nrHp; // nr == NaturalRecovery
    [SerializeField] private int nrMp;

    private float timer = 0;
    [SerializeField]private float interval = 5f;
    
    private void Start()
    {
        _hp  = GetComponent<HP>();
        _mp = GetComponent<MP>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < interval)
        {
            return;
        }
        
        if(nrHp > 0) _hp.Recover(nrHp);
        if (nrMp > 0) _mp.Recover(nrMp);
        
        timer = 0;
    }
}
