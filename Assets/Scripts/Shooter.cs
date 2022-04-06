using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private GameObject shootPrefab;
<<<<<<< Updated upstream

    public void DoShoot() {
        Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
    }

=======
    
    public void DoShoot(){
        Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
    }
>>>>>>> Stashed changes
}
