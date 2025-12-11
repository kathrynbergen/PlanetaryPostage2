using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SpriteTools
{
    public static float TopPadding = 250f;
    public static Vector3 ConstrainToScreen(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        
        float topLimit = Screen.height - TopPadding;
        
        // if we're offscreen to the top
        if (SpriteTop(spriteRenderer) > topLimit)
            screenPosition.y = topLimit - SpriteHalfHeight(spriteRenderer);


        // if we're offscreen to the bottom
        if (SpriteBottom(spriteRenderer) < 0)
            screenPosition.y = SpriteHalfHeight(spriteRenderer);


        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
  
    private static float SpriteTop(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.y + SpriteHalfHeight(spriteRenderer);
    }


    private static float SpriteBottom(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.y - SpriteHalfHeight(spriteRenderer);
    }
  
    private static float SpriteHalfHeight(SpriteRenderer spriteRenderer)
    {
        float worldHalfHeight = spriteRenderer.bounds.extents.y;


        Vector3 screenTop = Camera.main.WorldToScreenPoint(
            spriteRenderer.transform.position + new Vector3(0, worldHalfHeight, 0)
        );


        Vector3 screenCenter = Camera.main.WorldToScreenPoint(
            spriteRenderer.transform.position
        );


        return screenTop.y - screenCenter.y;
    }
}