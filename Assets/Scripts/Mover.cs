using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de mover los objetos que se requiera 
public class Mover : MonoBehaviour
{
    public void DoMove(Vector3 moverValue){
        transform.Translate(moverValue);
    }
}
