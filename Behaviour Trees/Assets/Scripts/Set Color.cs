using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    // Start is called before the first frame update

    public Color color;
    public MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer.material.color = color;
    }

    
}
