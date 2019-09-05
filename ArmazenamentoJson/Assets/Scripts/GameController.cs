using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] InputField nome;
    [SerializeField] Dropdown sexo;
    [SerializeField] Slider volume;
    [SerializeField] Toggle notificacoes;
    Configuracoes config;
    string nomeArquivoConfiguracoes;

    private void Start()
    {
        config = new Configuracoes();
        nomeArquivoConfiguracoes = "configuracoes.json";

        CarregarConfiguracoes();
    }

    private void CarregarConfiguracoes()
    {
        string caminhoArquivo =
            Path.Combine(Application.streamingAssetsPath, nomeArquivoConfiguracoes);
        if (File.Exists(caminhoArquivo))
        {
            string dadosJson = File.ReadAllText(caminhoArquivo);
            config = JsonUtility.FromJson<Configuracoes>(dadosJson);

            nome.text = config.nome;
            sexo.value = config.sexo;
            volume.value = config.volume;
            notificacoes.isOn = config.notificacoes;
        }
    }

    public void SalvarConfiguracoes()
    {
        config.nome = nome.text;
        config.sexo = (byte) sexo.value;
        config.volume = volume.value;
        config.notificacoes = notificacoes.isOn;

        string configJson = JsonUtility.ToJson(config);
        string caminhoArquivo =
            Path.Combine(Application.streamingAssetsPath, nomeArquivoConfiguracoes);
        File.WriteAllText(caminhoArquivo, configJson);
    }
}
