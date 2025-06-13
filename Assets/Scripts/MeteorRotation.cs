using UnityEngine;

public class MeteorRotation : MonoBehaviour
{
    /// <summary>
    /// Awake is to set the initial rotation of the meteor to a random angle.
    /// </summary>
    void Awake() => gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    
    // Rotate the meteor around its Z axis at a constant speed
    void LateUpdate() => transform.Rotate(0, 0, 50 * Time.deltaTime);
    


}
