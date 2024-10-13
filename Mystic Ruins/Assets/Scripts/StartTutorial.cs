using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartTutorial : MonoBehaviour
{
    public UIManager ui;
    
    public GameObject player;
    public GameObject boardWall;    
    public GameObject boardTwinkle;
    public GameObject saveTwinkle;

    public float msgPrintTime;

    public bool isUse;
    public bool isSave;
    
    public int state;

    bool[] alphas = new bool[4];
    float yAngle;

    void Start()
    {        
        yAngle = player.transform.rotation.eulerAngles.y;
        ui.SetTutoText(messages[0]);
        StartCoroutine(ui.FadeTutoText(msgPrintTime));
    }

    void Update()
    {
        switch(state)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.W)) alphas[0] = true;
                if (Input.GetKeyDown(KeyCode.S)) alphas[1] = true;
                if (Input.GetKeyDown(KeyCode.A)) alphas[2] = true;
                if (Input.GetKeyDown(KeyCode.D)) alphas[3] = true;

                if (alphas[0] && alphas[1] && alphas[2] && alphas[3])
                {                    
                    state = 2;
                    ui.SetTutoText(messages[state - 1]);
                    StartCoroutine(ui.FadeTutoText(msgPrintTime));
                }
                break;

            case 2:
                if (player.transform.rotation.eulerAngles.y != yAngle)
                {
                    state = 3;
                    ui.SetTutoText(messages[state - 1]);
                    StartCoroutine(ui.FadeTutoText(msgPrintTime));                    
                }
                break;

            case 3:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    state = 4;
                    ui.SetTutoText(messages[state - 1]);
                    StartCoroutine(ui.FadeTutoText(msgPrintTime));                    
                }
                break;

            case 4:
                if (Input.GetMouseButtonDown(0))
                {
                    state = 5;
                    ui.SetTutoText(messages[state - 1]);
                    StartCoroutine(ui.FadeTutoText(msgPrintTime));
                    boardTwinkle.SetActive(true);
                }
                break;

            case 5:
                if(isUse)
                {
                    state = 6;
                    boardWall.SetActive(false);
                    ui.SetTutoText(messages[state - 1]);
                    StartCoroutine(ui.FadeTutoText(msgPrintTime));
                    saveTwinkle.SetActive(true);
                }
                break;

            case 6:
                if (isSave)
                {
                    boardWall.SetActive(false);
                    saveTwinkle.SetActive(false);
                    ui.tutoMsg.color = new Color(ui.tutoMsg.color.r, ui.tutoMsg.color.g, ui.tutoMsg.color.b, 0f);
                    ui.msgText.color = new Color(ui.msgText.color.r, ui.msgText.color.g, ui.msgText.color.b, 0f);
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }

    string[] messages = new string[6] {
        "W,A,S,D�� ���� �̵�",
        "���콺 ȸ������ ���� ����",
        "LeftShift�� ���� ������",
        "���콺 ��Ŭ������ �����ϱ�",
        "F�� ���� ������ ȹ��/���",
        "E�� ���� ���� ���� ����"
    };

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            state = 1;
        }
    }
}
