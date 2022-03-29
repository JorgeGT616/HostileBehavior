using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//movimiento mosca de un asteroide

public class AsteroideBehaviour : MonoBehaviour
{
    public Mover mover;

    private void Update() {
        Vector3 desplazamiento =  new Vector3(UnityEngine.Random.Range(-1, 1f), transform.position.z);
        mover.DoMove(desplazamiento);
    }
}
