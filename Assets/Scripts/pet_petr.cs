using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pet_petr : MonoBehaviour
{
    public float jumpVel;
    public float fallMulti = 2.5f;
    public float lowJumpMulti = 2f;


    Rigidbody2D rb;

    public Button Petr;
    private int pets;

    void Awake() { 
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = Petr.GetComponent<Button>();
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
    }

    void Falling() {
        if(rb.velocity.y < jumpVel){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;

        }
    }
}
