using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float speed;
    private float waitTime;           //����� ������ ����� ��������������
    public float startWaitTime;
    void Start()
    {
        waitTime = startWaitTime;
        transform.eulerAngles = new Vector3(0, 0, 0);
        
    }
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)        //���� ������ ������ �����, ���� ������
        {
            float x = UnityEngine.Random.Range(-65, 65);
            float y = UnityEngine.Random.Range(-32, 32);     //���� ��� ������� ��������� ������� ������ ������ � ���������� x � z
            Vector3 target = new Vector3(x, y, 0);               //������ �����, � ������� ������ ������ ������
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);  //��������������!
            waitTime = startWaitTime;    //������� ������, ������ ��������
        }
    }
}