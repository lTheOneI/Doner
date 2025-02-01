using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KebabMaking : MonoBehaviour
{
    public Button insKebab;
    public GameObject kebabPrefs;
    public Transform kebabPoint;

    private void Start()
    {
        insKebab.onClick.AddListener(CreateKebabs);
    }
    void Update()
    {
        
    }

    void CreateKebabs()
    {
        Instantiate(kebabPrefs, kebabPoint.position, Quaternion.identity);
    }
}
