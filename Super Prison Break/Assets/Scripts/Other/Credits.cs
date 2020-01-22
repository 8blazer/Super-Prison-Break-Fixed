using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Credits : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public Text first;
    public Text second;
    public Text third;
    List<string> nameOrder = new List<string>();
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        nameOrder.Add("Conner Anderson");
        nameOrder.Add("Taran Zorn");
        nameOrder.Add("Stone Eskelesen");
        int i = rnd.Next(1, 4);
        first.text = nameOrder[i - 1];
        nameOrder.RemoveAt(i - 1);
        i = rnd.Next(1, 3);
        second.text = nameOrder[i - 1];
        nameOrder.RemoveAt(i - 1);
        third.text = nameOrder[0];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            Application.Quit();
        }
    }
}
