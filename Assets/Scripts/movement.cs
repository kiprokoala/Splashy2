using UnityEngine;

public class movement : MonoBehaviour
{
    private float speed = 5f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float position_x = 0;
        //If screen is touched, then we take the position of the touch in order to move the ball to it
        //Si l'�cran est touch�, on prend la position du toucher pour bouger la balle vers cet endroit de l'�cran
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            position_x = touch.position.x - Screen.width / 2;
            position_x /= 100;
        }

        //Permits translation over time for a fluid movement
        //Permet la translation tout au long afin d'obtenir un mouvement fluide
        //transform.Translate(Time.deltaTime * new Vector3(
        //    position_x * speed,
        //    0,
        //    10f
        //    ), Space.World);


        //Don't take in account with the final code
        //A ne pas prendre en compte lors de l'�valuation du code final
        ///////////////////////////////////////////////////////////////////////////
        //Code functionable on computer (tried it)
        //Code fonctionnel sur ordinateur (test�)
        transform.Translate(Time.deltaTime * new Vector3(
            Input.GetAxis("Horizontal") * speed,
            0,
            10f
            ), Space.World);
        ///////////////////////////////////////////////////////////////////////////
        ///
    }

    private void OnCollisionEnter(Collision collision)
    {
        //The only way I found without using Dotween to move the ball up, with horizontal and forward movements
        //La seule fa�on que j'ai trouv�, sans utiliser Dotween, de faire bouger la balle vers le haut, tout en continuant le mouvement vers l'avant et les c�t�s
        rb.AddForce(new Vector3(0, -Physics.gravity.y / 2 + 0.001f, 0), ForceMode.VelocityChange);

        columns.instance.goingOnNext();

        inventory.instance.nbPoints += inventory.instance.combo + 1;
        inventory.instance.setPointsText();
    }
}