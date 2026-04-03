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
        List<PokemonDto> pokedex = LoadJson();
        Debug.Log("Pokedex loaded");


        Debug.Log("Count Psychic : " + pokedex.Where(i => i.Type.Contains("Psychic")).Count());

        /*
        List<PokemonDto> electricPokemon = pokedex.Where(i => i.Type.Contains("Electric")).ToList();

        PokemonDto pokemon = electricPokemon.Aggregate((a, b) => GetHeight(a) > GetHeight(b) ? a : b);

        Debug.Log("Height : " + pokemon.Name.English);
        */

        List<PokemonDto> top10 = pokedex.OrderByDescending(i => i.Base.Attack + i.Base.Defense).Take(10).ToList();

        for (int i = 0; i < top10.Count; ++i)
        {
            PokemonDto pokemonTop = top10[i];
            Debug.Log($"top {i + 1} : " + pokemonTop.Name.French);
        }
    }
    
    private float GetHeight(PokemonDto pokemon)
    {
        return float.Parse(pokemon.Profile.Height.Split(' ')[0]);
    }

}
