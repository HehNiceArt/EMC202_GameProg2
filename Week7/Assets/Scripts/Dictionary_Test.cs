using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary_Test : MonoBehaviour
{
    // pairs
    //      <Keytype,Valuetype>
    Dictionary<string, int> BountyPirates = new Dictionary<string, int>()
    {
        {"Luffy", 300_000_000},
        {"Chopper", 1000}
    };
    Dictionary<string, string> CelestialDragon = new Dictionary<string, string>()
    {
        {"Saturn", "EggHead"}
    };

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdateBounty("Luffy", 600_000_000);
            Debug.Log("aa");
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            AddPirates("Aaron Magat", 999_999);
            Debug.Log("Pirate Count: " + BountyPirates.Count);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (CelestialDragon.ContainsKey("Saturn") && CelestialDragon.ContainsValue("EggHead"))
            {
                DeletePirates("Aaron Magat");
                Debug.Log("fuck");
            }
        }
    }
    void AddPirates(string pirateName, int bounty)
    {
        BountyPirates.Add(pirateName, bounty);
    }
    void UpdateBounty(string bountyName, int newBounty) 
    {
        BountyPirates[bountyName] = newBounty;
    }
    void DeletePirates(string pirateName)
    {
        BountyPirates.Remove(pirateName);
    }
}
