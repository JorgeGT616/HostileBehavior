using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour {
    [SerializeField] public Transform shootOrigin;
    [SerializeField] private GameObject shootPrefab;

    public void DoShoot() {
        Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);
    }
    /*
    public void Awake()
    {
        //var foundTransforObjects = FindObjectsOfType<ShootOrigin>();
        //Transform shootOrigin = (Transform)FindObjectsOfType(typeof(Transform));

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Jarron");

        DontDestroyOnLoad(this.gameObject);
    }
    */
}
