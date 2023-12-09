using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard instance;
    // Create a leaderboard with this ID in the Unity Cloud Dashboard
    const string LeaderboardId = "Your ID";

    public string playerName;

    public LeaderboardData leaderboardData;

    string VersionId { get; set; }
    int Offset { get; set; }
    int Limit { get; set; }
    int RangeLimit { get; set; }
    List<string> FriendIds { get; set; }

    async void Awake()
    {
        await UnityServices.InitializeAsync();


        if(!AuthenticationService.Instance.IsSignedIn)
            await SignInAnonymously();

        Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);    

        if (instance == null)
        {
            instance = this;
        }
    }

    async Task SignInAnonymously()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);
        };
        AuthenticationService.Instance.SignInFailed += s =>
        {
            // Take some action here...
            Debug.Log(s);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void AddScore(int score)
    {
        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, score);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetScores()
    {
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoresResponse));
        
        JsonUtility.FromJsonOverwrite(JsonConvert.SerializeObject(scoresResponse), leaderboardData);
        


    }

    public async void GetPaginatedScores()
    {
        Offset = 10;
        Limit = 10;
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId, new GetScoresOptions{Offset = Offset, Limit = Limit});
        Debug.Log(JsonConvert.SerializeObject(scoresResponse));

        JsonUtility.FromJsonOverwrite(JsonConvert.SerializeObject(scoresResponse), leaderboardData);

        
    }

    public async void GetPlayerScore()
    {
        var scoreResponse = 
            await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetVersionScores()
    {
        var versionScoresResponse =
            await LeaderboardsService.Instance.GetVersionScoresAsync(LeaderboardId, VersionId);
    Debug.Log(JsonConvert.SerializeObject(versionScoresResponse));
    }

    public async void UpdatePlayerName()
    {
        AuthenticationService.Instance.UpdatePlayerNameAsync(playerName);
    }
}
