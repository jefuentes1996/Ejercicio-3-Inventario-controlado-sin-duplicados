using System;
using System.Collections.Generic;

public class Inventario
{
    private Dictionary<string, int> productos;

    public Inventario()
    {
        productos = new Dictionary<string, int>();
    }

    public void AgregarProducto(string nombre, int cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine(" No se puede agregar una cantidad cero.");
            return;
        }

        string nombreClave = nombre.ToLower();

        if (productos.ContainsKey(nombreClave))
        {
            productos[nombreClave] += cantidad;
            Console.WriteLine($" Se agregó {cantidad} unidades al producto '{nombre}'.");
        }
        else
        {
            productos.Add(nombreClave, cantidad);
            Console.WriteLine($" Producto '{nombre}' agregado con {cantidad} unidades.");
        }
    }

    public void RetirarProducto(string nombre, int cantidad)
    {
        string nombreClave = nombre.ToLower();

        if (!productos.ContainsKey(nombreClave))
        {
            Console.WriteLine(" El producto no existe.");
            return;
        }

        if (cantidad <= 0)
        {
            Console.WriteLine(" Cantidad inválida para retirar.");
            return;
        }

        if (productos[nombreClave] < cantidad)
        {
            Console.WriteLine(" No hay suficiente cantidad para retirar.");
            return;
        }

        productos[nombreClave] -= cantidad;
        Console.WriteLine($" Se retiraron {cantidad} unidades de '{nombre}'.");
    }

    public void MostrarInventario()
    {
        Console.WriteLine("\n Inventario actual:");
        if (productos.Count == 0)
        {
            Console.WriteLine("El inventario está vacío.");
            return;
        }

        foreach (var item in productos)
        {
            Console.WriteLine($"- {item.Key}: {item.Value} unidades");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Inventario miInventario = new Inventario();

        miInventario.AgregarProducto("Lapiceros", 10);
        miInventario.AgregarProducto("Cuadernos", 5);
        miInventario.AgregarProducto("Lapiceros", 5);

        miInventario.RetirarProducto("Lapiceros", 3);
        miInventario.RetirarProducto("Cuadernos", 10);

        miInventario.MostrarInventario();
    }
}
