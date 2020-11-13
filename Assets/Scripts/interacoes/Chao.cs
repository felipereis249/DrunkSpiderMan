using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    private move movimento;

    void Start()
    {
        // Recupera a referência da classe de movimento que está associada ao Stickerman
        movimento = GetComponentInParent<move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Verifica se "tocou " com as pernas do stickerman. Caso tenha perdido, habilita o pulo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Tá colidindo");
        ChecaColisaoPernas(true);
    }

    // Verifica se "perdeu" a colisão com as pernas do stickerman. Caso tenha perdido, trava o pulo
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Parou a colisao");
        ChecaColisaoPernas(false);
    }

    private void ChecaColisaoPernas(bool lib)
    {
        movimento.SetLiberaPulo(lib);
    }

}
