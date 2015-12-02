using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{


   
    int i = 0;
    // Use this for initialization
    void Start()
    {

        //Destroy(gameObject, 5);       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(!otherCollider.gameObject.name.Contains("Fire"))
        {
            SpecialEffectHelper.Instance.Explosion(transform.position);
           
            Destroy(gameObject);
        }
    }
}