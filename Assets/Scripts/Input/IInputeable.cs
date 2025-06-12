using UnityEngine;

public interface IInputeable{
    void ShootPressed();
    //void GetHorizontalAxis(float value);
    //void GetVerticalAxis(float value);
    void GetDirection(Vector3 direction);
}
