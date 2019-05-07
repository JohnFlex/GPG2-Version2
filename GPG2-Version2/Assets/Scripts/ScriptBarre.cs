using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBarre : MonoBehaviour
{

    public Image Barre;
    public RawImage Indicateur;
    public RectTransform Center;
    public float Speed;

    private Vector2 centreBarre;
    private Vector2 posBarre;

    private bool vaVersLeBas = true;
    private bool canShoot = true;
    private int Power;
    
    // Start is called before the first frame update
    void Start()
    {
        centreBarre = new Vector2(Barre.rectTransform.rect.height / 2, Barre.rectTransform.rect.width / 2);
        posBarre = new Vector2(Barre.rectTransform.position.x, Barre.rectTransform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (vaVersLeBas && canShoot)
        {
            Indicateur.rectTransform.position += new Vector3(0, -Speed) * Time.deltaTime;
        }
        else if (canShoot)
        {
            Indicateur.rectTransform.position += new Vector3(0, Speed) * Time.deltaTime;
        }

        float posYIndic = Indicateur.rectTransform.localPosition.y;

        if ((posYIndic >= Barre.rectTransform.rect.height/2)||(posYIndic <= -Barre.rectTransform.rect.height/2)){
            vaVersLeBas = !vaVersLeBas;
        }

        if (Input.GetButtonDown("Submit"))
        {
            canShoot = false;
            Debug.Log(GetPower());
        }
    }

    public int GetPower()
    {
        return Power;
    }

    private void FixedUpdate()
    {
        Power = (Mathf.RoundToInt(100 - Vector2.Distance(Center.localPosition, Indicateur.rectTransform.localPosition))) /25 ;
    }

}
