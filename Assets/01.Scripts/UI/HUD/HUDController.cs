using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Slider wallHPSlider;
    [SerializeField] private TextMeshProUGUI StageText;
    [SerializeField] private TextMeshProUGUI WaveText;
    [SerializeField] private Slider expSlider;

    [SerializeField] private HP wall;
    [SerializeField] private EXPSystem exp;
    [SerializeField] private StageManager stageManager;

    private void Start()
    {
        StageText.SetText((GameManager.Instance.CurrentStageIndex + 1).ToString());
    }
    public void OnEnable()
    {
        wall.OnHPChanged += WallHpSliderChangeValue;
        exp.OnEXPChanged += EXPSliderChangeValue;
        stageManager.OnStageChanged += WaveChangeValue;
    }
    private void WaveChangeValue(int _currentStage)
    {
        WaveText.SetText(_currentStage.ToString());
    }

    private void OnDisable()
    {
        wall.OnHPChanged -= WallHpSliderChangeValue;
        exp.OnEXPChanged -= EXPSliderChangeValue;
        stageManager.OnStageChanged -= WaveChangeValue;
    }
    
    private void WallHpSliderChangeValue(int _currentHP, int _maxHP)
    {
        wallHPSlider.value = Mathf.InverseLerp(0, _maxHP, _currentHP);
    }
    private void EXPSliderChangeValue(float _currentEXP, float _requirEXP)
    {
        expSlider.value = Mathf.InverseLerp(0, _requirEXP, _currentEXP);
    }
    

}
