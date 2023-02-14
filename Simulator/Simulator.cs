namespace Simulator;

public static class Simulator
{
    //static BlApi.IBl bl = BlApi.Factory.Get();
    //private static volatile bool Running;

    //public delegate void SimulationCompleteEventHandler();
    //public static event SimulationCompleteEventHandler Simulation_Completed;

    //public delegate void UpdateEventHandler(BO.Order? order, DateTime newTime, int delay);
    //public static event UpdateEventHandler Updated;
    //public static Random random = new Random();
    //public static BO.Order? order = new BO.Order();
    //public static void StartSimulation()
    //{

    //    new Thread(() =>
    //    {
    //        Running = true;
    //        while (Running)
    //        {
    //            Run();
    //            Thread.Sleep(1000);
    //        }
    //        Simulation_Completed();
    //    }).Start();
    //}
    //private static void Run()
    //{

    //    DateTime new_date = new DateTime();
    //    order = bl.Order.nextOrder();
    //    if (order != null)
    //    {
    //        int time_delay = random.Next(3, 11);
    //        new_date = DateTime.Now + new TimeSpan(0, 0, time_delay);
    //        Updated(order, new_date, time_delay);
    //        Thread.Sleep(time_delay * 1000);
    //        if (order.Status == BO.Order.Status.)
    //        {
    //            bl.Order?.UpdateShipping(order.ID);
    //        }
    //        else if (order.Status == BO.Status.Shipped)
    //        {
    //            bl.Order?.UpdateDelivery(order.ID);
    //        }
    //    }

    //}

    //public static void StopSimulation()
    //{
    //    Running = false;

    //}

    //public static void RegisterForSimulationCompleteEvent(SimulationCompleteEventHandler e_handler)
    //{
    //    Simulation_Completed += e_handler;
    //}

    //public static void UnregisterFromSimulationCompleteEvent(SimulationCompleteEventHandler e_handler)
    //{
    //    Simulation_Completed -= e_handler;
    //}

    //public static void RegisterForUpdateEvent(UpdateEventHandler e_handler)
    //{
    //    Updated += e_handler;
    //}

    //public static void UnregisterFromUpdateEvent(UpdateEventHandler e_handler)
    //{
    //    Updated -= e_handler;
    //}
}