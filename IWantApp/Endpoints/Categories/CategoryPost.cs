using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    // criacao do endpoint
    public static string Template => "/categories";

    // criacao do verbo(s) a ser(em) acessado(s)
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    // criando acao
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        return Results.Ok();
    }
}
