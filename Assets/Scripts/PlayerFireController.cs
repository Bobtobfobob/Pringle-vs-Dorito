using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject regFire;
    public float fireWeight;
    private float fireWeightSeconds;
    void Start()
    {
        fireWeightSeconds = fireWeight;
    }

    // Update is called once per frame
    void Update()
    {
        fireWeightSeconds -= Time.deltaTime;
        if(fireWeightSeconds <= 0)
        {
            fire();
            fireWeightSeconds = fireWeight;
        }
    }
    public void fire()
    {
        GameObject CFire = Instantiate(regFire, firePoint.position, Quaternion.identity);
        CFire.GetComponent<LaserControl>().placement = 2;

        GameObject RFire = Instantiate(regFire, firePoint.position, Quaternion.Euler(0, 0, 45));
        RFire.GetComponent<LaserControl>().placement = 1;

        GameObject LFire = Instantiate(regFire, firePoint.position, Quaternion.Euler(0, 0, 135));
        LFire.GetComponent<LaserControl>().placement = 0;


    }
}
