using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenePoint {
    public GameObject obj;
    public Transform point;
    
    public void Start(){
        obj = GameObject.FindGameObjectWithTag("ScenePoint");
        point = obj.transform;
    }
}
