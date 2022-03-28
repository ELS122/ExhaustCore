using MSCLoader;
using UnityEngine;
using HutongGames.PlayMaker;

namespace ExhaustCore
{
    public class ExhaustController : MonoBehaviour
    {
        public FsmBool[][] installedBoolArray = new FsmBool[0][];
        public GameObject[] exhaustObjects;

        public void Update()
        {
            int score = 0;

            for (int i = 0; i < installedBoolArray.Length; i++)
            {
                int score2 = 0;
                for (int e = 0; e < installedBoolArray[i].Length; e++)
                    if (installedBoolArray[i][e] != null && installedBoolArray[i][e].Value)
                        score2++;
                    else
                        break;
                
                if (score2 >= score)
                    score = score2;
            }

            for (int i = 0; i < exhaustObjects.Length; i++)
                exhaustObjects[i].SetActive(i == score);
        }
    }

    public class ExhaustCore : Mod
    {
        public override string ID => "ExhaustCore";
        public override string Name => "ExhaustCore";
        public override string Author => "ELS";
        public override string Version => "1.0";
        public override bool UseAssetsFolder => false;



        public override void OnLoad()
        {
            GameObject exhaustSimObject = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation").transform.GetChild(0).gameObject;
            PlayMakerFSM exhaustSim = exhaustSimObject.GetComponent<PlayMakerFSM>();

            ExhaustController ec = exhaustSimObject.AddComponent<ExhaustController>();
            ec.exhaustObjects = new GameObject[]
            {
                GameObject.Find("SATSUMA(557kg, 248)/CarSimulation").transform.GetChild(0).GetChild(3).gameObject,
                GameObject.Find("SATSUMA(557kg, 248)/CarSimulation").transform.GetChild(0).GetChild(1).gameObject,
                GameObject.Find("SATSUMA(557kg, 248)/CarSimulation").transform.GetChild(0).GetChild(2).gameObject,
                GameObject.Find("SATSUMA(557kg, 248)/CarSimulation").transform.GetChild(0).GetChild(0).gameObject
            };

            ec.installedBoolArray = new FsmBool[][]
            {
                new FsmBool[]
                {
                    exhaustSim.FsmVariables.FindFsmGameObject("db_Required1").Value.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("Installed"),
                    exhaustSim.FsmVariables.FindFsmGameObject("db_Required3").Value.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("Installed"),
                    exhaustSim.FsmVariables.FindFsmGameObject("db_Required5").Value.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("Installed")
                },
                new FsmBool[]
                {
                    exhaustSim.FsmVariables.FindFsmGameObject("db_Required2").Value.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("Installed"),
                    exhaustSim.FsmVariables.FindFsmGameObject("db_Required4").Value.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("Installed"),
                    exhaustSim.FsmVariables.FindFsmGameObject("db_Required6").Value.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmBool("Installed")
                }
            };
            Object.Destroy(exhaustSim);
        }

    }
}
