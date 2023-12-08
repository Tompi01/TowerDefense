using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndClick : MonoBehaviour
{

    [SerializeField] GameObject _TurretPrefab;
    [SerializeField] GameObject _TurretSprite;
    [SerializeField] bool isSpriteGrabbed = false;
    [SerializeField] bool isClickingOnSpawner = false;
    [SerializeField] bool canDropTurret = false;


        public void MaFonction() { 

        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        if (Input.GetMouseButtonDown(0) && !isClickingOnSpawner)
        {
            Debug.Log("TestClick");
            // tu instanties ton sprite a la position de ton icone
            _SpriteToInstantiate = Instantiate(_TurretSprite, transform.position, Quaternion.identity);
            // la j'ai resize parce que c'etait chelou mais toz
            // _SpriteToInstantiate.transform.localScale = new Vector3(3.5f, 3.5f, 0);
            // tu set ton bool qui te dit si tu tu as "attrapé" le sprite fraichement instantié à true.
            isSpriteGrabbed = true;
        }


        // si tu as "attrapé" ton sprite
        if (isSpriteGrabbed)
        {
            Debug.Log("TestGrabbed");
            _SpriteToInstantiate = Instantiate(_TurretSprite, transform.position, Quaternion.identity);
            // tu set sa position pour qu'elle corresponde a celle de ta souris
            _SpriteToInstantiate.transform.position = mousePos;
            // tu autorises le fait de pouvoir poser une tourelle
            canDropTurret = true;
        }

        // si tu fais l'input popur poser la tourelle (ici j'ai mis clic droit parce que c'etait plus simple a gerer que 2 clics gauche)
        if (Input.GetMouseButtonDown(0) && canDropTurret)
        {
            Debug.Log("TestPosed");
            // tu reset ton bool qui te dit si tu as attrapé le sprite à false
            isSpriteGrabbed = false;
            // tu detruis le sprite accroché à ta souris (parce qu'on s'en fout maintenant)
            Destroy(_SpriteToInstantiate);
            // tu instanties ta tourelle a la position ou tu as cliqué
            _TurretToInstantiate = Instantiate(_TurretPrefab, mousePos, Quaternion.identity);
            // pareil le scale on s'en branle
            // _TurretToInstantiate.transform.localScale = new Vector3(5.5f, 5.5f, 0);
            // tu reset le fait de pouvoir poser une tourelle
            canDropTurret = false;
        }
    }
    // en fait on va instantier un gameObject plutot qu'un sprite parce que c'est plus simple, Unity veut pas instancier de Sprite)
    GameObject _SpriteToInstantiate;
    GameObject _TurretToInstantiate;


    // Update is called once per frame
    void Update()
    {
        // Recuperation de la position de la souris (c'est ici ou normalement faudrait faire une conversion mais j'ai pas reussi)
    }
    // la c'est un peu bancal mais en gros c'est pour detecter que tu as bien cliqué sur ton icone de tourelle
    private void OnMouseDown()
    {
        // si c'est le cas, tu mets ton boolean a true
        isClickingOnSpawner = true;
    }

}
