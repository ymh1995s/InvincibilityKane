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
        string tempHP="°ø";
        switch(hp)
        {
            case 9:
                tempHP = "¾ÆÈ©";
                break;
            case 8:
                tempHP = "ÆÈ";
                break;
            case 7:
                tempHP = "Ä¥";
                break;
            case 6:
                tempHP = "¿©¼¸";
                break;
            case 5:
                tempHP = "¿À";
                break;
            case 4:
                tempHP = "³Ý";
                break;
            case 3:
                tempHP = "»ï";
                break;
            case 2:
                tempHP = "µé";
                break;
            case 1:
                tempHP = "ÇÏ³ª";
                break;
            case 0:
                tempHP = "°ø";
                break;
            default:
                tempHP = "°ø";
                break;
        }
        return tempHP;
    }
}
