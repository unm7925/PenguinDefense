using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TargetSystem targetSystem;
    public TargetSystem TargetSystem => targetSystem;

    public static GameManager Instance;
    private void Awake() 
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Application.targetFrameRate = 120;

    }
}