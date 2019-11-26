using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenePoint : MonoBehaviour {
    public Transform point;
    
    public void Start(){
        point = this.transform;
    }
}
