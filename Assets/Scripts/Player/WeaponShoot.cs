using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
// kopiert von diesem Video: https://www.youtube.com/watch?v=mgjWA2mxLfI
{
    public GameObject bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
