using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
 
   public float offset;
   public GameObject bullet;
   public Transform shotPoint;

   private float timeBtwShots;
   public float startTimeBtwShots;
    
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var rotateOffset = transform.lossyScale.x < 0 ? 180 : 0;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotateOffset;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ +offset);
        
        if (timeBtwShots <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                var bulletRotation = transform.rotation * Quaternion.Euler(0,0,rotateOffset);
                Instantiate(bullet, shotPoint.position, bulletRotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    
}
