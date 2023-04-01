using System;
using System.Collections.Generic;

namespace Hamburgueseria
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Hamburguesa clasica = new Hamburguesa("Pan normal", "Carne normal", 10.0);
            clasica.AgregarIngrediente("Lechuga", 1.0);
            clasica.AgregarIngrediente("Tomate", 1.0);
            clasica.AgregarIngrediente("Bacon", 2.0);
            clasica.AgregarIngrediente("Pepinillo", 0.5);
            clasica.MostrarPrecio();

            
            HamburguesaSaludable saludable = new HamburguesaSaludable("Pan integral", "Carne de pollo", 12.0);
            saludable.AgregarIngrediente("Huevo", 1.5);
            saludable.AgregarIngrediente("Aguacate", 2.0);
            saludable.MostrarPrecio();

            
            HamburguesaPremium premium = new HamburguesaPremium("Pan normal", "Carne especial", 20.0);
            premium.AgregarPapas();
            premium.AgregarBebida();
            premium.MostrarPrecio();
        }
    }

    class Hamburguesa
    {
        private string tipoPan;
        private string tipoCarne;
        private double precioBase;
        private List<Tuple<string, double>> ingredientes;

        public Hamburguesa(string tipoPan, string tipoCarne, double precioBase)
        {
            this.tipoPan = tipoPan;
            this.tipoCarne = tipoCarne;
            this.precioBase = precioBase;
            this.ingredientes = new List<Tuple<string, double>>();
        }

        public void AgregarIngrediente(string nombre, double precio)
        {
            if (ingredientes.Count < 4)
            {
                ingredientes.Add(new Tuple<string, double>(nombre, precio));
            }
            else
            {
                Console.WriteLine("No se pueden agregar más ingredientes.");
            }
        }

        public void MostrarPrecio()
        {
            double total = precioBase;
            Console.WriteLine($"Hamburguesa {tipoPan} con {tipoCarne}");
            Console.WriteLine("Ingredientes:");
            foreach (var ingrediente in ingredientes)
            {
                Console.WriteLine($"{ingrediente.Item1} - ${ingrediente.Item2}");
                total += ingrediente.Item2;
            }
            Console.WriteLine($"Precio total: ${total}\n");
        }
    }

        class HamburguesaSaludable : Hamburguesa
    {
        private List<string> ingredientesSaludables;
        private const int maxIngredientesSaludables = 2;
        private const double precioIngredientesSaludables = 0.75;

        public HamburguesaSaludable(string tipoPan, string carne, double precio) : base(tipoPan, carne, precio)
        {
            ingredientesSaludables = new List<string>();
        }

        public void AgregarIngredienteSaludable(string ingrediente)
        {
            if (ingredientesSaludables.Count < maxIngredientesSaludables)
            {
                ingredientesSaludables.Add(ingrediente);
                Precio += precioIngredientesSaludables;
            }
            else
            {
                Console.WriteLine($"No se pueden agregar más de {maxIngredientesSaludables} ingredientes adicionales.");
            }
        }

        public override void MostrarPrecio()
        {
            base.MostrarPrecio();
            Console.WriteLine("Ingredientes adicionales saludables:");
            foreach (string ingrediente in ingredientesSaludables)
            {
                Console.WriteLine($" - {ingrediente}: {precioIngredientesSaludables}");
            }
            Console.WriteLine($"Precio total: {Precio}");
        }
    }

    class HamburguesaPremium : Hamburguesa
    {
        private const double precioPapas = 2.50;
        private const double precioBebida = 1.75;

        public HamburguesaPremium(string tipoPan, string carne, double precio) : base(tipoPan, carne, precio)
        {
            Precio += precioPapas + precioBebida;
        }

        public override void MostrarPrecio()
        {
            base.MostrarPrecio();
            Console.WriteLine("Adicionales premium:");
            Console.WriteLine($" - Papas fritas: {precioPapas}");
            Console.WriteLine($" - Bebida: {precioBebida}");
            Console.WriteLine($"Precio total: {Precio}");
        }
    }
}
