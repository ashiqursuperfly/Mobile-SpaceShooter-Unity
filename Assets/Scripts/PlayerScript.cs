using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    [SerializeField] private int speed = 3;
    [SerializeField] private float bulletDelay = 0.25f;

    [SerializeField] private GameObject bullet;
    Rigidbody2D player;
    float timeElapsed = 0;
    private static Queue<GameObject> bulletPool;
    void OnEnable() {
        player = this.GetComponent<Rigidbody2D>();
        bulletPool = new Queue<GameObject>();
        growPool();
    }

    // Update is called once per frame
    void Update() {
        move();
        shoot();
        userInput();
    }
    void shoot() {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= bulletDelay) {
            GameObject g = bulletPool.Dequeue();
            g.SetActive(true);
            g.GetComponent<BulletScript>().enabled = true;
            g.transform.position = this.transform.position;
            timeElapsed = 0;
        }
    }
    void move() {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        if (xDir > 0) {
            player.transform.Translate(Vector3.right * speed * Time.deltaTime);
        } else if (xDir < 0) {
            player.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (yDir > 0) {
            player.transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (yDir < 0) {
            player.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
    void growPool() {
        for (int i = 0; i < 20; i++) {
            GameObject g = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            g.SetActive(false);
            g.GetComponent<BulletScript>().enabled = false;
            bulletPool.Enqueue(g);
        }
    }
    public void returnToPool(GameObject g) {
        g.SetActive(false);
        g.GetComponent<BulletScript>().enabled = false;
        bulletPool.Enqueue(g);
    }
    private void userInput() {
        if (Input.touchCount > 0) {
            foreach (Touch touch in Input.touches) {
                Vector3 touch_position = Camera.main.ScreenToWorldPoint(touch.position);
                // Debug.Log(DEBUG_TAG + touch.phase);
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                    if (touch_position.x > 0) {
                        player.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    } else if (touch_position.x < 0) {
                        player.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    }
                } else { // we reject all other touch phases i.e ended,cancelled etc.

                }
            }
        } else { // if no touch is detected
        }
    }
}
