using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputSource { KEYBOARD, JOY1, JOY2, JOY3, JOY4 }

public class InputManager : MonoBehaviour {

    static public bool ShootButton(InputSource source) {
        return Input.GetButton("Shoot " + ((int)source).ToString());
    }

    static public bool SuperButton(InputSource source) {
        return Input.GetButton("Super " + ((int)source).ToString());
    }

    static public bool ReloadButton(InputSource source) {
        return Input.GetButton("Reload " + ((int)source).ToString());
    }

    static public float DashButton(InputSource source) {
        if (source == InputSource.KEYBOARD)
            return Input.GetButton("Dash 0") == true ? -1f : 1f;
        return Input.GetAxisRaw("Dash " + ((int)source).ToString());
    }

    static public Vector2 JoyLeft(InputSource source) {
        Vector2 result = new Vector2();
        result.x = Input.GetAxisRaw("L_Horizontal " + ((int)source).ToString());
        result.y = Input.GetAxisRaw("L_Vertical " + ((int)source).ToString());
        return result.normalized;
    }

    static public Vector2 JoyRight(InputSource source, GameObject caller) {
        Vector2 result = new Vector2();
        if (source == InputSource.KEYBOARD)
            result = Camera.main.ScreenToWorldPoint(Input.mousePosition) - caller.transform.position;
        else {
            result.x = Input.GetAxisRaw("R_Horizontal " + ((int)source).ToString());
            result.y = Input.GetAxisRaw("R_Vertical " + ((int)source).ToString());
        }
        return result.normalized;
    }

    static public InputSource SourceFromInt(int sourceId) {
        return (InputSource)sourceId;
    }
}
