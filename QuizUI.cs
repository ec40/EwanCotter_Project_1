//This file manages most of the UI aspects of the game
//It is also responsible for storing the correct answer information
//This code is very lightweight due to much of the content being able to be created stored as Unity's assets
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text timerText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private List<Button> options;
    [SerializeField] private Button tutorialButton, beginGameButton;
    [SerializeField] private Color correctCol, wrongCol, normalCol;

    //creates a list object in the unity UI which can be filled with the game panels as needed
    public List<GameObject> panels;

    public Text TimerText { get { return timerText; } }

    //Button indexes for correct answers of each stage
    public List<int> CaveAnswerList = new List<int> { 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1 };
    public List<int> ForestAnswerList = new List<int> { 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0 };
    public List<int> CastleAnswerList = new List<int> { 1, 2, 0, 1, 0, 1, 2, 1, 0, 1, 2, 0, 1, 1, 2 };

    //Indexing of the associated animation with each successful player counter - see 'successful()'
    public List<int> CavSuccessValueList = new List<int> { 2, 0, 0, 2, 3, 2, 0, 4, 4, 4, 0, 3, 4, 4, 4 };
    public List<int> ForSuccessValueList = new List<int> { 0, 1, 2, 4, 2, 2, 0, 2, 2, 4, 3, 4, 1, 2, 2 };
    public List<int> CasSuccessValueList = new List<int> { 1, 0, 4, 0, 0, 3, 0, 0, 4, 0, 0, 0, 3, 3, 3 };

    public int panelNo = 0;

    private List<int> CurrentAnswerList;
    private List<int> CurrentSuccesslist;
    private Scene currScene;

    //Animator objects - assigned in the unity UI
    public Animator Anim;
    public List<Animation> Enemyanim;
    public Animator Success;

    private void Start()
    {
        //checks what scene is currently loaded so it knows which answer list to look at
        currScene = SceneManager.GetActiveScene();
        if (currScene.buildIndex == 1)
        {
            CurrentAnswerList = CaveAnswerList;
            CurrentSuccesslist = CavSuccessValueList;
        } else if (currScene.buildIndex == 2)
        {
            CurrentAnswerList = ForestAnswerList;
            CurrentSuccesslist = ForSuccessValueList;
        } else if (currScene.buildIndex == 3)
        {
            CurrentAnswerList = CastleAnswerList;
            CurrentSuccesslist = CasSuccessValueList;
        }

    }
    
    //Button press handler
    public void ButtonCheck(Button btn)
    {
        if (btn.name == "Answer 0")
        {
            OnClick(0);
        }
        else if (btn.name == "Answer 1")
        {
            OnClick(1);
        } else if (btn.name == "Answer 2")
        {
            OnClick(2);
        }


    }
    
    //Correct answer checker
    private void OnClick(int val)
    {

        if (val != CurrentAnswerList[panelNo])
        {
            quizManager.Answer(false);
            StartCoroutine(wait(0));
        }
        else
        {
            StartCoroutine(wait(1));
        }

        //Responsible for what happens directly after player selects an answer
        IEnumerator wait(int i)
        {
            if (i == 0)
            {
                //enemy lunges forward
                Enemyanim[panelNo].Play("enemy attack");
                
                //wait for animations to complete
                yield return new WaitForSeconds(1);
                
                //next panel
                NextPanel(panelNo);
                panelNo++;
            }
            else if (i == 1)
            {
                //play successful counter animation
                successful(CurrentSuccesslist[panelNo]);
                
                //play enemy dies animation
                Enemyanim[panelNo].Play("Enemy die");
                
                //wait for animations to complete
                yield return new WaitForSeconds(1);
                
                //next panel
                NextPanel(panelNo);
                
                //successful answer sound
                SoundManagerScript.PlaySound("ding");
                panelNo++;
            }

        }
    }
    //Called when player dies or clicks restart
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Animates the number of hit points the player has(in the form of empty/full hearts)
    public void ReduceLife(int index)
    {
        lifeImageList[index].color = wrongCol;
    }

    //Responsible for each player counter animation category, called when player gets an asnwer correct
    void successful(int val)
    {
        if (val == 0)
        {
            Success.Play("Magdefend");
        }
        if (val == 1)
        {
            Success.Play("Magattack");
        }
        if (val == 2)
        {
            Success.Play("Meldefend");
        }
        if (val == 3)
        {
            Success.Play("Misattack");
        }
        if (val == 4)
        {
            Success.Play("Misdefend");
        }

    }

    //Activates current panel in sequence, deactivates completed panel
    public void NextPanel(int panelIndex)
    {
        if (panelIndex != 14)
        {
            panels[panelIndex].SetActive(false);
            
            //plays an animation for the enemy moving into frame
            Enemyanim[panelIndex + 1].Play("moving in anim");
        }
        else
        {
            //loads next stage if the last panel is reached
            LoadNextLevel();
        }
    }

    //Responsible for moving to the next scene
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Creates a 'fade-in/fade-out' animation from scene to scene
    IEnumerator LoadLevel(int levelIndex)
    {
        //triggers 'fade-out' animation
        Anim.SetTrigger("start");
        
        //waits for animation to complete(go fully black)
        yield return new WaitForSeconds(0.5f);

        //loads next scene
        SceneManager.LoadScene(levelIndex);
        
        //Each new scene has a default animation set within unity to 'fade-in'(i.e does not need to be triggered with code)
        //Fade in/out is achieved by placing a non-interactable layer on top of the scene and create an animation that slowly fills the layer with black and vice versa
    }
}


