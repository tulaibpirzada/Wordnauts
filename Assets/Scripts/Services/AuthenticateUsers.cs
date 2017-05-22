using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AuthenticateUsers:Singleton<AuthenticateUsers>
{
    public void getuser()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInWithCustomTokenAsync("5ba32de").ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("SignInWithCustomTokenAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("SignInWithCustomTokenAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.Log("User signed in successfully: ");
            Debug.Log(newUser);
        });
    }

}

