using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meat_drop : MonoBehaviour
{
    public GameObject meat;

    public float posX;
    public float posY;

    public Button Feed;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Feed.GetComponent<Button>();
        btn1.onClick.AddListener(DropMeat);
    }

    void DropMeat()
    {
        Instantiate(meat, new Vector2(posX, posY), Quaternion.identity);
    }

}
