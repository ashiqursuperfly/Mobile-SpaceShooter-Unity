using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    [SerializeField] private int speed;
    [SerializeField] private GameObject player;
    PlayerScript ps;
    void OnEnable() {
        ps = player.GetComponent<PlayerScript>();
    }
    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > GamePlayParameters.screenBounds.y) {
            ps.returnToPool(this.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<MeteorScript>() != null) {
            Destroy(other.gameObject);
        }
    }
}
