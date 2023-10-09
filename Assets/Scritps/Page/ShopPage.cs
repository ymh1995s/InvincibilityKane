using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPage : MonoBehaviour
{
    [SerializeField] Button HPBtn;
    [SerializeField] Button SpeedBtn;
    [SerializeField] Button MTEHPBtn;
    [SerializeField] Button MTEPlusBtn;
    [SerializeField] Button TurretAttackSpeedBtn;
    [SerializeField] Button TurretAccBtn;

    [SerializeField] Text HPButtonText;
    [SerializeField] Text SpeedButtonText;
    [SerializeField] Text MTEHPButtonText;
    [SerializeField] Text MTEPlusButtonText;
    [SerializeField] Text TurretAttackSpeedText;
    [SerializeField] Text TurretAccText;
    
    private void Update()
    {
        ButtonAtivate();
    }

    void ButtonAtivate()
    {
        if (PlayerPrefs.GetInt("PlayerMAXHP") >= 9)
        {
            HPButtonText.text = "���� �Ϸ�";
            HPBtn.interactable = false;
        }
        else HPBtn.interactable = true;

        if (PlayerPrefs.GetInt("PlayerSpeed") >= 10)
        {
            SpeedButtonText.text = "���� �Ϸ�";
            SpeedBtn.interactable = false;
        }
        else SpeedBtn.interactable = true;

        if (PlayerPrefs.GetInt("MAXMTESoldier") >= 10000)
        {
            MTEPlusButtonText.text = "���� �Ϸ�";
            MTEPlusBtn.interactable = false;
        }
        else MTEHPBtn.interactable = true;

        if (PlayerPrefs.GetInt("MAXMTEHP") >= 3)
        {
            MTEHPButtonText.text = "���� �Ϸ�";
            MTEHPBtn.interactable = false;
        }
        else MTEPlusBtn.interactable = true;

        if (PlayerPrefs.GetInt("TurretAttackSpeed") == 1)
        {
            TurretAttackSpeedText.text = "��ž ���� �ӵ� ���� ��� (5��)";
        }
        else TurretAttackSpeedText.text = "��ž ���� �ӵ� ���� (5��)";

        if (PlayerPrefs.GetInt("TurretAttackACC") == 1)
        {
            TurretAccText.text = "��ž ��Ȯ�� ���� ��� (5��)";
        }
        else TurretAccText.text = "��ž ��Ȯ�� ���� (5��)";
    }

    public void BuyPlayerHP()
    {
        if (PlayerPrefs.GetInt("Coin") < 10)
        {
            //����� ����
            return;
        }
        else
        {
            //��� ����
            int temp = PlayerPrefs.GetInt("PlayerMAXHP") + 1;
            PlayerPrefs.SetInt("PlayerMAXHP", temp);
        }
    }

    public void BuyPlayerSpeed()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //����� ����
            return;
        }
        else
        {
            //��� ����
            int temp = PlayerPrefs.GetInt("PlayerSpeed") + 1;
            PlayerPrefs.SetInt("PlayerSpeed", temp);
        }
    }
    
    public void BuyMTEHP()
    {
        if (PlayerPrefs.GetInt("Coin") < 15)
        {
            //����� ����
            return;
        }
        else
        {
            //��� ����
            int temp = PlayerPrefs.GetInt("MAXMTEHP") + 1;
            PlayerPrefs.SetInt("MAXMTEHP", temp);
        }
    }

    public void BuyMTESoldier()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //����� ����
            return;
        }
        else
        {
            //��� ����
            int temp = PlayerPrefs.GetInt("MAXMTESoldier") + 500;
            PlayerPrefs.SetInt("MAXMTESoldier", temp);
        }
    }

    public void BuyTurretAttackSpeed()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //����� ����
            return;
        }
        else
        {
            //��� ����
            int temp = PlayerPrefs.GetInt("TurretAttackSpeed");
            if (temp == 0) temp = 1;
            else temp = 0;
            PlayerPrefs.SetInt("TurretAttackSpeed", temp);
        }
    }

    public void BuyTurretACC()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //����� ����
            return;
        }
        else
        {
            //��� ����
            int temp = PlayerPrefs.GetInt("TurretAttackACC");
            if (temp == 0) temp = 1;
            else temp = 0;
            PlayerPrefs.SetInt("TurretAttackACC", temp);
        }
    }
}
