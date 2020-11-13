using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeInternalCollision : MonoBehaviour
{
    void Start()
    {
        // Recupera a lista de colisores do objeto
        Collider2D[] colisores = transform.GetComponentsInChildren<Collider2D>();
        
        // Remove a colisão entre os objetos
        for(int a = 0; a < colisores.Length; a++)
        {
            for(int b = 0; b < colisores.Length; b++)
            {
                Physics2D.IgnoreCollision(colisores[a], colisores[b]);
            }
        }
    }
}
