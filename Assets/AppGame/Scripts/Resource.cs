using System;
using UnityEngine;

[Serializable]
public class Resource {
    public Resource(int id, int count, Sprite texture) {
        this.id = id;
        this.count = count;
        sprite = texture;
    }
    
    public int id;
    public int count;
    public Sprite sprite;
}