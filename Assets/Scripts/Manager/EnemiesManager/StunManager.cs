using System.Collections;
using UnityEngine;

public class StunManager : MonoBehaviour
{
    public static void ApplyStunToPlayer(Player player, float stunDuration)
    {
        player.InputController.BlockInputsEffect();
        player.StartCoroutine(ReleaseStun(player, stunDuration));
    }

    private static IEnumerator ReleaseStun(Player player, float stunDuration)
    {
        yield return new WaitForSeconds(stunDuration);
        player.InputController.UnlockInputsEffect(); 
    }
}
