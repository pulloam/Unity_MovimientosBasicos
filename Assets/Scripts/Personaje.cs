using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour{
    private float movX, movY;

    //Componentes GameObject
    private Rigidbody2D rbd2;
    
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

        velocidadMovimiento = 25;
        fuerzaSalto = 200;
        masSuave = true;
    }

    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {


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

    private void saltar() {
        rbd2.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            saltar();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string colisionNombre = collision.gameObject.tag;
        print("Colisionando con " + colisionNombre );
        if(colisionNombre == "Enemigo") {
            rbd2.transform.position = new Vector3(-13, 4, 0);
        }
     
    }

    private void OnMouseEnter() {
        print("Entró al personaje");
    }


}
