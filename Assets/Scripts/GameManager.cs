using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /*
     * List of all units/buildings
     * Action phase coroutine
     * Decision phase coroutine
     */

    public BaseManager[] bases;
    public GameObject[] prefabs;

    public int roundLimit = 30;
    public float startDelay = 1f;
    public float endDelay = 1f;

    // index 0 is player 1, index 1 is player 2
    public Transform[] laneSpawnPoint;
    public Transform[] building1SpawnPoint;
    public Transform[] building2SpawnPoint;

    public Camera actionPhaseCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    public Camera decisionPhaseCamera1 = GameObject.Find("Player1Camera").GetComponent<Camera>();
    public Camera decisionPhaseCamera2 = GameObject.Find("Player2Camera").GetComponent<Camera>();

    private int currentPlayer;
    private int currentRound;
    private int winner;
    private bool gameEnd;
    private WaitForSeconds turnStartWait;
    private WaitForSeconds turnEndWait;
    private CountdownTimer timer;

    // Start is called before the first frame update
    void Start()
    {
        actionPhaseCamera.enabled = false;
        decisionPhaseCamera1.enabled = true;
        decisionPhaseCamera2.enabled = false;
        turnStartWait = new WaitForSeconds(startDelay);
        turnEndWait = new WaitForSeconds(endDelay);
        currentPlayer = 0;
        currentRound = 0;
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GameLoop()
    {
        currentRound++;
        // Player 1 decision phase

        yield return StartCoroutine(DecisionStarting());
        yield return StartCoroutine(DecisionDuring());
        yield return StartCoroutine(DecisionEnding());

        // Player 2 decision phase
        yield return StartCoroutine(DecisionStarting());
        yield return StartCoroutine(DecisionDuring());
        yield return StartCoroutine(DecisionEnding());

        // Shared action phase
        yield return StartCoroutine(ActionStarting());
        yield return StartCoroutine(ActionDuring());
        yield return StartCoroutine(ActionEnding());


        if (gameEnd)
        {
            Debug.Log("Game over: player " + (winner + 1).ToString() + " lost");
            // Application.LoadLevel();
        }
        else if (currentRound < roundLimit)
            StartCoroutine(GameLoop());
        else
        {
            gameEnd = true;
            Debug.Log("Game over: max rounds reached");
        }
    }

    private IEnumerator DecisionStarting()
    {
        // display that it's current player's turn to decide
        if (currentPlayer == 0)
        {
            cameraSwitch.camerChange(decisionPhaseCamera1, actionPhaseCamera, decisionPhaseCamera2);
        }else if (currentPlayer == 1)
        {
            cameraSwitch.camerChange(decisionPhaseCamera2, actionPhaseCamera, decisionPhaseCamera1);
        }
        timer.reset();
        timer.startCountdown();
        yield return turnStartWait;
    }

    private IEnumerator DecisionDuring()
    {
        // give current player decision phase controls
        while (!timer.expired)
        {
            yield return null;
        }
    }

    private IEnumerator DecisionEnding()
    {
        currentPlayer = 1 - currentPlayer; // switch current player for next decision phase
        // start delay for starting action phase
        yield return turnEndWait;
    }

    private IEnumerator ActionStarting()
    {
        // turn on action phase controls
        cameraSwitch.camerChange(actionPhaseCamera,decisionPhaseCamera1,decisionPhaseCamera2);
        // start countdown
        timer.reset();
        timer.startCountdown();
        yield return turnStartWait;
    }

    private IEnumerator ActionDuring()
    {
        // also need to check that base health is nonzero for both players
        int loser = -1;
        while ((loser = playerLost()) < 0 && !timer.expired)
        {
            yield return null;
        }
        if (loser >= 0)
        {
            gameEnd = true;
            winner = 1 - loser;
        }
    }

    private IEnumerator ActionEnding()
    {
        // turn off action phase controls for both players
        
        // start delay for starting decision phase
        yield return turnEndWait;
    }

    private int playerLost()
    {
        if (bases[0].health == 0)
        {
            return 0;
        }
        else if (bases[1].health == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private string getCurrentPlayerTag()
    {
        return "Player" + (currentPlayer+1);
    }

    public void spawnBuilding(int lane, int card)
    {
        GameObject building = Instantiate(prefabs[card], building1SpawnPoint[currentPlayer]);
        building.tag = getCurrentPlayerTag();
    }

    public void spawnMinion(int lane, int card)
    {
        // lane doesn't matter for now, there's only one lane
        GameObject minion = Instantiate(prefabs[card], laneSpawnPoint[currentPlayer]);
        minion.tag = getCurrentPlayerTag();
    }
}
