using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectList : MonoBehaviour {

    public int playerId;
    public bool active = false;
    public float timeSinceActivated = 0;
    public GameObject overlay;

    public InputSource source;

    public CharLock[] chars = new CharLock[4];
    public int currentChar = 0;
    public bool moving = false;
    public float moveTime = 0.5f;

    public bool madeSelection = false;

    void Start() {
        CheckIfPlayerEntered();
        for (int i = 0; i < 4; ++i)
            chars[i] = transform.GetChild(i).GetComponent<CharLock>();
    }

    void CheckIfPlayerEntered() {
        if (CharSelectionMenu.instance.currentPlayer > playerId) {
            source = (InputSource)CharSelectionMenu.instance.sources[playerId];
            active = true;
        }
        overlay.SetActive(!active);
    }

    void Update() {
        if (!madeSelection) {
            if (!active)
                CheckIfPlayerEntered();
            else
                timeSinceActivated += Time.deltaTime;
            if (active && !moving && timeSinceActivated > 1f) {
                float xInput = InputManager.JoyLeft(source).x;
                if (xInput > 0 && currentChar < 3)
                    StartCoroutine(Move(right:true));
                else if (xInput < 0 && currentChar > 0)
                    StartCoroutine(Move(right:false));
                else if (InputManager.ShootButton(source) && !chars[currentChar].locked) {
                    madeSelection = true;
                    CharSelectionMenu.instance.selections[playerId] = currentChar;
                    chars[currentChar].selected = true;
                }
            }
        }
    }

    IEnumerator Move(bool right) {
        moving = true;
        currentChar += 1 * (right ? 1 : -1);
        float start = GetComponent<RectTransform>().localPosition.x;
        float end = start + 120 * (right ? -1 : 1);
        float elapsedTime = 0;
        var currentPos = GetComponent<RectTransform>().localPosition;
        while (elapsedTime < moveTime) {
            elapsedTime += Time.deltaTime;
            currentPos.x = Mathf.Lerp(start, end, elapsedTime/moveTime);
            GetComponent<RectTransform>().localPosition = currentPos;
            yield return null;
        }
        currentPos.x = end;
        GetComponent<RectTransform>().localPosition = currentPos;
        moving = false;
    }
}
