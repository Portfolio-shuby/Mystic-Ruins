using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ax : MonoBehaviour
{
    public float rotationSpeed = 45f; // ȸ�� �ӵ� (��/��)
    public float moveDistance = 3f;   // �̵� �Ÿ�
    public float moveSpeed = 2f;      // �̵� �ӵ�

    private Vector3 originalPosition;
    private float currentRotation = 0f;
    private bool isMovingForward = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Y �� ������ ȸ��
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // �̵� ����
        if (isMovingForward)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Vector3.Distance(originalPosition, transform.position) >= moveDistance)
            {
                isMovingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            if (Vector3.Distance(originalPosition, transform.position) <= 0.1f)
            {
                isMovingForward = true;
            }
        }
    }
}
