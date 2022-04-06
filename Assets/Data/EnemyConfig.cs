using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyConfig", menuName = "Enemies/Enemy config", order = 0)]
public class EnemyConfig : ScriptableObject {
    public float moverSpeed;
    public Material material;
    public bool isShooter;
    public float shootInitialWaitTime;
    public float shootCadence;
    public int score;

}
