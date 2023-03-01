using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gameobject;
    Vector3 vector3;
    private void Start()
    {
        vector3 = new Vector3(gameobject.transform.position.x + 8, transform.position.y, gameobject.transform.position.z - 10);
    }
    void Update()
    {
        vector3 = new Vector3((gameobject.transform.position.x + 8)*Time.deltaTime, transform.position.y, gameobject.transform.position.z - 10);
        transform.position=vector3;
    }
}
