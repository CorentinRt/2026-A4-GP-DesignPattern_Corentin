using System.Collections.Generic;
using Newtonsoft.Json;

public sealed class PokemonDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public PokemonNameDto Name { get; set; }

    [JsonProperty("type")]
    public List<string> Type { get; set; }

    [JsonProperty("base")]
    public PokemonBaseStatsDto Base { get; set; }

    [JsonProperty("species")]
    public string Species { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("evolution")]
    public PokemonEvolutionDto Evolution { get; set; }

    [JsonProperty("profile")]
    public PokemonProfileDto Profile { get; set; }

    [JsonProperty("image")]
    public PokemonImageDto Image { get; set; }
}

public sealed class PokemonNameDto
{
    [JsonProperty("english")]
    public string English { get; set; }

    [JsonProperty("japanese")]
    public string Japanese { get; set; }

    [JsonProperty("chinese")]
    public string Chinese { get; set; }

    [JsonProperty("french")]
    public string French { get; set; }
}

public sealed class PokemonBaseStatsDto
{
    [JsonProperty("HP")]
    public int HP { get; set; }

    [JsonProperty("Attack")]
    public int Attack { get; set; }

    [JsonProperty("Defense")]
    public int Defense { get; set; }

    [JsonProperty("Sp. Attack")]
    public int SpecialAttack { get; set; }

    [JsonProperty("Sp. Defense")]
    public int SpecialDefense { get; set; }

    [JsonProperty("Speed")]
    public int Speed { get; set; }
}

public sealed class PokemonEvolutionDto
{
    [JsonProperty("prev")]
    public List<string> Prev { get; set; }

    [JsonProperty("next")]
    public List<List<string>> Next { get; set; }
}

public sealed class PokemonProfileDto
{
    [JsonProperty("height")]
    public string Height { get; set; }

    [JsonProperty("weight")]
    public string Weight { get; set; }

    [JsonProperty("egg")]
    public List<string> Egg { get; set; }

    [JsonProperty("ability")]
    public List<List<string>> Ability { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }
}

public sealed class PokemonImageDto
{
    [JsonProperty("sprite")]
    public string Sprite { get; set; }

    [JsonProperty("thumbnail")]
    public string Thumbnail { get; set; }

    [JsonProperty("hires")]
    public string Hires { get; set; }
}

