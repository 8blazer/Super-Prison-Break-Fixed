using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpeningCutscene : MonoBehaviour
{
    float timer = 0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (this.gameObject.name == "Door" && timer > 3.5)
        {
            color.a = color.a - .05f;
            GetComponent<SpriteRenderer>().color = color;
        }
        else if (timer > 3.3 && timer < 7 && this.gameObject.name != "Door")
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (this.gameObject.name != "Door" && timer > 7 && timer < 9)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (timer > 9 && this.gameObject.name != "Door")
        {
            GetComponent<Animator>().enabled = true;
            transform.position = transform.position + new Vector3(.075f, 0, 0);
        }
        if (timer > 12)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
