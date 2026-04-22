using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej5.Domain;

public class VehiculoCombustible: Vehiculo
{
    private double kilometrosPorLitro;
    private double litrosExtra;

    public VehiculoCombustible(string patente, string marca, string modelo, int anio, double capacidadCarga, 
        Sucursal sucursal, double kilometrosPorLitro, double litrosExtra) : base(VehiculoTipo.Combustible, patente, marca, modelo, anio, capacidadCarga, sucursal)
    {
        this.kilometrosPorLitro = kilometrosPorLitro;
        this.litrosExtra = litrosExtra;
    }

    public double GetKilometrosPorLitro()
    {
        return kilometrosPorLitro;
    }

    public double GetLitrosExtra()
    {
        return litrosExtra;
    }

    public override double CalcularConsumo(double kilometros)
    {
        double totalConsumo = 0;

        int anioActual = DateTime.Now.Year;
        totalConsumo = kilometros / kilometrosPorLitro;

        if ((anioActual - GetAnio()) > 5)
        {
            totalConsumo += (kilometros / 15.0) * GetLitrosExtra();
        }

        totalConsumo = Math.Round(totalConsumo, 2);

        return totalConsumo;
    }
}
