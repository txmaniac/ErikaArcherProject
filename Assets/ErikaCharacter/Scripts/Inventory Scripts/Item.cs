using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : ScriptableObject{
    public string name;
    public int id;
    public string description;
    public Sprite icon;

    public virtual void Use()
    {

    }
}