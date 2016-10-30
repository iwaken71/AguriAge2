using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldScript : MonoBehaviour {

	[SerializeField]
	InputField field;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			PushAddButton ();
		}
	}

	public void PushAddButton(){
		int inputNumber = 0;
		string inputString = field.text;
		bool isIntNumber = int.TryParse (inputString, out inputNumber);
		if (isIntNumber) {
			GameManeger.instance.AddAge (inputNumber);
			field.text = "";
			field.ActivateInputField ();

		} else {
			field.text = "";
			field.ActivateInputField ();
		}
	}

	public void PushDoneButton(){
		GameManeger.instance.FinishInput ();
		SceneManager.LoadScene ("Result");
	}
}
