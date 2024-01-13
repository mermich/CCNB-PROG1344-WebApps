using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        builder.Services.AddCors();
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        var app = builder.Build();
        app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        var employees = new Employee[]
        {
            new Employee( 1, "John", 31 ),
            new Employee( 2, "Mary", 27 ),
            new Employee( 3, "Bob", 41 ),
            new Employee( 4, "Sue", 24 ),
            new Employee( 5, "Greg", 35 ),
            new Employee( 6, "Jerry", 39 )
        };

        // On Cree un groupe d'api pour les employees
        var employeesApi = app.MapGroup("/employees");

        // On map la route /employees pour retourner la liste des employees
        // A noter  : on a mapper sur le groupe 'employeesApi'
        employeesApi.MapGet("/", () =>
        {
            // on simule un delai de 2 secondes
            Thread.Sleep(2_000);
            return employees;
        });

        // On map la route /employees/{id} pour retourner un employee
        // A noter  : on a mapper sur le groupe 'employeesApi'
        employeesApi.MapGet("/{id}", (int id) => employees.FirstOrDefault(a => a.Id == id));

        app.MapGet("/", () => Results.Redirect("/index.html"));
        app.Run();
    }
}

public record Employee(int Id, string? Name, int? Age = null);

[JsonSerializable(typeof(Employee[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
