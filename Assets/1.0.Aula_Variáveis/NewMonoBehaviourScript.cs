using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int x = 7;
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
        MinhaFuncao();

        if (y > x)
        {
            print("Y é maior que X");
        }
        else
        {
            print("Gosto de chocolate");
        }

    }


    private void Update()
    {
        sprite.color = GetColor();

    }

    public void MinhaFuncao()
    {
        print("Olá mundo, essa é minha função");
    }

    public Color GetColor()
    {
        return Color.red;
    }

}
