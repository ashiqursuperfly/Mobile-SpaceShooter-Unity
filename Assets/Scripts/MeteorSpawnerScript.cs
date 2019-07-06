using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MeteorSpawnerScript : MonoBehaviour {
    [SerializeField] private GameObject meteor;
    [SerializeField] private float delay;
    float timeElapsed = 0;
    void Update() {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= delay) {
            spawnMeteor();
            timeElapsed = 0;
        }
    }
    void spawnMeteor() {
        GameObject g = Instantiate(meteor,
        new Vector3(Random.Range(GamePlayParameters.screenBounds.x, -GamePlayParameters.screenBounds.x)
        , GamePlayParameters.screenBounds.y, 0), Quaternion.identity) as GameObject;
    }
}
