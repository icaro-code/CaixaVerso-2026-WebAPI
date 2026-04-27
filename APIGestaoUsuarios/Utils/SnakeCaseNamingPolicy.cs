using System.Text.Json;

namespace APIGestaoUsuarios.Utils
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            // Converte "NomePropriedade" para "nome_propriedade"
            return string.Concat(
                name.Select((c, i) =>
                    i > 0 && char.IsUpper(c) ? "_" + char.ToLower(c) : char.ToLower(c).ToString()
                )
            );
        }
    }
}