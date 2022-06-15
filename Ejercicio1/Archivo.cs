namespace Ejercicio1{

public class Archivo{

        public int Id { get ; set; }
        public string Nombre { get; set;}
        public string Extension{ get; set; }

        public Archivo(int id, string nombre, string extension){
            Id = id;
            Nombre = nombre;
            Extension = extension;
        }

    }
}
