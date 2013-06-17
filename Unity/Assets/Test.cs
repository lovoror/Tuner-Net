using UnityEngine;
using System.Collections;
using TNet.Client;
using System.IO;

public class Test : MonoBehaviour {

	// Use this for 
    int id;
    void Awake()
    {
        id = Random.Range(1, 10);
        TNetMgr.Instance.Init(new DP_TNet_Adapter());
		TNetMgr.Instance.Connect("192.168.1.138", 9298);
      
        
    }
	void Start () {
        if (TNetMgr.Instance.IsConnected())
        {
            testSend();
        }
	}

    void testSend()
    {
// 
//  TunerMessage.TMLogin temp = new TunerMessage.TMLogin();
//  temp.username = "cotngf";
//   temp.password = "dlkeyf";
//    TNetMgr.Instance.SendNetMessage<TunerMessage.TMLogin>(1, temp);

        TunerMessage.TMLogin temp = new TunerMessage.TMLogin();
        temp.Username = "cotngf1";
        temp.Password = "dlkeyf1";

        MemoryStream tempStream = new MemoryStream();
        TunerMessage.TMLogin.Serialize(tempStream, temp);



        TNetMgr.Instance.SendNetMessage(1, tempStream);
        
       // TunerMessage.TMLogin.Serialize()
    }
	
	// Update is called once per frame
	void Update () {
        TNetMgr.Instance.Update();
      //
	}
}
