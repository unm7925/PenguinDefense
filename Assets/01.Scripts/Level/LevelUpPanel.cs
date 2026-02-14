using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanel:MonoBehaviour
{
        [SerializeField] private UnityEngine.GameObject panel;
        [SerializeField] private UnityEngine.GameObject button;
        
        private void Show(List<BaseWeaponData> candidates)
        {
                panel.SetActive(true);
                // 이놈도 레벨업에 구독해야할듯? 
                
                // 데이터 전달인거면 슬롯 <- 이라는 스크립트 이미 생성해서 거기에 load해서 data 넣어야할듯.
                // 버튼 눌러지면 그 슬롯에서 웨폰 컨테이너로 -> 데이터 전송 하는 식 인듯?
                // 게임 멈춤을 여기서 해야하나? 흠.. 아닌거같은데 맞나? 잘모르겠음 ㅇㅇ
        }

        private void Hide()
        {
            panel.SetActive(false);
            // 
            // 버튼 눌러지면 Hide 그러니까 이벤트 구독 형식인듯? 슬롯에서 OnClick <- 이벤트 만들고 이걸 거기에 구독해야할것같음.
        }

        private void GenerateCandidates()
        {
            // 전체 무기 리스트.. 에서 그럼 이놈이 무기 리스트를 다 둘러봐야하는거 아닌가? 최대레벨도 .. 베이스 웨폰 데이터에 넣어놔야겠네
            // 데이터 들 중 랜덤으로 3개, <- 중복해도 상관없음 아무튼 전달. random 쓰면 될 듯 그냥?
        }
        
}
