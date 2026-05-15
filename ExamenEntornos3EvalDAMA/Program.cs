using ExamenEntornos3EvalDAMA;

List<Album> lista = new List<Album>
{
    new Album("Master of Puppets", "Metallica", 1986, true),
    new Album("Thriller", "Michael Jackson", 1982, false),
    new Album("72 Seasons", "Metallica", 2023, true)
};

Console.WriteLine("TODOS LOS ALBUMES:");
foreach (var a in lista) Console.WriteLine(a.ToString());

Console.WriteLine("\nSOLO METALLICA:");
foreach (var a in lista)
{
    if (a.GetArtista().Contains("Metallica")) Console.WriteLine(a.ToString());
}

Console.WriteLine("\nFecha actual: " + DateTime.Now.ToShortDateString());

GuardarAlbums(lista, "albums.txt");

static void GuardarAlbums(List<Album> lista, string ruta)
{
    using (StreamWriter sw = new StreamWriter(ruta))
    {
        foreach (var a in lista)
        {
            sw.WriteLine($"{a.GetTitulo()};{a.GetArtista()};{a.GetAnyo()};{a.IsDisponible()}");
        }
    }
}