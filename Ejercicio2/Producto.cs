namespace TP9;

class Producto{
    public string? nombre { get; set; }
    public DateTime fechaVencimiento { get; set; }
    public float precio { get; set; }
    public string? tamanio { get; set; }

    public Producto()
    {
        
    }
    
    public Producto (string nombre, DateTime fechaVencimiento, float precio, string tamanio){
        this.nombre = nombre;
        this.fechaVencimiento = fechaVencimiento;
        this.precio = precio;
        this.tamanio = tamanio;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Fecha de vencimiento: " + fechaVencimiento);
        Console.WriteLine("Precio: " + precio);
        Console.WriteLine("Tamanño: " + tamanio);
    }
}