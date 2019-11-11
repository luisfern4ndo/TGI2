using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{

    public GameObject gamePlayer;
    public GameObject gameBOSS;
    public GameObject consoleTotalColecionaveis;

    public GameObject panelQuestion1;
    public GameObject panelFINAL;
    public TextMeshProUGUI txtFINAL;

    public Question[] questions;
    private static List<Question> unansweredQuestion;
    private Question currentQuestion;

    [SerializeField]
    private TextMeshProUGUI factText;


    public GameObject trueButton;
    public GameObject falseButton;
    [SerializeField]
    private TextMeshProUGUI trueAnswerText;
    [SerializeField]
    private TextMeshProUGUI falseAnswerText;

    [SerializeField]
    private float timeBetweenQuestions = 1.1f;

   [SerializeField]
   private float timeResposta = 0.8f;

    [SerializeField]
    Animator animator;

    public int contQuestions = 0;
    public int qtdCorretas = 0;


    void Start()
    {

        if (unansweredQuestion == null || unansweredQuestion.Count == 0) 
        {
            unansweredQuestion = questions.ToList<Question>();
        }

        trueButton.GetComponent<Button>().enabled = false;
        falseButton.GetComponent<Button>().enabled = false;
        SetCurrentQuestion();
       
    }


    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestion.Count);
        currentQuestion = unansweredQuestion[randomQuestionIndex];
        factText.text = currentQuestion.fact;    


        trueButton.GetComponent<Button>().enabled = true;
        falseButton.GetComponent<Button>().enabled = true;

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
        Debug.Log("lista: " + unansweredQuestion.Count + " index: " + randomQuestionIndex);
        StartCoroutine(tempoResposta());

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestion.Remove(currentQuestion);
        if (contQuestions < 10)
        {
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
            Debug.Log("ACABOU, você acertou " +qtdCorretas+ " de 10 questões");
            consoleTotalColecionaveis.SetActive(true);
            StartCoroutine(final());
        }

    }

     IEnumerator tempoResposta()
     {
      yield return new WaitForSeconds(timeResposta);
        trueAnswerText.GetComponent<TextMeshProUGUI>().enabled = true;
        falseAnswerText.GetComponent<TextMeshProUGUI>().enabled = true;
     }

    IEnumerator final()
    {
        unansweredQuestion = questions.ToList<Question>();
        if (qtdCorretas < 6)
        {
            yield return new WaitForSeconds(1f);
            panelQuestion1.SetActive(false);
            yield return new WaitForSeconds(2.2f);
            gamePlayer.GetComponent<Animator>().SetBool("gameover", true);
            txtFINAL.GetComponent<TextMeshProUGUI>().text = "<b>GAME OVER</b>\n Foi acertado " + qtdCorretas+ "/10 questões, o vírus ganhou esta batalha e os robos estão se destruindo, no final das contas os humanos não deixaram barato. Obrigado por jogar este beta!  Esperamos que tenha se divertido e aprendido algo";
            yield return new WaitForSeconds(5f);
            panelFINAL.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(1f);
            panelQuestion1.SetActive(false);
            txtFINAL.GetComponent<TextMeshProUGUI>().text = "<b>MISSÃO CUMPRIDA!</b>\nVocê acertou " + qtdCorretas + "/10 questões, o virus foi derrotado e o reinado dos robôs poderá finalmente prosperar. Obrigado por ter jogado este beta! Esperamos que tenha se divertido e aprendido algo";
            gameBOSS.GetComponent<BossDerrota>().derrotado = true;
            yield return new WaitForSeconds(5f);
            panelFINAL.SetActive(true);
        }  

    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        
            if (currentQuestion.isTrue)
        {
            qtdCorretas++;

        }
        trueButton.GetComponent<Button>().enabled = false;
        falseButton.GetComponent<Button>().enabled = false;
        StartCoroutine(TransitionToNextQuestion());
    
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        

            if (!currentQuestion.isTrue)
            {
                qtdCorretas++;
            }

        trueButton.GetComponent<Button>().enabled = false;
        falseButton.GetComponent<Button>().enabled = false;
        StartCoroutine(TransitionToNextQuestion());
        
    }

}
