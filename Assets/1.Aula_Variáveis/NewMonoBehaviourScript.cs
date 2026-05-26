using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private int x = 7;
    public float y = 5f;
    char c = '0';
    public string s = "o que você quiser";
    public bool vof = true;
    public Color cor = Color.white;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = cor;
    }

    private void Update()
    {
        sprite.color = Random.ColorHSV();
        Vector3 position = transform.position;
        position.x += Time.deltaTime;
        transform.position = position;
    }

}
