using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PronounGen : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private TMP_InputField defaultBox;
    private TMP_InputField lowestBox;

    private float boxXPos;
    private float boxZPos;

    private float lowestBoxYPos;

    List<string> playerPronouns = new List<string>();



    // Start is called before the first frame update
    void Start()
    {
        lowestBox = FindObjectOfType<TMP_InputField>();
        defaultBox = lowestBox; //using this instead of prefab for the object's script

        boxXPos = defaultBox.gameObject.transform.position.x;
        boxZPos = defaultBox.gameObject.transform.position.z;

        lowestBoxYPos = defaultBox.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewPronounBox(TMP_InputField alteredBox) {
        playerPronouns.Add(lowestBox.text);

        float altBoxYPos = alteredBox.gameObject.transform.position.y;

        //Make a new box
        if (altBoxYPos == lowestBoxYPos)
        {
            lowestBoxYPos -= 75;
            lowestBox = Instantiate(defaultBox, new Vector3(boxXPos, lowestBoxYPos, boxZPos), Quaternion.identity, canvas.transform);
            lowestBox.onValueChanged.RemoveAllListeners();
            lowestBox.onValueChanged.AddListener(delegate { AddNewPronounBox(lowestBox); });
            lowestBox.text = "";
        }

        //OR on select if the text is already in pP then its not the lowest box and we dont need to change it

        else { 
            
        }
        
        lowestBox.Select();


        foreach (string s in playerPronouns) {
            Debug.Log(s);
        }
    }
}
