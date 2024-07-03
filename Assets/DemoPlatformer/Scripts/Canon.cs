using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    private float currentTimeBeforeShoot;
    
    void Start()
    {
        currentTimeBeforeShoot = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeBeforeShoot -= Time.deltaTime;
        if(currentTimeBeforeShoot <= 0 )
        {
            Instantiate(projectile, shootPoint.position, shootPoint.rotation);
            currentTimeBeforeShoot = timeBetweenShots;
        }
    }
}
