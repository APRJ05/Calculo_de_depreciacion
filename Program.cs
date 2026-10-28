using System;

namespace DepreciacionSaldoDecreciente
{
    internal class Program
    {
        static decimal Depreciar(decimal v, decimal r, int t)
        {
            // Caso base: sin tiempo transcurrido, el valor es el costo original.
            if (t == 0)
            {
                return v;
            }

            // Caso recursivo: valor del año anterior (t - 1) multiplicado por el factor de retención.
            return Depreciar(v, r, t - 1) * r;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Depreciación por Saldo Decreciente ===");

            decimal v = LeerDecimal("Valor de compra original (V): ", 0.01m, decimal.MaxValue);
            decimal d = LeerDecimal("Tasa de depreciación anual en % (d, 0 a 100): ", 0m, 100m);
            int t = LeerEntero("Años de uso (t): ");

            // Factor de retención de valor.
            decimal r = 1 - d / 100;

            decimal resultado = Depreciar(v, r, t);

            Console.WriteLine();
            Console.WriteLine($"Valor original : {v:N2}");
            Console.WriteLine($"Depreciación   : {d}% anual (r = {r})");
            Console.WriteLine($"Años de uso    : {t}");
            Console.WriteLine($"Valor contable : {resultado:N2}");
            Console.ReadKey();
        }

        static decimal LeerDecimal(string mensaje, decimal minimo, decimal maximo)
        {
            Console.Write(mensaje);
            if (decimal.TryParse(Console.ReadLine(), out decimal valor)
                && valor >= minimo && valor <= maximo)
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Intenta de nuevo.");
            return LeerDecimal(mensaje, minimo, maximo); 
        }

        static int LeerEntero(string mensaje)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Los años deben ser un entero mayor o igual a 0.");
            return LeerEntero(mensaje);
        }
    }
}