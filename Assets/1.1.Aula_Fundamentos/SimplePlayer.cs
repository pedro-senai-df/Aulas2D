using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    public float velocidade = 1f;
    public float forcaPulo = 100f;
    public bool flip;

    private Rigidbody2D rb_;
    private SpriteRenderer sr_;


    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        sr_ = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        rb_.linearVelocityX = input * velocidade;

        if (input > 0f)
        {
            sr_.flipX = flip;
        }
        else if (input < 0f)
        {
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
