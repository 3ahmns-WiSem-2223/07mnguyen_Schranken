using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private bool schranke1 = false;
    private bool schranke2 = false;
    [SerializeField] GameObject schrankeA;
    [SerializeField] GameObject schrankeB;
    [SerializeField] GameObject ziel;
    int mausKlick = 0;
    [SerializeField] GameObject textGewonnen;
    float catMove = -7.5f;
    void Start()
    {
        ziel.transform.position = new Vector3(-7.5f, -0.5f, 0f);
        textGewonnen.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mausKlick++;
        }
        if (mausKlick % 2 != 0)
        {
            schranke1 = true;
            schrankeA.transform.position = new Vector3(-4, 3, 0);
        }
        if (mausKlick % 2 == 0 && mausKlick != 0)
        {
            schranke2 = true;
            schrankeB.transform.position = new Vector3(4, 3, 0);
        }
        
        if (Input.GetKey("d"))
        {
            catMove = catMove + 0.01f;
            ziel.transform.position = new Vector3(catMove, -0.5f, 0f);
            if (catMove >= -6.55 && schranke1 == false)
            {
                catMove = -6.55f;
            }
            if (catMove >= 1.50f && schranke2 == false)
            {
                catMove = 1.5f;
            }
        }

        if (catMove >= 7.5f)
        {
            textGewonnen.SetActive(true);
        } 
    }
}