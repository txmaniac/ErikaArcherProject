using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class AIVision{
    Transform transform;
    
    public AIVision(GameObject obj){
        transform = obj.GetComponent<Transform>();
    }
    
    public bool InFieldofView(GameObject obj){
        Transform t = obj.GetComponent<Transform>();
        if(t==null)
            return false;
        return InFieldofView(t.position);
    }
    
    public bool InFieldofView(Vector3 vec){
        float Angle = Vector3.Angle(vec - transform.position,transform.forward);
        
        if(Angle >= 0 && Angle <= 90){
            return true;
        }
        
        else
            return false;
    }
}
