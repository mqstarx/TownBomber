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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.name.Contains("bp"))
        {
            SpecialEffectHelper.Instance.Explosion(transform.position);
           
            Destroy(gameObject);
        }
    }
}