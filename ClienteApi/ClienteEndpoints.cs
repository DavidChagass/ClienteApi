using Microsoft.EntityFrameworkCore;
using ClienteApi.Data;
using ClienteApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace ClienteApi;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Cliente").WithTags(nameof(Cliente));

        group.MapGet("/", async (ClienteApiContext db) =>
        {
            return await db.Cliente.ToListAsync();
        })
        .WithName("GetAllClientes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Cliente>, NotFound>> (int id, ClienteApiContext db) =>
        {
            return await db.Cliente.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Cliente model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetClienteById")
        .WithOpenApi();

        group.MapPut("/{id}", async (int id, Cliente cliente, ClienteApiContext db) =>
        {
            var client = await db.Cliente.FindAsync(id);
            if (client is null) return Results.NotFound();
            client.Nome = cliente.Nome;
            client.Email = cliente.Email;
            client.CPF = cliente.CPF;
            client.Nascimento = cliente.Nascimento;
            await db.SaveChangesAsync();
            return Results.NoContent();
           // return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCliente")
        .WithOpenApi();

        group.MapPost("/", async (Cliente cliente, ClienteApiContext db) =>
        {
            db.Cliente.Add(cliente);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Cliente/{cliente.Id}",cliente);
        })
        .WithName("CreateCliente")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id, ClienteApiContext db) =>
        {
            var client = await db.Cliente.FindAsync(id);
            if (client is null) { return Results.NotFound(); }
            db.Cliente.Remove(client);
            await db.SaveChangesAsync();
            return Results.Ok();
        })
        .WithName("DeleteCliente")
        .WithOpenApi();
    }
}
