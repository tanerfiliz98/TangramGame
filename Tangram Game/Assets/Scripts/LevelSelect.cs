using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public List<Button> listButton;
    // Start is called before the first frame update
    void Start()
    {
        
        int saveLevelIndex = PlayerPrefs.GetInt("SaveLevelIndex",1);

        for (int i = 0; i < listButton.Count; i++)
        {
            if (saveLevelIndex>i)
            {
                listButton[i].interactable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
