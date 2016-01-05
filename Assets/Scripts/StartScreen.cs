using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


using System.Collections.Generic;
using System.Linq;

public class StartScreen : MonoBehaviour {

	private readonly List<PlayPhone.Billing.PurchaseDetails> restoredPurchaseDetails 
	= new List<PlayPhone.Billing.PurchaseDetails>();

	void Start ()
	{
		InitPlayphone ();
		InitBilling ();
	}

	void InitPlayphone() {
		PlayPhone.Plugin.IncrementTracking();

		PlayPhone.Plugin.OnInit += () => 
		{
			PlayPhone.Plugin.ShowIcon();
			PlayPhone.Plugin.GetLaunchScreen();
		};

		PlayPhone.Plugin.OnInitError += (error) =>
		{
			Debug.Log("ERROR LEH");//report error message;
		};

		PlayPhone.Plugin.Init();
	}

	void InitBilling() {
		PlayPhone.Billing.OnSuccess += (purchaseDetails) => 
		{ 
			Debug.Log("Purchased: " + purchaseDetails.Name);
		};
		PlayPhone.Billing.OnError += (error) => 
		{ 
			Debug.Log("Error: " + error);
		};
		PlayPhone.Billing.OnCancel += () => 
		{ 
			Debug.Log("Canceled");
		};
		PlayPhone.Billing.OnRestore += (purchaseDetails) => 
		{
			restoredPurchaseDetails.Add(purchaseDetails);
			var names = (from p in restoredPurchaseDetails select string.Format("{0}(id={1})", p.Name, p.ItemId)).ToArray();
			Debug.Log("Restored: " + string.Join(", ", names));
		};
	}
	void OnApplicationQuit() {
		PlayPhone.Plugin.DecrementTracking();
	}

	void Update() {
		if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	public void OnBtnClickEasy() {
		DiscMovement.speed = 0.03f;
		PlayPhone.Billing.Purchase ("21972");
		//SceneManager.LoadScene ("main");
	}
	
	public void OnBtnClickMedium() {
		DiscMovement.speed = 0.1f;
		var leaderboardId = "1784";
		var score = 42;
		PlayPhone.MyPlay.SubmitScore (leaderboardId, score);
		//SceneManager.LoadScene ("main");
	}
	
	public void OnBtnClickHard() {
		DiscMovement.speed = 0.2f;		
		var achievementId = "3890";
		PlayPhone.MyPlay.UnlockAchievement (achievementId);
		//SceneManager.LoadScene ("main");
	}
}
