using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePosition;
    private float BulletSpeed=2000;
    private float FireTimeDelay=1f;
    private float LastFireTime;

    public Transform BulletParent;
    private GameObject[] BulletPool;
    private int BulletMax = 10;
    private int BulletID;
    private void Start()
    {
        Bullet.SetActive(false);
        CreateBulletPool(BulletMax);
    }

    private void CreateBulletPool(int amount)
    {
        BulletPool = new GameObject[amount];
        for(int i = 0;i<amount;i++)
        {
            GameObject bullet = Instantiate(Bullet, FirePosition.position, FirePosition.rotation) as GameObject;
            bullet.name = "Bullet_" + i;
            //bullet.transform.parent = BulletParent;
            bullet.SetActive(false);
            BulletPool[i] = bullet;
        }

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (FireTimeDelay < Time.time - LastFireTime)
            {
                LastFireTime = Time.time;
                //CreateBullet();
                FireBullet();
            }
        }
    }

   //private void CreateBullet()
   //{
   //    GameObject bullet = Instantiate(Bullet, FirePosition.position, FirePosition.rotation) as GameObject;
   //    bullet.SetActive(true);
   //    bullet.GetComponent<Rigidbody>().AddForce(FirePosition.forward*BulletSpeed);
   //}

    private void FireBullet()
    {
        GameObject bullet = BulletPool[BulletID];
        bullet.SetActive(true);
        bullet.transform.position = FirePosition.position;
        bullet.transform.localRotation = Quaternion.identity; 
        bullet.GetComponent<Rigidbody>().AddForce(FirePosition.forward * BulletSpeed);
        ++BulletID;
        if(BulletMax -1 <BulletID)
        {
            BulletID = 0;
        }
    }
}
