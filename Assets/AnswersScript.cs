using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{

	public bool isCorrect = false;

	public QuizManager QuizManager;
	public void Answer(){
		if(isCorrect){
			Debug.Log("Correct Answer");
			QuizManager.correct();
			// GameBehavior.Instance.SceneToMoveTo("dobraScena");
		}else{
			Debug.Log("Wrong Answer");
			QuizManager.correct();
		}
	}
}
