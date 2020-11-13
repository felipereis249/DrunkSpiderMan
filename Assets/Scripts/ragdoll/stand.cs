using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stand : MonoBehaviour
{
    public Musculos[] musculos;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        foreach(Musculos musc in musculos)
        {
            musc.AtivarMusculos(); 
        }
    }
}

[System.Serializable]
public class Musculos
{
    public Rigidbody2D ossos;
    public float idleRotacao;
    public float forca;

    public void AtivarMusculos()
    {
        // Ajusta a rotação do osso baseado na força aplicada no osso
        ossos.MoveRotation(Mathf.LerpAngle(ossos.rotation, idleRotacao, forca * Time.deltaTime));
    }
}