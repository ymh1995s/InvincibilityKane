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
            HPButtonText.text = "구매 완료";
            HPBtn.interactable = false;
        }
        else HPBtn.interactable = true;

        if (PlayerPrefs.GetInt("PlayerSpeed") >= 10)
        {
            SpeedButtonText.text = "구매 완료";
            SpeedBtn.interactable = false;
        }
        else SpeedBtn.interactable = true;

        if (PlayerPrefs.GetInt("MAXMTESoldier") >= 10000)
        {
            MTEPlusButtonText.text = "구매 완료";
            MTEPlusBtn.interactable = false;
        }
        else MTEHPBtn.interactable = true;

        if (PlayerPrefs.GetInt("MAXMTEHP") >= 3)
        {
            MTEHPButtonText.text = "구매 완료";
            MTEHPBtn.interactable = false;
        }
        else MTEPlusBtn.interactable = true;

        if (PlayerPrefs.GetInt("TurretAttackSpeed") == 1)
        {
            TurretAttackSpeedText.text = "포탑 공격 속도 증가 취소 (5원)";
        }
        else TurretAttackSpeedText.text = "포탑 공격 속도 증가 (5원)";

        if (PlayerPrefs.GetInt("TurretAttackACC") == 1)
        {
            TurretAccText.text = "포탑 정확도 증가 취소 (5원)";
        }
        else TurretAccText.text = "포탑 정확도 증가 (5원)";
    }

    public void BuyPlayerHP()
    {
        if (PlayerPrefs.GetInt("Coin") < 10)
        {
            //못사는 사운드
            return;
        }
        else
        {
            //사는 사운드
            int temp = PlayerPrefs.GetInt("PlayerMAXHP") + 1;
            PlayerPrefs.SetInt("PlayerMAXHP", temp);
        }
    }

    public void BuyPlayerSpeed()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //못사는 사운드
            return;
        }
        else
        {
            //사는 사운드
            int temp = PlayerPrefs.GetInt("PlayerSpeed") + 1;
            PlayerPrefs.SetInt("PlayerSpeed", temp);
        }
    }
    
    public void BuyMTEHP()
    {
        if (PlayerPrefs.GetInt("Coin") < 15)
        {
            //못사는 사운드
            return;
        }
        else
        {
            //사는 사운드
            int temp = PlayerPrefs.GetInt("MAXMTEHP") + 1;
            PlayerPrefs.SetInt("MAXMTEHP", temp);
        }
    }

    public void BuyMTESoldier()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //못사는 사운드
            return;
        }
        else
        {
            //사는 사운드
            int temp = PlayerPrefs.GetInt("MAXMTESoldier") + 500;
            PlayerPrefs.SetInt("MAXMTESoldier", temp);
        }
    }

    public void BuyTurretAttackSpeed()
    {
        if (PlayerPrefs.GetInt("Coin") < 5)
        {
            //못사는 사운드
            return;
        }
        else
        {
            //사는 사운드
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
            //못사는 사운드
            return;
        }
        else
        {
            //사는 사운드
            int temp = PlayerPrefs.GetInt("TurretAttackACC");
            if (temp == 0) temp = 1;
            else temp = 0;
            PlayerPrefs.SetInt("TurretAttackACC", temp);
        }
    }
}
