using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPage : MonoBehaviour
{
    public void GameExit()
    {
        GameManager.instance.GameExit();
    }
}
