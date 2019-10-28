using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{

    public GameObject panelQuestion1;

    public Question[] questions;
    private static List<Question> unansweredQuestion;
    private Question currentQuestion;

    [SerializeField]
    private TextMeshProUGUI factText;


    [SerializeField]
    private TextMeshProUGUI trueAnswerText;

    [SerializeField]
    private TextMeshProUGUI falseAnswerText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    Animator animator;

    public int contQuestions = 0;
    public int qtdCorretas = 0;


    void Start()
    {

        if(unansweredQuestion == null || unansweredQuestion.Count == 0)
        {
            unansweredQuestion = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        
        
    }


    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestion.Count);
        currentQuestion = unansweredQuestion[randomQuestionIndex];

        unansweredQuestion.Remove(currentQuestion);

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "CORRETO";
            falseAnswerText.text = "ERRADO";
        }
        else
        {
            trueAnswerText.text = "ERRADO";
            falseAnswerText.text = "CORRETO";
        }

        contQuestions++;

    }

    IEnumerator TransitionToNextQuestion()
    {
        if (contQuestions < 10)
        {

            yield return new WaitForSeconds(timeBetweenQuestions);

            animator.SetTrigger("No");

            panelQuestion1.SetActive(false);
            panelQuestion1.SetActive(true);

            SetCurrentQuestion();
        }
        else
        {
            Debug.Log("ACABOU, você acertou " +qtdCorretas+ " de 10 questões");
            panelQuestion1.SetActive(false);
        }

    }

        public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRETO");
            qtdCorretas++;
            
        }
        else
        {
            Debug.Log("BURRO");
        }

        StartCoroutine(TransitionToNextQuestion());
    
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRETO");
            qtdCorretas++;
           
        }
        else
        {
            Debug.Log("BURRO");
        }
        StartCoroutine(TransitionToNextQuestion());
    }

}
