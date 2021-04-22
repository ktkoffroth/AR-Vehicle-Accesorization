using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private int[] intArray;

    private List<GameObject> buttons;

    void Start() //Generating list
    {
        buttons = new List<GameObject>();

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            
            buttons.Clear();
        }

        foreach (int i in intArray)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText("Button " + i);
            
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    
    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }

    /*
    [SerializeField] private GameObject buttonTemplate;

    void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            GameObject button = Instantiate((buttonTemplate) as GameObject);
            button.SetActive(true);
            
            button.GetComponent<ButtonListButton>().SetText("Button " + i);
            
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }
    */
}