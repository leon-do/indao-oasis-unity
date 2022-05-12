using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnProceduralGeneration : MonoBehaviour
{
    public GameObject FlyCamera;

    // when space player exits sphere, delete this object
    void OnTriggerExit(Collider collider)
    {
        // get position of FlyCamera
        Vector3 flyCamPos = FlyCamera.transform.position;
        // generate random position
        float x = Random.Range(100, 800) * (Random.Range(0, 2) == 0 ? -1 : 1);
        float y = Random.Range(100, 800) * (Random.Range(0, 2) == 0 ? -1 : 1);
        float z = Random.Range(100, 800) * (Random.Range(0, 2) == 0 ? -1 : 1);
        // move this object to FlyCamera's position plus random
        collider.transform.position = new Vector3(flyCamPos.x + x, flyCamPos.y + y, flyCamPos.z + z);
        // set random rotation
        collider.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    } 
}
