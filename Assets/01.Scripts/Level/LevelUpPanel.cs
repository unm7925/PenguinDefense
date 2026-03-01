using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel:MonoBehaviour
{
    [SerializeField] private WeaponContainer weaponContainer;
    [SerializeField] private AllWeaponData allWeaponData;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button[] slots;
    [SerializeField] private TextMeshProUGUI[] slotsName;
    [SerializeField] private TextMeshProUGUI[] slots_descriptions;
    
    List<CardOption> pool = new List<CardOption>();
        
        public void Show()
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            
            GetRandomWeapons();

            SetSlots();

        }

        private void SetSlots()
        {
            for (int i = 0; i < Mathf.Min(pool.Count, slots.Length); i++) {
                int index = i;
                slots[i].onClick.RemoveAllListeners();
                slots[i].onClick.AddListener(() => OnSelectWeapon(index));
                slotsName[i].text = pool[i].name;
                slots_descriptions[i].text = pool[i].description;
            }
        }
        private void OnSelectWeapon(int _index)
        {
            pool[_index].onSelect?.Invoke();
            Hide();
        }
        private void GetRandomWeapons()
        {
            foreach (var weaponData in allWeaponData.allWeapons) 
            {
                if (!weaponContainer.HasWeapon(weaponData)) 
                {
                    pool.Add(new CardOption
                    {
                        name = weaponData.waeponName,
                        description = "무기 획득",
                        onSelect = () => weaponContainer.AddWeapon(weaponData)
                    });
                }
            }

            foreach (var instance in weaponContainer.GetUpgradeableWeapons())
            {
                pool.Add(new CardOption
                {
                    name = instance.GetWeaponData().waeponName,
                    description = instance.GetNextUpgrade().description,
                    onSelect = () => weaponContainer.UpgradeWeapon(instance.GetWeaponData())
                });
            }
            
            
            for (int i = pool.Count - 1; i >= 0; i--) 
            {
                int j = Random.Range(0, i+1);
                (pool[i], pool[j]) = (pool[j], pool[i]);
            }
        }

        private void Hide()
        {
            Time.timeScale = 1f;
            pool.Clear();
            panel.SetActive(false);
        }

}
