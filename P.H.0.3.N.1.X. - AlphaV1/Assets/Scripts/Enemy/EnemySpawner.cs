using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject ManipulatorPrefab;
    [SerializeField] private GameObject TransportPrefab;
    [SerializeField] private GameObject MagneticPrefab;
    [SerializeField] private GameObject ElectricPrefab;
    [SerializeField] private GameObject DestroyerPrefab;
    [SerializeField] private GameObject BatteryPrefab;
    [SerializeField] private GameObject CrabPrefab;

    [SerializeField] private float spawnInterval = 5.0f;

    [SerializeField] private float spawnDistanceX;
    [SerializeField] private float spawnDistanceY;

    [SerializeField] private List<GameObject> userSpawnedRobots = new List<GameObject>();
    private Dictionary<GameObject, Robot> trackedRobots = new Dictionary<GameObject, Robot>();

    [SerializeField] private SoundData soundDataSpawner1;
    [SerializeField] private SoundData soundDataSpawner2;
    [SerializeField] private SoundData soundDataSpawner3;

    private List<GameObject> EnemyFormList;


    private void Start()
    {
        StartCoroutine(initialize());
        LoadRobotList();
    }

    public void UpdateCurrentRobotsList(GameObject caller)
    {
        StartCoroutine(SpawnRobot(new Robot(trackedRobots[caller].m_form, trackedRobots[caller].m_position)));
        trackedRobots.Remove(caller);
    }

    private IEnumerator initialize()
    {
        yield return new WaitForEndOfFrame();
        LoadUserSpawnedRobots();
    }

    private void LoadRobotList()
    {
        EnemyFormList = new List<GameObject>();

        EnemyFormList.Add(ManipulatorPrefab);
        EnemyFormList.Add(TransportPrefab);
        EnemyFormList.Add(MagneticPrefab);
        EnemyFormList.Add(ElectricPrefab);
        EnemyFormList.Add(DestroyerPrefab);
        EnemyFormList.Add(BatteryPrefab);
        EnemyFormList.Add(CrabPrefab);
    }

    private IEnumerator SpawnRobot(Robot robot)
    {
        yield return new WaitForSeconds(spawnInterval);

        GameObject newEnemy = Instantiate(
            EnemyFormList[(int)robot.m_form],
            new Vector3(
                Random.Range(transform.position.x - spawnDistanceX, transform.position.x + spawnDistanceX) + 0.5f,
                Random.Range(transform.position.y - spawnDistanceY, transform.position.y + spawnDistanceY) + 0.5f,
                0
            ),
            Quaternion.identity
        );

        trackedRobots.Add(newEnemy, robot);
        yield return 0;

        newEnemy.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        newEnemy.GetComponent<EnemyController>().UpdatePreferredPosition(robot.m_position);

        RandomSpawnerSound();
    }

    private void LoadUserSpawnedRobots()
    {
        foreach(GameObject robot in userSpawnedRobots)
        {
            Form robotForm = robot.GetComponent<CharacterFormsController>().currForm;

            trackedRobots.Add(robot, new Robot(robotForm, robot.transform.position));

            robot.GetComponent<EnemyInteraction>().deathEvent.AddListener(UpdateCurrentRobotsList);
        }
    } 

    private void RandomSpawnerSound()
    {
        //Get a random number
        int randNum = Random.Range(1, 4);

        //Pick a jump sound
        switch (randNum)
        {
            case 1:
                //Play the jump sound 1
                GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataSpawner1);
                break;
            case 2:
                //Play the jump sound 2
                GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataSpawner2);
                break;
            case 3:
                //Play the jump sound 3
                GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataSpawner3);
                break;
        }
    }
}

public struct Robot
{
    public Robot(Form form, Vector3 position)
    {
        m_form = form;
        m_position = position;
    }

    public Form m_form;
    public Vector3 m_position;
}