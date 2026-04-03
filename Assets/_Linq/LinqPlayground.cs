using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Newtonsoft.Json;
using UnityEngine;

public class LinqPlayground : MonoBehaviour
{
    [SerializeField] TextAsset _jsonDocument;

    List<PokemonDto> LoadJson() => JsonConvert.DeserializeObject<List<PokemonDto>>(_jsonDocument.text);
    
    [Button]
    void Run()
    {
        var pokedex = LoadJson();
        Debug.Log("Pokedex loaded");
        
        

    }
    
}
