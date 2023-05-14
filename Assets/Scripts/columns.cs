using System.Collections;
using UnityEngine;

public class columns : MonoBehaviour
{
    public static columns instance;

    public GameObject the_face;
    public GameObject the_base;
    
    public GameObject myCoin;

    //Distance between 2 columns
    //Distance entre 2 colonnes
    public float distanceBetweenColumns = 10f;
    public float horizontalDistance = 10f;

    Vector3 position;
    Vector3 scale;

    private int maxColumn;    
    public int columnNumber = 0;

    public ArrayList allFaces = new ArrayList();
    public ArrayList allBases = new ArrayList();

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        position = the_face.transform.position;
        scale = the_face.transform.localScale;

        maxColumn = 120;

        //Creating 30 columns to make the impression of infinite
        //Création de 30 colonnes pour avoir une impression d'infini
        for (int i = 0; i < 30; i++)
        {
            createColumn();
        }
    }

    public void goingOnNext()
    {
        //Destroying and creating columns to create the illusion of infinite
        //Détruire et créer des colonnes pour avoir l'illusion de l'infini
        Destroy((GameObject)allFaces[0]);
        allFaces.RemoveAt(0);

        Destroy((GameObject)allBases[0]);
        allBases.RemoveAt(0);

        createColumn();

        //Moves forward the deathZone in order to kill the player each time he falls of
        //Fait avancer la deathZone pour que le joueur soit tué à chaque fois qu'il tombe
        GameObject deathZone = GameObject.FindGameObjectWithTag("DeathZone");
        Vector3 deathZone_position = deathZone.transform.position;
        deathZone.transform.position = new Vector3(deathZone_position.x, deathZone_position.y, deathZone_position.z + distanceBetweenColumns);
    }

    public void createColumn()
    {
        //Creating coins
        //Création des pièces
        if (columnNumber % 3 == 2)
        {
            Vector3 coinPosition = position;
            coinPosition.y += 1;
            Quaternion rotation = Quaternion.identity;
            rotation.x += 90;
            rotation.y += 90;
            rotation.z += 90;
            Instantiate(myCoin, coinPosition, rotation);

            //Downscaling the platform to add difficulty
            //Diminuer la surface de la plateforme pour ajouter de la difficulté
            scale.x -= 12f / maxColumn;
            scale.z = scale.x;

            if(scale.x <= 1f)
            {
                scale.x = 1f;
                scale.z = 1f;
            }

        //Rescaling platforms for the beginning of the game so you can advance for a short period of time
        //Remettre les plateformes à leur taille initiale pour que le jeu soit jouable pendant le début de la partie
        }else if (columnNumber % maxColumn == 0)
        {
            bool minimumPassed = maxColumn <= 15;
            scale.x = minimumPassed ? 1f : 5f;
            scale.z = scale.x;
            maxColumn /= minimumPassed ? 1 :2;
        }

        //Creating columns and moving the next ones to other positions (forward, and randomly on the side)
        //Création des colonnes et déplacement des futures à d'autres positions (vers l'avant, et aléatoirement sur le côté)
        GameObject temp = Instantiate(the_face, position, Quaternion.identity);
        allFaces.Add(temp);
        temp.transform.localScale = scale;
        allBases.Add(Instantiate(the_base, new Vector3(position.x, position.y - 100, position.z), Quaternion.identity));

        position.z += distanceBetweenColumns;
        position.x = Random.Range(position.x - horizontalDistance, position.x + horizontalDistance);
        columnNumber++;
    }
}
