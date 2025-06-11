using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Renpy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image img_BG; // 배경
    [SerializeField] Image[] img_Character; // 캐릭터
    
    [SerializeField] TextMeshProUGUI txt_Name; // 캐릭터 이름 : 호시노
    [SerializeField] TextMeshProUGUI txt_NameTitle; // 캐릭터 타이틀 : 대책위원회
    [SerializeField] TextMeshProUGUI txt_Dialogue; // 대사 : 여기에 대사가 출력됩니다.

    int id = 1;

    void Start()
    {
        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 1번 ID의 캐릭터 ID 컬럼을 가지고 온다.

        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름을 가지고 온다.
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 캐릭터 iD에 해당하는 타이틀을 가지고 온다.
        
        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // 대사 출력
    }

    public void OnClickButton()
    {
        id++; // 2로 증가되고 계속 증가한다.
        int characterID = SData.GetDialogueData(id).Character; // 대사 테이블의 1번 ID의 캐릭터 ID 컬럼을 가지고 온다.

        txt_Name.text = SData.GetCharacterData(characterID).Name; // 캐릭터 테이블에서 캐릭터 ID에 해당하는 이름을 가지고 온다.
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // 캐릭터 테이블에서 캐릭터 iD에 해당하는 타이틀을 가지고 온다.

        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // 대사 출력

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).BG);
        
        for (int i = 0; i < img_Character.Length; i++)
        {
            if(i == SData.GetDialogueData(id).Position)
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(characterID).Image);
                img_Character[i].gameObject.SetActive(true); // 캐릭터 이미지 활성화


            }
        }
    }

    void Update()
    {

    }
}