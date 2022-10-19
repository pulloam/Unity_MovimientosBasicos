using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public AudioSource audioExplosion;

    private Rigidbody2D rb;
    private bool destruir, rotar;
    // Start is called before the first frame update
    void Start(){
        rotar = Random.Range(0, 2) == 0 ? true : false; ;
        destruir = Random.Range(0,2) == 0 ? true : false;
        //if(Random.Range(0, 2) == 0) {
        //    destruir = true;
        //} else {
        //    destruir = false;
        //}
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(0.1f,3);
        transform.localScale = new Vector3(Random.Range(1,3), Random.Range(1,3), 0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(rotar)
            transform.Rotate(new Vector3(0, 0, Random.Range(5,25)));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Piso" || collision.gameObject.tag == "Enemigo") {
            if (destruir) {
                audioExplosion.PlayDelayed(0.2f);
                Destroy(gameObject, 1f);   
            }
            rotar = false;
        }
        
    }
}
