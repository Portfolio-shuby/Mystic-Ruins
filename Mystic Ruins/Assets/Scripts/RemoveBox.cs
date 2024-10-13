using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBox : MonoBehaviour
{
    bool isInteract;

    void Update()
    {
        if(isInteract)
        {
            StartCoroutine("Burning");
        }
    }

    IEnumerator Burning()
    {
        //�� Ÿ�� �ִϸ��̼� Ȥ�� ��ƼŬ ���
        yield return new WaitForSeconds(3);     //�ҿ� Ÿ �������µ� �ɸ��� �ð�
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            isInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
            isInteract = false;
    }

}
