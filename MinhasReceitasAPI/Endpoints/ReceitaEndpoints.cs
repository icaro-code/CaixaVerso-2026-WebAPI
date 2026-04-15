public static class ReceitaEndpoints
{
    private static List<Receita> receitas = new();

    public static void MapReceitaEndpoints(this IEndpointRouteBuilder app)
    {
        // Listar todas
        app.MapGet("/api/receitas", () => receitas);

        // Buscar por ID
        app.MapGet("/api/receitas/{id:int}", (int id) =>
        {
            var receita = receitas.FirstOrDefault(r => r.Id == id);
            return receita is not null ? Results.Ok(receita) : Results.NotFound();
        });

        // Buscar por Nome
        app.MapGet("/api/receitas/nome/{nome}", (string nome) =>
        {
            var receita = receitas.FirstOrDefault(r => 
                r.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            return receita is not null ? Results.Ok(receita) : Results.NotFound();
        });

        // Cadastrar nova
        app.MapPost("/api/receitas", (Receita novaReceita) =>
        {
            if (string.IsNullOrEmpty(novaReceita.Ingredientes))
                throw new Exception("Ingredientes não podem ser nulos.");
            if (string.IsNullOrEmpty(novaReceita.Nome))
                throw new Exception("Nome não pode ser nulo.");

            novaReceita.Id = receitas.Count > 0 ? receitas.Max(r => r.Id) + 1 : 1;
            receitas.Add(novaReceita);
            return Results.Created($"/api/receitas/{novaReceita.Id}", novaReceita);
        });

        // Atualizar nome e ingredientes
        app.MapPut("/api/receitas/{id:int}", (int id, Receita receitaAtualizada) =>
        {
            var receita = receitas.FirstOrDefault(r => r.Id == id);
            if (receita is null) return Results.NotFound();

            if (string.IsNullOrEmpty(receitaAtualizada.Ingredientes))
                throw new Exception("Ingredientes não podem ser nulos.");
            if (string.IsNullOrEmpty(receitaAtualizada.Nome))
                throw new Exception("Nome não pode ser nulo.");

            receita.Nome = receitaAtualizada.Nome;
            receita.Ingredientes = receitaAtualizada.Ingredientes;
            return Results.Ok(receita);
        });

        // Remover
        app.MapDelete("/api/receitas/{id:int}", (int id) =>
        {
            var receita = receitas.FirstOrDefault(r => r.Id == id);
            if (receita is null) return Results.NotFound();

            receitas.Remove(receita);
            return Results.NoContent();
        });
    }
}
