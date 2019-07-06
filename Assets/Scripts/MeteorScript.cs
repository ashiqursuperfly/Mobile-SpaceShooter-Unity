using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private Sprite[] meteors;
    [SerializeField] private int speedMin, speedMax;
    int speed;
    void OnEnable() {
        int r = Random.Range(0, meteors.Length);
        this.GetComponent<SpriteRenderer>().sprite = meteors[r];
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y > -2 * GamePlayParameters.screenBounds.y)
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        else Destroy(gameObject);
    }
}
