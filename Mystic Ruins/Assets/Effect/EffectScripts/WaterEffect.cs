using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterEffect : MonoBehaviour
{
    public float Maxtime = 1;
    public float waitTime = 0.1f;
    public GameObject[] objA;
    public string ReperenceName;
    private Renderer[] RenA;
    
    void Start()
    {
        RenA = new Renderer[objA.Length]; //�迭���� �ʱ�ȭ
        for (int i = 0; i < objA.Length; i++) {
            RenA[i]= objA[i].GetComponent<Renderer>();
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(func());
        }
    }

    IEnumerator func()
    {
        float TimaA = 0;
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            for (int i = 0;i < objA.Length;i++) {
                RenA[i].material.SetFloat(ReperenceName, TimaA); //�̶� ���� �̸��� NAME�� �ƴ� Reference���ִ� �̸��� ����Ͽ��� �Ѵ�.
            }
            TimaA += waitTime;
            if (TimaA > Maxtime) { yield break; }
        }
    }
}
