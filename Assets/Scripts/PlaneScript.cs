using UnityEngine;
using System.Collections;
using System;

public class PlaneScript : MonoBehaviour {


    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 movement;
    public Transform bp1;
    // Use this for initialization
    public event EventHandler PlaneOverScreen;



    void InitBuldings()
    {
       // int h_ = 1
        for (int i = 0; i < 17; i++)
        {

           // for (int j = 0; j < h_; j++)
          //  {
                var b = Instantiate(bp1) as Transform;
                b.position = new Vector3((float)(-8.5 + i * ((float)b.GetComponent<Renderer>().bounds.size.x + 0.4)), 0);
               
           // }
           
        }


    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    public Vector2 CurrentPosition
    {
        get
        {
            return gameObject.GetComponent<Transform>().position;
        }
    }
    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().velocity = movement;

       if( gameObject.GetComponent<Transform>().position.x>10)
        {
            //InitBuldings();

            if (PlaneOverScreen != null)
                PlaneOverScreen(null, null);
            gameObject.GetComponent<Transform>().position = new Vector2(-8, gameObject.GetComponent<Transform>().position.y - 0.5f);


        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("bp"))
        {
            SpecialEffectHelper.Instance.Explosion(transform.position);

            Destroy(gameObject);
        }
    }
}
