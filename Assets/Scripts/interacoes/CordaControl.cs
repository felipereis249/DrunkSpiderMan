using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordaControl : MonoBehaviour
{
    public Corda[] corda;
    private int indice = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMouse();
    }

    private void MoveToMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Recupera a posição atual do mouse na cena
            Vector2 worldPos= (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            corda[indice].Visivel = true;
            corda[indice].AlteraStartPos(worldPos);

            // itera o contador e reseta de acordo com a quantidade de elementos do vetor
            indice++;
            if (indice > corda.Length -1)
            {
                indice = 0;
            }
        }
        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
        //    corda.Visivel = false;
        //}
    }
}
