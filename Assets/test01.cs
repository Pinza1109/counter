using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class test01 : MonoBehaviour {
	public countercont[] countlist;
	// Use this for initialization
	void Start () {
		loadValue ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void buttun()
    {
        Debug.Log("START");
		string Value = "";
		for (int i=0; i<countlist.Length; i++) {
			Debug.Log(countlist[i].textdisp.text+"="+countlist[i].num);
			Value += countlist[i].textdisp.text+"="+countlist[i].num +"\n";
		}
		sendMail (Value);
    }
	public void clearValue()
	{
		for (int i=0; i<countlist.Length; i++) {
			Debug.Log(countlist[i].textdisp.text+"="+countlist[i].num);
			PlayerPrefs.SetString(countlist[i].gameObject.name,
			                      countlist[i].textdisp.text+",0"); 
			
		}
		PlayerPrefs.Save ();
		loadValue();

	}
	private void saveValue()
	{
		for (int i=0; i<countlist.Length; i++) {
			Debug.Log(countlist[i].textdisp.text+"="+countlist[i].num);
			PlayerPrefs.SetString(countlist[i].gameObject.name,
			                      countlist[i].textdisp.text+","+countlist[i].num); 

		}
		PlayerPrefs.Save ();

	}
	private void loadValue()
	{
		for (int i=0; i<countlist.Length; i++) {
			string value=PlayerPrefs.GetString(countlist[i].gameObject.name,",0");
			string[] values = value.Split(',');
			if (values.Length == 2){
				countlist[i].setValues(values[0],values[1]);
			}

		}

	}

	void OnApplicationPause(bool iPause){
		if (iPause) {
			Debug.Log("SAVE");
			saveValue ();
		} else {
			loadValue ();
			Debug.Log("LOAD");
		}
	}
	void sendMail(string iValue) {
		string email    =   "yagi@region-umui.co.jp";
		string subject  =   "計測結果";
		string body     =   "計測結果\n"+ iValue;
		
		//エスケープ処理
		body    =System.Uri.EscapeDataString(body);
		subject =System.Uri.EscapeDataString(subject);
		
		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

}
