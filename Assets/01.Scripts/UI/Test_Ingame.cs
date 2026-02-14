using UnityEngine;

public class Test_Ingame : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject StagesPanel;
    public void OnClick()
    {
           StagesPanel.SetActive(!StagesPanel.activeSelf);
    }
}
