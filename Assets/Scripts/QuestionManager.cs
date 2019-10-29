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
    private float timeBetweenQuestions = 1.1f;

    public bool aguardeNovaQuest = false;

    [SerializeField]
    private float timeResposta = 1.15f;

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
        aguardeNovaQuest = false;

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
        StartCoroutine(tempoResposta());

    }

    IEnumerator TransitionToNextQuestion()
    {
        if (contQuestions < 10)
        {
            aguardeNovaQuest = true;
            yield return new WaitForSeconds(timeBetweenQuestions);

            animator.SetTrigger("No");

            panelQuestion1.SetActive(false);
            trueAnswerText.GetComponent<TextMeshProUGUI>().enabled = false;
            falseAnswerText.GetComponent<TextMeshProUGUI>().enabled = false;
            panelQuestion1.SetActive(true);

            SetCurrentQuestion();
        }
        else
        {
            aguardeNovaQuest = true;
            Debug.Log("ACABOU, você acertou " +qtdCorretas+ " de 10 questões");
            panelQuestion1.SetActive(false);
        }

    }

    IEnumerator tempoResposta()
    {
        yield return new WaitForSeconds(timeResposta);
        trueAnswerText.GetComponent<TextMeshProUGUI>().enabled = true;
        falseAnswerText.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        
            if (currentQuestion.isTrue && aguardeNovaQuest == false)
        {
            qtdCorretas++;

        }
            StartCoroutine(TransitionToNextQuestion());
    
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        

            if (!currentQuestion.isTrue && aguardeNovaQuest == false)
            {
                qtdCorretas++;
            }

            StartCoroutine(TransitionToNextQuestion());
        
    }

}
