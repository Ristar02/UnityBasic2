using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Renpy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image img_BG; // ���
    [SerializeField] Image[] img_Character; // ĳ����
    
    [SerializeField] TextMeshProUGUI txt_Name; // ĳ���� �̸� : ȣ�ó�
    [SerializeField] TextMeshProUGUI txt_NameTitle; // ĳ���� Ÿ��Ʋ : ��å����ȸ
    [SerializeField] TextMeshProUGUI txt_Dialogue; // ��� : ���⿡ ��簡 ��µ˴ϴ�.

    int id = 1;

    void Start()
    {
        int characterID = SData.GetDialogueData(id).Character; // ��� ���̺��� 1�� ID�� ĳ���� ID �÷��� ������ �´�.

        txt_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� �̸��� ������ �´�.
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� ĳ���� iD�� �ش��ϴ� Ÿ��Ʋ�� ������ �´�.
        
        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // ��� ���
    }

    public void OnClickButton()
    {
        id++; // 2�� �����ǰ� ��� �����Ѵ�.
        int characterID = SData.GetDialogueData(id).Character; // ��� ���̺��� 1�� ID�� ĳ���� ID �÷��� ������ �´�.

        txt_Name.text = SData.GetCharacterData(characterID).Name; // ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� �̸��� ������ �´�.
        txt_NameTitle.text = SData.GetCharacterData(characterID).Title; // ĳ���� ���̺��� ĳ���� iD�� �ش��ϴ� Ÿ��Ʋ�� ������ �´�.

        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; // ��� ���

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).BG);
        
        for (int i = 0; i < img_Character.Length; i++)
        {
            if(i == SData.GetDialogueData(id).Position)
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(characterID).Image);
                img_Character[i].gameObject.SetActive(true); // ĳ���� �̹��� Ȱ��ȭ


            }
        }
    }

    void Update()
    {

    }
}