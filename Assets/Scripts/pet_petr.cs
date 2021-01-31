using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//code can be doubly used to enhance the feel of gravity by leaving the 
//hearts and Petr But empty

public class pet_petr : MonoBehaviour
{
    public GameObject hearts;
    private float heartposX;
    private float heartposY;

    public float jumpVel;
    public float fallMulti = 2.5f;
    public float lowJumpMulti = 2f;

    Rigidbody2D rb;

    public Button PetrBut;
    private int pets = 0;

    void Awake() { 
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = PetrBut.GetComponent<Button>();
        btn1.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        Falling();
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVel;
        heartposX = transform.position.x;
        heartposY = transform.position.y;

        Instantiate(hearts, new Vector2(heartposX, heartposY), Quaternion.identity);
    }

    void Falling() {
        if(rb.velocity.y < jumpVel){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;

        }
    }
}
