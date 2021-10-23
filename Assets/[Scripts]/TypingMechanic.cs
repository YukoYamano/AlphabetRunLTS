using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingMechanic : MonoBehaviour
{
    [SerializeField] private string[] Questions = {"ok", "hi","up","in"};
    //[SerializeField] private string[] middleQuestions = { "hello", "game" };
   
    private int questionNumber;
    private string stringQuestion;
    private int indexOfString;  //how many number of string.
    private string correctString;
    private int correctN;
    private int mistakeN;

    private Text displayQuestionText;
    private Text UII;
    private Text UIcorrectA;
    private Text mistakeNtext;
    public Text tutorialText;


    // Start is called before the first frame update
    void Start()
    {
        //Finiding gameObject named questionText and inside the component get Text.
        displayQuestionText = GameObject.Find("QuestionText").GetComponent<Text>();
        UII = GameObject.Find("InputText").GetComponent<Text>();
        UIcorrectA = GameObject.Find("CorrectAnswer").GetComponent<Text>();
        mistakeNtext = GameObject.Find("MistakeAnswer").GetComponent<Text>();
        

        correctN = 0;
        UIcorrectA.text = correctN.ToString();
        mistakeN = 0;
        mistakeNtext.text = mistakeN.ToString();

        DisplayQuestion();
    }

  


    // Update is called once per frame
    void Update()
    {
        Typing();
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
       
        yield return new WaitForSeconds(3.0f);
        // tutorialText.gameObject.SetActive(false);
        tutorialText.text = "";
    }



    public void Typing()
    {
        //checking the firstletter
        if (Input.GetKeyDown(stringQuestion[indexOfString].ToString()))
        {
            Correct();
           // Debug.Log(stringQuestion[indexOfString].ToString());
           // indexOfString++;


            if (indexOfString >= stringQuestion.Length)
            {
                //display other question
                DisplayQuestion();
                //Enable question text
                Debug.Log("Pass");
            }

        }else if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Spacekey igonered");
            }
            else
            {
                //you will die here. Try again text come! Restart from the beginning.  
                Wrong();
                correctN--;
                UIcorrectA.text = correctN.ToString();
            }
           
        }
   
        
    }

    private void DisplayQuestion()
    {
        displayQuestionText.text = "";
        UII.text = "";
        correctString = "";

        indexOfString = 0;
        questionNumber = Random.Range(0, Questions.Length);  //get random number through 0~3
        stringQuestion = Questions[questionNumber];   // 0~3  = 4questions
        displayQuestionText.text = stringQuestion;
    }

    void Correct()
    {
        correctN++;
        UIcorrectA.text = correctN.ToString();
        CorrectRate();
        //　正解した文字を表示
        correctString += stringQuestion[indexOfString].ToString();
        UII.text = correctString;
        //　次の文字を指す
        indexOfString++;
    }
    void Wrong()
    {
        mistakeN++;
        mistakeNtext.text = mistakeN.ToString();
    }

    void CorrectRate()
    {
        Debug.Log("Accuracy rate will be calculated");
    }
}
