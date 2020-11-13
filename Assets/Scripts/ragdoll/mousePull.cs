using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePull : MonoBehaviour
{
    private float forca = 70f;
    public Rigidbody2D rb2d; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputMouse();    
    }

    private void InputMouse()
    {
        // Verifica o clique do Mouse
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Diferença: Delta da posição do boneco em relação ao mouse na TELA (world position)
            Vector2 vec = rb2d.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec = vec.normalized;

            rb2d.AddForce(-vec * forca * Time.deltaTime * 1000);

            Debug.Log("Acionou");
        }
    }
}
