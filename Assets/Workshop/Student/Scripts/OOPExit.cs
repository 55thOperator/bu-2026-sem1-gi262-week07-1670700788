using Searching;
using UnityEngine;

namespace Solution
{

    public class OOPExit : Identity
    {
        public Leaderboard leaderboard;
        public string ItemToOpen = "Key";
        public int ItemAmountToOpen = 2;
        
        public override bool Hit()
        {
            bool IsHasItemAmount = mapGenerator.player.inventory.HasItem(ItemToOpen, ItemAmountToOpen);
            if (IsHasItemAmount)
            {
                mapGenerator.player.inventory.UseItem(ItemToOpen, ItemAmountToOpen);
                leaderboard.gameObject.SetActive(true);

                Debug.Log("You win");
                //add code to manage leaderboard scores
    
                return true;
            }
            else {
                Debug.Log("Need Item " + ItemToOpen + " to Open");
                return false;
            }
        }
        //Logic CalculateScore
        int CalculateScore() {
            int score = (int)((mapGenerator.player.energy * 100) / Time.time);
            return score;
        }
    }
}