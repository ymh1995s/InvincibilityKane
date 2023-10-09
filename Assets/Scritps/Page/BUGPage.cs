using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUGPage : MonoBehaviour
{
    public void RestartBtnClick()
    {
        GameManager.instance.GameRestart();
    }
}
