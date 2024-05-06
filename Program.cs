using System;

class Program
{
    static Superheroe superheroe1;
    static Superheroe superheroe2;

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Cargar Datos Superhéroe 1");
            Console.WriteLine("2. Cargar Datos Superhéroe 2");
            Console.WriteLine("3. Competir");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    superheroe1 = CargarSuperheroe(1);
                    Console.WriteLine($"Se ha creado el superhéroe {superheroe1.Nombre}");
                    break;
                case 2:
                    superheroe2 = CargarSuperheroe(2);
                    Console.WriteLine($"Se ha creado el superhéroe {superheroe2.Nombre}");
                    break;
                case 3:
                    if (superheroe1 != null && superheroe2 != null)
                    {
                        Pelear(superheroe1, superheroe2);
                    }
                    else
                    {
                        Console.WriteLine("Debes cargar los datos de ambos superhéroes primero.");
                    }
                    break;
                case 4:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }

    static Superheroe CargarSuperheroe(int numero)
    {
        Console.WriteLine($"Ingrese los datos del superhéroe {numero}:");
        Console.WriteLine("Ingrese nombre");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese ciudad");
        string ciudad = Console.ReadLine();
        Console.WriteLine("Ingrese peso");
        double peso = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese fuerza");
        double fuerza = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese velocidad");
        double velocidad = double.Parse(Console.ReadLine());

        if (peso <= 0 || fuerza <= 0 || velocidad <= 0)
        {
            Console.WriteLine("Error: Los datos ingresados no son válidos.");
            return null;
        }

        return new Superheroe(nombre, ciudad, peso, fuerza, velocidad);
    }

    static void Pelear(Superheroe heroe1, Superheroe heroe2)
    {
        double skill1 = heroe1.ObtenerSkill();
        double skill2 = heroe2.ObtenerSkill();

        Console.WriteLine($"Skill de {heroe1.Nombre}: {skill1}");
        Console.WriteLine($"Skill de {heroe2.Nombre}: {skill2}");

        if (skill1 > skill2)
        {
            if (skill1 - skill2 >= 30)
                Console.WriteLine($"Ganó {heroe1.Nombre} por amplia diferencia");
            else if (skill1 - skill2 >= 10)
                Console.WriteLine($"Ganó {heroe1.Nombre}. ¡Fue muy parejo!");
            else
                Console.WriteLine($"Ganó {heroe1.Nombre}. ¡No le sobró nada!");
        }
        else if (skill2 > skill1)
        {
            if (skill2 - skill1 >= 30)
                Console.WriteLine($"Ganó {heroe2.Nombre} por amplia diferencia");
            else if (skill2 - skill1 >= 10)
                Console.WriteLine($"Ganó {heroe2.Nombre}. ¡Fue muy parejo!");
            else
                Console.WriteLine($"Ganó {heroe2.Nombre}. ¡No le sobró nada!");
        }
        else
        {
            Console.WriteLine("¡La pelea terminó en empate!");
        }
    }
}