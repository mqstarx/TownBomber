using UnityEngine;
using System.Collections;
using System;

public class BiltdingPart : MonoBehaviour
{


    public event EventHandler Destroyed;
    public event EventHandler Damaged;
    public int Health ;
    public Transform Oskolok;
    private int heals_begin;
    public bool RandomHealth;
    // Use this for initialization
    void Start()
    {
        if (RandomHealth)
        {
            heals_begin = UnityEngine.Random.Range(1, Health);
            Health = heals_begin;
        }
        else
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

            //  SpecialEffectHelper.Instance.Explosion(transform.position);
            //Destroy(otherCollider.gameObject, 0.5f);
            Color c = gameObject.GetComponent<Renderer>().material.color;
            Health -= 3;
            Color d = new Color(1f, c.g - (1f - (float)Health / (float)heals_begin), c.b - (1f - (float)Health / (float)heals_begin));
            gameObject.GetComponent<Renderer>().material.color = d;
            //  gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g - 2.55f / heals_begin, c.b - 1.55f / heals_begin);
            if (Health <= 0)
            {
                if (Destroyed != null)
                    Destroyed(null, null);
                Destroy(gameObject);
               // Destroy(otherCollider.gameObject, 1);
                Oskolki();
            }
            else
            {
                if (Damaged != null)
                    Damaged(null, null);
                Destroy(otherCollider.gameObject);
                SpecialEffectHelper.Instance.Explosion(otherCollider.transform.position);
            }

        }
        if (otherCollider.gameObject.name.Contains("FireEffect(Clone)") && !otherCollider.gameObject.name.Contains("Smoke"))
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            Health -= 1;
            Color d = new Color(1f, c.g - (1f - (float)Health / (float)heals_begin), c.b - (1f - (float)Health / (float)heals_begin ));
            gameObject.GetComponent<Renderer>().material.color = d;

            if (Damaged != null)
                Damaged(null, null);

            /* if (Health <= heals_begin / 2)
                 gameObject.GetComponent<Renderer>().material.color = Color.yellow;

             if (Health <= heals_begin / 3)
                 gameObject.GetComponent<Renderer>().material.color = Color.red;
             if (Health <= 0)
                 Destroy(gameObject);*/

            if (Health <= 0)
            {
                if (Destroyed != null)
                    Destroyed(null, null);
                Destroy(gameObject);
                Destroy(otherCollider.gameObject, 1);
                Oskolki();
            }
            else
            {
                if (Damaged != null)
                    Damaged(null, null);
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
