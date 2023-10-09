using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Ÿ ��ũ��Ʈ ��ü")]
    public ObjectManager objectManager;

    public bool gamePause = false;

    //public GameObject destination;

    [Header("# ���� ���� ���� �ý��� ������ ����")]
    //���⼭�� �⺻ ����
    //PlayerPrefs.GetInt("MAXMTE"); ����� �⺻ 0�� ���� �ִ� ��
    int systemMAXMTESoldier = 500;
    int systemHP = 3;
    int systemCoin = 0;
    int systemMAXMTEHP = 1;
    int turretAttackSpeedUP = 0;//0 off, 1 on
    int turretAccUP = 0;//0 off, 1 on

    [Header("# ������")]
    [SerializeField] GameObject GameClearPage;
    [SerializeField] GameObject GameOverPage;
    public GameObject BugPage;

    [Header("# ���� ���� ���� ���� ���ӿ� �ݿ��� ����")]
    public int MTE;
    public int HP;
    //public int Coin;

    void Awake()
    {
        systemCoin += PlayerPrefs.GetInt("Coin");
        systemHP += PlayerPrefs.GetInt("PlayerMAXHP");
        systemMAXMTESoldier += PlayerPrefs.GetInt("MAXMTESoldier");

        MTE = systemMAXMTESoldier;
        HP = systemHP;
        //Coin = systemCoin;

        instance = this;

        DebugSystem();
    }

    void DebugSystem()
    {
        PlayerPrefs.SetInt("PlayerMAXHP", 3);
        PlayerPrefs.SetInt("PlayerSpeed", 5);
        PlayerPrefs.SetInt("MAXMTESoldier", 500);
        PlayerPrefs.SetInt("MAXMTEHP", 1);
        PlayerPrefs.SetInt("TurretAttackSpeed", 0);
        PlayerPrefs.SetInt("TurretAttackACC", 0);
    }

    public void GameOver()
    {
        GameOverPage.SetActive(true);
    }

    public void GameClear()
    {
        GameClearPage.SetActive(true);
        //�ý��� ���� �ʱ�ȭ ��������?
    }

    public void BugEffect()
    {
        BugPage.SetActive(true);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
