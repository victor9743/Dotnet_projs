var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/nome", () => new{nome = "Victor", idade="25"});
app.MapGet("/rota", (HttpResponse response) => {
    response.Headers.Add("teste", "testeteste");
    return  new{nome = "Victor", idade="25"};
});

app.MapPost("/saveproduct", (Product product) => {
    // adicionando um produto
    ProductReposity.Add(product);
    // return product.Code + " - " + product.Name;
});

app.MapGet("/getproduct/{code}", (string code) =>{
    var product = ProductReposity.GetBy(code);
    return product;
});

app.MapPut("/editproduct", (Product product) => {
    // realizar busca no banco
    var productSaved = ProductReposity.GetBy(product.Code);

    // atualizar o nome do registro
    productSaved.Name = product.Name;
});

app.MapDelete("/deleteproduct/{code}", (string code) => {
     // realizar busca no banco
    var productSaved = ProductReposity.GetBy(code);

    ProductReposity.Remove(productSaved);
});

app.Run();

public class ProductReposity {
    public static List<Product> Products {get; set;}

    public static void Add(Product product) {
        if (Products == null)
            Products = new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code) {
        return Products.FirstOrDefault(p => p.Code == code);
    }

    public static void Remove(Product product) {
        Products.Remove(product);
    }

}

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}
