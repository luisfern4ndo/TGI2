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
        if(qtdCorretas < 6)
        {
            yield return new WaitForSeconds(1f);
            panelQuestion1.SetActive(false);
            yield return new WaitForSeconds(2.2f);
            gamePlayer.GetComponent<Animator>().SetBool("gameover", true);
            txtFINAL.GetComponent<TextMeshProUGUI>().text = "<b>GAME OVER</b>\n Foi acertado " + qtdCorretas+ "/10 questões, o vírus ganhou esta batalha e os robos estão se destruindo, no final das contas os humanos não deixaram barato. Obrigado por jogar este beta!  Esperamos que tenha se divertido e aprendido algo \n\nLuis Fernando de Góis Teixeira\nGuilherme Guimarães\nUniversidade Cruzeiro do Sul";
            yield return new WaitForSeconds(5f);
            panelFINAL.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(1f);
            panelQuestion1.SetActive(false);
            txtFINAL.GetComponent<TextMeshProUGUI>().text = "<b>MISSÃO CUMPRIDA!</b>\nVocê acertou " + qtdCorretas + "/10 questões, o virus foi derrotado e o reinado dos robôs poderá finalmente prosperar. Obrigado por ter jogado este beta! Esperamos que tenha se divertido e aprendido algo \n\nLuis Fernando de Góis Teixeira\nGuilherme Guimarães\nUniversidade Cruzeiro do Sul";
            yield return new WaitForSeconds(3f);
            gameBOSS.GetComponent<BossDerrota>().derrotado = true;
            yield return new WaitForSeconds(5f);
            panelFINAL.SetActive(true);
        }  

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
