using EcomAPI.BackEnd.Data.Interfaces.Repo;
using EcomAPI.BackEnd.Data.Services.Catalog.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EcomAPI.BackEnd.Data.Services.Catalog
{  

public static class CatalogEndpoints
    {
        public static void MapCatalogEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/Catalog/GetCatalog", async (IItemRepository itemRepository) =>
            {
                return await itemRepository.GetAllAsync();
            });

            endpoints.MapGet("/api/Catalog/GetItem/{id}", async (int id, IItemRepository itemRepository) =>
            {
                var item = await itemRepository.GetByIdAsync(id);
                return item is not null ? Results.Ok(item) : Results.NotFound();
            });

            endpoints.MapPost("/api/Catalog/AddItem", async (ItemDTO newItemDto, IItemRepository itemRepository) =>
            {
                await itemRepository.CreateAsync(newItemDto);
                return Results.Created($"/items/{newItemDto.Id}", newItemDto);
            });

            endpoints.MapPut("/api/Catalog/UpdateItem/{id}", async (int id, ItemDTO updatedItemDto, IItemRepository itemRepository) =>
            {
                var existingItem = await itemRepository.GetByIdAsync(id);
                if (existingItem is null) return Results.NotFound();

                existingItem.Name = updatedItemDto.Name;
                existingItem.price = updatedItemDto.price;
                await itemRepository.UpdateAsync(id, existingItem);
                return Results.Ok(existingItem);
            });

            endpoints.MapDelete("/api/Catalog/DeleteItem/{id}", async (int id, IItemRepository itemRepository) =>
            {
                var existingItem = await itemRepository.GetByIdAsync(id);
                if (existingItem is null) return Results.NotFound();

                await itemRepository.DeleteAsync(id);
                return Results.NoContent();
            });
        }
    }
}
