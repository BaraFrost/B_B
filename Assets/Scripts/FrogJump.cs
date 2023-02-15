using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
    public float speed;
    private float waitTime;           //врем€ отдыха между передвижени€ми
    public float startWaitTime;
    void Start()
    {
        waitTime = startWaitTime;
        transform.eulerAngles = new Vector3(0, 0, 0);
        
    }
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)        //если таймер отдыха истек, идем гул€ть
        {
            float x = UnityEngine.Random.Range(-65, 65);
            float y = UnityEngine.Random.Range(-32, 32);     //беру дл€ гул€ний небольшую область вокруг центра с рандомными x и z
            Vector3 target = new Vector3(x, y, 0);               //создаю точку, к которой овечка должна шагать
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);  //“≈Ћ≈ѕќ–“»–”ё—№!
            waitTime = startWaitTime;    //обнул€ю таймер, овечка отдыхает
        }
    }
}