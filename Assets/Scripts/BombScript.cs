using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{


   
   
    // Use this for initialization
    void Start()
    {

        Destroy(gameObject, 5);       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(!otherCollider.gameObject.name.Contains("Fire") && !otherCollider.gameObject.name.Contains("bp1(Clone)") && !otherCollider.gameObject.name.Contains("Smoke")&&  !otherCollider.gameObject.name.Contains("bp1_oskolok(Clone)"))
        {
            SpecialEffectHelper.Instance.Explosion(transform.position);
           
            Destroy(gameObject);
        }
    }
}