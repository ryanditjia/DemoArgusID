using UnityEngine;
using TMPro;
using Nakama;
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MenuManager : MonoBehaviour
{
    public TMP_Text jwtText;

    [DllImport("__Internal")]
    private static extern void InitiateLogin();

    static string sha256(string jwt)
    {
        var crypt = new System.Security.Cryptography.SHA256Managed();
        var hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(jwt));
        foreach (byte theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }
        return hash.ToString();
    }

    // This exact function name is required by Argus Web Player (React) to communicate the JWT to Unity
    public async void ReceiveJWT(string jwt)
    {
        Debug.Log("Unity: Received JWT: " + jwt);
        jwtText.text = "JWT received";

        var client = new Client("defaultkey", UnityWebRequestAdapter.Instance);

        string id = sha256(jwt);
        Debug.Log("Unity: ID: " + id);

        var vars = new Dictionary<string, string>
        {
            { "type", "argus" },
            { "jwt", jwt }
        };

        var session = await client.AuthenticateCustomAsync(id, username: "dummy-username", create: true, vars: vars);
        Debug.Log("Unity: Session: " + session);
    }

   public void Login()
   {
        Debug.Log("Unity: Initiating login");
        #if UNITY_WEBGL == true && UNITY_EDITOR == false
            InitiateLogin();
        #endif
   }
}
