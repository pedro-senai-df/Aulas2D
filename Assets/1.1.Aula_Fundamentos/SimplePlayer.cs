using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    public float velocidade = 10f;
    public float forcaPulo = 300f;
    public bool flip;

    private Rigidbody2D rb_;
    private SpriteRenderer sr_;
    private Animator anim_;


    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        sr_ = GetComponent<SpriteRenderer>();
        anim_ = GetComponent<Animator>();
    }


    private void Update()
    {
        // Aqui pegamos o valor do Axis (eixo) Horizontal
        
        float input = Input.GetAxis("Horizontal");

        // esse valor pode ser:
        // -1 (quando indo para esquerda)
        // 1 (quando indo para direita)
        // 0 (quando não estiver indo para lugar algum).


        // Então usamos esse valor de (-1, 0, 1) como modificador
        // para alterar a velocidade do nosso rigidbody usando o valor
        // da nossa variável velocidade
        rb_.linearVelocityX = input * velocidade;

        // atribuímos ao parâmetro do animator que "andando"  
        // será verdadeiro sempre que input NÃO for igual a zero
        anim_.SetBool("andando", input != 0f);


        // Se nosso input for maior que zero
        if (input > 0f)
        {
            // colocamos o valor de flipX para ser o mesmo da variável flip
            sr_.flipX = flip;
        }
        // Se o input não for maior que zero, E caso seja menor que zero
        else if (input < 0f)
        {
            // colocamos o valor de flipX para ser o valor oposto ao de flip
            sr_.flipX = !flip;
        }


        // Se apertamos o ESPAÇO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // O player PULA
            rb_.AddForceY(forcaPulo);
        }

    }

}
