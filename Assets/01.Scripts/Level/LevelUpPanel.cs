using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel:MonoBehaviour
{
    [SerializeField] private WeaponContainer weaponContainer;
    [SerializeField] private AllWeaponData allWeaponData;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button slot1, slot2;
    [SerializeField] private TextMeshProUGUI slot1Txt , slot2Txt;

    private BaseWeaponData[] selectedWeapons = new BaseWeaponData[2];
        
        public void Show()
        {
            Time.timeScale = 0f;
                panel.SetActive(true);
                GetRandomWeapons();
                slot1Txt.text = selectedWeapons[0].name;
                slot2Txt.text = selectedWeapons[1].name;
                
                slot1.onClick.RemoveAllListeners();
                slot2.onClick.RemoveAllListeners();
                slot1.onClick.AddListener(() => OnSelectWeapon(0));
                slot2.onClick.AddListener(()=> OnSelectWeapon(1));
        }
        private void OnSelectWeapon(int _index)
        {
            weaponContainer.AddWeapon(selectedWeapons[_index]);
            Hide();
        }
        private void GetRandomWeapons()
        {
            List<BaseWeaponData> temp = new List<BaseWeaponData>(allWeaponData.allWeapons);

            for (int i = temp.Count - 1; i >= 0; i--) 
            {
                int j = Random.Range(0, i+1);
                (temp[i], temp[j]) = (temp[j], temp[i]);
            }
            
            selectedWeapons[0] = temp[0];
            selectedWeapons[1] = temp[1];
        }

        private void Hide()
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
        }
    
}
