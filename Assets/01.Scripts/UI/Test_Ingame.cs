using UnityEngine;

public class Test_Ingame : MonoBehaviour
{
    [SerializeField] private GameObject StagesPanel;
    public void OnClick()
    {
           StagesPanel.SetActive(!StagesPanel.activeSelf);
    }
}
