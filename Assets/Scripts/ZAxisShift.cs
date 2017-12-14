using UnityEngine;

public class ZAxisShift : MonoBehaviour {

    void FixedUpdate() {
        var position = transform.position;
        position = new Vector3(position.x, position.y, position.y);
        transform.position = position;
    }
}
