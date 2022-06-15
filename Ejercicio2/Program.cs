using System.Text.Json;
using TP9;

namespace Ejercicio2;

public class Program{

    private static string[] Nombres = {"Mayonesa", "Savora", "Harina"};
    private static string[] Tamanios = {"Pequeño", "Mediano", "Grande"};
    private static readonly string PathArchivo = @"\productos.json";

    public static void Main(string[] args){
        Console.WriteLine("Ingrese la cantidad de productos que quiere crear");
        int cantidadProductos = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el path donde se guardarán la lista");
        string? path = Console.ReadLine();

        string productosJson = JsonSerializer.Serialize(CrearProductosAleatorios(cantidadProductos));

        /*
        * Escribe en el archivo
        */
        using(FileStream fileStream = new FileStream(path + PathArchivo, FileMode.OpenOrCreate))
        using(StreamWriter streamWriter = new StreamWriter(fileStream)){
            streamWriter.WriteLine(productosJson);
        }
        
        /*
        * Lee el arhcivo
        */
        using(StreamReader streamReader = new StreamReader(path + PathArchivo))
        {
            var elementosJson = JsonSerializer.Deserialize<List<Producto>>(streamReader.ReadLine());
            if (elementosJson == null) return;
            
            foreach (var item in elementosJson)
            {
                item.MostrarInformacion();
            }
        }

    }

    private static List<Producto> CrearProductosAleatorios(int cantidadProductos){
        Random aleatorio = new Random();
        List<Producto> productos = new List<Producto>();

        for(var i = 0; i < cantidadProductos; i++){
            string nombre = Nombres[aleatorio.Next(Nombres.Length)];
            DateTime fecha = new DateTime(aleatorio.Next(2022, 2030), aleatorio.Next(1,13), aleatorio.Next(1, 28));
            float precio = aleatorio.Next(1, 100);
            string tamanio = Tamanios[aleatorio.Next(Tamanios.Length)];
            var producto = new Producto(nombre, fecha, precio, tamanio);
            productos.Add(producto);
            // Console.WriteLine(nombre + " " + fecha.ToString() + " " + tamanio);
        }

        return productos;
    }

}
