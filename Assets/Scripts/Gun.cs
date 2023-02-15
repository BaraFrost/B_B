using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public GunType gunType;
   public float offset;
   public GameObject bullet;
   public Joystick joystick;
   public Transform shotPoint;

   private float timeBtwShots;
   public float startTimeBtwShots;


   private float rotZ;
   private Vector3 difference;
   private Player player;

   public enum GunType {Default, Enemy}

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
        if(player.controlType == Player.ControlType.PC && gunType == GunType.Default) 
        {
            joystick.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        var rotateOffset = transform.lossyScale.x < 0 ? 180 : 0;
        if (gunType == GunType.Default)
        {
            if (player.controlType == Player.ControlType.PC)
            {
                difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotateOffset;

            }
            else if (player.controlType == Player.ControlType.Android && Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
            {
                rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg + rotateOffset;
            }
        }
        else if(gunType== GunType.Enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotateOffset;
        }
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ +offset);
        
        if (timeBtwShots <= 0)
        {
            if(Input.GetMouseButton(0) && player.controlType == Player.ControlType.PC || gunType == GunType.Enemy)
            {
                Shoot(rotateOffset);
            }
            else if (player.controlType == Player.ControlType.Android)
            {
                if(joystick.Horizontal != 0 || joystick.Vertical != 0) 
                {
                    Shoot(rotateOffset);
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void Shoot(float rotateOffset)
    {
        var bulletRotation = transform.rotation * Quaternion.Euler(0, 0, rotateOffset);
        Instantiate(bullet, shotPoint.position, bulletRotation);//shotPoint
        timeBtwShots = startTimeBtwShots;
    }
}
