using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countercont : MonoBehaviour {
	public InputField textdisp;
    public Text numdisp;
	// Use this for initialization
	void Start () {
//        num = 0;
//        numdisp.text = num.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}
	public int num = 0;
    public void upbuttun()
    {
        Debug.Log("UP");
        num++;
        numdisp.text = num.ToString();
    }
    public void dwbuttun()
    {
        Debug.Log("DOWN");
        if (num != 0) {
			num--;
		}
		numdisp.text = num.ToString();
    }
	public void setValues(string iText, string iNum){
		num = int.Parse (iNum);
		numdisp.text = num.ToString();
		textdisp.text = iText;
	}
}
