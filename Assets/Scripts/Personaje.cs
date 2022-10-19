using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour{
    private float movX, movY;
    private bool enPiso, saltar;


    //Componentes GameObject
    private Rigidbody2D rbd2;
    private AudioSource audioSource;
    
    [Header("Movimientos")]
    [SerializeField]
    private float velocidadMovimiento;
    [SerializeField]
    private bool masSuave;
    [SerializeField]
    [Range(5,1000)]
    private int fuerzaSalto;


    private Vector3 velocidad = Vector3.zero;

    void Start(){
        //print("Ejecución método Start");
        rbd2 = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        velocidadMovimiento = 25;
        fuerzaSalto = 250;
        masSuave = true; enPiso = true; saltar = false;
    }

    private void FixedUpdate() {
        print("Velocidad  " + rbd2.velocity);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
            if (Mathf.Abs(rbd2.velocity.x) <= 10 && enPiso){
                movX = Input.GetAxis("Horizontal") * velocidadMovimiento;
                //movY = Input.GetAxis("Vertical") * velocidadMovimiento;
                movY = rbd2.velocity.y;
                Vector3 velocidadObjeto = new Vector3(movX, movY);

                if (masSuave)
                    rbd2.velocity = Vector3.SmoothDamp(rbd2.velocity, velocidadObjeto, ref velocidad, 0.3f);
                else
                    rbd2.velocity = velocidadObjeto;

            }
        }

        if (saltar && enPiso) { 
            rbd2.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            audioSource.Play();
            saltar = false;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
            saltar = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string colisionNombre = collision.gameObject.tag;
        print("Colisionando con " + colisionNombre );
        if(colisionNombre == "Enemigo") {
            rbd2.transform.position = new Vector3(-13, 4, 0);
        }

        if(collision.gameObject.name == "Piso")
            enPiso = true;
    }


    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Piso")
            enPiso = false;
    }

    private void OnMouseEnter() {
        print("Entró al personaje");
    }

    private void OnDrawGizmos() {
        //Gizmos.DrawSphere(transform.position, 3);
    }


}
