using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de mover los objetos que se requiera, sin importar que objeto sea 
public class Mover : MonoBehaviour
{
    public Vector3 direction;
    //public float speed;

    [SerializeField] public float speed;
    [SerializeField] int maximoSpeed;

    private void Start() {
        speed = maximoSpeed;
    }

    public void TomarDaño (int daño) {
        //speed -= daño;
        if (speed <= 0){
            Destroy(gameObject);
        }
        
    }

    public void Curar (int curacion) {
        if ((speed + curacion) > maximoSpeed) {
            //speed = maximoSpeed;
        } else {
            //speed += curacion;
        }
        
    }

    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
