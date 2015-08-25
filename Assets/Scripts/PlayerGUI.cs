using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerGUI : MonoBehaviour {

  public Vector2 TextureSize = new Vector2(240, 40);
  //Health Variables
  [SerializeField]
  PlayerGUIComponent HealthComponent;
  [SerializeField]
  PlayerGUIComponent HungerComponent;
  [SerializeField]
  PlayerGUIComponent ThirstComponent;
  [SerializeField]
  PlayerGUIComponent StaminaComponent;
  private CharacterMotor CharacterMotor;
  private FirstPersonController FirstPersonController;
  private CharacterController CharacterController;

  void Start()
  {
    HealthComponent = new PlayerGUIComponent(TextureSize, new Vector2(20, 20), 150);
    HungerComponent = new PlayerGUIComponent(TextureSize, new Vector2(20, 60), 150);
    ThirstComponent = new PlayerGUIComponent(TextureSize, new Vector2(20, 100), 100);
    StaminaComponent = new PlayerGUIComponent(TextureSize, new Vector2(20, 140), 35);

    CharacterController = GetComponent<CharacterController>();
    CharacterMotor = GetComponent<CharacterMotor>();
    FirstPersonController = GetComponent<FirstPersonController>();
  }

  void OnGUI()
  {
    HealthComponent.Render();
    HungerComponent.Render();
    ThirstComponent.Render();
    StaminaComponent.Render();
  }
}
