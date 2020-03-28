using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabCombat : MonoBehaviour
{

    [SerializeField] private GameObject hitPointPrefab;
    [SerializeField] private bool hasHit = false;
    [SerializeField] private int health = 100;
    public bool isDead = false;


    void OnCollisionEnter(Collision collision)
    {
        if (!hasHit)
        {
            //gets the initial contact when hit
            ContactPoint hitPoint = collision.GetContact(0);

            //Instantiate tiny sphere at hit location. 
            GameObject hitLocation = Instantiate(hitPointPrefab, hitPoint.point, Quaternion.identity);

            //parent the hit sphere so we know where it was hit. 
            hitLocation.transform.parent = this.transform;

            hasHit = true;

            print("hit");
            SubtractHealth();
        }
    }

    //Subtracting health
    private void SubtractHealth()
    {
        health = health - 25;
        print(health);

        //Check if dead
        if(health <= 0)
        {
            isDead = true;
            DestroyCrab();
        }
    }

    //This will be more complex once animations are involved, such as delays, etc.
    private void DestroyCrab()
    {
        Destroy(this.gameObject);
    }

    //Resetting bool
    private void OnCollisionExit(Collision collision)
    {
        hasHit = false;
    }
}
