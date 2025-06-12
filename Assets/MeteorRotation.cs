using UnityEngine;

public class MeteorRotation : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }
}
