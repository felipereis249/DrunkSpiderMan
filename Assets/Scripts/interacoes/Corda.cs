using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corda : MonoBehaviour
{
    private LineRenderer linha;
    private float larguraLinha = 0.2f;
    public Rigidbody2D origem;
    public Material materialCorda;
    private bool visivel;
    private Vector3 velocidade;
    private float aceleracao = 70f;
    private bool puxando;
    private float forcaPuxo = 30f;
    private bool atualizando = false;
    private float comprimentoCorda = 50f;

    private float tempoCorda = 3f;
    private IEnumerator tempo;

    public bool useCurve = true;
    public bool Visivel { get => visivel; set => visivel = value; }

    void Start()
    {
        linha = GetComponent<LineRenderer>();

        if (!linha)
        {
            linha = this.gameObject.AddComponent<LineRenderer>();
        }
        // Adiciona o material da Corda
        // Inicializa a largura da linha (inicial e final)
        linha.material = materialCorda;
        linha.startWidth = larguraLinha;
        linha.endWidth = larguraLinha;
        linha.SetColors(Color.white, Color.white);
                     
        // Inicia a posição da corda já na posição do objeto emissor
        this.transform.position = origem.position;
        Visivel = false;
        puxando = false;
    }
    
    // Altera a posição da corda de acordo com o clique do mouse (classe CordaControl)
    public void AlteraStartPos(Vector2 targetPos)
    {
        Vector2 diferenca = targetPos - origem.position;
        diferenca = diferenca.normalized;
        velocidade = diferenca * aceleracao;
        transform.position = origem.position + diferenca;

        // Variaveis de controle
        puxando = false;
        atualizando = true;

        // Se tiver expirado o tempo, aborta a rotina
        if (tempo != null)
        {
            StopCoroutine(tempo);
            tempo = null;
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        if (!atualizando)
            return;

        if (puxando)
        {
            // Adiciona a força em direção ao ponto que a corda está presa
            Vector2 dir = (Vector2)transform.position - origem.position;
            origem.AddForce(dir * forcaPuxo);
        }
        else
        {
            // Desenha a corda na direção clicada + efeito de aceleração 
            transform.position += velocidade * Time.deltaTime;

            // Verifica a distância máxima da corda
            float distancia = Vector2.Distance(transform.position, origem.position);
            if(distancia > comprimentoCorda)
            {
                atualizando = false;
                linha.positionCount = 2;
                linha.SetPosition(0, Vector2.zero);
                linha.SetPosition(1, Vector2.zero);
                return;
            }
        }
        var variacao = new Vector2(transform.position.x + 1.5f, transform.position.y - 1.5f);

        //DrawSineWave(origem.position, 10f, 10f);
        DrawQuadraticBezierCurve(transform.position, variacao, origem.position);
        //linha.SetPosition(0, transform.position);
        //linha.SetPosition(1, origem.position);
    }
    void DrawSineWave(Vector3 startPoint, float amplitude, float wavelength)
    {
        float x = 0f;
        float y;
        float k = 2 * Mathf.PI / wavelength;
        linha.positionCount = 200;
        for (int i = 0; i < linha.positionCount; i++)
        {
            x += i * 0.001f;
            y = amplitude * Mathf.Sin(k * x);
            linha.SetPosition(i, new Vector3(x, y, 0) + startPoint);
        }
    }
    void DrawQuadraticBezierCurve(Vector3 point0, Vector3 point1, Vector3 point2)
    {
        linha.positionCount = 200;
        float t = 0f;
        Vector3 B = new Vector3(0, 0, 0);
        for (int i = 0; i < linha.positionCount; i++)
        {
            B = (1 - t) * (1 - t) * point0 + 2 * (1 - t) * t * point1 + t * t * point2;
            linha.SetPosition(i, B);
            t += (1 / (float)linha.positionCount);
        }
    }

    IEnumerator reset(float delay)
    {
        yield return new WaitForSeconds(delay);
        atualizando = false;
        linha.positionCount = 2;
        linha.SetPosition(0, Vector2.zero);
        linha.SetPosition(1, Vector2.zero);
    }

    // Ao colidir com algo, zera a velocidade
    // Obs.: No objeto de cena foi acrescentado 1 layer para o player, outra para a corda.
    // Em Project-> Settings -> Physics 2D, foi desabilitada a interação da CORDA com o PLAYER. Logo não há colisão entre os dois
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            velocidade = Vector2.zero;
            puxando = true;
            
            // Inicia o contador que definirá o tempo que a corda ficará na tela
            tempo = reset(tempoCorda);
            StartCoroutine(tempo);
        }
    }
}
