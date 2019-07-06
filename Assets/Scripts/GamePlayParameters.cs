using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayParameters : MonoBehaviour {
    //PLAYER CONSTANTS
    public static float SCROLL_DOWN_SPEED = 4f, DEATH_ZONE_WIDTH = 1;
    public static Vector2 screenBounds;

    #region Non Static Copies to tweak them from Unity OnInspector        
    [SerializeField] private float _DEATH_ZONE_WIDTH = 1;
    [SerializeField] private float _SCROLL_DOWN_SPEED = 0.25f;
    #endregion

    void OnEnable() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log("Screenbounds" + screenBounds.ToString());
    }

    void Update() {
        SCROLL_DOWN_SPEED = _SCROLL_DOWN_SPEED;
    }


}
