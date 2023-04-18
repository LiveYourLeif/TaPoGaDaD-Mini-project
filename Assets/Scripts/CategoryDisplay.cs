using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoryDisplay : MonoBehaviour
{
    public cardClass category_class;
    public TextMeshProUGUI categoryName;
    public TextMeshProUGUI categoryDescription;


    void Start()
    {
        categoryName.text = category_class.name;
        categoryDescription.text = category_class.description;
    }

}
