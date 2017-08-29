using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerController : MonoBehaviour {

    public Text countText;
    public Text winText;

    private Rigidbody rb;
    public float speed = 10;
    private int count;

    void Start () {

        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();
        winText.text = "";

    }

	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("PickUp")) {

            other.gameObject.SetActive(false);
            count++;
            setCountText();

        }

    }

    void setCountText() {

        countText.text = "Count : " + count;
        if (count >= 8)
            winText.text = "You Win!";

    }

}
