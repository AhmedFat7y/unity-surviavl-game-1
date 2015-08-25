using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
  [Serializable]
  public class PlayerGUIComponent
  {
    public Vector2 ComponentSize;
    public Vector2 ComponentPosition;
    float MaxComponentBarDisplay;
    float ComponentBarDisplay;
    float MinComponentBarDisplay;
    [SerializeField]
    private Texture2D ComponentBarFullTexture;
    [SerializeField]
    private Texture2D ComponentBarEmptyTexture;
    [SerializeField]
    private int FallRate;
    [SerializeField]
    //public float FallRateMultiplier;
    public PlayerGUIComponent(Vector2 componentSize, Vector2 componentPosition, int fallRate) : this(componentSize, componentPosition, fallRate, null, null)
    {
      
    }
    public PlayerGUIComponent(Vector2 componentSize, Vector2 componentPosition, int fallRate, Texture2D componentBarFullTexture, Texture2D componentBarEmptyTexture, float maxComponentBarDisplay = 1, float minComponentBarDisplay = 0)
    {
      this.ComponentPosition = componentPosition;
      this.MaxComponentBarDisplay = maxComponentBarDisplay;
      this.MinComponentBarDisplay = minComponentBarDisplay;
      this.ComponentBarFullTexture = componentBarFullTexture;
      this.ComponentBarEmptyTexture = componentBarEmptyTexture;
      this.FallRate = fallRate;
      this.ComponentSize = componentSize;
    }

    public void Render()
    {
      GUI.BeginGroup(new Rect(this.ComponentPosition, this.ComponentSize));
      GUI.Box(new Rect(Vector2.zero, this.ComponentSize), this.ComponentBarEmptyTexture);
      
      GUI.BeginGroup(new Rect(this.ComponentPosition, this.ComponentSize));
      GUI.Box(new Rect(Vector2.zero.x, Vector2.zero.y, this.ComponentSize.x * this.ComponentBarDisplay, this.ComponentSize.y), this.ComponentBarFullTexture);
      GUI.EndGroup();
      GUI.EndGroup();
    }
    public bool IsEmpty()
    {
      return ComponentBarDisplay == 0;
    }
    public bool IsFull()
    {
      return ComponentBarDisplay == 1;
    }
    public void Update(int multiplier = 1)
    {
      if (ComponentBarDisplay > 0) 
      {
        ComponentBarDisplay -= Time.deltaTime / FallRate * multiplier;
        if (ComponentBarDisplay < 0)
        {
          ComponentBarDisplay = 0;
        }
      }
    }
  }
}
