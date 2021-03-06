using System.Text.Json;

namespace Ejercicio1;

public class Program{

    private static string[] Nombres = {"Mayonesa", "Savora", "Harina"};

    public static void Main(string[] args){
        Console.WriteLine("Ingrese un path");
        string? carpetaPath = Console.ReadLine();
        
        if(!Directory.Exists(carpetaPath)) return;

        List<string> listadoDeCarpetas = Directory.GetDirectories(carpetaPath).ToList();
        string nombreArchivo = carpetaPath + @"\index.json";
        
        FileStream fileStream;

        if(!File.Exists(nombreArchivo)){
            fileStream = File.Create(nombreArchivo);
            fileStream.Close();
        }

        using(fileStream = new FileStream(nombreArchivo, FileMode.OpenOrCreate))
        using(var streamWriter = new StreamWriter(fileStream))
        {            
            var contador = 0;
            
            var carpetas = new List<Carpeta>();
            var archivos = new List<Archivo>();

            foreach(string auxiliar in listadoDeCarpetas){
                var carpeta = new Carpeta(contador, new DirectoryInfo(auxiliar).Name);
                carpetas.Add(carpeta);
                contador++;
            }

            foreach(string auxiliar in Directory.GetFiles(carpetaPath)){
                var archivo = new Archivo(contador, Path.GetFileNameWithoutExtension(auxiliar), Path.GetExtension(auxiliar));
                archivos.Add(archivo);
                contador++;
            }

            string carpetaJson = JsonSerializer.Serialize(carpetas);
            string archivoJson = JsonSerializer.Serialize(archivos);
            streamWriter.WriteLine(carpetaJson);
            streamWriter.WriteLine(archivoJson);
        }
    }
}
