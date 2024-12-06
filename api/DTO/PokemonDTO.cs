namespace FirstAPI.DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string DataStart { get; set; }
        public string DateEnd { get; set; }
        public string PokeName { get; set; }
        public int DamageDoneTrainer { get; set; }
        public int DamageReceivedTrainer { get; set; }
        public int DamageDonePokemon { get; set; }
        public string Image { get; set; }
        public bool Catch { get; set; }
        public bool Shiny { get; set; }
    }
}
