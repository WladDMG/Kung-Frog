using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Slider volumeSlider; // Slider para controlar o volume
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");        
    }

    //M�todo para mudar o volume e 
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    //M�todo para salvar as altera��es
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    // M�todo para o bot�o "Novo Jogo" - carrega a cena inicial do jogo
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Fase1"); // Substitua pelo nome da sua cena do jogo
    }
        

}
