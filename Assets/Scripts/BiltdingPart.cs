using UnityEngine;
using System.Collections;
using System;

public class BiltdingPart : MonoBehaviour
{


    public event EventHandler CollisionWirhBomb;
    public int Health ;
    public Transform Oskolok;
    private int heals_begin;
    // Use this for initialization
    void Start()
    {
        heals_begin = Health;

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.name.Contains("Bomb"))
        {
            if (CollisionWirhBomb != null)
                CollisionWirhBomb(null, null);
            //  SpecialEffectHelper.Instance.Explosion(transform.position);
            Destroy(otherCollider.gameObject, 0.1f);


            Destroy(gameObject);
            Oskolki();

        }
        if (otherCollider.gameObject.name.Contains("Fire"))
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            Health -= 1;

            gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g- 2.55f  / heals_begin, c.b - 1.55f / heals_begin);

            /* if (Health <= heals_begin / 2)
                 gameObject.GetComponent<Renderer>().material.color = Color.yellow;

             if (Health <= heals_begin / 3)
                 gameObject.GetComponent<Renderer>().material.color = Color.red;
             if (Health <= 0)
                 Destroy(gameObject);*/

            if (Health <= 0)
            {
                Destroy(gameObject);
                Destroy(otherCollider.gameObject, 1);
                Oskolki();
            }
           
        }
       


    }

    private void Oskolki()
    {
        for (int i = 0; i < 15; i++)
        {
            var osk = Instantiate(Oskolok);

            osk.transform.Rotate(0, 0, UnityEngine.Random.Range(-30, 30));
            osk.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5));
           
            osk.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y);
        }
    }
}
