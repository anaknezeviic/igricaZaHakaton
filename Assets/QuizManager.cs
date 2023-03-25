using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
	public List<QuestionAndAnswers> QnA;
	public GameObject[] options;
	public int currentQuestion;

	public Text QuestionTxt;

	private void Start(){
		generateQuestion();
	}

	public void correct(){
		QnA.RemoveAt(currentQuestion);
		if (QnA.Count > 0 )	
			generateQuestion();
			else
			{
				if(options[0].GetComponent<AnswersScript>().isCorrect == true)
					// SceneChanger.ChangeScene("dobraScena");
					Debug.Log("gas");
				else
					Debug.Log("gas");
					// SceneChanger.ChangeScene("losaScena");
			}
	}

	void SetAnswers(){
		for(int i = 0; i < options.Length; i++){
			options[i].GetComponent<AnswersScript>().isCorrect = false;
			options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
			
			if(QnA[currentQuestion].CorrectAnswer == i+1){
				options[i].GetComponent<AnswersScript>().isCorrect = true;
			}
		}
	}

	void generateQuestion(){
		currentQuestion = Random.Range(0, QnA.Count);
		Debug.Log("Current q: " + currentQuestion);
		QuestionTxt.text = QnA[currentQuestion].Question;
		SetAnswers();

		
	}
}
