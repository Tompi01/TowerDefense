using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class turrerPlacer : MonoBehaviour
{

    [SerializeField]
    private Transform _block;
    [SerializeField]
    private GameObject _TurretPrefab;
    [SerializeField]
    private Collider2D _BlockCollider;
    [SerializeField]
    private GameObject _price;

    private int __CurrentPrice = 130;
    // Start is called before the first frame update


    void Start()
    {
                
    }

    private void OnMouseDown()
    {
        if (LevelManager.Money >= __CurrentPrice)
        {
            Debug.Log(this.gameObject);
            Instantiate(_TurretPrefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 1), this.gameObject.transform.rotation);
            //Destroy(gameObject);
            LevelManager.Money -= __CurrentPrice;
            Destroy(_price);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
