using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PolygonMove : MonoBehaviour
{
    const float doubleClickTime = 0.2f;
    float lastClickTime = 0.0f;
    bool pieceStatusLock = false;
    bool mouseMoving;
    Collider2D lockObj;
    public Text puan;
    public int TotalPieceNumber;
    public string NextLevelName;

    private void collisonCheck(Collider2D col)
    {
        if (col.gameObject.name == gameObject.name + "1")
        {

            if (col.transform.rotation == gameObject.transform.rotation)
            {
                lockObj = col;
                pieceStatusLock = true;
            }
            else
            {
                pieceStatusLock = false;
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisonCheck(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collisonCheck(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pieceStatusLock = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (mouseMoving)
        {
            Vector2 mousePositon = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePositon);
            transform.localPosition = objPosition;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float sinceLastClick = Time.time - lastClickTime;
            GetComponent<SpriteRenderer>().sortingOrder++;
            mouseMoving = true;
            if (sinceLastClick <= doubleClickTime)
            {
                transform.Rotate(0f, 0f, 45f);
            }
            lastClickTime = Time.time;

        }

    }
    private void OnMouseUp()
    {
        mouseMoving = false;
        GetComponent<SpriteRenderer>().sortingOrder--;
        if (pieceStatusLock)
        {
            GetComponent<SpriteRenderer>().sortingOrder--;
            transform.position = lockObj.transform.position;
            if (gameObject.GetComponent<Collider2D>() != null)
            {
                Destroy(gameObject.GetComponent<Collider2D>());
            }
            if (lockObj != null)
            {
                Destroy(lockObj);
            }
            int p;
            int.TryParse(puan.text,out p);
            p++;
            if (p>=TotalPieceNumber)
            {
                SceneManager.LoadScene(NextLevelName);
            }
            puan.text = p.ToString();
        }

    }
}
