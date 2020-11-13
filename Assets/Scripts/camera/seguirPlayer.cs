using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirPlayer : MonoBehaviour
{
    public GameObject player;
    public float camVel = 0.25f;
    private bool seguePlayer;
    public Vector3 ultimaAlvoPos;
    public Vector3 velAtual;

    void Start()
    {
        // Inicializa a posição inicial da câmera
        seguePlayer = true;
        ultimaAlvoPos = player.transform.position;
    }

    void FixedUpdate()
    {
        if (seguePlayer)
        {
            Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, player.transform.position, ref velAtual, camVel);
            transform.position = new Vector3(novaCamPos.x, novaCamPos.y, transform.position.z);
            ultimaAlvoPos = player.transform.position;
        }
    }
}
