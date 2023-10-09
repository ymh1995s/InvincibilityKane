using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Text MTE;
    [SerializeField] Text HP;
    [SerializeField] Text Coin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HUDTextUpdate();
    }

    void HUDTextUpdate()
    {
        //print(GameManager.instance.MTE);
        string tempHP = changeHP(GameManager.instance.HP);
        MTE.text = Convert.ToString(GameManager.instance.MTE);
        HP.text = tempHP;
        Coin.text = Convert.ToString(PlayerPrefs.GetInt("Coin"));
    }

    string changeHP(int hp)
    {
        string tempHP="��";
        switch(hp)
        {
            case 9:
                tempHP = "��ȩ";
                break;
            case 8:
                tempHP = "��";
                break;
            case 7:
                tempHP = "ĥ";
                break;
            case 6:
                tempHP = "����";
                break;
            case 5:
                tempHP = "��";
                break;
            case 4:
                tempHP = "��";
                break;
            case 3:
                tempHP = "��";
                break;
            case 2:
                tempHP = "��";
                break;
            case 1:
                tempHP = "�ϳ�";
                break;
            case 0:
                tempHP = "��";
                break;
            default:
                tempHP = "��";
                break;
        }
        return tempHP;
    }
}
