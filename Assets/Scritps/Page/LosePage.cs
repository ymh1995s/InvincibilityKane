using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePage : MonoBehaviour
{
    public void RestartBtnClick()
    {
        GameManager.instance.GameRestart();
    }
}
