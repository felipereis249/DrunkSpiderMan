using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLava : MonoBehaviour
{
    // Start is called before the first frame update
    private float velocidade = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = new Vector2(velocidade * Time.deltaTime, 0);
        this.transform.position = vec;
    }
}
