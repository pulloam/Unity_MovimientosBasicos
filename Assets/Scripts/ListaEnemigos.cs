using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaEnemigos : MonoBehaviour{
    public GameObject enemigo;

    private float tiempoUnSegundo;

    void Start(){
        tiempoUnSegundo = 0;
        
    }

    // Update is called once per frame
    void Update(){
        tiempoUnSegundo += Time.deltaTime;
        if(tiempoUnSegundo >= 1) {
            int posicionEnemigo = Random.Range(-13, 12);
            Instantiate(enemigo).transform.position = new Vector3(posicionEnemigo, 8, 0);
            tiempoUnSegundo = 0;
        }  
    }
}
