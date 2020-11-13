using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D corpo;
    public float forcaPulo = 150f;
    public static bool liberaPulo;
    private float jetPack = 1.5f;

    void Start()
    {
        liberaPulo = true;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    public void SetLiberaPulo(bool lib)
    {
        liberaPulo = lib;
    }

    private void Inputs()
    {
        // Pulo
        // Verifica se o player pressionou a tecla SPACE para efetuar um salto
        if (Input.GetKeyDown(KeyCode.Space) && liberaPulo)
        {
            corpo.AddForce(forcaPulo * Vector2.up, ForceMode2D.Impulse);
        }
    }
}