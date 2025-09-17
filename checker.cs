using System;
using System.Diagnostics;

public class Checker
{
    public enum VitalStatus
    {
        Normal,
        TemperatureAbnormal,
        PulseRateAbnormal,
        Spo2Abnormal
    }

    public static VitalStatus EvaluateVitals(float temperature, int pulseRate, int spo2)
    {
        if (temperature > 102 || temperature < 95)
            return VitalStatus.TemperatureAbnormal;
        if (pulseRate < 60 || pulseRate > 100)
            return VitalStatus.PulseRateAbnormal;
        if (spo2 < 90)
            return VitalStatus.Spo2Abnormal;

        return VitalStatus.Normal;
    }

    public static bool VitalsOk(float temperature, int pulseRate, int spo2)
    {
        VitalStatus result = EvaluateVitals(temperature, pulseRate, spo2);

        if (result == VitalStatus.TemperatureAbnormal)
        {
            ShowBlinkingAlert("Temperature critical!");
            return false;
        }

        if (result == VitalStatus.PulseRateAbnormal)
        {
            ShowBlinkingAlert("Pulse Rate is out of range!");
            return false;
        }

        if (result == VitalStatus.Spo2Abnormal)
        {
            ShowBlinkingAlert("Oxygen Saturation out of range!");
            return false;
        }

        // result == VitalStatus.Normal
        Console.WriteLine("Vitals received within normal range");
        Console.WriteLine("Temperature: {0} Pulse: {1}, SO2: {2}", temperature, pulseRate, spo2);
        return true;
    }

    private static void ShowBlinkingAlert(string message)
    {
        Console.WriteLine(message);
        for (int i = 0; i < 6; i++)
        {
            Console.Write("\r* ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("\r *");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
