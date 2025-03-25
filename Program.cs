public class Program
{
    public static void Main()
    {
        
        ContainerShip ship1 = new ContainerShip("Mors", 25, 10, 10000);
        ContainerShip ship2 = new ContainerShip("Neptun", 22, 8, 8000);
        
        Container c1 = new LiquidContainer(2000, 500, 220, 150, true);
        Container c2 = new GasContainer(1500, 400, 210, 130, 10);
        Container c3 = new RefrigeratedContainer(1800, 450, 200, 140, "Fish", 2);
        
        c1.Load(1100);
        c2.Load(1200);
        c3.Load(1500);

        ship1.LoadContainer(c1);
        ship1.LoadContainer(c2);
        ship1.LoadContainer(c3);

        ship1.PrintShipInfo();

        ship1.UnloadContainer(c2.SerialNumber);
        ship1.PrintShipInfo();

        Container c4 = new RefrigeratedContainer(1900, 470, 210, 140, "Meat", -15);
        c4.Load(1600);
        ship1.ReplaceContainer(c1.SerialNumber, c4);
        ship1.PrintShipInfo();

        ship1.TransferContainer(ship2, c4.SerialNumber);
        ship2.PrintShipInfo();
        ship1.PrintShipInfo();

        ship1.PrintContainerInfo(c1.SerialNumber);
    }
}
